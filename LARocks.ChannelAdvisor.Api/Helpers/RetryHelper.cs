using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Helpers
{
    internal class RetryHelper
    {
        public static double IncreaseExponentially(int step)
        {
            if (ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS == 1)
            {
                return 0;
            }

            if(step < 1 || step > ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS) 
            {
                throw new ArgumentException("Step must be between 1 and 10.");
            }

            double min = Math.Log(60); // 1 minute
            double max = Math.Log(600); // 10 minutes
            double scale = (max - min) / (double)(ChannelAdvisorApi.API_CALL_RETRY_ATTEMPTS - 1);

            return Math.Exp(min + scale * (step - 1));
        }

    }
}
