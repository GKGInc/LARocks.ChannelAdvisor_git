using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LARocks.ChannelAdvisor.Api;
using LARocks.ChannelAdvisor.EdiFileProcessor.FileProcessors;
using MicroFour.StrataFrame.Data;
using Newtonsoft.Json.Linq;
using NLog;

namespace LARocks.ChannelAdvisor.EdiFileProcessor
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static string ApiKey;
        public static string ApiUrl;
        public static string ApiToken; 
        public static string DistributionCenterID;
        public static bool TestMode;

        static void Main(string[] args)
        {
            RunTest();
            return;

            logger.Info("Start of EdiFileProcessor");

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            try
            {
                ReadConfig();

                var filePath = GetFilePath(args);

                var jsonString = File.ReadAllText(filePath);

                logger.Debug("JSON file contents:\r\n" + jsonString);

                logger.Info("Getting EDI type");
                var ediDocType = GetEdiType(jsonString, out JObject jobject);

                switch (ediDocType)
                {
                    case "846": // Inventory Inquiry/Advice
                        logger.Info("Starting 846 Inventory Inquiry/Advice...");

                        var edi846Proc = new InventoryQtyUpdater846();
                        edi846Proc.ProcessEdi846Json(jobject);

                        ArchiveFile(filePath);

                        break;
                    case "855": // PO Acknowledgment
                        logger.Info("Starting 855 PO Acknowledgement...");

                        var edi855Proc = new OrderAcknowledge855();
                        edi855Proc.SendAcknowledgments(jobject);

                        ArchiveFile(filePath);

                        break;
                    case "856": // Ship Notice
                        logger.Info("Starting 856 Ship Notice...");

                        var edi865ShipNotice = new ShipmentUpload856();
                        edi865ShipNotice.SendShipments(jobject);

                        ArchiveFile(filePath);

                        break;
                }

                logger.Info("Done.");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unhandled Exception");
            }
        }

        private static void ArchiveFile(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);

            var archiveDir = Path.Combine(dir, "Archive");
            if (!Directory.Exists(archiveDir))
            {
                Directory.CreateDirectory(archiveDir);
            }

            try
            {
                var targetPath = Path.Combine(archiveDir, Path.GetFileName(filePath));
                if (File.Exists(targetPath))
                {
                    targetPath = Path.Combine(archiveDir, Path.GetFileNameWithoutExtension(filePath) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(filePath));
                }

                File.Move(filePath, targetPath);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Failed to save archive file.\n{filePath}");
            }
        }

        private static string GetEdiType(string jsonString, out JObject jobject)
        {
            // read json object
            jobject = JObject.Parse(jsonString);

            // get the JSON.document.doc value
            var docToken = jobject.SelectToken("document.doc");

            if (docToken == null)
            {
                throw new Exception("Could not find 'document.doc' value in root JSON object.");
            }

            return docToken.ToString();
        }

        private static string GetFilePath(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception($"Program expected 1 argument, got {args.Length}.");
            }

            var fn = args[0];

            if (!File.Exists(fn))
            {
                throw new Exception($"File does not exist.\n({fn})");
            }

            logger.Info($"Received and found file: {fn}");

            return fn;
        }

        private static void ReadConfig()
        {
            logger.Debug("Reading app configuration");

            DataLayer.DataSources.Add(new SqlDataSourceItem("", ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString));

            Program.ApiKey = ConfigurationManager.AppSettings["CA-ApiKey"];
            Program.ApiUrl = ConfigurationManager.AppSettings["CA-ApiUrl"];
            Program.ApiToken = ConfigurationManager.AppSettings["CA-ApiToken"];

            Program.DistributionCenterID = ConfigurationManager.AppSettings["DistributionCenterID"];
            Program.TestMode = Boolean.Parse(ConfigurationManager.AppSettings["TestMode"]);

            if (String.IsNullOrWhiteSpace(Program.ApiKey))
                throw new Exception("API Key config value is empty.");

            if (String.IsNullOrWhiteSpace(Program.ApiUrl))
                throw new Exception("API URL config value is empty.");

            ChannelAdvisorApi.ApiUrl = Program.ApiUrl;
            ChannelAdvisorApi.ApiKey = Program.ApiKey;
            ChannelAdvisorApi.ApiToken = Program.ApiToken;
            ChannelAdvisorApi.TestMode = Program.TestMode;

            if (int.TryParse(Program.DistributionCenterID, out int distributionCenterID))
            {
                ChannelAdvisorApi.DistributionCenterID = distributionCenterID;
            }

            if (Int32.TryParse(ConfigurationManager.AppSettings["API-Call-Retry-Attempts"], out int apiCallAttempts))
            {
                ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS = apiCallAttempts;
            }
        }


        private static void RunTest()
        {
            ReadConfig();

            //var edi846Proc = new InventoryQtyUpdater846();
            //edi846Proc.ProcessEdi846Json(jobject);

            var stockApi = new UpdateQuantityApi();

            Models.Edi846Record record = new Models.Edi846Record() { item = "ABC", sku = "12345", qty = 12 };

            try
            {
                var resultJsonString = stockApi.SendStockUpdate(record.sku, record.qty, ChannelAdvisorApi.DistributionCenterID);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
