using MicroFour.StrataFrame.Business;
using MicroFour.StrataFrame.Security;
using MicroFour.StrataFrame.UI.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace LARocks.ChannelAdvisor.BusinessObjects
{
    partial class StagingOrderHeaderBO
    {

        #region Component Implementation

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.CheckRulesOnCurrentRow += new CheckRulesOnCurrentRowEventHandler(StagingOrderHeaderBO_CheckRulesOnCurrentRow);
            this.SetDefaultValues += new SetDefaultValuesEventHandler(StagingOrderHeaderBO_SetDefaultValues);
        }

        #endregion


        #region BusinessLayer Overriden Methods & Properties

        /// <summary>
        /// The collection of required fields for the business object.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override RequiredFieldsCollection RequiredFields
        {
            get
            {
                return base.RequiredFields;
            }
            set
            {
                base.RequiredFields = value;
            }
        }

        /// <summary>
        /// Defines the constraint that defines the parent-child relationship between this business object type and another business object type.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override IBusinessParentRelationship ParentRelationship
        {
            get
            {
                return base.ParentRelationship;
            }
            set
            {
                base.ParentRelationship = value;
            }
        }

        /// <summary>
        /// Returns all of the field names in a single string in the form of [field1],[field2],...  This must be used in the place of '*' in select statements if Query Notifications are to be registered.
        /// </summary>
        protected override String AllFieldNames
        {
            get
            {
                return "[pk],[ID],[ProfileID],[SiteID],[SiteName],[UserDataPresent],[UserDataRemovalDateUTC],[SiteAccountID],[SiteOrderID],[SecondarySiteOrderID],[SellerOrderID],[CheckoutSourceID],[Currency],[CreatedDateUtc],[ImportDateUtc],[UpdatedDateUtc],[PublicNotes],[SpecialInstructions],[TotalPrice],[TotalTaxPrice],[TotalShippingPrice],[TotalShippingTaxPrice],[TotalInsurancePrice],[TotalGiftOptionPrice],[TotalGiftOptionTaxPrice],[AdditionalCostOrDiscount],[EstimatedShipDateUtc],[DeliverByDateUtc],[RequestedShippingCarrier],[RequestedShippingClass],[ResellerID],[FlagID],[FlagDescription],[OrderTags],[DistributionCenterTypeRollup],[CheckoutStatus],[PaymentStatus],[ShippingStatus],[CheckoutDateUtc],[PaymentDateUtc],[ShippingDateUtc],[BuyerUserId],[BuyerEmailAddress],[BuyerEmailOptIn],[OrderTaxType],[ShippingTaxType],[GiftOptionsTaxType],[PaymentMethod],[PaymentTransactionID],[PaymentPaypalAccountID],[PaymentCreditCardLast4],[PaymentMerchantReferenceNumber],[ShippingTitle],[ShippingFirstName],[ShippingLastName],[ShippingSuffix],[ShippingCompanyName],[ShippingCompanyJobTitle],[ShippingDaytimePhone],[ShippingEveningPhone],[ShippingAddressLine1],[ShippingAddressLine2],[ShippingCity],[ShippingStateOrProvince],[ShippingStateOrProvinceName],[ShippingPostalCode],[ShippingCountry],[BillingTitle],[BillingFirstName],[BillingLastName],[BillingSuffix],[BillingCompanyName],[BillingCompanyJobTitle],[BillingDaytimePhone],[BillingEveningPhone],[BillingAddressLine1],[BillingAddressLine2],[BillingCity],[BillingStateOrProvince],[BillingStateOrProvinceName],[BillingPostalCode],[BillingCountry],[PromotionCode],[PromotionAmount]";
            }
        }

        /// <summary>
        /// The name of the database that contains the table to which this business object is mapped.
        /// </summary>
        public override String Database
        {
            get
            {
                return "LARocks_ChannelAdvisor";
            }
        }

        private static string[] _PrimaryKeyFields = new string[] { "pk" };
        /// <summary>
        /// Gets the field or fields that comprise the primary key for the business object.
        /// </summary>
        public override string[] PrimaryKeyFields
        {
            get
            {
                return _PrimaryKeyFields;
            }
        }

        /// <summary>
        /// The name of the table in the database to which this business object is mapped.
        /// </summary>
        public override String TableName
        {
            get
            {
                return "StagingOrderHeader";
            }
        }

        /// <summary>
        /// The schema of the table in the database to which this business object is mapped.
        /// </summary>
        public override String TableSchema
        {
            get
            {
                return "dbo";
            }
        }

        /// <summary>
        /// Creates and returns an array of DataColumns that contains the schema for the table.  This is used to prevent a round trip to the server to aquire the initial schema for the internal DataTable.
        /// </summary>
        protected override DataColumn[] CreateTableSchema()
        {
            return new DataColumn[] {
new DataColumn("pk", typeof(System.Int32)),
new DataColumn("ID", typeof(System.Int64)),
new DataColumn("ProfileID", typeof(System.Int64)),
new DataColumn("SiteID", typeof(System.Int32)),
new DataColumn("SiteName", typeof(System.String)),
new DataColumn("UserDataPresent", typeof(System.Int32)),
new DataColumn("UserDataRemovalDateUTC", typeof(System.DateTime)),
new DataColumn("SiteAccountID", typeof(System.Int64)),
new DataColumn("SiteOrderID", typeof(System.String)),
new DataColumn("SecondarySiteOrderID", typeof(System.String)),
new DataColumn("SellerOrderID", typeof(System.Int64)),
new DataColumn("CheckoutSourceID", typeof(System.Int64)),
new DataColumn("Currency", typeof(System.String)),
new DataColumn("CreatedDateUtc", typeof(System.DateTime)),
new DataColumn("ImportDateUtc", typeof(System.DateTime)),
new DataColumn("UpdatedDateUtc", typeof(System.DateTime)),
new DataColumn("PublicNotes", typeof(System.String)),
new DataColumn("SpecialInstructions", typeof(System.String)),
new DataColumn("TotalPrice", typeof(System.Decimal)),
new DataColumn("TotalTaxPrice", typeof(System.Decimal)),
new DataColumn("TotalShippingPrice", typeof(System.Decimal)),
new DataColumn("TotalShippingTaxPrice", typeof(System.Decimal)),
new DataColumn("TotalInsurancePrice", typeof(System.Decimal)),
new DataColumn("TotalGiftOptionPrice", typeof(System.Decimal)),
new DataColumn("TotalGiftOptionTaxPrice", typeof(System.Decimal)),
new DataColumn("AdditionalCostOrDiscount", typeof(System.Decimal)),
new DataColumn("EstimatedShipDateUtc", typeof(System.DateTime)),
new DataColumn("DeliverByDateUtc", typeof(System.DateTime)),
new DataColumn("RequestedShippingCarrier", typeof(System.String)),
new DataColumn("RequestedShippingClass", typeof(System.String)),
new DataColumn("ResellerID", typeof(System.String)),
new DataColumn("FlagID", typeof(System.Int64)),
new DataColumn("FlagDescription", typeof(System.String)),
new DataColumn("OrderTags", typeof(System.String)),
new DataColumn("DistributionCenterTypeRollup", typeof(System.String)),
new DataColumn("CheckoutStatus", typeof(System.String)),
new DataColumn("PaymentStatus", typeof(System.String)),
new DataColumn("ShippingStatus", typeof(System.String)),
new DataColumn("CheckoutDateUtc", typeof(System.DateTime)),
new DataColumn("PaymentDateUtc", typeof(System.DateTime)),
new DataColumn("ShippingDateUtc", typeof(System.DateTime)),
new DataColumn("BuyerUserId", typeof(System.String)),
new DataColumn("BuyerEmailAddress", typeof(System.String)),
new DataColumn("BuyerEmailOptIn", typeof(System.Boolean)),
new DataColumn("OrderTaxType", typeof(System.String)),
new DataColumn("ShippingTaxType", typeof(System.String)),
new DataColumn("GiftOptionsTaxType", typeof(System.String)),
new DataColumn("PaymentMethod", typeof(System.String)),
new DataColumn("PaymentTransactionID", typeof(System.String)),
new DataColumn("PaymentPaypalAccountID", typeof(System.String)),
new DataColumn("PaymentCreditCardLast4", typeof(System.String)),
new DataColumn("PaymentMerchantReferenceNumber", typeof(System.String)),
new DataColumn("ShippingTitle", typeof(System.String)),
new DataColumn("ShippingFirstName", typeof(System.String)),
new DataColumn("ShippingLastName", typeof(System.String)),
new DataColumn("ShippingSuffix", typeof(System.String)),
new DataColumn("ShippingCompanyName", typeof(System.String)),
new DataColumn("ShippingCompanyJobTitle", typeof(System.String)),
new DataColumn("ShippingDaytimePhone", typeof(System.String)),
new DataColumn("ShippingEveningPhone", typeof(System.String)),
new DataColumn("ShippingAddressLine1", typeof(System.String)),
new DataColumn("ShippingAddressLine2", typeof(System.String)),
new DataColumn("ShippingCity", typeof(System.String)),
new DataColumn("ShippingStateOrProvince", typeof(System.String)),
new DataColumn("ShippingStateOrProvinceName", typeof(System.String)),
new DataColumn("ShippingPostalCode", typeof(System.String)),
new DataColumn("ShippingCountry", typeof(System.String)),
new DataColumn("BillingTitle", typeof(System.String)),
new DataColumn("BillingFirstName", typeof(System.String)),
new DataColumn("BillingLastName", typeof(System.String)),
new DataColumn("BillingSuffix", typeof(System.String)),
new DataColumn("BillingCompanyName", typeof(System.String)),
new DataColumn("BillingCompanyJobTitle", typeof(System.String)),
new DataColumn("BillingDaytimePhone", typeof(System.String)),
new DataColumn("BillingEveningPhone", typeof(System.String)),
new DataColumn("BillingAddressLine1", typeof(System.String)),
new DataColumn("BillingAddressLine2", typeof(System.String)),
new DataColumn("BillingCity", typeof(System.String)),
new DataColumn("BillingStateOrProvince", typeof(System.String)),
new DataColumn("BillingStateOrProvinceName", typeof(System.String)),
new DataColumn("BillingPostalCode", typeof(System.String)),
new DataColumn("BillingCountry", typeof(System.String)),
new DataColumn("PromotionCode", typeof(System.String)),
new DataColumn("PromotionAmount", typeof(System.Decimal))};
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected void AddBrokenRule(StagingOrderHeaderBOFieldNames Field, string ErrorMessage)
        {
            base.AddBrokenRule(Field, ErrorMessage);
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected new void AddBrokenRule(string FieldName, string ErrorMessage)
        {
            base.AddBrokenRule(FieldName, ErrorMessage);
        }

        /// <summary>
        /// Adds a broken rules to the business object's collection using the given message key to pull the error message from the localization database
        /// </summary>
        protected void AddBrokenRuleByKey(StagingOrderHeaderBOFieldNames Field, string ErrorMessageKey)
        {
            base.AddBrokenRuleByKey(Field, ErrorMessageKey);
        }

        /// <summary>
        /// Adds a broken rules to the business object's collection using the given message key to pull the error message from the localization database
        /// </summary>
        protected new void AddBrokenRuleByKey(string FieldName, string ErrorMessageKey)
        {
            base.AddBrokenRuleByKey(FieldName, ErrorMessageKey);
        }

        /// <summary>
        /// Gets a collection of the names for all fields that belong to this business object and map to the database.
        /// </summary>
        public override List<string> AllFieldsList
        {
            get
            {
                return _AllFieldsList;
            }
        }

        /// <summary>
        /// Gets a dictionary of the DbTypes for all fields that belong to this business object and map to the database.
        /// </summary>
        public override Dictionary<string, DbType> FieldDbTypes
        {
            get
            {
                return _FieldDbTypes;
            }
        }

        /// <summary>
        /// Gets a dictionary of all fields within this business object that map to the FieldNames enumeration for this business object.
        /// </summary>
        public override BusinessLayerFieldEnumDictionary FieldEnums
        {
            get
            {
                return _FieldEnums;
            }
        }

        /// <summary>
        /// Gets a dictionary of all of the lengths for all fields within this business object that map to a field in the database.
        /// </summary>
        public override Dictionary<string, int> FieldLengths
        {
            get
            {
                return _FieldLengths;
            }
        }

        /// <summary>
        /// Gets a dictionary of the native DbType (SqlDbType, OracleType, OleDbType, etc.) for all fields within this buisness object that map to a field in the database.
        /// </summary>
        public override Dictionary<string, int> FieldNativeDbTypes
        {
            get
            {
                return _FieldNativeDbTypes;
            }
        }

        /// <summary>
        /// Gets a dictionary of the security permission keys for each field in the business object.
        /// </summary>
        public override Dictionary<string, string> FieldPermissionKeys
        {
            get
            {
                return _FieldPermissionKeys;
            }
        }

        #endregion

        #region Field Properties

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int32 pk
        {
            get
            {
                return (System.Int32)this.CurrentRow["pk"];
            }
            set
            {
                this.CurrentRow["pk"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 ID
        {
            get
            {
                return (System.Int64)this.CurrentRow["ID"];
            }
            set
            {
                this.CurrentRow["ID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 ProfileID
        {
            get
            {
                return (System.Int64)this.CurrentRow["ProfileID"];
            }
            set
            {
                this.CurrentRow["ProfileID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int32 SiteID
        {
            get
            {
                return (System.Int32)this.CurrentRow["SiteID"];
            }
            set
            {
                this.CurrentRow["SiteID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SiteName
        {
            get
            {
                return (System.String)this.CurrentRow["SiteName"];
            }
            set
            {
                this.CurrentRow["SiteName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int32 UserDataPresent
        {
            get
            {
                return (System.Int32)this.CurrentRow["UserDataPresent"];
            }
            set
            {
                this.CurrentRow["UserDataPresent"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime UserDataRemovalDateUTC
        {
            get
            {
                return (System.DateTime)this.CurrentRow["UserDataRemovalDateUTC"];
            }
            set
            {
                this.CurrentRow["UserDataRemovalDateUTC"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 SiteAccountID
        {
            get
            {
                return (System.Int64)this.CurrentRow["SiteAccountID"];
            }
            set
            {
                this.CurrentRow["SiteAccountID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SiteOrderID
        {
            get
            {
                return (System.String)this.CurrentRow["SiteOrderID"];
            }
            set
            {
                this.CurrentRow["SiteOrderID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SecondarySiteOrderID
        {
            get
            {
                return (System.String)this.CurrentRow["SecondarySiteOrderID"];
            }
            set
            {
                this.CurrentRow["SecondarySiteOrderID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 SellerOrderID
        {
            get
            {
                return (System.Int64)this.CurrentRow["SellerOrderID"];
            }
            set
            {
                this.CurrentRow["SellerOrderID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 CheckoutSourceID
        {
            get
            {
                return (System.Int64)this.CurrentRow["CheckoutSourceID"];
            }
            set
            {
                this.CurrentRow["CheckoutSourceID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String Currency
        {
            get
            {
                return (System.String)this.CurrentRow["Currency"];
            }
            set
            {
                this.CurrentRow["Currency"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime CreatedDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["CreatedDateUtc"];
            }
            set
            {
                this.CurrentRow["CreatedDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime? ImportDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["ImportDateUtc"];
            }
            set
            {
                this.CurrentRow["ImportDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime UpdatedDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["UpdatedDateUtc"];
            }
            set
            {
                this.CurrentRow["UpdatedDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PublicNotes
        {
            get
            {
                return (System.String)this.CurrentRow["PublicNotes"];
            }
            set
            {
                this.CurrentRow["PublicNotes"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SpecialInstructions
        {
            get
            {
                return (System.String)this.CurrentRow["SpecialInstructions"];
            }
            set
            {
                this.CurrentRow["SpecialInstructions"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalPrice"];
            }
            set
            {
                this.CurrentRow["TotalPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalTaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalTaxPrice"];
            }
            set
            {
                this.CurrentRow["TotalTaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalShippingPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalShippingPrice"];
            }
            set
            {
                this.CurrentRow["TotalShippingPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalShippingTaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalShippingTaxPrice"];
            }
            set
            {
                this.CurrentRow["TotalShippingTaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalInsurancePrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalInsurancePrice"];
            }
            set
            {
                this.CurrentRow["TotalInsurancePrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalGiftOptionPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalGiftOptionPrice"];
            }
            set
            {
                this.CurrentRow["TotalGiftOptionPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TotalGiftOptionTaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TotalGiftOptionTaxPrice"];
            }
            set
            {
                this.CurrentRow["TotalGiftOptionTaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal AdditionalCostOrDiscount
        {
            get
            {
                return (System.Decimal)this.CurrentRow["AdditionalCostOrDiscount"];
            }
            set
            {
                this.CurrentRow["AdditionalCostOrDiscount"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime EstimatedShipDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["EstimatedShipDateUtc"];
            }
            set
            {
                this.CurrentRow["EstimatedShipDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime DeliverByDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["DeliverByDateUtc"];
            }
            set
            {
                this.CurrentRow["DeliverByDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String RequestedShippingCarrier
        {
            get
            {
                return (System.String)this.CurrentRow["RequestedShippingCarrier"];
            }
            set
            {
                this.CurrentRow["RequestedShippingCarrier"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String RequestedShippingClass
        {
            get
            {
                return (System.String)this.CurrentRow["RequestedShippingClass"];
            }
            set
            {
                this.CurrentRow["RequestedShippingClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ResellerID
        {
            get
            {
                return (System.String)this.CurrentRow["ResellerID"];
            }
            set
            {
                this.CurrentRow["ResellerID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 FlagID
        {
            get
            {
                return (System.Int64)this.CurrentRow["FlagID"];
            }
            set
            {
                this.CurrentRow["FlagID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String FlagDescription
        {
            get
            {
                return (System.String)this.CurrentRow["FlagDescription"];
            }
            set
            {
                this.CurrentRow["FlagDescription"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String OrderTags
        {
            get
            {
                return (System.String)this.CurrentRow["OrderTags"];
            }
            set
            {
                this.CurrentRow["OrderTags"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String DistributionCenterTypeRollup
        {
            get
            {
                return (System.String)this.CurrentRow["DistributionCenterTypeRollup"];
            }
            set
            {
                this.CurrentRow["DistributionCenterTypeRollup"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String CheckoutStatus
        {
            get
            {
                return (System.String)this.CurrentRow["CheckoutStatus"];
            }
            set
            {
                this.CurrentRow["CheckoutStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentStatus
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentStatus"];
            }
            set
            {
                this.CurrentRow["PaymentStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingStatus
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingStatus"];
            }
            set
            {
                this.CurrentRow["ShippingStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime CheckoutDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["CheckoutDateUtc"];
            }
            set
            {
                this.CurrentRow["CheckoutDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime PaymentDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["PaymentDateUtc"];
            }
            set
            {
                this.CurrentRow["PaymentDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime ShippingDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["ShippingDateUtc"];
            }
            set
            {
                this.CurrentRow["ShippingDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BuyerUserId
        {
            get
            {
                return (System.String)this.CurrentRow["BuyerUserId"];
            }
            set
            {
                this.CurrentRow["BuyerUserId"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BuyerEmailAddress
        {
            get
            {
                return (System.String)this.CurrentRow["BuyerEmailAddress"];
            }
            set
            {
                this.CurrentRow["BuyerEmailAddress"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean BuyerEmailOptIn
        {
            get
            {
                return (System.Boolean)this.CurrentRow["BuyerEmailOptIn"];
            }
            set
            {
                this.CurrentRow["BuyerEmailOptIn"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String OrderTaxType
        {
            get
            {
                return (System.String)this.CurrentRow["OrderTaxType"];
            }
            set
            {
                this.CurrentRow["OrderTaxType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingTaxType
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingTaxType"];
            }
            set
            {
                this.CurrentRow["ShippingTaxType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String GiftOptionsTaxType
        {
            get
            {
                return (System.String)this.CurrentRow["GiftOptionsTaxType"];
            }
            set
            {
                this.CurrentRow["GiftOptionsTaxType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentMethod
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentMethod"];
            }
            set
            {
                this.CurrentRow["PaymentMethod"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentTransactionID
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentTransactionID"];
            }
            set
            {
                this.CurrentRow["PaymentTransactionID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentPaypalAccountID
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentPaypalAccountID"];
            }
            set
            {
                this.CurrentRow["PaymentPaypalAccountID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentCreditCardLast4
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentCreditCardLast4"];
            }
            set
            {
                this.CurrentRow["PaymentCreditCardLast4"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PaymentMerchantReferenceNumber
        {
            get
            {
                return (System.String)this.CurrentRow["PaymentMerchantReferenceNumber"];
            }
            set
            {
                this.CurrentRow["PaymentMerchantReferenceNumber"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingTitle
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingTitle"];
            }
            set
            {
                this.CurrentRow["ShippingTitle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingFirstName
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingFirstName"];
            }
            set
            {
                this.CurrentRow["ShippingFirstName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingLastName
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingLastName"];
            }
            set
            {
                this.CurrentRow["ShippingLastName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingSuffix
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingSuffix"];
            }
            set
            {
                this.CurrentRow["ShippingSuffix"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingCompanyName
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingCompanyName"];
            }
            set
            {
                this.CurrentRow["ShippingCompanyName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingCompanyJobTitle
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingCompanyJobTitle"];
            }
            set
            {
                this.CurrentRow["ShippingCompanyJobTitle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingDaytimePhone
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingDaytimePhone"];
            }
            set
            {
                this.CurrentRow["ShippingDaytimePhone"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingEveningPhone
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingEveningPhone"];
            }
            set
            {
                this.CurrentRow["ShippingEveningPhone"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingAddressLine1
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingAddressLine1"];
            }
            set
            {
                this.CurrentRow["ShippingAddressLine1"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingAddressLine2
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingAddressLine2"];
            }
            set
            {
                this.CurrentRow["ShippingAddressLine2"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingCity
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingCity"];
            }
            set
            {
                this.CurrentRow["ShippingCity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingStateOrProvince
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingStateOrProvince"];
            }
            set
            {
                this.CurrentRow["ShippingStateOrProvince"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingStateOrProvinceName
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingStateOrProvinceName"];
            }
            set
            {
                this.CurrentRow["ShippingStateOrProvinceName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingPostalCode
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingPostalCode"];
            }
            set
            {
                this.CurrentRow["ShippingPostalCode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingCountry
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingCountry"];
            }
            set
            {
                this.CurrentRow["ShippingCountry"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingTitle
        {
            get
            {
                return (System.String)this.CurrentRow["BillingTitle"];
            }
            set
            {
                this.CurrentRow["BillingTitle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingFirstName
        {
            get
            {
                return (System.String)this.CurrentRow["BillingFirstName"];
            }
            set
            {
                this.CurrentRow["BillingFirstName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingLastName
        {
            get
            {
                return (System.String)this.CurrentRow["BillingLastName"];
            }
            set
            {
                this.CurrentRow["BillingLastName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingSuffix
        {
            get
            {
                return (System.String)this.CurrentRow["BillingSuffix"];
            }
            set
            {
                this.CurrentRow["BillingSuffix"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingCompanyName
        {
            get
            {
                return (System.String)this.CurrentRow["BillingCompanyName"];
            }
            set
            {
                this.CurrentRow["BillingCompanyName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingCompanyJobTitle
        {
            get
            {
                return (System.String)this.CurrentRow["BillingCompanyJobTitle"];
            }
            set
            {
                this.CurrentRow["BillingCompanyJobTitle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingDaytimePhone
        {
            get
            {
                return (System.String)this.CurrentRow["BillingDaytimePhone"];
            }
            set
            {
                this.CurrentRow["BillingDaytimePhone"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingEveningPhone
        {
            get
            {
                return (System.String)this.CurrentRow["BillingEveningPhone"];
            }
            set
            {
                this.CurrentRow["BillingEveningPhone"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingAddressLine1
        {
            get
            {
                return (System.String)this.CurrentRow["BillingAddressLine1"];
            }
            set
            {
                this.CurrentRow["BillingAddressLine1"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingAddressLine2
        {
            get
            {
                return (System.String)this.CurrentRow["BillingAddressLine2"];
            }
            set
            {
                this.CurrentRow["BillingAddressLine2"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingCity
        {
            get
            {
                return (System.String)this.CurrentRow["BillingCity"];
            }
            set
            {
                this.CurrentRow["BillingCity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingStateOrProvince
        {
            get
            {
                return (System.String)this.CurrentRow["BillingStateOrProvince"];
            }
            set
            {
                this.CurrentRow["BillingStateOrProvince"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingStateOrProvinceName
        {
            get
            {
                return (System.String)this.CurrentRow["BillingStateOrProvinceName"];
            }
            set
            {
                this.CurrentRow["BillingStateOrProvinceName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingPostalCode
        {
            get
            {
                return (System.String)this.CurrentRow["BillingPostalCode"];
            }
            set
            {
                this.CurrentRow["BillingPostalCode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String BillingCountry
        {
            get
            {
                return (System.String)this.CurrentRow["BillingCountry"];
            }
            set
            {
                this.CurrentRow["BillingCountry"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String PromotionCode
        {
            get
            {
                return (System.String)this.CurrentRow["PromotionCode"];
            }
            set
            {
                this.CurrentRow["PromotionCode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal PromotionAmount
        {
            get
            {
                return (System.Decimal)this.CurrentRow["PromotionAmount"];
            }
            set
            {
                this.CurrentRow["PromotionAmount"] = value;
            }
        }

        #endregion

        #region Field Property Events 

        #endregion

        #region Nested Types & Field Security

        /// <summary>
        /// Contains all of the field names that belong to the business object.
        /// </summary>
        public enum StagingOrderHeaderBOFieldNames
        {
            pk,
            ID,
            ProfileID,
            SiteID,
            SiteName,
            UserDataPresent,
            UserDataRemovalDateUTC,
            SiteAccountID,
            SiteOrderID,
            SecondarySiteOrderID,
            SellerOrderID,
            CheckoutSourceID,
            Currency,
            CreatedDateUtc,
            ImportDateUtc,
            UpdatedDateUtc,
            PublicNotes,
            SpecialInstructions,
            TotalPrice,
            TotalTaxPrice,
            TotalShippingPrice,
            TotalShippingTaxPrice,
            TotalInsurancePrice,
            TotalGiftOptionPrice,
            TotalGiftOptionTaxPrice,
            AdditionalCostOrDiscount,
            EstimatedShipDateUtc,
            DeliverByDateUtc,
            RequestedShippingCarrier,
            RequestedShippingClass,
            ResellerID,
            FlagID,
            FlagDescription,
            OrderTags,
            DistributionCenterTypeRollup,
            CheckoutStatus,
            PaymentStatus,
            ShippingStatus,
            CheckoutDateUtc,
            PaymentDateUtc,
            ShippingDateUtc,
            BuyerUserId,
            BuyerEmailAddress,
            BuyerEmailOptIn,
            OrderTaxType,
            ShippingTaxType,
            GiftOptionsTaxType,
            PaymentMethod,
            PaymentTransactionID,
            PaymentPaypalAccountID,
            PaymentCreditCardLast4,
            PaymentMerchantReferenceNumber,
            ShippingTitle,
            ShippingFirstName,
            ShippingLastName,
            ShippingSuffix,
            ShippingCompanyName,
            ShippingCompanyJobTitle,
            ShippingDaytimePhone,
            ShippingEveningPhone,
            ShippingAddressLine1,
            ShippingAddressLine2,
            ShippingCity,
            ShippingStateOrProvince,
            ShippingStateOrProvinceName,
            ShippingPostalCode,
            ShippingCountry,
            BillingTitle,
            BillingFirstName,
            BillingLastName,
            BillingSuffix,
            BillingCompanyName,
            BillingCompanyJobTitle,
            BillingDaytimePhone,
            BillingEveningPhone,
            BillingAddressLine1,
            BillingAddressLine2,
            BillingCity,
            BillingStateOrProvince,
            BillingStateOrProvinceName,
            BillingPostalCode,
            BillingCountry,
            PromotionCode,
            PromotionAmount,
            CUSTOM_FIELD
        }

        /// <summary>
        /// Gets the System.Type of the enumeration that contains the field names for the business object.
        /// </summary>
        public override System.Type GetFieldEnumType()
        {
            return typeof(StagingOrderHeaderBOFieldNames);
        }

        /// <summary>
        /// Creates a new CheckFieldSecurityEventArgs object that can be used with this business object type.
        /// </summary>
        protected override CheckFieldSecurityEventArgsBase CreateNewFieldSecurityEventArgs(System.Enum Field, string CustomField, string PermissionKey, PermissionInfo Perm)
        {
            return new CheckFieldSecurityEventArgs<StagingOrderHeaderBOFieldNames>(Field, CustomField, PermissionKey, Perm);
        }

        /// <summary>
        /// Describes a method that will handle the CheckFieldScurity event.
        /// </summary>
        public delegate void CheckFieldSecurityEventHandler(object sender, CheckFieldSecurityEventArgs<StagingOrderHeaderBOFieldNames> e);

        /// <summary>
        /// Occurs when the business objects needs to check the security on a field.
        /// </summary>
        public event CheckFieldSecurityEventHandler CheckFieldSecurity;

        /// <summary>
        /// Raises the CheckFieldSecurity event.
        /// </summary>
        protected override void OnCheckFieldSecurity(CheckFieldSecurityEventArgsBase e)
        {
            if (this.CheckFieldSecurity != null)
            {
                this.CheckFieldSecurity(this, (CheckFieldSecurityEventArgs<StagingOrderHeaderBOFieldNames>)e);
            }
        }

        #endregion

        #region Item Property Implementation


        private static List<string> _AllFieldsList;
        private static Dictionary<string, DbType> _FieldDbTypes;
        private static BusinessLayerFieldEnumDictionary _FieldEnums;
        private static Dictionary<string, int> _FieldLengths;
        private static Dictionary<string, int> _FieldNativeDbTypes;
        private static Dictionary<string, string> _FieldPermissionKeys;

        /// <summary>
        /// Initializes the static members of the StagingOrderHeaderBO class.
        /// </summary>
        static StagingOrderHeaderBO()
        {
            //-- Create the new shared dictionary and populate it with an 
            //   instance of each property descriptor
            _PropertyDescriptors = new PropertyDescriptorDictionary(89);
            _PropertyDescriptors.Add("pk", new FieldDescriptor(StagingOrderHeaderBOFieldNames.pk, typeof(System.Int32)));
            _PropertyDescriptors.Add("ID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ID, typeof(System.Int64)));
            _PropertyDescriptors.Add("ProfileID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ProfileID, typeof(System.Int64)));
            _PropertyDescriptors.Add("SiteID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SiteID, typeof(System.Int32)));
            _PropertyDescriptors.Add("SiteName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SiteName, typeof(System.String)));
            _PropertyDescriptors.Add("UserDataPresent", new FieldDescriptor(StagingOrderHeaderBOFieldNames.UserDataPresent, typeof(System.Int32)));
            _PropertyDescriptors.Add("UserDataRemovalDateUTC", new FieldDescriptor(StagingOrderHeaderBOFieldNames.UserDataRemovalDateUTC, typeof(System.DateTime)));
            _PropertyDescriptors.Add("SiteAccountID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SiteAccountID, typeof(System.Int64)));
            _PropertyDescriptors.Add("SiteOrderID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SiteOrderID, typeof(System.String)));
            _PropertyDescriptors.Add("SecondarySiteOrderID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SecondarySiteOrderID, typeof(System.String)));
            _PropertyDescriptors.Add("SellerOrderID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SellerOrderID, typeof(System.Int64)));
            _PropertyDescriptors.Add("CheckoutSourceID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.CheckoutSourceID, typeof(System.Int64)));
            _PropertyDescriptors.Add("Currency", new FieldDescriptor(StagingOrderHeaderBOFieldNames.Currency, typeof(System.String)));
            _PropertyDescriptors.Add("CreatedDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.CreatedDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("ImportDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ImportDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("UpdatedDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.UpdatedDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("PublicNotes", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PublicNotes, typeof(System.String)));
            _PropertyDescriptors.Add("SpecialInstructions", new FieldDescriptor(StagingOrderHeaderBOFieldNames.SpecialInstructions, typeof(System.String)));
            _PropertyDescriptors.Add("TotalPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalTaxPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalTaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalShippingPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalShippingPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalShippingTaxPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalShippingTaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalInsurancePrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalInsurancePrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalGiftOptionPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalGiftOptionPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TotalGiftOptionTaxPrice", new FieldDescriptor(StagingOrderHeaderBOFieldNames.TotalGiftOptionTaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("AdditionalCostOrDiscount", new FieldDescriptor(StagingOrderHeaderBOFieldNames.AdditionalCostOrDiscount, typeof(System.Decimal)));
            _PropertyDescriptors.Add("EstimatedShipDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.EstimatedShipDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("DeliverByDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.DeliverByDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("RequestedShippingCarrier", new FieldDescriptor(StagingOrderHeaderBOFieldNames.RequestedShippingCarrier, typeof(System.String)));
            _PropertyDescriptors.Add("RequestedShippingClass", new FieldDescriptor(StagingOrderHeaderBOFieldNames.RequestedShippingClass, typeof(System.String)));
            _PropertyDescriptors.Add("ResellerID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ResellerID, typeof(System.String)));
            _PropertyDescriptors.Add("FlagID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.FlagID, typeof(System.Int64)));
            _PropertyDescriptors.Add("FlagDescription", new FieldDescriptor(StagingOrderHeaderBOFieldNames.FlagDescription, typeof(System.String)));
            _PropertyDescriptors.Add("OrderTags", new FieldDescriptor(StagingOrderHeaderBOFieldNames.OrderTags, typeof(System.String)));
            _PropertyDescriptors.Add("DistributionCenterTypeRollup", new FieldDescriptor(StagingOrderHeaderBOFieldNames.DistributionCenterTypeRollup, typeof(System.String)));
            _PropertyDescriptors.Add("CheckoutStatus", new FieldDescriptor(StagingOrderHeaderBOFieldNames.CheckoutStatus, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentStatus", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentStatus, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingStatus", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingStatus, typeof(System.String)));
            _PropertyDescriptors.Add("CheckoutDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.CheckoutDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("PaymentDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("ShippingDateUtc", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("BuyerUserId", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BuyerUserId, typeof(System.String)));
            _PropertyDescriptors.Add("BuyerEmailAddress", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BuyerEmailAddress, typeof(System.String)));
            _PropertyDescriptors.Add("BuyerEmailOptIn", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BuyerEmailOptIn, typeof(System.Boolean)));
            _PropertyDescriptors.Add("OrderTaxType", new FieldDescriptor(StagingOrderHeaderBOFieldNames.OrderTaxType, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingTaxType", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingTaxType, typeof(System.String)));
            _PropertyDescriptors.Add("GiftOptionsTaxType", new FieldDescriptor(StagingOrderHeaderBOFieldNames.GiftOptionsTaxType, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentMethod", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentMethod, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentTransactionID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentTransactionID, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentPaypalAccountID", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentPaypalAccountID, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentCreditCardLast4", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentCreditCardLast4, typeof(System.String)));
            _PropertyDescriptors.Add("PaymentMerchantReferenceNumber", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PaymentMerchantReferenceNumber, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingTitle", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingTitle, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingFirstName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingFirstName, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingLastName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingLastName, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingSuffix", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingSuffix, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCompanyName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingCompanyName, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCompanyJobTitle", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingCompanyJobTitle, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingDaytimePhone", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingDaytimePhone, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingEveningPhone", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingEveningPhone, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingAddressLine1", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingAddressLine1, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingAddressLine2", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingAddressLine2, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCity", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingCity, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingStateOrProvince", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingStateOrProvince, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingStateOrProvinceName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingStateOrProvinceName, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingPostalCode", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingPostalCode, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCountry", new FieldDescriptor(StagingOrderHeaderBOFieldNames.ShippingCountry, typeof(System.String)));
            _PropertyDescriptors.Add("BillingTitle", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingTitle, typeof(System.String)));
            _PropertyDescriptors.Add("BillingFirstName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingFirstName, typeof(System.String)));
            _PropertyDescriptors.Add("BillingLastName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingLastName, typeof(System.String)));
            _PropertyDescriptors.Add("BillingSuffix", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingSuffix, typeof(System.String)));
            _PropertyDescriptors.Add("BillingCompanyName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingCompanyName, typeof(System.String)));
            _PropertyDescriptors.Add("BillingCompanyJobTitle", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingCompanyJobTitle, typeof(System.String)));
            _PropertyDescriptors.Add("BillingDaytimePhone", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingDaytimePhone, typeof(System.String)));
            _PropertyDescriptors.Add("BillingEveningPhone", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingEveningPhone, typeof(System.String)));
            _PropertyDescriptors.Add("BillingAddressLine1", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingAddressLine1, typeof(System.String)));
            _PropertyDescriptors.Add("BillingAddressLine2", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingAddressLine2, typeof(System.String)));
            _PropertyDescriptors.Add("BillingCity", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingCity, typeof(System.String)));
            _PropertyDescriptors.Add("BillingStateOrProvince", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingStateOrProvince, typeof(System.String)));
            _PropertyDescriptors.Add("BillingStateOrProvinceName", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingStateOrProvinceName, typeof(System.String)));
            _PropertyDescriptors.Add("BillingPostalCode", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingPostalCode, typeof(System.String)));
            _PropertyDescriptors.Add("BillingCountry", new FieldDescriptor(StagingOrderHeaderBOFieldNames.BillingCountry, typeof(System.String)));
            _PropertyDescriptors.Add("PromotionCode", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PromotionCode, typeof(System.String)));
            _PropertyDescriptors.Add("PromotionAmount", new FieldDescriptor(StagingOrderHeaderBOFieldNames.PromotionAmount, typeof(System.Decimal)));

            _AllFieldsList = new List<string>(84);
            _AllFieldsList.Add("pk");
            _AllFieldsList.Add("ID");
            _AllFieldsList.Add("ProfileID");
            _AllFieldsList.Add("SiteID");
            _AllFieldsList.Add("SiteName");
            _AllFieldsList.Add("UserDataPresent");
            _AllFieldsList.Add("UserDataRemovalDateUTC");
            _AllFieldsList.Add("SiteAccountID");
            _AllFieldsList.Add("SiteOrderID");
            _AllFieldsList.Add("SecondarySiteOrderID");
            _AllFieldsList.Add("SellerOrderID");
            _AllFieldsList.Add("CheckoutSourceID");
            _AllFieldsList.Add("Currency");
            _AllFieldsList.Add("CreatedDateUtc");
            _AllFieldsList.Add("ImportDateUtc");
            _AllFieldsList.Add("UpdatedDateUtc");
            _AllFieldsList.Add("PublicNotes");
            _AllFieldsList.Add("SpecialInstructions");
            _AllFieldsList.Add("TotalPrice");
            _AllFieldsList.Add("TotalTaxPrice");
            _AllFieldsList.Add("TotalShippingPrice");
            _AllFieldsList.Add("TotalShippingTaxPrice");
            _AllFieldsList.Add("TotalInsurancePrice");
            _AllFieldsList.Add("TotalGiftOptionPrice");
            _AllFieldsList.Add("TotalGiftOptionTaxPrice");
            _AllFieldsList.Add("AdditionalCostOrDiscount");
            _AllFieldsList.Add("EstimatedShipDateUtc");
            _AllFieldsList.Add("DeliverByDateUtc");
            _AllFieldsList.Add("RequestedShippingCarrier");
            _AllFieldsList.Add("RequestedShippingClass");
            _AllFieldsList.Add("ResellerID");
            _AllFieldsList.Add("FlagID");
            _AllFieldsList.Add("FlagDescription");
            _AllFieldsList.Add("OrderTags");
            _AllFieldsList.Add("DistributionCenterTypeRollup");
            _AllFieldsList.Add("CheckoutStatus");
            _AllFieldsList.Add("PaymentStatus");
            _AllFieldsList.Add("ShippingStatus");
            _AllFieldsList.Add("CheckoutDateUtc");
            _AllFieldsList.Add("PaymentDateUtc");
            _AllFieldsList.Add("ShippingDateUtc");
            _AllFieldsList.Add("BuyerUserId");
            _AllFieldsList.Add("BuyerEmailAddress");
            _AllFieldsList.Add("BuyerEmailOptIn");
            _AllFieldsList.Add("OrderTaxType");
            _AllFieldsList.Add("ShippingTaxType");
            _AllFieldsList.Add("GiftOptionsTaxType");
            _AllFieldsList.Add("PaymentMethod");
            _AllFieldsList.Add("PaymentTransactionID");
            _AllFieldsList.Add("PaymentPaypalAccountID");
            _AllFieldsList.Add("PaymentCreditCardLast4");
            _AllFieldsList.Add("PaymentMerchantReferenceNumber");
            _AllFieldsList.Add("ShippingTitle");
            _AllFieldsList.Add("ShippingFirstName");
            _AllFieldsList.Add("ShippingLastName");
            _AllFieldsList.Add("ShippingSuffix");
            _AllFieldsList.Add("ShippingCompanyName");
            _AllFieldsList.Add("ShippingCompanyJobTitle");
            _AllFieldsList.Add("ShippingDaytimePhone");
            _AllFieldsList.Add("ShippingEveningPhone");
            _AllFieldsList.Add("ShippingAddressLine1");
            _AllFieldsList.Add("ShippingAddressLine2");
            _AllFieldsList.Add("ShippingCity");
            _AllFieldsList.Add("ShippingStateOrProvince");
            _AllFieldsList.Add("ShippingStateOrProvinceName");
            _AllFieldsList.Add("ShippingPostalCode");
            _AllFieldsList.Add("ShippingCountry");
            _AllFieldsList.Add("BillingTitle");
            _AllFieldsList.Add("BillingFirstName");
            _AllFieldsList.Add("BillingLastName");
            _AllFieldsList.Add("BillingSuffix");
            _AllFieldsList.Add("BillingCompanyName");
            _AllFieldsList.Add("BillingCompanyJobTitle");
            _AllFieldsList.Add("BillingDaytimePhone");
            _AllFieldsList.Add("BillingEveningPhone");
            _AllFieldsList.Add("BillingAddressLine1");
            _AllFieldsList.Add("BillingAddressLine2");
            _AllFieldsList.Add("BillingCity");
            _AllFieldsList.Add("BillingStateOrProvince");
            _AllFieldsList.Add("BillingStateOrProvinceName");
            _AllFieldsList.Add("BillingPostalCode");
            _AllFieldsList.Add("BillingCountry");
            _AllFieldsList.Add("PromotionCode");
            _AllFieldsList.Add("PromotionAmount");

            _FieldDbTypes = new Dictionary<string, DbType>(84);
            _FieldDbTypes.Add("pk", DbType.Int32);
            _FieldDbTypes.Add("ID", DbType.Int64);
            _FieldDbTypes.Add("ProfileID", DbType.Int64);
            _FieldDbTypes.Add("SiteID", DbType.Int32);
            _FieldDbTypes.Add("SiteName", DbType.AnsiString);
            _FieldDbTypes.Add("UserDataPresent", DbType.Int32);
            _FieldDbTypes.Add("UserDataRemovalDateUTC", DbType.DateTime);
            _FieldDbTypes.Add("SiteAccountID", DbType.Int64);
            _FieldDbTypes.Add("SiteOrderID", DbType.AnsiString);
            _FieldDbTypes.Add("SecondarySiteOrderID", DbType.AnsiString);
            _FieldDbTypes.Add("SellerOrderID", DbType.Int64);
            _FieldDbTypes.Add("CheckoutSourceID", DbType.Int64);
            _FieldDbTypes.Add("Currency", DbType.AnsiString);
            _FieldDbTypes.Add("CreatedDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("ImportDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("UpdatedDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("PublicNotes", DbType.AnsiString);
            _FieldDbTypes.Add("SpecialInstructions", DbType.AnsiString);
            _FieldDbTypes.Add("TotalPrice", DbType.Currency);
            _FieldDbTypes.Add("TotalTaxPrice", DbType.Currency);
            _FieldDbTypes.Add("TotalShippingPrice", DbType.Currency);
            _FieldDbTypes.Add("TotalShippingTaxPrice", DbType.Currency);
            _FieldDbTypes.Add("TotalInsurancePrice", DbType.Currency);
            _FieldDbTypes.Add("TotalGiftOptionPrice", DbType.Currency);
            _FieldDbTypes.Add("TotalGiftOptionTaxPrice", DbType.Currency);
            _FieldDbTypes.Add("AdditionalCostOrDiscount", DbType.Currency);
            _FieldDbTypes.Add("EstimatedShipDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("DeliverByDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("RequestedShippingCarrier", DbType.AnsiString);
            _FieldDbTypes.Add("RequestedShippingClass", DbType.AnsiString);
            _FieldDbTypes.Add("ResellerID", DbType.AnsiString);
            _FieldDbTypes.Add("FlagID", DbType.Int64);
            _FieldDbTypes.Add("FlagDescription", DbType.AnsiString);
            _FieldDbTypes.Add("OrderTags", DbType.AnsiString);
            _FieldDbTypes.Add("DistributionCenterTypeRollup", DbType.AnsiString);
            _FieldDbTypes.Add("CheckoutStatus", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentStatus", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingStatus", DbType.AnsiString);
            _FieldDbTypes.Add("CheckoutDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("PaymentDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("ShippingDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("BuyerUserId", DbType.AnsiString);
            _FieldDbTypes.Add("BuyerEmailAddress", DbType.AnsiString);
            _FieldDbTypes.Add("BuyerEmailOptIn", DbType.Boolean);
            _FieldDbTypes.Add("OrderTaxType", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingTaxType", DbType.AnsiString);
            _FieldDbTypes.Add("GiftOptionsTaxType", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentMethod", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentTransactionID", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentPaypalAccountID", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentCreditCardLast4", DbType.AnsiString);
            _FieldDbTypes.Add("PaymentMerchantReferenceNumber", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingTitle", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingFirstName", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingLastName", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingSuffix", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCompanyName", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCompanyJobTitle", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingDaytimePhone", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingEveningPhone", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingAddressLine1", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingAddressLine2", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCity", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingStateOrProvince", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingStateOrProvinceName", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingPostalCode", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCountry", DbType.AnsiString);
            _FieldDbTypes.Add("BillingTitle", DbType.AnsiString);
            _FieldDbTypes.Add("BillingFirstName", DbType.AnsiString);
            _FieldDbTypes.Add("BillingLastName", DbType.AnsiString);
            _FieldDbTypes.Add("BillingSuffix", DbType.AnsiString);
            _FieldDbTypes.Add("BillingCompanyName", DbType.AnsiString);
            _FieldDbTypes.Add("BillingCompanyJobTitle", DbType.AnsiString);
            _FieldDbTypes.Add("BillingDaytimePhone", DbType.AnsiString);
            _FieldDbTypes.Add("BillingEveningPhone", DbType.AnsiString);
            _FieldDbTypes.Add("BillingAddressLine1", DbType.AnsiString);
            _FieldDbTypes.Add("BillingAddressLine2", DbType.AnsiString);
            _FieldDbTypes.Add("BillingCity", DbType.AnsiString);
            _FieldDbTypes.Add("BillingStateOrProvince", DbType.AnsiString);
            _FieldDbTypes.Add("BillingStateOrProvinceName", DbType.AnsiString);
            _FieldDbTypes.Add("BillingPostalCode", DbType.AnsiString);
            _FieldDbTypes.Add("BillingCountry", DbType.AnsiString);
            _FieldDbTypes.Add("PromotionCode", DbType.AnsiString);
            _FieldDbTypes.Add("PromotionAmount", DbType.Currency);

            _FieldEnums = new BusinessLayerFieldEnumDictionary(85);
            _FieldEnums.Add("pk", StagingOrderHeaderBOFieldNames.pk);
            _FieldEnums.Add("ID", StagingOrderHeaderBOFieldNames.ID);
            _FieldEnums.Add("ProfileID", StagingOrderHeaderBOFieldNames.ProfileID);
            _FieldEnums.Add("SiteID", StagingOrderHeaderBOFieldNames.SiteID);
            _FieldEnums.Add("SiteName", StagingOrderHeaderBOFieldNames.SiteName);
            _FieldEnums.Add("UserDataPresent", StagingOrderHeaderBOFieldNames.UserDataPresent);
            _FieldEnums.Add("UserDataRemovalDateUTC", StagingOrderHeaderBOFieldNames.UserDataRemovalDateUTC);
            _FieldEnums.Add("SiteAccountID", StagingOrderHeaderBOFieldNames.SiteAccountID);
            _FieldEnums.Add("SiteOrderID", StagingOrderHeaderBOFieldNames.SiteOrderID);
            _FieldEnums.Add("SecondarySiteOrderID", StagingOrderHeaderBOFieldNames.SecondarySiteOrderID);
            _FieldEnums.Add("SellerOrderID", StagingOrderHeaderBOFieldNames.SellerOrderID);
            _FieldEnums.Add("CheckoutSourceID", StagingOrderHeaderBOFieldNames.CheckoutSourceID);
            _FieldEnums.Add("Currency", StagingOrderHeaderBOFieldNames.Currency);
            _FieldEnums.Add("CreatedDateUtc", StagingOrderHeaderBOFieldNames.CreatedDateUtc);
            _FieldEnums.Add("ImportDateUtc", StagingOrderHeaderBOFieldNames.ImportDateUtc);
            _FieldEnums.Add("UpdatedDateUtc", StagingOrderHeaderBOFieldNames.UpdatedDateUtc);
            _FieldEnums.Add("PublicNotes", StagingOrderHeaderBOFieldNames.PublicNotes);
            _FieldEnums.Add("SpecialInstructions", StagingOrderHeaderBOFieldNames.SpecialInstructions);
            _FieldEnums.Add("TotalPrice", StagingOrderHeaderBOFieldNames.TotalPrice);
            _FieldEnums.Add("TotalTaxPrice", StagingOrderHeaderBOFieldNames.TotalTaxPrice);
            _FieldEnums.Add("TotalShippingPrice", StagingOrderHeaderBOFieldNames.TotalShippingPrice);
            _FieldEnums.Add("TotalShippingTaxPrice", StagingOrderHeaderBOFieldNames.TotalShippingTaxPrice);
            _FieldEnums.Add("TotalInsurancePrice", StagingOrderHeaderBOFieldNames.TotalInsurancePrice);
            _FieldEnums.Add("TotalGiftOptionPrice", StagingOrderHeaderBOFieldNames.TotalGiftOptionPrice);
            _FieldEnums.Add("TotalGiftOptionTaxPrice", StagingOrderHeaderBOFieldNames.TotalGiftOptionTaxPrice);
            _FieldEnums.Add("AdditionalCostOrDiscount", StagingOrderHeaderBOFieldNames.AdditionalCostOrDiscount);
            _FieldEnums.Add("EstimatedShipDateUtc", StagingOrderHeaderBOFieldNames.EstimatedShipDateUtc);
            _FieldEnums.Add("DeliverByDateUtc", StagingOrderHeaderBOFieldNames.DeliverByDateUtc);
            _FieldEnums.Add("RequestedShippingCarrier", StagingOrderHeaderBOFieldNames.RequestedShippingCarrier);
            _FieldEnums.Add("RequestedShippingClass", StagingOrderHeaderBOFieldNames.RequestedShippingClass);
            _FieldEnums.Add("ResellerID", StagingOrderHeaderBOFieldNames.ResellerID);
            _FieldEnums.Add("FlagID", StagingOrderHeaderBOFieldNames.FlagID);
            _FieldEnums.Add("FlagDescription", StagingOrderHeaderBOFieldNames.FlagDescription);
            _FieldEnums.Add("OrderTags", StagingOrderHeaderBOFieldNames.OrderTags);
            _FieldEnums.Add("DistributionCenterTypeRollup", StagingOrderHeaderBOFieldNames.DistributionCenterTypeRollup);
            _FieldEnums.Add("CheckoutStatus", StagingOrderHeaderBOFieldNames.CheckoutStatus);
            _FieldEnums.Add("PaymentStatus", StagingOrderHeaderBOFieldNames.PaymentStatus);
            _FieldEnums.Add("ShippingStatus", StagingOrderHeaderBOFieldNames.ShippingStatus);
            _FieldEnums.Add("CheckoutDateUtc", StagingOrderHeaderBOFieldNames.CheckoutDateUtc);
            _FieldEnums.Add("PaymentDateUtc", StagingOrderHeaderBOFieldNames.PaymentDateUtc);
            _FieldEnums.Add("ShippingDateUtc", StagingOrderHeaderBOFieldNames.ShippingDateUtc);
            _FieldEnums.Add("BuyerUserId", StagingOrderHeaderBOFieldNames.BuyerUserId);
            _FieldEnums.Add("BuyerEmailAddress", StagingOrderHeaderBOFieldNames.BuyerEmailAddress);
            _FieldEnums.Add("BuyerEmailOptIn", StagingOrderHeaderBOFieldNames.BuyerEmailOptIn);
            _FieldEnums.Add("OrderTaxType", StagingOrderHeaderBOFieldNames.OrderTaxType);
            _FieldEnums.Add("ShippingTaxType", StagingOrderHeaderBOFieldNames.ShippingTaxType);
            _FieldEnums.Add("GiftOptionsTaxType", StagingOrderHeaderBOFieldNames.GiftOptionsTaxType);
            _FieldEnums.Add("PaymentMethod", StagingOrderHeaderBOFieldNames.PaymentMethod);
            _FieldEnums.Add("PaymentTransactionID", StagingOrderHeaderBOFieldNames.PaymentTransactionID);
            _FieldEnums.Add("PaymentPaypalAccountID", StagingOrderHeaderBOFieldNames.PaymentPaypalAccountID);
            _FieldEnums.Add("PaymentCreditCardLast4", StagingOrderHeaderBOFieldNames.PaymentCreditCardLast4);
            _FieldEnums.Add("PaymentMerchantReferenceNumber", StagingOrderHeaderBOFieldNames.PaymentMerchantReferenceNumber);
            _FieldEnums.Add("ShippingTitle", StagingOrderHeaderBOFieldNames.ShippingTitle);
            _FieldEnums.Add("ShippingFirstName", StagingOrderHeaderBOFieldNames.ShippingFirstName);
            _FieldEnums.Add("ShippingLastName", StagingOrderHeaderBOFieldNames.ShippingLastName);
            _FieldEnums.Add("ShippingSuffix", StagingOrderHeaderBOFieldNames.ShippingSuffix);
            _FieldEnums.Add("ShippingCompanyName", StagingOrderHeaderBOFieldNames.ShippingCompanyName);
            _FieldEnums.Add("ShippingCompanyJobTitle", StagingOrderHeaderBOFieldNames.ShippingCompanyJobTitle);
            _FieldEnums.Add("ShippingDaytimePhone", StagingOrderHeaderBOFieldNames.ShippingDaytimePhone);
            _FieldEnums.Add("ShippingEveningPhone", StagingOrderHeaderBOFieldNames.ShippingEveningPhone);
            _FieldEnums.Add("ShippingAddressLine1", StagingOrderHeaderBOFieldNames.ShippingAddressLine1);
            _FieldEnums.Add("ShippingAddressLine2", StagingOrderHeaderBOFieldNames.ShippingAddressLine2);
            _FieldEnums.Add("ShippingCity", StagingOrderHeaderBOFieldNames.ShippingCity);
            _FieldEnums.Add("ShippingStateOrProvince", StagingOrderHeaderBOFieldNames.ShippingStateOrProvince);
            _FieldEnums.Add("ShippingStateOrProvinceName", StagingOrderHeaderBOFieldNames.ShippingStateOrProvinceName);
            _FieldEnums.Add("ShippingPostalCode", StagingOrderHeaderBOFieldNames.ShippingPostalCode);
            _FieldEnums.Add("ShippingCountry", StagingOrderHeaderBOFieldNames.ShippingCountry);
            _FieldEnums.Add("BillingTitle", StagingOrderHeaderBOFieldNames.BillingTitle);
            _FieldEnums.Add("BillingFirstName", StagingOrderHeaderBOFieldNames.BillingFirstName);
            _FieldEnums.Add("BillingLastName", StagingOrderHeaderBOFieldNames.BillingLastName);
            _FieldEnums.Add("BillingSuffix", StagingOrderHeaderBOFieldNames.BillingSuffix);
            _FieldEnums.Add("BillingCompanyName", StagingOrderHeaderBOFieldNames.BillingCompanyName);
            _FieldEnums.Add("BillingCompanyJobTitle", StagingOrderHeaderBOFieldNames.BillingCompanyJobTitle);
            _FieldEnums.Add("BillingDaytimePhone", StagingOrderHeaderBOFieldNames.BillingDaytimePhone);
            _FieldEnums.Add("BillingEveningPhone", StagingOrderHeaderBOFieldNames.BillingEveningPhone);
            _FieldEnums.Add("BillingAddressLine1", StagingOrderHeaderBOFieldNames.BillingAddressLine1);
            _FieldEnums.Add("BillingAddressLine2", StagingOrderHeaderBOFieldNames.BillingAddressLine2);
            _FieldEnums.Add("BillingCity", StagingOrderHeaderBOFieldNames.BillingCity);
            _FieldEnums.Add("BillingStateOrProvince", StagingOrderHeaderBOFieldNames.BillingStateOrProvince);
            _FieldEnums.Add("BillingStateOrProvinceName", StagingOrderHeaderBOFieldNames.BillingStateOrProvinceName);
            _FieldEnums.Add("BillingPostalCode", StagingOrderHeaderBOFieldNames.BillingPostalCode);
            _FieldEnums.Add("BillingCountry", StagingOrderHeaderBOFieldNames.BillingCountry);
            _FieldEnums.Add("PromotionCode", StagingOrderHeaderBOFieldNames.PromotionCode);
            _FieldEnums.Add("PromotionAmount", StagingOrderHeaderBOFieldNames.PromotionAmount);
            _FieldEnums.Add("CUSTOM_FIELD", StagingOrderHeaderBOFieldNames.CUSTOM_FIELD);

            _FieldLengths = new Dictionary<string, int>(84);
            _FieldLengths.Add("pk", 4);
            _FieldLengths.Add("ID", 8);
            _FieldLengths.Add("ProfileID", 8);
            _FieldLengths.Add("SiteID", 4);
            _FieldLengths.Add("SiteName", 100);
            _FieldLengths.Add("UserDataPresent", 4);
            _FieldLengths.Add("UserDataRemovalDateUTC", 8);
            _FieldLengths.Add("SiteAccountID", 8);
            _FieldLengths.Add("SiteOrderID", 30);
            _FieldLengths.Add("SecondarySiteOrderID", 20);
            _FieldLengths.Add("SellerOrderID", 8);
            _FieldLengths.Add("CheckoutSourceID", 8);
            _FieldLengths.Add("Currency", 10);
            _FieldLengths.Add("CreatedDateUtc", 8);
            _FieldLengths.Add("ImportDateUtc", 8);
            _FieldLengths.Add("UpdatedDateUtc", 8);
            _FieldLengths.Add("PublicNotes", -1);
            _FieldLengths.Add("SpecialInstructions", -1);
            _FieldLengths.Add("TotalPrice", 8);
            _FieldLengths.Add("TotalTaxPrice", 8);
            _FieldLengths.Add("TotalShippingPrice", 8);
            _FieldLengths.Add("TotalShippingTaxPrice", 8);
            _FieldLengths.Add("TotalInsurancePrice", 8);
            _FieldLengths.Add("TotalGiftOptionPrice", 8);
            _FieldLengths.Add("TotalGiftOptionTaxPrice", 8);
            _FieldLengths.Add("AdditionalCostOrDiscount", 8);
            _FieldLengths.Add("EstimatedShipDateUtc", 8);
            _FieldLengths.Add("DeliverByDateUtc", 8);
            _FieldLengths.Add("RequestedShippingCarrier", 20);
            _FieldLengths.Add("RequestedShippingClass", 20);
            _FieldLengths.Add("ResellerID", 20);
            _FieldLengths.Add("FlagID", 8);
            _FieldLengths.Add("FlagDescription", 200);
            _FieldLengths.Add("OrderTags", 200);
            _FieldLengths.Add("DistributionCenterTypeRollup", 30);
            _FieldLengths.Add("CheckoutStatus", 20);
            _FieldLengths.Add("PaymentStatus", 20);
            _FieldLengths.Add("ShippingStatus", 20);
            _FieldLengths.Add("CheckoutDateUtc", 8);
            _FieldLengths.Add("PaymentDateUtc", 8);
            _FieldLengths.Add("ShippingDateUtc", 8);
            _FieldLengths.Add("BuyerUserId", 100);
            _FieldLengths.Add("BuyerEmailAddress", 100);
            _FieldLengths.Add("BuyerEmailOptIn", 1);
            _FieldLengths.Add("OrderTaxType", 30);
            _FieldLengths.Add("ShippingTaxType", 30);
            _FieldLengths.Add("GiftOptionsTaxType", 30);
            _FieldLengths.Add("PaymentMethod", 30);
            _FieldLengths.Add("PaymentTransactionID", 30);
            _FieldLengths.Add("PaymentPaypalAccountID", 100);
            _FieldLengths.Add("PaymentCreditCardLast4", 10);
            _FieldLengths.Add("PaymentMerchantReferenceNumber", 30);
            _FieldLengths.Add("ShippingTitle", 100);
            _FieldLengths.Add("ShippingFirstName", 30);
            _FieldLengths.Add("ShippingLastName", 50);
            _FieldLengths.Add("ShippingSuffix", 10);
            _FieldLengths.Add("ShippingCompanyName", 50);
            _FieldLengths.Add("ShippingCompanyJobTitle", 100);
            _FieldLengths.Add("ShippingDaytimePhone", 20);
            _FieldLengths.Add("ShippingEveningPhone", 20);
            _FieldLengths.Add("ShippingAddressLine1", 100);
            _FieldLengths.Add("ShippingAddressLine2", 100);
            _FieldLengths.Add("ShippingCity", 50);
            _FieldLengths.Add("ShippingStateOrProvince", 30);
            _FieldLengths.Add("ShippingStateOrProvinceName", 30);
            _FieldLengths.Add("ShippingPostalCode", 20);
            _FieldLengths.Add("ShippingCountry", 30);
            _FieldLengths.Add("BillingTitle", 100);
            _FieldLengths.Add("BillingFirstName", 30);
            _FieldLengths.Add("BillingLastName", 50);
            _FieldLengths.Add("BillingSuffix", 10);
            _FieldLengths.Add("BillingCompanyName", 50);
            _FieldLengths.Add("BillingCompanyJobTitle", 100);
            _FieldLengths.Add("BillingDaytimePhone", 20);
            _FieldLengths.Add("BillingEveningPhone", 20);
            _FieldLengths.Add("BillingAddressLine1", 100);
            _FieldLengths.Add("BillingAddressLine2", 100);
            _FieldLengths.Add("BillingCity", 50);
            _FieldLengths.Add("BillingStateOrProvince", 30);
            _FieldLengths.Add("BillingStateOrProvinceName", 30);
            _FieldLengths.Add("BillingPostalCode", 20);
            _FieldLengths.Add("BillingCountry", 30);
            _FieldLengths.Add("PromotionCode", 30);
            _FieldLengths.Add("PromotionAmount", 8);

            _FieldNativeDbTypes = new Dictionary<string, int>(84);
            _FieldNativeDbTypes.Add("pk", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("ID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("ProfileID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("SiteID", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("SiteName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("UserDataPresent", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("UserDataRemovalDateUTC", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("SiteAccountID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("SiteOrderID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SecondarySiteOrderID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SellerOrderID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("CheckoutSourceID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("Currency", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("CreatedDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("ImportDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("UpdatedDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("PublicNotes", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SpecialInstructions", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("TotalPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalTaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalShippingPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalShippingTaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalInsurancePrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalGiftOptionPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TotalGiftOptionTaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("AdditionalCostOrDiscount", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("EstimatedShipDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("DeliverByDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("RequestedShippingCarrier", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("RequestedShippingClass", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ResellerID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("FlagID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("FlagDescription", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("OrderTags", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("DistributionCenterTypeRollup", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("CheckoutStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("CheckoutDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("PaymentDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("ShippingDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("BuyerUserId", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BuyerEmailAddress", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BuyerEmailOptIn", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("OrderTaxType", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingTaxType", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("GiftOptionsTaxType", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentMethod", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentTransactionID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentPaypalAccountID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentCreditCardLast4", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PaymentMerchantReferenceNumber", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingTitle", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingFirstName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingLastName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingSuffix", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCompanyName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCompanyJobTitle", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingDaytimePhone", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingEveningPhone", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingAddressLine1", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingAddressLine2", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCity", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingStateOrProvince", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingStateOrProvinceName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingPostalCode", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCountry", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingTitle", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingFirstName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingLastName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingSuffix", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingCompanyName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingCompanyJobTitle", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingDaytimePhone", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingEveningPhone", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingAddressLine1", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingAddressLine2", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingCity", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingStateOrProvince", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingStateOrProvinceName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingPostalCode", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("BillingCountry", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PromotionCode", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("PromotionAmount", (int)System.Data.SqlDbType.Money);

            _FieldPermissionKeys = new Dictionary<string, string>(84);

        }

        private static bool _AreCustomDescriptorsEvaluated = false;
        protected override bool AreCustomDescriptorsEvaluated
        {
            get
            {
                bool llReturn = _AreCustomDescriptorsEvaluated;
                _AreCustomDescriptorsEvaluated = true;
                return llReturn;
            }
        }

        private static PropertyDescriptorDictionary _PropertyDescriptors;
        protected override PropertyDescriptorDictionary PropertyDescriptors
        {
            get
            {
                return _PropertyDescriptors;
            }
        }

        /// <summary>
        /// A PropertyDescriptor class used to Get and Set the value of fields within the StagingOrderHeaderBO business object.
        /// </summary>
        private class FieldDescriptor :
        MicroFour.StrataFrame.Business.FieldPropertyDescriptor<StagingOrderHeaderBOFieldNames>
        {
            public FieldDescriptor(StagingOrderHeaderBOFieldNames field, Type fieldType) :
            base(field, fieldType)
            { }
            private static Type _ComponentType = typeof(StagingOrderHeaderBO);
            public override object GetValue(object component)
            {
                switch (this.Field)
                {
                    case StagingOrderHeaderBOFieldNames.pk:
                        return ((StagingOrderHeaderBO)component).pk;
                    case StagingOrderHeaderBOFieldNames.ID:
                        return ((StagingOrderHeaderBO)component).ID;
                    case StagingOrderHeaderBOFieldNames.ProfileID:
                        return ((StagingOrderHeaderBO)component).ProfileID;
                    case StagingOrderHeaderBOFieldNames.SiteID:
                        return ((StagingOrderHeaderBO)component).SiteID;
                    case StagingOrderHeaderBOFieldNames.SiteName:
                        return ((StagingOrderHeaderBO)component).SiteName;
                    case StagingOrderHeaderBOFieldNames.UserDataPresent:
                        return ((StagingOrderHeaderBO)component).UserDataPresent;
                    case StagingOrderHeaderBOFieldNames.UserDataRemovalDateUTC:
                        return ((StagingOrderHeaderBO)component).UserDataRemovalDateUTC;
                    case StagingOrderHeaderBOFieldNames.SiteAccountID:
                        return ((StagingOrderHeaderBO)component).SiteAccountID;
                    case StagingOrderHeaderBOFieldNames.SiteOrderID:
                        return ((StagingOrderHeaderBO)component).SiteOrderID;
                    case StagingOrderHeaderBOFieldNames.SecondarySiteOrderID:
                        return ((StagingOrderHeaderBO)component).SecondarySiteOrderID;
                    case StagingOrderHeaderBOFieldNames.SellerOrderID:
                        return ((StagingOrderHeaderBO)component).SellerOrderID;
                    case StagingOrderHeaderBOFieldNames.CheckoutSourceID:
                        return ((StagingOrderHeaderBO)component).CheckoutSourceID;
                    case StagingOrderHeaderBOFieldNames.Currency:
                        return ((StagingOrderHeaderBO)component).Currency;
                    case StagingOrderHeaderBOFieldNames.CreatedDateUtc:
                        return ((StagingOrderHeaderBO)component).CreatedDateUtc;
                    case StagingOrderHeaderBOFieldNames.ImportDateUtc:
                        return ((StagingOrderHeaderBO)component).ImportDateUtc;
                    case StagingOrderHeaderBOFieldNames.UpdatedDateUtc:
                        return ((StagingOrderHeaderBO)component).UpdatedDateUtc;
                    case StagingOrderHeaderBOFieldNames.PublicNotes:
                        return ((StagingOrderHeaderBO)component).PublicNotes;
                    case StagingOrderHeaderBOFieldNames.SpecialInstructions:
                        return ((StagingOrderHeaderBO)component).SpecialInstructions;
                    case StagingOrderHeaderBOFieldNames.TotalPrice:
                        return ((StagingOrderHeaderBO)component).TotalPrice;
                    case StagingOrderHeaderBOFieldNames.TotalTaxPrice:
                        return ((StagingOrderHeaderBO)component).TotalTaxPrice;
                    case StagingOrderHeaderBOFieldNames.TotalShippingPrice:
                        return ((StagingOrderHeaderBO)component).TotalShippingPrice;
                    case StagingOrderHeaderBOFieldNames.TotalShippingTaxPrice:
                        return ((StagingOrderHeaderBO)component).TotalShippingTaxPrice;
                    case StagingOrderHeaderBOFieldNames.TotalInsurancePrice:
                        return ((StagingOrderHeaderBO)component).TotalInsurancePrice;
                    case StagingOrderHeaderBOFieldNames.TotalGiftOptionPrice:
                        return ((StagingOrderHeaderBO)component).TotalGiftOptionPrice;
                    case StagingOrderHeaderBOFieldNames.TotalGiftOptionTaxPrice:
                        return ((StagingOrderHeaderBO)component).TotalGiftOptionTaxPrice;
                    case StagingOrderHeaderBOFieldNames.AdditionalCostOrDiscount:
                        return ((StagingOrderHeaderBO)component).AdditionalCostOrDiscount;
                    case StagingOrderHeaderBOFieldNames.EstimatedShipDateUtc:
                        return ((StagingOrderHeaderBO)component).EstimatedShipDateUtc;
                    case StagingOrderHeaderBOFieldNames.DeliverByDateUtc:
                        return ((StagingOrderHeaderBO)component).DeliverByDateUtc;
                    case StagingOrderHeaderBOFieldNames.RequestedShippingCarrier:
                        return ((StagingOrderHeaderBO)component).RequestedShippingCarrier;
                    case StagingOrderHeaderBOFieldNames.RequestedShippingClass:
                        return ((StagingOrderHeaderBO)component).RequestedShippingClass;
                    case StagingOrderHeaderBOFieldNames.ResellerID:
                        return ((StagingOrderHeaderBO)component).ResellerID;
                    case StagingOrderHeaderBOFieldNames.FlagID:
                        return ((StagingOrderHeaderBO)component).FlagID;
                    case StagingOrderHeaderBOFieldNames.FlagDescription:
                        return ((StagingOrderHeaderBO)component).FlagDescription;
                    case StagingOrderHeaderBOFieldNames.OrderTags:
                        return ((StagingOrderHeaderBO)component).OrderTags;
                    case StagingOrderHeaderBOFieldNames.DistributionCenterTypeRollup:
                        return ((StagingOrderHeaderBO)component).DistributionCenterTypeRollup;
                    case StagingOrderHeaderBOFieldNames.CheckoutStatus:
                        return ((StagingOrderHeaderBO)component).CheckoutStatus;
                    case StagingOrderHeaderBOFieldNames.PaymentStatus:
                        return ((StagingOrderHeaderBO)component).PaymentStatus;
                    case StagingOrderHeaderBOFieldNames.ShippingStatus:
                        return ((StagingOrderHeaderBO)component).ShippingStatus;
                    case StagingOrderHeaderBOFieldNames.CheckoutDateUtc:
                        return ((StagingOrderHeaderBO)component).CheckoutDateUtc;
                    case StagingOrderHeaderBOFieldNames.PaymentDateUtc:
                        return ((StagingOrderHeaderBO)component).PaymentDateUtc;
                    case StagingOrderHeaderBOFieldNames.ShippingDateUtc:
                        return ((StagingOrderHeaderBO)component).ShippingDateUtc;
                    case StagingOrderHeaderBOFieldNames.BuyerUserId:
                        return ((StagingOrderHeaderBO)component).BuyerUserId;
                    case StagingOrderHeaderBOFieldNames.BuyerEmailAddress:
                        return ((StagingOrderHeaderBO)component).BuyerEmailAddress;
                    case StagingOrderHeaderBOFieldNames.BuyerEmailOptIn:
                        return ((StagingOrderHeaderBO)component).BuyerEmailOptIn;
                    case StagingOrderHeaderBOFieldNames.OrderTaxType:
                        return ((StagingOrderHeaderBO)component).OrderTaxType;
                    case StagingOrderHeaderBOFieldNames.ShippingTaxType:
                        return ((StagingOrderHeaderBO)component).ShippingTaxType;
                    case StagingOrderHeaderBOFieldNames.GiftOptionsTaxType:
                        return ((StagingOrderHeaderBO)component).GiftOptionsTaxType;
                    case StagingOrderHeaderBOFieldNames.PaymentMethod:
                        return ((StagingOrderHeaderBO)component).PaymentMethod;
                    case StagingOrderHeaderBOFieldNames.PaymentTransactionID:
                        return ((StagingOrderHeaderBO)component).PaymentTransactionID;
                    case StagingOrderHeaderBOFieldNames.PaymentPaypalAccountID:
                        return ((StagingOrderHeaderBO)component).PaymentPaypalAccountID;
                    case StagingOrderHeaderBOFieldNames.PaymentCreditCardLast4:
                        return ((StagingOrderHeaderBO)component).PaymentCreditCardLast4;
                    case StagingOrderHeaderBOFieldNames.PaymentMerchantReferenceNumber:
                        return ((StagingOrderHeaderBO)component).PaymentMerchantReferenceNumber;
                    case StagingOrderHeaderBOFieldNames.ShippingTitle:
                        return ((StagingOrderHeaderBO)component).ShippingTitle;
                    case StagingOrderHeaderBOFieldNames.ShippingFirstName:
                        return ((StagingOrderHeaderBO)component).ShippingFirstName;
                    case StagingOrderHeaderBOFieldNames.ShippingLastName:
                        return ((StagingOrderHeaderBO)component).ShippingLastName;
                    case StagingOrderHeaderBOFieldNames.ShippingSuffix:
                        return ((StagingOrderHeaderBO)component).ShippingSuffix;
                    case StagingOrderHeaderBOFieldNames.ShippingCompanyName:
                        return ((StagingOrderHeaderBO)component).ShippingCompanyName;
                    case StagingOrderHeaderBOFieldNames.ShippingCompanyJobTitle:
                        return ((StagingOrderHeaderBO)component).ShippingCompanyJobTitle;
                    case StagingOrderHeaderBOFieldNames.ShippingDaytimePhone:
                        return ((StagingOrderHeaderBO)component).ShippingDaytimePhone;
                    case StagingOrderHeaderBOFieldNames.ShippingEveningPhone:
                        return ((StagingOrderHeaderBO)component).ShippingEveningPhone;
                    case StagingOrderHeaderBOFieldNames.ShippingAddressLine1:
                        return ((StagingOrderHeaderBO)component).ShippingAddressLine1;
                    case StagingOrderHeaderBOFieldNames.ShippingAddressLine2:
                        return ((StagingOrderHeaderBO)component).ShippingAddressLine2;
                    case StagingOrderHeaderBOFieldNames.ShippingCity:
                        return ((StagingOrderHeaderBO)component).ShippingCity;
                    case StagingOrderHeaderBOFieldNames.ShippingStateOrProvince:
                        return ((StagingOrderHeaderBO)component).ShippingStateOrProvince;
                    case StagingOrderHeaderBOFieldNames.ShippingStateOrProvinceName:
                        return ((StagingOrderHeaderBO)component).ShippingStateOrProvinceName;
                    case StagingOrderHeaderBOFieldNames.ShippingPostalCode:
                        return ((StagingOrderHeaderBO)component).ShippingPostalCode;
                    case StagingOrderHeaderBOFieldNames.ShippingCountry:
                        return ((StagingOrderHeaderBO)component).ShippingCountry;
                    case StagingOrderHeaderBOFieldNames.BillingTitle:
                        return ((StagingOrderHeaderBO)component).BillingTitle;
                    case StagingOrderHeaderBOFieldNames.BillingFirstName:
                        return ((StagingOrderHeaderBO)component).BillingFirstName;
                    case StagingOrderHeaderBOFieldNames.BillingLastName:
                        return ((StagingOrderHeaderBO)component).BillingLastName;
                    case StagingOrderHeaderBOFieldNames.BillingSuffix:
                        return ((StagingOrderHeaderBO)component).BillingSuffix;
                    case StagingOrderHeaderBOFieldNames.BillingCompanyName:
                        return ((StagingOrderHeaderBO)component).BillingCompanyName;
                    case StagingOrderHeaderBOFieldNames.BillingCompanyJobTitle:
                        return ((StagingOrderHeaderBO)component).BillingCompanyJobTitle;
                    case StagingOrderHeaderBOFieldNames.BillingDaytimePhone:
                        return ((StagingOrderHeaderBO)component).BillingDaytimePhone;
                    case StagingOrderHeaderBOFieldNames.BillingEveningPhone:
                        return ((StagingOrderHeaderBO)component).BillingEveningPhone;
                    case StagingOrderHeaderBOFieldNames.BillingAddressLine1:
                        return ((StagingOrderHeaderBO)component).BillingAddressLine1;
                    case StagingOrderHeaderBOFieldNames.BillingAddressLine2:
                        return ((StagingOrderHeaderBO)component).BillingAddressLine2;
                    case StagingOrderHeaderBOFieldNames.BillingCity:
                        return ((StagingOrderHeaderBO)component).BillingCity;
                    case StagingOrderHeaderBOFieldNames.BillingStateOrProvince:
                        return ((StagingOrderHeaderBO)component).BillingStateOrProvince;
                    case StagingOrderHeaderBOFieldNames.BillingStateOrProvinceName:
                        return ((StagingOrderHeaderBO)component).BillingStateOrProvinceName;
                    case StagingOrderHeaderBOFieldNames.BillingPostalCode:
                        return ((StagingOrderHeaderBO)component).BillingPostalCode;
                    case StagingOrderHeaderBOFieldNames.BillingCountry:
                        return ((StagingOrderHeaderBO)component).BillingCountry;
                    case StagingOrderHeaderBOFieldNames.PromotionCode:
                        return ((StagingOrderHeaderBO)component).PromotionCode;
                    case StagingOrderHeaderBOFieldNames.PromotionAmount:
                        return ((StagingOrderHeaderBO)component).PromotionAmount;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override void SetValue(object component, object value)
            {
                switch (this.Field)
                {
                    case StagingOrderHeaderBOFieldNames.pk:
                        ((StagingOrderHeaderBO)component).pk = (System.Int32)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ID:
                        ((StagingOrderHeaderBO)component).ID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ProfileID:
                        ((StagingOrderHeaderBO)component).ProfileID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SiteID:
                        ((StagingOrderHeaderBO)component).SiteID = (System.Int32)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SiteName:
                        ((StagingOrderHeaderBO)component).SiteName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.UserDataPresent:
                        ((StagingOrderHeaderBO)component).UserDataPresent = (System.Int32)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.UserDataRemovalDateUTC:
                        ((StagingOrderHeaderBO)component).UserDataRemovalDateUTC = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SiteAccountID:
                        ((StagingOrderHeaderBO)component).SiteAccountID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SiteOrderID:
                        ((StagingOrderHeaderBO)component).SiteOrderID = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SecondarySiteOrderID:
                        ((StagingOrderHeaderBO)component).SecondarySiteOrderID = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SellerOrderID:
                        ((StagingOrderHeaderBO)component).SellerOrderID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.CheckoutSourceID:
                        ((StagingOrderHeaderBO)component).CheckoutSourceID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.Currency:
                        ((StagingOrderHeaderBO)component).Currency = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.CreatedDateUtc:
                        ((StagingOrderHeaderBO)component).CreatedDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ImportDateUtc:
                        ((StagingOrderHeaderBO)component).ImportDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.UpdatedDateUtc:
                        ((StagingOrderHeaderBO)component).UpdatedDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PublicNotes:
                        ((StagingOrderHeaderBO)component).PublicNotes = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.SpecialInstructions:
                        ((StagingOrderHeaderBO)component).SpecialInstructions = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalPrice:
                        ((StagingOrderHeaderBO)component).TotalPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalTaxPrice:
                        ((StagingOrderHeaderBO)component).TotalTaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalShippingPrice:
                        ((StagingOrderHeaderBO)component).TotalShippingPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalShippingTaxPrice:
                        ((StagingOrderHeaderBO)component).TotalShippingTaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalInsurancePrice:
                        ((StagingOrderHeaderBO)component).TotalInsurancePrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalGiftOptionPrice:
                        ((StagingOrderHeaderBO)component).TotalGiftOptionPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.TotalGiftOptionTaxPrice:
                        ((StagingOrderHeaderBO)component).TotalGiftOptionTaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.AdditionalCostOrDiscount:
                        ((StagingOrderHeaderBO)component).AdditionalCostOrDiscount = (System.Decimal)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.EstimatedShipDateUtc:
                        ((StagingOrderHeaderBO)component).EstimatedShipDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.DeliverByDateUtc:
                        ((StagingOrderHeaderBO)component).DeliverByDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.RequestedShippingCarrier:
                        ((StagingOrderHeaderBO)component).RequestedShippingCarrier = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.RequestedShippingClass:
                        ((StagingOrderHeaderBO)component).RequestedShippingClass = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ResellerID:
                        ((StagingOrderHeaderBO)component).ResellerID = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.FlagID:
                        ((StagingOrderHeaderBO)component).FlagID = (System.Int64)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.FlagDescription:
                        ((StagingOrderHeaderBO)component).FlagDescription = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.OrderTags:
                        ((StagingOrderHeaderBO)component).OrderTags = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.DistributionCenterTypeRollup:
                        ((StagingOrderHeaderBO)component).DistributionCenterTypeRollup = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.CheckoutStatus:
                        ((StagingOrderHeaderBO)component).CheckoutStatus = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentStatus:
                        ((StagingOrderHeaderBO)component).PaymentStatus = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingStatus:
                        ((StagingOrderHeaderBO)component).ShippingStatus = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.CheckoutDateUtc:
                        ((StagingOrderHeaderBO)component).CheckoutDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentDateUtc:
                        ((StagingOrderHeaderBO)component).PaymentDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingDateUtc:
                        ((StagingOrderHeaderBO)component).ShippingDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BuyerUserId:
                        ((StagingOrderHeaderBO)component).BuyerUserId = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BuyerEmailAddress:
                        ((StagingOrderHeaderBO)component).BuyerEmailAddress = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BuyerEmailOptIn:
                        ((StagingOrderHeaderBO)component).BuyerEmailOptIn = (System.Boolean)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.OrderTaxType:
                        ((StagingOrderHeaderBO)component).OrderTaxType = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingTaxType:
                        ((StagingOrderHeaderBO)component).ShippingTaxType = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.GiftOptionsTaxType:
                        ((StagingOrderHeaderBO)component).GiftOptionsTaxType = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentMethod:
                        ((StagingOrderHeaderBO)component).PaymentMethod = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentTransactionID:
                        ((StagingOrderHeaderBO)component).PaymentTransactionID = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentPaypalAccountID:
                        ((StagingOrderHeaderBO)component).PaymentPaypalAccountID = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentCreditCardLast4:
                        ((StagingOrderHeaderBO)component).PaymentCreditCardLast4 = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PaymentMerchantReferenceNumber:
                        ((StagingOrderHeaderBO)component).PaymentMerchantReferenceNumber = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingTitle:
                        ((StagingOrderHeaderBO)component).ShippingTitle = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingFirstName:
                        ((StagingOrderHeaderBO)component).ShippingFirstName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingLastName:
                        ((StagingOrderHeaderBO)component).ShippingLastName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingSuffix:
                        ((StagingOrderHeaderBO)component).ShippingSuffix = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingCompanyName:
                        ((StagingOrderHeaderBO)component).ShippingCompanyName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingCompanyJobTitle:
                        ((StagingOrderHeaderBO)component).ShippingCompanyJobTitle = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingDaytimePhone:
                        ((StagingOrderHeaderBO)component).ShippingDaytimePhone = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingEveningPhone:
                        ((StagingOrderHeaderBO)component).ShippingEveningPhone = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingAddressLine1:
                        ((StagingOrderHeaderBO)component).ShippingAddressLine1 = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingAddressLine2:
                        ((StagingOrderHeaderBO)component).ShippingAddressLine2 = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingCity:
                        ((StagingOrderHeaderBO)component).ShippingCity = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingStateOrProvince:
                        ((StagingOrderHeaderBO)component).ShippingStateOrProvince = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingStateOrProvinceName:
                        ((StagingOrderHeaderBO)component).ShippingStateOrProvinceName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingPostalCode:
                        ((StagingOrderHeaderBO)component).ShippingPostalCode = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.ShippingCountry:
                        ((StagingOrderHeaderBO)component).ShippingCountry = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingTitle:
                        ((StagingOrderHeaderBO)component).BillingTitle = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingFirstName:
                        ((StagingOrderHeaderBO)component).BillingFirstName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingLastName:
                        ((StagingOrderHeaderBO)component).BillingLastName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingSuffix:
                        ((StagingOrderHeaderBO)component).BillingSuffix = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingCompanyName:
                        ((StagingOrderHeaderBO)component).BillingCompanyName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingCompanyJobTitle:
                        ((StagingOrderHeaderBO)component).BillingCompanyJobTitle = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingDaytimePhone:
                        ((StagingOrderHeaderBO)component).BillingDaytimePhone = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingEveningPhone:
                        ((StagingOrderHeaderBO)component).BillingEveningPhone = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingAddressLine1:
                        ((StagingOrderHeaderBO)component).BillingAddressLine1 = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingAddressLine2:
                        ((StagingOrderHeaderBO)component).BillingAddressLine2 = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingCity:
                        ((StagingOrderHeaderBO)component).BillingCity = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingStateOrProvince:
                        ((StagingOrderHeaderBO)component).BillingStateOrProvince = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingStateOrProvinceName:
                        ((StagingOrderHeaderBO)component).BillingStateOrProvinceName = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingPostalCode:
                        ((StagingOrderHeaderBO)component).BillingPostalCode = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.BillingCountry:
                        ((StagingOrderHeaderBO)component).BillingCountry = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PromotionCode:
                        ((StagingOrderHeaderBO)component).PromotionCode = (System.String)value;
                        break;
                    case StagingOrderHeaderBOFieldNames.PromotionAmount:
                        ((StagingOrderHeaderBO)component).PromotionAmount = (System.Decimal)value;
                        break;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override Type ComponentType
            {
                get
                {
                    return _ComponentType;
                }
            }
        }

        #endregion

    }

}
