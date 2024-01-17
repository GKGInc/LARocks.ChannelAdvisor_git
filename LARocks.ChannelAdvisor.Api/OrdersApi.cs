using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Polly;
using NLog;
using LARocks.ChannelAdvisor.Api.Helpers;

namespace LARocks.ChannelAdvisor.Api
{
    public class OrdersApi
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public JObject GetNewOrders(int channelId, DateTime afterDateUtc, int page = 1)
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

            afterDateUtc = afterDateUtc.AddSeconds(1);

            var afterDateString = GetCestTimeZoneDateParam(afterDateUtc);

            logger.Debug($"getting orders. channelId: {channelId}, page: {page}, fromCreatedAt: '{afterDateString}'");

            var result = uploadPolicy.ExecuteAndCapture(() =>
            {
                var query = ChannelAdvisorApi.ApiUrl
                    .AppendPathSegments("v2", "orders")
                    .WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
                    .SetQueryParam("channelIds", channelId)
                    .SetQueryParam("statuses", "NEW")
                    .SetQueryParam("fromCreatedAtDate", afterDateString)
                    .SetQueryParam("page", page);

                logger.Info($"API Call: GET {query.Url}");

                var resp = query.GetStringAsync().Result;

                logger.Trace($"API Response:\r\n{resp}");

                return JObject.Parse(resp);
            });

			if (result.Outcome == OutcomeType.Failure)
            {
                throw result.FinalException;
            }

            return result.Result;
        }

        private string GetCestTimeZoneDateParam(DateTime date)
        {
            TimeZoneInfo cestTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
	        DateTime cestDateTime = TimeZoneInfo.ConvertTime(date, cestTimeZone);
            var cestOff = cestTimeZone.GetUtcOffset(cestDateTime);

            return (cestDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff") + (cestOff.Hours > 0 ? "+" : "") + $"{cestOff.Hours:00}:{cestOff.Minutes:00}");
        }
    }
}
