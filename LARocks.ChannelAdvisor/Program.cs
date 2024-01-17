using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MicroFour.StrataFrame.Data;
using NLog;
using LARocks.ChannelAdvisor.Api;
using System.IO;
using Newtonsoft.Json.Linq;
using LARocks.ChannelAdvisor.BusinessObjects;
using LARocks.ChannelAdvisor.BusinessObjects.Models;
using AutoMapper;
using System.Data;

namespace LARocks.ChannelAdvisor
{
    class Program
    {
        #region Contructors and Variables

        public static string ApiKey;
        public static string ApiUrl;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Info($"Start of Tanya.ChannelEngine.OrderDownload...");

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            try
            {
                ReadAppConfig();

                //var filePath = GetFilePath(args);
                var filePath = @"C:\temp\testJson.txt";

                var jsonString = File.ReadAllText(filePath);

                JObject jobject = JObject.Parse(jsonString);

                StagingOrderHeader header = GetOrderHeader(jobject);

                ProcessOrderHeader(header);

                //var orderDownloader = new OrderDownloadProcessor();
                //orderDownloader.Run();

                logger.Info("Done");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unhandled exception");
            }
        }

        #endregion

        #region Private Functions

        private static void ReadAppConfig()
        {
            logger.Debug("Reading app configuration");

            DataLayer.DataSources.Add(new SqlDataSourceItem("", ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString));

            Program.ApiKey = ConfigurationManager.AppSettings["CA-ApiKey"];
            Program.ApiUrl = ConfigurationManager.AppSettings["CA-ApiUrl"];

            if (String.IsNullOrWhiteSpace(Program.ApiKey))
                throw new Exception("API Key config value is empty.");

            if (String.IsNullOrWhiteSpace(Program.ApiUrl))
                throw new Exception("API URL config value is empty.");

            ChannelAdvisorApi.ApiUrl = Program.ApiUrl;
            ChannelAdvisorApi.ApiKey = Program.ApiKey;
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

        private static StagingOrderHeader GetOrderHeader(JObject jobject)
        {
            if (jobject == null)
            {
                return new StagingOrderHeader();
                logger.Info("Empty JObject");
            }

            StagingOrderHeader header = jobject.SelectToken("payload")?.ToObject<StagingOrderHeader>();

            //List<StagingOrderItems> items = JObject.Parse(jobject.SelectToken("payload").ToString()).SelectToken("Items").ToObject<List<StagingOrderItems>>();
            //List<StagingOrderFulfillments> fulfillments = JObject.Parse(jobject.SelectToken("payload").ToString()).SelectToken("Fulfillments").ToObject<List<StagingOrderFulfillments>>();
            //var fulfillmentsList = JObject.Parse(jobject.SelectToken("payload").ToString()).SelectToken("Fulfillments").ToList();
            //foreach (JToken j in fulfillmentsList)
            //{
            //    StagingOrderFulfillments fulfillment = j.ToObject<StagingOrderFulfillments>();
            //    List<StagingOrderFulfillmentsItems> fItems = j.SelectToken("Items").ToObject<List<StagingOrderFulfillmentsItems>>();
            //    fulfillment.Items = fItems;
            //    header.Fulfillments.Add(fulfillment);
            //} 

            return header;
        }

        private static void ProcessOrderHeader(StagingOrderHeader orderHeader)
        {
            Int64 orderId = orderHeader.ID;

            StagingOrderHeaderBO stagingOrderHeaderBO = new StagingOrderHeaderBO();
            StagingOrderItemsBO stagingOrderItemsBO = new StagingOrderItemsBO();
            StagingOrderFulfillmentsBO stagingOrderFulfillmentsBO = new StagingOrderFulfillmentsBO();
            StagingOrderFulfillmentsItemsBO stagingOrderFulfillmentsItemsBO = new StagingOrderFulfillmentsItemsBO();

            //stagingOrderHeaderBO.FillByOrderId(orderId);
            //stagingOrderItemsBO.FillByOrderId(orderId);
            //stagingOrderFulfillmentsBO.FillByOrderId(orderId);
            //stagingOrderFulfillmentsItemsBO.FillByOrderId(orderId);

            if (stagingOrderHeaderBO.Count == 0)
            {
                try
                {
                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<StagingOrderHeaderBO, StagingOrderHeader>()
                        .ForMember(dest => dest.Items, opt => opt.Ignore())
                        .ForMember(dest => dest.Fulfillments, opt => opt.Ignore());
                        cfg.CreateMap<StagingOrderHeader, StagingOrderHeaderBO>()
                        .ForMember(dest => dest.pk, opt => opt.Ignore());

                        cfg.CreateMap<StagingOrderItemsBO, StagingOrderItems>();
                        cfg.CreateMap<StagingOrderItems, StagingOrderItemsBO>()
                        .ForMember(dest => dest.pk, opt => opt.Ignore());

                        cfg.CreateMap<StagingOrderFulfillmentsBO, StagingOrderFulfillments>()
                        .ForMember(dest => dest.Items, opt => opt.Ignore());
                        cfg.CreateMap<StagingOrderFulfillments, StagingOrderFulfillmentsBO>()
                        .ForMember(dest => dest.pk, opt => opt.Ignore());

                        cfg.CreateMap<StagingOrderFulfillmentsItemsBO, StagingOrderFulfillmentsItems>();
                        cfg.CreateMap<StagingOrderFulfillmentsItems, StagingOrderFulfillmentsItemsBO>()
                        .ForMember(dest => dest.pk, opt => opt.Ignore());
                    });

                    AutoMapper.Mapper mapper = new AutoMapper.Mapper(configuration);

                    stagingOrderHeaderBO.NewRow();
                    mapper.Map<StagingOrderHeader, StagingOrderHeaderBO>(orderHeader, stagingOrderHeaderBO);
                    foreach (StagingOrderItems item in orderHeader.Items)
                    {
                        stagingOrderItemsBO.NewRow();
                        mapper.Map<StagingOrderItems, StagingOrderItemsBO>(item, stagingOrderItemsBO);
                    }
                    foreach (StagingOrderFulfillments fulfillments in orderHeader.Fulfillments)
                    {
                        stagingOrderFulfillmentsBO.NewRow();
                        mapper.Map<StagingOrderFulfillments, StagingOrderFulfillmentsBO>(fulfillments, stagingOrderFulfillmentsBO);

                        foreach (StagingOrderFulfillmentsItems item in fulfillments.Items)
                        {
                            stagingOrderFulfillmentsItemsBO.NewRow();
                            mapper.Map<StagingOrderFulfillmentsItems, StagingOrderFulfillmentsItemsBO>(item, stagingOrderFulfillmentsItemsBO);
                        }
                    }

                    //stagingOrderHeaderBO.CopyDataFrom(ProcessBusinessObjectNulls(stagingOrderHeaderBO.CurrentRow.Table), MicroFour.StrataFrame.Business.BusinessCloneDataType.ClearAndFillFromCompleteTable);
                    //stagingOrderItemsBO.CopyDataFrom(ProcessBusinessObjectNulls(stagingOrderItemsBO.CurrentRow.Table), MicroFour.StrataFrame.Business.BusinessCloneDataType.ClearAndFillFromCompleteTable);
                    //stagingOrderFulfillmentsBO.CopyDataFrom(ProcessBusinessObjectNulls(stagingOrderFulfillmentsBO.CurrentRow.Table), MicroFour.StrataFrame.Business.BusinessCloneDataType.ClearAndFillFromCompleteTable);
                    //stagingOrderFulfillmentsItemsBO.CopyDataFrom(ProcessBusinessObjectNulls(stagingOrderFulfillmentsItemsBO.CurrentRow.Table), MicroFour.StrataFrame.Business.BusinessCloneDataType.ClearAndFillFromCompleteTable);

                    stagingOrderHeaderBO = ProcessStagingOrderNulls<StagingOrderHeaderBO>(stagingOrderHeaderBO);
                    stagingOrderItemsBO = ProcessStagingOrderNulls<StagingOrderItemsBO>(stagingOrderItemsBO);
                    stagingOrderFulfillmentsBO = ProcessStagingOrderNulls<StagingOrderFulfillmentsBO>(stagingOrderFulfillmentsBO);
                    stagingOrderFulfillmentsItemsBO = ProcessStagingOrderNulls<StagingOrderFulfillmentsItemsBO>(stagingOrderFulfillmentsItemsBO);

                    //stagingOrderHeaderBO = ProcessStagingOrderHeaderNulls(stagingOrderHeaderBO);
                    //stagingOrderItemsBO = ProcessStagingOrderItemsNulls(stagingOrderItemsBO);
                    //stagingOrderFulfillmentsBO = ProcessStagingOrderFulfillmentsNulls(stagingOrderFulfillmentsBO);
                    //stagingOrderFulfillmentsItemsBO = ProcessStagingOrderFulfillmentsItemsNulls(stagingOrderFulfillmentsItemsBO);

                    //stagingOrderHeaderBO.Save();
                    //stagingOrderItemsBO.Save();
                    //stagingOrderFulfillmentsBO.Save();
                    //stagingOrderFulfillmentsItemsBO.Save();
                }
                catch (Exception ex)
                {
                    logger.Fatal(ex, "Unhandled exception");
                }

            }

        }

        #endregion

        #region Helper Functions

        private static T ProcessStagingOrderNulls<T>(MicroFour.StrataFrame.Business.BusinessLayer bo)
        {
            Dictionary<string, System.Data.DbType> fieldDbTypes = bo.FieldDbTypes;
            DateTime emptyDate = new DateTime(1800, 1, 1);
            System.Data.DbType type;

            foreach (MicroFour.StrataFrame.Business.BusinessLayer row in bo.GetEnumerable())
            {
                foreach (string field in fieldDbTypes.Keys)
                {
                    try
                    {
                        type = fieldDbTypes[field];
                        if (row[field] == DBNull.Value)
                        {
                            if (type == System.Data.DbType.String || type == System.Data.DbType.AnsiString)
                            {
                                row[field] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + field + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == System.Data.DbType.DateTime && (DateTime)row[field] < emptyDate)
                            {
                                row[field] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }
            }

            return (T)Convert.ChangeType(bo, typeof(T)); ;
        }
        
        private static System.Data.DataTable ProcessBusinessObjectNulls(System.Data.DataTable dataTable)
        {
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            DateTime emptyDate = new DateTime(1800, 1, 1);
            Type type;
            string colName;

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    type = col.DataType;
                    colName = col.ColumnName;

                    try
                    {
                        if (dr[colName] == DBNull.Value)
                        {
                            if (type == typeof(String))
                            {
                                dr[colName] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + colName + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == typeof(DateTime) && (DateTime)dr[colName] < emptyDate)
                            {
                                dr[colName] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }

            }

            return dataTable;
        }

        private static StagingOrderHeaderBO ProcessStagingOrderHeaderNulls(StagingOrderHeaderBO stagingOrderHeaderBO)
        {
            Dictionary<string, System.Data.DbType> fieldDbTypes = stagingOrderHeaderBO.FieldDbTypes;
            DateTime emptyDate = new DateTime(1800, 1, 1);
            System.Data.DbType type;

            foreach (StagingOrderHeaderBO row in stagingOrderHeaderBO.GetEnumerable())
            {
                foreach (string field in fieldDbTypes.Keys)
                {
                    try
                    {
                        type = fieldDbTypes[field];
                        if (row[field] == DBNull.Value)
                        {
                            if (type == System.Data.DbType.String || type == System.Data.DbType.AnsiString)
                            {
                                row[field] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + field + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == System.Data.DbType.DateTime && (DateTime)row[field] < emptyDate)
                            {
                                row[field] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }
            }

            return stagingOrderHeaderBO;
        }
        private static StagingOrderItemsBO ProcessStagingOrderItemsNulls(StagingOrderItemsBO stagingOrderItemsBO)
        {
            Dictionary<string, System.Data.DbType> fieldDbTypes = stagingOrderItemsBO.FieldDbTypes;
            DateTime emptyDate = new DateTime(1800, 1, 1);
            System.Data.DbType type;

            foreach (StagingOrderItemsBO row in stagingOrderItemsBO.GetEnumerable())
            {
                foreach (string field in fieldDbTypes.Keys)
                {
                    try
                    {
                        type = fieldDbTypes[field];
                        if (row[field] == DBNull.Value)
                        {
                            if (type == System.Data.DbType.String || type == System.Data.DbType.AnsiString)
                            {
                                row[field] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + field + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == System.Data.DbType.DateTime && (DateTime)row[field] < emptyDate)
                            {
                                row[field] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }
            }

            return stagingOrderItemsBO;
        }
        private static StagingOrderFulfillmentsBO ProcessStagingOrderFulfillmentsNulls(StagingOrderFulfillmentsBO stagingOrderFulfillmentsBO)
        {
            Dictionary<string, System.Data.DbType> fieldDbTypes = stagingOrderFulfillmentsBO.FieldDbTypes;
            DateTime emptyDate = new DateTime(1800, 1, 1);
            System.Data.DbType type;

            foreach (StagingOrderFulfillmentsBO row in stagingOrderFulfillmentsBO.GetEnumerable())
            {
                foreach (string field in fieldDbTypes.Keys)
                {
                    try
                    {
                        type = fieldDbTypes[field];
                        if (row[field] == DBNull.Value)
                        {
                            if (type == System.Data.DbType.String || type == System.Data.DbType.AnsiString)
                            {
                                row[field] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + field + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == System.Data.DbType.DateTime && (DateTime)row[field] < emptyDate)
                            {
                                row[field] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }
            }
            
            return stagingOrderFulfillmentsBO;
        }
        private static StagingOrderFulfillmentsItemsBO ProcessStagingOrderFulfillmentsItemsNulls(StagingOrderFulfillmentsItemsBO stagingOrderFulfillmentsItemsBO)
        {
            Dictionary<string, System.Data.DbType> fieldDbTypes = stagingOrderFulfillmentsItemsBO.FieldDbTypes;
            DateTime emptyDate = new DateTime(1800, 1, 1);
            System.Data.DbType type;

            foreach (StagingOrderFulfillmentsItemsBO row in stagingOrderFulfillmentsItemsBO.GetEnumerable())
            {
                foreach (string field in fieldDbTypes.Keys)
                {
                    try
                    {
                        type = fieldDbTypes[field];
                        if (row[field] == DBNull.Value)
                        {
                            if (type == System.Data.DbType.String || type == System.Data.DbType.AnsiString)
                            {
                                row[field] = "";
                            }
                            else
                            {
                                logger.Warn("Null field [" + field + "] not handled");
                            }
                        }
                        else
                        {
                            if (type == System.Data.DbType.DateTime && (DateTime)row[field] < emptyDate)
                            {
                                row[field] = emptyDate;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Fatal(ex, "Unhandled exception");
                    }
                }
            }

            return stagingOrderFulfillmentsItemsBO;
        }

        #endregion
    }
}
