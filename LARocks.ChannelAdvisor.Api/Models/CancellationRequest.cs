using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Models
{
    public class CancellationRequest
    {
        public string MerchantCancellationNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Reason { get; set; }
        public string ReasonCode { get; set; }

        public List<CancellationRequestLine> Lines { get; set; } = new List<CancellationRequestLine>();
    }

    public class CancellationRequestLine
    {
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
    }
}
