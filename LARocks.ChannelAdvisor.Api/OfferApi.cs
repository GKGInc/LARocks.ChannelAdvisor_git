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

namespace LARocks.ChannelAdvisor.Api
{
    public class OfferApi // TO BE DELETED
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

   //     public string SendStockUpdate(List<StockUpdateRequest> stockUpdateList)
   //     {
   //         // create request data object
   //         var data = stockUpdateList.Select(r => {
   //             return new {
   //                 MerchantProductNo = r.sku,
   //                 StockLocations = new [] {
   //                     new {
   //                         Stock = r.qty
   //                     }
   //                 }
   //             };
   //         });

   //         // retry n times
   //         // increasing the duration exponentially
   //         var uploadPolicy = Policy
   //             .Handle<Exception>()
   //             .WaitAndRetry(
   //                 ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS,
   //                 tryNumber => TimeSpan.FromSeconds(RetryHelper.IncreaseExponentially(tryNumber)),
   //                 onRetry: (exc, timeSpan, retryCount, context) =>
   //                 {
   //                     Thread.Sleep(ChannelAdvisorApi.API_CALL_DEFAULT_DELAY);

   //                     if (exc is AggregateException)
   //                     {
   //                         var sb = new StringBuilder();
   //                         int innerCount = 1;
   //                         foreach (var innerExc in ((AggregateException)exc).InnerExceptions)
   //                         {
   //                             sb.AppendLine($"Inner Exception #{innerCount}:");
   //                             sb.AppendLine(innerExc.ToString());
   //                         }
   //                         logger.Warn($"Failed on Retry #{retryCount}.\r\n{sb}");
   //                     }
   //                     else
   //                     {
   //                         logger.Warn(exc, $"Failed on Retry #{retryCount}.");
   //                     }
   //                 });

   //         var result = uploadPolicy.ExecuteAndCapture(() =>
   //         {
   //             var jsonString = FlurlHttp.GlobalSettings.JsonSerializer.Serialize(data);
   //             logger.Debug($"API Call: PUT {ChannelAdvisorApi.ApiUrl}/v2/offer/stock");
   //             logger.Trace($"Body:\r\n{jsonString}");

   //             var resp = ChannelAdvisorApi.ApiUrl
   //                 .AppendPathSegments("v2", "offer", "stock")
   //                 .WithHeader(ChannelAdvisorApi.ApiKeyHeaderName, ChannelAdvisorApi.ApiKey)
   //                 .PutJsonAsync(data).Result;

   //             var responseString = resp.GetStringAsync().Result;

   //             logger.Trace($"API Response:\r\n{responseString}");

   //             return responseString;
   //         });

			//if (result.Outcome == OutcomeType.Failure)
   //         {
   //             throw result.FinalException;
   //         }

   //         return result.Result;
   //     }
    
    }
}
