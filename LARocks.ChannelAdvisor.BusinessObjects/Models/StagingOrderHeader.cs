using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LARocks.ChannelAdvisor.BusinessObjects.Models
{
    public class StagingOrderHeader
    {
        //public System.Int32 pk { get; set; }
        public System.Int64 ID { get; set; }
        public System.Int64 ProfileID { get; set; }
        public System.Int32 SiteID { get; set; }
        public System.String SiteName { get; set; }
        public System.Int32 UserDataPresent { get; set; }
        public System.DateTime? UserDataRemovalDateUTC { get; set; }
        public System.Int64 SiteAccountID { get; set; }
        public System.String SiteOrderID { get; set; }
        public System.String SecondarySiteOrderID { get; set; }
        public System.Int64? SellerOrderID { get; set; }
        public System.Int64? CheckoutSourceID { get; set; }
        public System.String Currency { get; set; }
        public System.DateTime? CreatedDateUtc { get; set; }
        public System.DateTime? ImportDateUtc { get; set; }
        public System.DateTime? UpdatedDateUtc { get; set; }
        public System.String PublicNotes { get; set; }
        public System.String SpecialInstructions { get; set; }
        public System.Decimal TotalPrice { get; set; }
        public System.Decimal TotalTaxPrice { get; set; }
        public System.Decimal TotalShippingPrice { get; set; }
        public System.Decimal TotalShippingTaxPrice { get; set; }
        public System.Decimal TotalInsurancePrice { get; set; }
        public System.Decimal TotalGiftOptionPrice { get; set; }
        public System.Decimal TotalGiftOptionTaxPrice { get; set; }
        public System.Decimal AdditionalCostOrDiscount { get; set; }
        public System.DateTime? EstimatedShipDateUtc { get; set; }
        public System.DateTime? DeliverByDateUtc { get; set; }
        public System.String RequestedShippingCarrier { get; set; }
        public System.String RequestedShippingClass { get; set; }
        public System.String ResellerID { get; set; }
        public System.Int64 FlagID { get; set; }
        public System.String FlagDescription { get; set; }
        public System.String OrderTags { get; set; }
        public System.String DistributionCenterTypeRollup { get; set; }
        public System.String CheckoutStatus { get; set; }
        public System.String PaymentStatus { get; set; }
        public System.String ShippingStatus { get; set; }
        public System.DateTime? CheckoutDateUtc { get; set; }
        public System.DateTime? PaymentDateUtc { get; set; }
        public System.DateTime? ShippingDateUtc { get; set; }
        public System.String BuyerUserId { get; set; }
        public System.String BuyerEmailAddress { get; set; }
        public System.Boolean BuyerEmailOptIn { get; set; }
        public System.String OrderTaxType { get; set; }
        public System.String ShippingTaxType { get; set; }
        public System.String GiftOptionsTaxType { get; set; }
        public System.String PaymentMethod { get; set; }
        public System.String PaymentTransactionID { get; set; }
        public System.String PaymentPaypalAccountID { get; set; }
        public System.String PaymentCreditCardLast4 { get; set; }
        public System.String PaymentMerchantReferenceNumber { get; set; }
        public System.String ShippingTitle { get; set; }
        public System.String ShippingFirstName { get; set; }
        public System.String ShippingLastName { get; set; }
        public System.String ShippingSuffix { get; set; }
        public System.String ShippingCompanyName { get; set; }
        public System.String ShippingCompanyJobTitle { get; set; }
        public System.String ShippingDaytimePhone { get; set; }
        public System.String ShippingEveningPhone { get; set; }
        public System.String ShippingAddressLine1 { get; set; }
        public System.String ShippingAddressLine2 { get; set; }
        public System.String ShippingCity { get; set; }
        public System.String ShippingStateOrProvince { get; set; }
        public System.String ShippingStateOrProvinceName { get; set; }
        public System.String ShippingPostalCode { get; set; }
        public System.String ShippingCountry { get; set; }
        public System.String BillingTitle { get; set; }
        public System.String BillingFirstName { get; set; }
        public System.String BillingLastName { get; set; }
        public System.String BillingSuffix { get; set; }
        public System.String BillingCompanyName { get; set; }
        public System.String BillingCompanyJobTitle { get; set; }
        public System.String BillingDaytimePhone { get; set; }
        public System.String BillingEveningPhone { get; set; }
        public System.String BillingAddressLine1 { get; set; }
        public System.String BillingAddressLine2 { get; set; }
        public System.String BillingCity { get; set; }
        public System.String BillingStateOrProvince { get; set; }
        public System.String BillingStateOrProvinceName { get; set; }
        public System.String BillingPostalCode { get; set; }
        public System.String BillingCountry { get; set; }
        public System.String PromotionCode { get; set; }
        public System.Decimal PromotionAmount { get; set; }

        public List<StagingOrderItems> Items = new List<StagingOrderItems>();
        public List<StagingOrderFulfillments> Fulfillments = new List<StagingOrderFulfillments>();
    }
}
