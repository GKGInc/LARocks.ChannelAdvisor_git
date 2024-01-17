using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.Models
{
    public class Edi846Record
    {
        public string item { get; set; }
        public string sku { get; set; }
        public int qty { get; set; }
    }
}
