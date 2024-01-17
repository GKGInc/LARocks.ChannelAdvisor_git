using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.BusinessObjects.Models
{
    public class StagingOrderItems
    {
        //public System.Int32 pk { get; set; }
        public System.Int64 ID { get; set; }
        public System.Int64 ProfileID { get; set; }
        public System.Int64 OrderID { get; set; }
        public System.Int64 ProductID { get; set; }
        public System.String SiteOrderItemID { get; set; }
        public System.String SellerOrderItemID { get; set; }
        public System.String SiteListingID { get; set; }
        public System.String Sku { get; set; }
        public System.String ReferenceSku { get; set; }
        public System.String ReferenceProductID { get; set; }
        public System.String Title { get; set; }
        public System.Int32 Quantity { get; set; }
        public System.Decimal UnitPrice { get; set; }
        public System.Decimal? TaxPrice { get; set; }
        public System.Decimal? ShippingPrice { get; set; }
        public System.Decimal? ShippingTaxPrice { get; set; }
        public System.Decimal? RecyclingFee { get; set; }
        public System.Decimal? UnitEstimatedShippingCost { get; set; }
        public System.String GiftMessage { get; set; }
        public System.String GiftNotes { get; set; }
        public System.Decimal? GiftPrice { get; set; }
        public System.Decimal? GiftTaxPrice { get; set; }
        public System.Boolean IsBundle { get; set; }
        public System.String ItemURL { get; set; }
        public System.String HarmonizedCode { get; set; }

    }
}
