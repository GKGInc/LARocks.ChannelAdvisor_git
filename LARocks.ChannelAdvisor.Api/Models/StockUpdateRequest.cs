using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.Api.Models
{
    public class StockUpdateRequest
    {
        public string UpdateType { get; set; }
        public List<StockUpdateRequestUpdatesList> Updates = new List<StockUpdateRequestUpdatesList>();
    }
    public class StockUpdateRequestUpdatesList
    {
        public int DistributionCenterID { get; set; }
        public int Quantity { get; set; }
    }
}
