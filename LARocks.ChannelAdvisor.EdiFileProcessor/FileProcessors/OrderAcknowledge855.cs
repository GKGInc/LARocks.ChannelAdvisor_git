using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LARocks.ChannelAdvisor.Api;
//using LARocks.ChannelAdvisor.BusinessObjects;
using LARocks.ChannelAdvisor.EdiFileProcessor.Models;
using NLog.Targets;
using LARocks.ChannelAdvisor.Api.Models;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.FileProcessors
{
    internal class OrderAcknowledge855
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void SendAcknowledgments(JObject joAckDocument)
        {
            logger.Info("Reading document header information.");
            var doc = joAckDocument.SelectToken("document")?.ToObject<DocumentHeader>();

            if (doc == null)
            {
                throw new Exception("No document header found in JSON.");
            }

            if (Program.TestMode)
            {
                logger.Warn("**** TEST MODE ****, skipping sending order acks to API");
                return;
            }

            var responseData = SendAcknowledgmentsToApi(joAckDocument);

            SendCancellations(joAckDocument, responseData);

            Write997(responseData, doc);
        }

        private List<Models.Edi997AckMessage> SendAcknowledgmentsToApi(JObject joAckData)
        {
            logger.Info("Sending acknowledgments to API...");

            // read unique "sono", "extrefid" and send that to 
            var refNoList = joAckData.SelectToken("_data.edi855")?.ToObject<List<Edi855Record>>();

            logger.Info($"Found {refNoList.Count} orders in _data.edi855");

            var failedAck = 0;
            var orderAckApi = new OrderAckApi();
            var responseData = new List<Models.Edi997AckMessage>();

            foreach(var order in refNoList)
            {
                try
                {
                    if (Program.TestMode)
                    {
                        continue;
                    }

                    Thread.Sleep(ChannelAdvisorApi.API_CALL_DEFAULT_DELAY);
                    var ackResponse = orderAckApi.PostOrderAcknowledgment(order.sono, Int64.Parse(order.extrefno));

                    if (!ackResponse.Success)
                    {
                        failedAck++;
                        logger.Warn($"Order Ack API call failed, sono: '{order.sono.Trim()}'\nmsg: '{ackResponse.Message}'");

                        responseData.Add(new Models.Edi997AckMessage
                        {
                            key = order.sono,
                            message = ackResponse.Message
                        });
                    }

                }
                catch (Exception ex)
                {
                    failedAck++;

                    logger.Warn($"Order Ack threw exception, sono: '{order.sono.Trim()}'\nmsg: '{ex.Message}'");
                    logger.Warn(ex.ToString());

                    responseData.Add(new Models.Edi997AckMessage
                    {
                        key = order.sono,
                        message = ex.Message
                    });
                }
            }

            if (failedAck > 0)
            {
                logger.Error($"Failed to acknowledge {failedAck} orders.");
            }

            return responseData;
        }

        private void SendCancellations(JObject joAckData, List<Models.Edi997AckMessage> responseData)
        {
            logger.Info("Sending cancellation to API...");

            // get all order records where the line item status = 'IR'
            var full855Records = joAckData.SelectToken("_data.edi855")?.ToObject<List<Edi855Record>>();
            var cancelled855Orders = from row in full855Records
                                      where !String.IsNullOrWhiteSpace(row.status) && (row.status.Trim().Equals("IR", StringComparison.CurrentCultureIgnoreCase)
                                            || row.status.Trim().Equals("IC", StringComparison.CurrentCultureIgnoreCase))
                                      group row by new { sono = row.sono.Trim(), extrefno = row.extrefno.Trim() } into cancelledOrderLines
                                      select new
                                      {
                                          sono = cancelledOrderLines.Key.sono,
                                          extrefno = cancelledOrderLines.Key.extrefno,
                                          lines = cancelledOrderLines
                                      };

            if (!cancelled855Orders.Any())
            {
                logger.Info("No cancellations found.");
                return;
            }

            var failedCount = 0;
            var now = DateTime.Now;
            var cancelApi = new CancellationApi();

            foreach (var order in cancelled855Orders)
            {
                try
                {
                    Random random = new Random();
                    int randomNumber = random.Next(100000, 999999);
                    var cancelNo = $"{order.sono}C{now:ddHH}{randomNumber}";

                    var newc = new CancellationRequest
                    {
                        MerchantCancellationNo = cancelNo,
                        MerchantOrderNo = order.sono,
                        ReasonCode = "NOT_IN_STOCK"
                    };

                    foreach(var line in order.lines)
                    {
                        var cancelQty = line.qty - line.stat_qty;

                        newc.Lines.Add(new CancellationRequestLine
                        {
                            MerchantProductNo = line.item,
                            Quantity = cancelQty
                        });
                    }

                    var cancelJsonString = JsonConvert.SerializeObject(newc, Formatting.Indented);
                    logger.Trace($"Sending cancellation json:\n" + cancelJsonString);

                    // send cancellation for each order with lines and reason code
                    var resp = cancelApi.SendCancellation(newc);

                    if (!resp.Success)
                    {
                        failedCount++;
                        logger.Warn($"Cancel failed, sono: '{order.sono}'\nmsg: '{resp.Message}'");

                        AppendResponse(responseData, order.sono, resp.Message);
                    }
                }
                catch (Exception ex)
                {
                    failedCount++;
                    logger.Warn($"Cancel failed, sono: '{order.sono}'\nmsg: '{ex.Message}'");

                    AppendResponse(responseData, order.sono, ex.Message);                    
                }
            }

            if (failedCount > 0)
            {
                logger.Error($"Failed to cancel {failedCount} orders.");
            }
        }

        private void Write997(List<Models.Edi997AckMessage> responseData, DocumentHeader doc)
        {
            // write response file
            var responseObject = new Edi997Ack
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
                    messages = responseData
                }
            };

            Acknowledgment997.Write997(responseObject);
        }

        private void AppendResponse(List<Models.Edi997AckMessage> responseData, string msgSono, string newMessage)
        {
            var orderMessage = responseData.FirstOrDefault(r => r.key == msgSono);
            if (orderMessage == null)
            {
                responseData.Add(new Models.Edi997AckMessage
                {
                    key = msgSono,
                    message = newMessage
                });
            }

            orderMessage.message += "| " + newMessage;
        }
    }
}
