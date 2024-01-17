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
using LARocks.ChannelAdvisor.Api.Models;
using LARocks.ChannelAdvisor.Api.Helpers;

namespace LARocks.ChannelAdvisor.Api
{
    public class ShipmentApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ShipmentResponse PostShipment(Models.ShipmentRequest shipment)
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
                var jsonString = FlurlHttp.GlobalSettings.JsonSerializer.Serialize(shipment);
                logger.Debug($"API Call: POST {ChannelAdvisorApi.ApiUrl}/v2/shipments");
                logger.Debug($"Body:\r\n{jsonString}");

			    var resp = ChannelAdvisorApi.ApiUrl
				    .AppendPathSegments("v2", "shipments")
				    .WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
				    .AllowAnyHttpStatus()
				    .PostJsonAsync(shipment)
				    .ReceiveJson<ShipmentResponse>().Result;

                var responseString = FlurlHttp.GlobalSettings.JsonSerializer.Serialize(resp);
                logger.Debug($"API Response:\r\n{responseString}");

                return resp;
            });

			if (result.Outcome == OutcomeType.Failure)
            {
                throw result.FinalException;
            }

            return result.Result;
        }

    }
}
