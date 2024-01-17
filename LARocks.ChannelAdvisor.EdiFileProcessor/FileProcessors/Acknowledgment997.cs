using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using LARocks.ChannelAdvisor.BusinessObjects;
using LARocks.ChannelAdvisor.EdiFileProcessor.Models;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.FileProcessors
{
    public class Acknowledgment997
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Write997(Edi997Ack ackDocument)
        {
            //var doc = ackDocument.document;
            //var tradingPartnerBo = GetTradingPartner(doc.senderid);

            //string filePath = Path.Combine(tradingPartnerBo.edi_output_folder, $"{doc.control_number}-997.json");

            //logger.Info($"Saving response file: {filePath}");

            //try
            //{
            //    File.WriteAllText(filePath, JsonConvert.SerializeObject(ackDocument));
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex, $"Failed to save 997.\n{filePath}");
            //}
        }

        //private static TradingPartnerBO GetTradingPartner(string tradPartnerId)
        //{
        //    var tpBo = new TradingPartnerBO();

        //    tpBo.FillByTradingPartnerId(tradPartnerId);

        //    if (tpBo.IsEmpty)
        //    {
        //        throw new Exception($"Could not find Trading Partner in SQL TradingPartners table. ('{tradPartnerId}')");
        //    }

        //    return tpBo;
        //}

    }
}
