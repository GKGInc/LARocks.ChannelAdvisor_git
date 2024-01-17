using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.Models
{
    public class DocumentHeader
    {
        public string control_number { get; set; }
        public int data_bytes { get; set; }
        public string doc { get; set; }
        public string receiverid { get; set; }
        public string senderid { get; set; }
        public int transaction_sets { get; set; }
    }
}
