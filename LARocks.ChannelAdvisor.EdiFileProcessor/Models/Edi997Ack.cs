using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.Models
{
    public class Edi997Ack
    {
        public DocumentHeader document { get; set; }
        public MessagesData _data { get; set; }
    }

    public class MessagesData
    {
        public List<Edi997AckMessage> messages { get; set; }
    }
}
