using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.BusinessObjects.Models
{
    public class StagingOrderFulfillments
    {
        //public System.Int32 pk { get; set; }
        public System.Int64 ID { get; set; }
        public System.Int64 ProfileID { get; set; }
        public System.Int64 OrderID { get; set; }
        public System.DateTime CreatedDateUtc { get; set; }
        public System.DateTime UpdatedDateUtc { get; set; }
        public System.String Type { get; set; }
        public System.String DeliveryStatus { get; set; }
        public System.String TrackingNumber { get; set; }
        public System.String ShippingCarrier { get; set; }
        public System.String ShippingClass { get; set; }
        public System.Int64? DistributionCenterID { get; set; }
        public System.String ExternalFulfillmentCenterCode { get; set; }
        public System.String ExternalFulfillmentStatus { get; set; }
        public System.Decimal? ShippingCost { get; set; }
        public System.Decimal? InsuranceCost { get; set; }
        public System.Decimal? TaxCost { get; set; }
        public System.DateTime? ShippedDateUtc { get; set; }
        public System.Int64? SellerFulfillmentID { get; set; }
        public System.Boolean HasShippingLabel { get; set; }
        public System.Boolean HasChannelPackingSlip { get; set; }
        public System.Boolean HasReturnLabel { get; set; }
        public System.Boolean HasChannelReturnLabel { get; set; }
        public System.String ExternalFulfillmentNumber { get; set; }
        public System.String ExternalFulfillmentReferenceNumber { get; set; }
        public System.Int64? ShippingLabelRequestID { get; set; }
        public System.String StagingLocation { get; set; }
        public System.String LabelFormat { get; set; }
        public System.String ReturnLabelFormat { get; set; }
        public System.String ChannelReturnLabelFormat { get; set; }


        public List<StagingOrderFulfillmentsItems> Items = new List<StagingOrderFulfillmentsItems>();
        public List<String> itemsJson = new List<String>();

    }
}
