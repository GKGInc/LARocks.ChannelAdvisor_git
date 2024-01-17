using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using LARocks.ChannelAdvisor.Api;
using LARocks.ChannelAdvisor.Api.Models;
//using LARocks.ChannelAdvisor.BusinessObjects;
using LARocks.ChannelAdvisor.EdiFileProcessor.Models;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.FileProcessors
{
    internal class ShipmentUpload856
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void SendShipments(JObject joShipmentsDocument)
        {
            logger.Info("Reading document header information");
            var doc = joShipmentsDocument.SelectToken("document")?.ToObject<Models.DocumentHeader>();

            if (doc == null)
            {
                throw new Exception("No document header found in JSON.");
            }

            if (Program.TestMode)
            {
                logger.Warn("**** TEST MODE ****, skipping sending shipments to API");
                return;
            }

            var responseData = SendShipmentToApi(joShipmentsDocument);

            Write997(responseData, doc);
        }

        public List<Models.Edi997AckMessage> SendShipmentToApi(JObject joShipmentsDocument)
        {
            logger.Info("Sending shipments to API...");

            var edi856Data = joShipmentsDocument.SelectToken("_data.edi856")?.ToObject<List<Models.Edi856Record>>();

            var ordersFound = edi856Data.SelectMany(asn => asn.orders).Select(o => o).ToList();

            logger.Info($"Found {ordersFound.Count} orders in _data.edi856");

            var failed = 0;
            var sendShipmentApi = new ShipmentApi();
            var responseData = new List<Models.Edi997AckMessage>();

            if (Program.TestMode)
            {
                logger.Warn("**** TEST MODE ****, skipping sending to API");
            }

	        foreach(var asn in edi856Data)
	        {
		        foreach(var order in asn.orders)
		        {
                    try
                    {
    			        var shipment = CreateShipment(asn, order);

                        // record successful post in response list
                        if (Program.TestMode)
                        {
                            continue;
                        }

                        logger.Debug($"Sending ship notice for SONO '{order.sono}'");

                        Thread.Sleep(ChannelAdvisorApi.API_CALL_DEFAULT_DELAY);
                        var shipResponse = sendShipmentApi.PostShipment(shipment);

                        if (!shipResponse.Success)
                        {
                            failed++;
                            logger.Warn($"Ship Notice API call failed, sono: '{order.sono}'\nmsg: '{shipResponse.Message}'");

                            responseData.Add(new Models.Edi997AckMessage
                            {
                                key = order.sono,
                                message = shipResponse.Message
                            });
                        }
                    }
			        catch (Exception ex)
                    {
                        failed++;

                        logger.Warn($"Ship Notice threw exception, sono: '{order.sono}'\nmsg: '{ex.Message}'");
                        logger.Warn(ex.ToString());

                        responseData.Add(new Models.Edi997AckMessage
                        {
                            key = order.sono,
                            message = ex.Message
                        });
                    }
		        }
	        }

            if (failed > 0)
            {
                logger.Error($"Failed to send shipments {failed} orders.");
            }

            return responseData;
        }

        ShipmentRequest CreateShipment(Edi856Record asn, Edi856Order order)
        {
            var shipment = new ShipmentRequest
            {
                MerchantShipmentNo = order.invno.Trim(),
                MerchantOrderNo = order.sono.Trim(),
                TrackTraceNo = order.cartons.First().pro.Trim(),
                Method = asn.scac.Trim(),
                ShipmentDate = asn.shipdte
            };

            // get all the cartons
            var items = order.cartons
                .SelectMany(c => c.items)
                .Select(i => i).ToList();

            // converting carton.item.iqty to integer
            foreach (var item in items)
            {
                if (!Int32.TryParse(item.iqty, out int quantity))
                {
                    throw new Exception($"Failed to parse carton.iqty. sono: '{order.sono}', item: '{item.item}', iqty: '{item.iqty}'");
                }
                item._iqty = quantity;
            }

            // group by item
            var groupedItems = (from i in items
                                group i by i.item into itemGroup
                                select new
                                {
                                    item = itemGroup.Key,
                                    iqty = itemGroup.Sum(i => i._iqty)
                                }).ToList();

            // add the line items to shipment
            foreach (var item in groupedItems)
            {
                shipment.Lines.Add(new ShipmentLine
                {
                    Quantity = item.iqty,
                    MerchantProductNo = item.item.Trim()
                });
            }

            return shipment;
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

    }
}
