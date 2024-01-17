using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Models
{
    public class ShipmentRequest
    {
        public string MerchantShipmentNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string TrackTraceNo { get; set; }
        public string TrackTraceUrl { get; set; }
        public string Method { get; set; }
        public DateTime ShipmentDate { get; set; }

        public List<ShipmentLine> Lines { get; set; } = new List<ShipmentLine>(); 
    }

    public class ShipmentLine
    {
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
    }
}
