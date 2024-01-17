using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Polly;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LARocks.ChannelAdvisor.Api.Models;
using LARocks.ChannelAdvisor.Api.Helpers;
using NLog;

namespace LARocks.ChannelAdvisor.Api
{
    public class OrderAckApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public OrderAcknowledgeResponse PostOrderAcknowledgment(string merchOrderNo, long ceOrderId)
        {
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
                var ackRequest = new OrderAcknowledgeRequest
				    {
					    MerchantOrderNo = merchOrderNo.Trim(),
					    OrderId = ceOrderId
				    };

                var jsonString = FlurlHttp.GlobalSettings.JsonSerializer.Serialize(ackRequest);
                logger.Debug($"API Call: POST {ChannelAdvisorApi.ApiUrl}/v2/orders/acknowledge");
                logger.Trace($"Body:\r\n{jsonString}");

			    var resp = ChannelAdvisorApi.ApiUrl
				    .AppendPathSegments("v2", "orders", "acknowledge")
				    .WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
				    .AllowAnyHttpStatus()
				    .PostJsonAsync(ackRequest)
				    .ReceiveString().Result;

                logger.Trace($"API Response:\r\n{resp}");

                var respObject = FlurlHttp.GlobalSettings.JsonSerializer.Deserialize<OrderAcknowledgeResponse>(resp);

                return respObject;
            });

			if (result.Outcome == OutcomeType.Failure)
            {
                throw result.FinalException;
            }

            return result.Result;

        }
    }
}
