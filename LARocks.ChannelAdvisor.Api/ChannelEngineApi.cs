using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api
{
    public class ChannelAdvisorApi
    {
        public static readonly string ApiKeyHeaderName = "X-CE-KEY";
        public static string ApiUrl;
        public static string ApiKey;
        public static string ApiToken;

        public static int DistributionCenterID;

        public static int API_CALL_DEFAULT_DELAY = 2000;
        public static int API_CALL_RETRY_ATTEMPTS = 4;

        public static bool TestMode;
    }
}
