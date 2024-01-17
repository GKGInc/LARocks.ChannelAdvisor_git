using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using LARocks.ChannelAdvisor.Api;
using LARocks.ChannelAdvisor.Api.Models;
//using LARocks.ChannelAdvisor.BusinessObjects;
using LARocks.ChannelAdvisor.EdiFileProcessor.Models;
using static MicroFour.StrataFrame.Win32.ApiCalls.User32;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.FileProcessors
{
    public class InventoryQtyUpdater846
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void ProcessEdi846Json(JObject jo846Doc)
        {
            logger.Info("Read document header information.");
            var doc = jo846Doc.SelectToken("document")?.ToObject<DocumentHeader>();

            if (doc == null)
            {
                throw new Exception("No document header found in JSON.");
            }

            if (Program.TestMode)
            {
                logger.Warn("**** TEST MODE ****, skipping sending Inventory Qty to API");
                return;
            }

            var data = jo846Doc.SelectToken("_data.edi846")?.ToObject<List<Edi846Record>>();

            string resultJsonString = null;
            bool hasError = false;
            try
            {
                resultJsonString = SendStockUpdate(data);
            }
            catch(AggregateException aggExc)
            {
                hasError = true;
                var firstExc = aggExc.InnerExceptions.First();

                logger.Error(firstExc, $"API Call failed after {ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS} retries.\r\n");

                WriteException997(firstExc.Message, data, doc);
            }
            catch (Exception ex)
            {
                hasError = true;
                logger.Error(ex, $"API Call failed after {ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS} retries.\r\n");

                WriteException997(ex.Message, data, doc);
            }

            if (!hasError)
            {
                Write997(resultJsonString, doc);
            }
        }

        private void WriteException997(string message, List<Edi846Record> data, DocumentHeader doc)
        {
            var msgList = data.Select(r => new Models.Edi997AckMessage
            {
                key = r.sku,
                message = message
            }).ToList();

            var responseObj = new Edi997Ack
            {
                document = new DocumentHeader
                {
                    control_number = doc.control_number,
                    data_bytes = 0,
                    doc = "997",
                    receiverid = doc.senderid,
                    senderid = doc.receiverid,
                    transaction_sets = 1
                },
                _data = new MessagesData
                {
                    messages = msgList
                }
            };

            Acknowledgment997.Write997(responseObj);            
        }

        private string SendStockUpdate(List<Edi846Record> data)
        {
            var stockApi = new UpdateQuantityApi();

            foreach (Edi846Record record in data)
            {
                var resultJsonString = stockApi.SendStockUpdate(record.sku, record.qty, ChannelAdvisorApi.DistributionCenterID);
            }
            return "";
        }

        private void Write997(string jsonString, DocumentHeader doc)
        {
            var msgList = ExtractResultMessages(jsonString);

            var responseObj = new Edi997Ack
            {
                document = new DocumentHeader
                {
                    control_number = doc.control_number,
                    data_bytes = 0,
                    doc = "997",
                    receiverid = doc.senderid,
                    senderid = doc.receiverid,
                    transaction_sets = 1
                },
                _data = new MessagesData
                {
                    messages = msgList
                }
            };

            Acknowledgment997.Write997(responseObj);
        }

        private List<Models.Edi997AckMessage> ExtractResultMessages(string resultJsonString)
        {
            var messageList = new List<Models.Edi997AckMessage>();
            var resultJObj = (JObject) JObject.Parse(resultJsonString).SelectToken("Content.Results");

            if (resultJObj == null)
            {
                return messageList;
            }
	
            foreach(var prop in resultJObj.Properties())
            {
                var sku = prop.Name;

                var itemMessages = prop.Value.ToObject<List<string>>();

                messageList.Add(new Models.Edi997AckMessage { 
                        key = sku, 
                        message = String.Join("| ", itemMessages) 
                    });
            }

            return messageList;
        }
    }
}
