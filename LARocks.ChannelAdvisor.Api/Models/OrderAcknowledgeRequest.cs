using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Models
{
    public class OrderAcknowledgeRequest
    {
        public string MerchantOrderNo { get; set; }
        public long OrderId { get; set; }
    }
}
