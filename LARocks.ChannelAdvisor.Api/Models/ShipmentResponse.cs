using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Models
{
    public class ShipmentResponse
    {
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}
