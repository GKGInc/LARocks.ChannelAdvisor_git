using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using NLog;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LARocks.ChannelAdvisor.Api.Helpers;
using LARocks.ChannelAdvisor.Api.Models;

namespace LARocks.ChannelAdvisor.Api
{
    public class CancellationApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CancellationResponse SendCancellation(CancellationRequest cancelRequest)
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
                var resp = ChannelAdvisorApi.ApiUrl
                    .AppendPathSegments("v2", "cancellations")
                    .WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
                    .AllowAnyHttpStatus()
                    .PostJsonAsync(cancelRequest).Result;

                return resp.GetStringAsync().Result;
            });

			if (result.Outcome == OutcomeType.Failure)
            {
                throw result.FinalException;
            }

            logger.Trace("Response JSON:\r\n" + result.Result);

            var joResponse = JObject.Parse(result.Result);
            var cancelResp = joResponse.ToObject<CancellationResponse>();

            if (!cancelResp.Success)
            {
                // extract errors and log them
                try
                {
                    var verrors = joResponse.SelectToken("ValidationErrors");
                    logger.Warn($"ValidationErrors:\n" + verrors.ToString());
                }
                catch 
                {
                    logger.Error("Failed to extract API ValidationErrors from json.\r\nJSON:\r\n" + result.Result);
                }
            }

            return cancelResp;

        }
    }
}
