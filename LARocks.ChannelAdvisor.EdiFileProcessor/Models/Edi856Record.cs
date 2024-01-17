using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.EdiFileProcessor.Models
{
	public class Edi856Record
	{
		public long asn { get; set; }
		public string carname { get; set; }
		public string scac { get; set; }
		public DateTime shipdte { get; set; }
	
		public List<Edi856Order> orders { get; set; }
	}

	public class Edi856Order
	{
		public string extrefno { get; set; }
		public string sono { get; set; }
		public string invno { get; set; }
	
		public List<Edi856Carton> cartons { get; set; }
	}

	public class Edi856Carton
	{
		public string pro { get; set; }
		public string cserial { get; set; }
	
		public List<Edi856CartonItem> items { get; set; }
	}

	public class Edi856CartonItem
	{
		public string desc { get; set; }
		public string buystyl { get; set; }
		public string item { get; set; }
		public string iqty { get; set; }
		public int _iqty { get; set; }
	
	}
}
