using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.BusinessObjects.Models
{
    public class StagingOrderFulfillmentsItems
    {
        //public System.Int32 pk { get; set; }
        public System.Int32 ID { get; set; }
        public System.String Sku { get; set; }
        public System.Int64 ProfileID { get; set; }
        public System.Int64 FulfillmentID { get; set; }
        public System.Int64 OrderID { get; set; }
        public System.Int64? OrderItemID { get; set; }
        public System.Int32 Quantity { get; set; }
        public System.Int64? ProductID { get; set; }
        public System.Int64? SellerFulfillmentItemID { get; set; }
        public System.String MarketplaceShippingStatus { get; set; }
        public System.Decimal? DistributionCenterItemUnitCost { get; set; }
        public System.Decimal? DistributionCenterShippingCost { get; set; }
        public System.Decimal? DistributionCenterCalculatedItemUnitCost { get; set; }
        public System.Decimal? DistributionCenterCalculatedShippingCost { get; set; }
        public System.String ReferenceSku { get; set; }
        public System.Int64? ReferenceProductID { get; set; }
        public System.String WarehouseLocation { get; set; }

    }
}
