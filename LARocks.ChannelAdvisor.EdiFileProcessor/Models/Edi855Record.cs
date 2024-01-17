using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.Models
{
    internal class Edi855Record
    {
        public string po { get; set; }
        public string sono { get; set; }
        public string extrefno { get; set; }
        public string status { get; set; }
        public string item { get; set; }
        public int stat_qty { get; set; }
        public int qty { get; set; }
    }
}
