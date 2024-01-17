using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using NLog;
using Polly;
using LARocks.ChannelAdvisor.Api.Helpers;
using LARocks.ChannelAdvisor.Api.Models;
using Newtonsoft.Json.Linq;

namespace LARocks.ChannelAdvisor.Api
{
    public class UpdateQuantityApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string SendStockUpdate(string productId, int productQty, int distributionCenterID)
        {
            StockUpdateRequestUpdatesList listItem = new StockUpdateRequestUpdatesList() { DistributionCenterID = distributionCenterID, Quantity = productQty };
            List<StockUpdateRequestUpdatesList> updates = new List<StockUpdateRequestUpdatesList>();
            updates.Add(listItem);

            // build json string
            var data = new JObject();
            data.Add("Value", JObject.FromObject(new
            {
                UpdateType = "InStock",
                Updates = updates
            }));

            // retry n times
            // increasing the duration exponentially
            var uploadPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetry(
                    ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS,
                    tryNumber => TimeSpan.FromSeconds(RetryHelper.IncreaseExponentially(tryNumber)),
                    onRetry: (exc, timeSpan, retryCount, context) =>
                    {
                        Thread.Sleep(ChannelAdvisorApi.API_CALL_DEFAULT_DELAY);

                        if (exc is AggregateException)
                        {
                            var sb = new StringBuilder();
                            int innerCount = 1;
                            foreach (var innerExc in ((AggregateException)exc).InnerExceptions)
                            {
                                sb.AppendLine($"Inner Exception #{innerCount}:");
                                sb.AppendLine(innerExc.ToString());
                            }
                            logger.Warn($"Failed on Retry #{retryCount}.\r\n{sb}");
                        }
                        else
                        {
                            logger.Warn(exc, $"Failed on Retry #{retryCount}.");
                        }
                    });

            var result = uploadPolicy.ExecuteAndCapture(() =>
            {
                var jsonString = FlurlHttp.GlobalSettings.JsonSerializer.Serialize(data);
                logger.Debug($"API Call: POST {ChannelAdvisorApi.ApiUrl}/v1/Products(" + productId + ")/UpdateQuantity?access_token=" + ChannelAdvisorApi.ApiToken);
                logger.Trace($"Body:\r\n{jsonString}");

                var resp = ChannelAdvisorApi.ApiUrl
                    .AppendPathSegments("v1", "Products(" + productId + ")", "UpdateQuantity?access_token=" + ChannelAdvisorApi.ApiToken)
                    //.WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
                    .PostJsonAsync(data).Result;

                if (!ChannelAdvisorApi.TestMode)
                {
                    var responseString = resp.GetStringAsync().Result;

                    logger.Trace($"API Response:\r\n{responseString}");

                    return responseString;
                }
                else
                {
                    return "Testing";
                }
            });

			if (result.Outcome == OutcomeType.Failure)
            {
                throw result.FinalException;
            }

            return result.Result;
        }
    }
}
