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
    partial class StagingOrderItemsBO
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

            this.CheckRulesOnCurrentRow += new CheckRulesOnCurrentRowEventHandler(StagingOrderItemsBO_CheckRulesOnCurrentRow);
            this.SetDefaultValues += new SetDefaultValuesEventHandler(StagingOrderItemsBO_SetDefaultValues);
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
                return "[pk],[ID],[ProfileID],[OrderID],[ProductID],[SiteOrderItemID],[SellerOrderItemID],[SiteListingID],[Sku],[ReferenceSku],[ReferenceProductID],[Title],[Quantity],[UnitPrice],[TaxPrice],[ShippingPrice],[ShippingTaxPrice],[RecyclingFee],[UnitEstimatedShippingCost],[GiftMessage],[GiftNotes],[GiftPrice],[GiftTaxPrice],[IsBundle],[ItemURL],[HarmonizedCode]";
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
                return "StagingOrderItems";
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
new DataColumn("OrderID", typeof(System.Int64)),
new DataColumn("ProductID", typeof(System.Int64)),
new DataColumn("SiteOrderItemID", typeof(System.String)),
new DataColumn("SellerOrderItemID", typeof(System.String)),
new DataColumn("SiteListingID", typeof(System.String)),
new DataColumn("Sku", typeof(System.String)),
new DataColumn("ReferenceSku", typeof(System.String)),
new DataColumn("ReferenceProductID", typeof(System.String)),
new DataColumn("Title", typeof(System.String)),
new DataColumn("Quantity", typeof(System.Int32)),
new DataColumn("UnitPrice", typeof(System.Decimal)),
new DataColumn("TaxPrice", typeof(System.Decimal)),
new DataColumn("ShippingPrice", typeof(System.Decimal)),
new DataColumn("ShippingTaxPrice", typeof(System.Decimal)),
new DataColumn("RecyclingFee", typeof(System.Decimal)),
new DataColumn("UnitEstimatedShippingCost", typeof(System.Decimal)),
new DataColumn("GiftMessage", typeof(System.String)),
new DataColumn("GiftNotes", typeof(System.String)),
new DataColumn("GiftPrice", typeof(System.Decimal)),
new DataColumn("GiftTaxPrice", typeof(System.Decimal)),
new DataColumn("IsBundle", typeof(System.Boolean)),
new DataColumn("ItemURL", typeof(System.String)),
new DataColumn("HarmonizedCode", typeof(System.String))};
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected void AddBrokenRule(StagingOrderItemsBOFieldNames Field, string ErrorMessage)
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
        protected void AddBrokenRuleByKey(StagingOrderItemsBOFieldNames Field, string ErrorMessageKey)
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
        public System.Int64 OrderID
        {
            get
            {
                return (System.Int64)this.CurrentRow["OrderID"];
            }
            set
            {
                this.CurrentRow["OrderID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 ProductID
        {
            get
            {
                return (System.Int64)this.CurrentRow["ProductID"];
            }
            set
            {
                this.CurrentRow["ProductID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SiteOrderItemID
        {
            get
            {
                return (System.String)this.CurrentRow["SiteOrderItemID"];
            }
            set
            {
                this.CurrentRow["SiteOrderItemID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SellerOrderItemID
        {
            get
            {
                return (System.String)this.CurrentRow["SellerOrderItemID"];
            }
            set
            {
                this.CurrentRow["SellerOrderItemID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SiteListingID
        {
            get
            {
                return (System.String)this.CurrentRow["SiteListingID"];
            }
            set
            {
                this.CurrentRow["SiteListingID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String Sku
        {
            get
            {
                return (System.String)this.CurrentRow["Sku"];
            }
            set
            {
                this.CurrentRow["Sku"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ReferenceSku
        {
            get
            {
                return (System.String)this.CurrentRow["ReferenceSku"];
            }
            set
            {
                this.CurrentRow["ReferenceSku"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ReferenceProductID
        {
            get
            {
                return (System.String)this.CurrentRow["ReferenceProductID"];
            }
            set
            {
                this.CurrentRow["ReferenceProductID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String Title
        {
            get
            {
                return (System.String)this.CurrentRow["Title"];
            }
            set
            {
                this.CurrentRow["Title"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int32 Quantity
        {
            get
            {
                return (System.Int32)this.CurrentRow["Quantity"];
            }
            set
            {
                this.CurrentRow["Quantity"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal UnitPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["UnitPrice"];
            }
            set
            {
                this.CurrentRow["UnitPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TaxPrice"];
            }
            set
            {
                this.CurrentRow["TaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal ShippingPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["ShippingPrice"];
            }
            set
            {
                this.CurrentRow["ShippingPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal ShippingTaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["ShippingTaxPrice"];
            }
            set
            {
                this.CurrentRow["ShippingTaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal RecyclingFee
        {
            get
            {
                return (System.Decimal)this.CurrentRow["RecyclingFee"];
            }
            set
            {
                this.CurrentRow["RecyclingFee"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal UnitEstimatedShippingCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["UnitEstimatedShippingCost"];
            }
            set
            {
                this.CurrentRow["UnitEstimatedShippingCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String GiftMessage
        {
            get
            {
                return (System.String)this.CurrentRow["GiftMessage"];
            }
            set
            {
                this.CurrentRow["GiftMessage"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String GiftNotes
        {
            get
            {
                return (System.String)this.CurrentRow["GiftNotes"];
            }
            set
            {
                this.CurrentRow["GiftNotes"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal GiftPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["GiftPrice"];
            }
            set
            {
                this.CurrentRow["GiftPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal GiftTaxPrice
        {
            get
            {
                return (System.Decimal)this.CurrentRow["GiftTaxPrice"];
            }
            set
            {
                this.CurrentRow["GiftTaxPrice"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean IsBundle
        {
            get
            {
                return (System.Boolean)this.CurrentRow["IsBundle"];
            }
            set
            {
                this.CurrentRow["IsBundle"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ItemURL
        {
            get
            {
                return (System.String)this.CurrentRow["ItemURL"];
            }
            set
            {
                this.CurrentRow["ItemURL"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String HarmonizedCode
        {
            get
            {
                return (System.String)this.CurrentRow["HarmonizedCode"];
            }
            set
            {
                this.CurrentRow["HarmonizedCode"] = value;
            }
        }

        #endregion

        #region Field Property Events 

        #endregion

        #region Nested Types & Field Security

        /// <summary>
        /// Contains all of the field names that belong to the business object.
        /// </summary>
        public enum StagingOrderItemsBOFieldNames
        {
            pk,
            ID,
            ProfileID,
            OrderID,
            ProductID,
            SiteOrderItemID,
            SellerOrderItemID,
            SiteListingID,
            Sku,
            ReferenceSku,
            ReferenceProductID,
            Title,
            Quantity,
            UnitPrice,
            TaxPrice,
            ShippingPrice,
            ShippingTaxPrice,
            RecyclingFee,
            UnitEstimatedShippingCost,
            GiftMessage,
            GiftNotes,
            GiftPrice,
            GiftTaxPrice,
            IsBundle,
            ItemURL,
            HarmonizedCode,
            CUSTOM_FIELD
        }

        /// <summary>
        /// Gets the System.Type of the enumeration that contains the field names for the business object.
        /// </summary>
        public override System.Type GetFieldEnumType()
        {
            return typeof(StagingOrderItemsBOFieldNames);
        }

        /// <summary>
        /// Creates a new CheckFieldSecurityEventArgs object that can be used with this business object type.
        /// </summary>
        protected override CheckFieldSecurityEventArgsBase CreateNewFieldSecurityEventArgs(System.Enum Field, string CustomField, string PermissionKey, PermissionInfo Perm)
        {
            return new CheckFieldSecurityEventArgs<StagingOrderItemsBOFieldNames>(Field, CustomField, PermissionKey, Perm);
        }

        /// <summary>
        /// Describes a method that will handle the CheckFieldScurity event.
        /// </summary>
        public delegate void CheckFieldSecurityEventHandler(object sender, CheckFieldSecurityEventArgs<StagingOrderItemsBOFieldNames> e);

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
                this.CheckFieldSecurity(this, (CheckFieldSecurityEventArgs<StagingOrderItemsBOFieldNames>)e);
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
        /// Initializes the static members of the StagingOrderItemsBO class.
        /// </summary>
        static StagingOrderItemsBO()
        {
            //-- Create the new shared dictionary and populate it with an 
            //   instance of each property descriptor
            _PropertyDescriptors = new PropertyDescriptorDictionary(31);
            _PropertyDescriptors.Add("pk", new FieldDescriptor(StagingOrderItemsBOFieldNames.pk, typeof(System.Int32)));
            _PropertyDescriptors.Add("ID", new FieldDescriptor(StagingOrderItemsBOFieldNames.ID, typeof(System.Int64)));
            _PropertyDescriptors.Add("ProfileID", new FieldDescriptor(StagingOrderItemsBOFieldNames.ProfileID, typeof(System.Int64)));
            _PropertyDescriptors.Add("OrderID", new FieldDescriptor(StagingOrderItemsBOFieldNames.OrderID, typeof(System.Int64)));
            _PropertyDescriptors.Add("ProductID", new FieldDescriptor(StagingOrderItemsBOFieldNames.ProductID, typeof(System.Int64)));
            _PropertyDescriptors.Add("SiteOrderItemID", new FieldDescriptor(StagingOrderItemsBOFieldNames.SiteOrderItemID, typeof(System.String)));
            _PropertyDescriptors.Add("SellerOrderItemID", new FieldDescriptor(StagingOrderItemsBOFieldNames.SellerOrderItemID, typeof(System.String)));
            _PropertyDescriptors.Add("SiteListingID", new FieldDescriptor(StagingOrderItemsBOFieldNames.SiteListingID, typeof(System.String)));
            _PropertyDescriptors.Add("Sku", new FieldDescriptor(StagingOrderItemsBOFieldNames.Sku, typeof(System.String)));
            _PropertyDescriptors.Add("ReferenceSku", new FieldDescriptor(StagingOrderItemsBOFieldNames.ReferenceSku, typeof(System.String)));
            _PropertyDescriptors.Add("ReferenceProductID", new FieldDescriptor(StagingOrderItemsBOFieldNames.ReferenceProductID, typeof(System.String)));
            _PropertyDescriptors.Add("Title", new FieldDescriptor(StagingOrderItemsBOFieldNames.Title, typeof(System.String)));
            _PropertyDescriptors.Add("Quantity", new FieldDescriptor(StagingOrderItemsBOFieldNames.Quantity, typeof(System.Int32)));
            _PropertyDescriptors.Add("UnitPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.UnitPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TaxPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.TaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("ShippingPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.ShippingPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("ShippingTaxPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.ShippingTaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("RecyclingFee", new FieldDescriptor(StagingOrderItemsBOFieldNames.RecyclingFee, typeof(System.Decimal)));
            _PropertyDescriptors.Add("UnitEstimatedShippingCost", new FieldDescriptor(StagingOrderItemsBOFieldNames.UnitEstimatedShippingCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("GiftMessage", new FieldDescriptor(StagingOrderItemsBOFieldNames.GiftMessage, typeof(System.String)));
            _PropertyDescriptors.Add("GiftNotes", new FieldDescriptor(StagingOrderItemsBOFieldNames.GiftNotes, typeof(System.String)));
            _PropertyDescriptors.Add("GiftPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.GiftPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("GiftTaxPrice", new FieldDescriptor(StagingOrderItemsBOFieldNames.GiftTaxPrice, typeof(System.Decimal)));
            _PropertyDescriptors.Add("IsBundle", new FieldDescriptor(StagingOrderItemsBOFieldNames.IsBundle, typeof(System.Boolean)));
            _PropertyDescriptors.Add("ItemURL", new FieldDescriptor(StagingOrderItemsBOFieldNames.ItemURL, typeof(System.String)));
            _PropertyDescriptors.Add("HarmonizedCode", new FieldDescriptor(StagingOrderItemsBOFieldNames.HarmonizedCode, typeof(System.String)));

            _AllFieldsList = new List<string>(26);
            _AllFieldsList.Add("pk");
            _AllFieldsList.Add("ID");
            _AllFieldsList.Add("ProfileID");
            _AllFieldsList.Add("OrderID");
            _AllFieldsList.Add("ProductID");
            _AllFieldsList.Add("SiteOrderItemID");
            _AllFieldsList.Add("SellerOrderItemID");
            _AllFieldsList.Add("SiteListingID");
            _AllFieldsList.Add("Sku");
            _AllFieldsList.Add("ReferenceSku");
            _AllFieldsList.Add("ReferenceProductID");
            _AllFieldsList.Add("Title");
            _AllFieldsList.Add("Quantity");
            _AllFieldsList.Add("UnitPrice");
            _AllFieldsList.Add("TaxPrice");
            _AllFieldsList.Add("ShippingPrice");
            _AllFieldsList.Add("ShippingTaxPrice");
            _AllFieldsList.Add("RecyclingFee");
            _AllFieldsList.Add("UnitEstimatedShippingCost");
            _AllFieldsList.Add("GiftMessage");
            _AllFieldsList.Add("GiftNotes");
            _AllFieldsList.Add("GiftPrice");
            _AllFieldsList.Add("GiftTaxPrice");
            _AllFieldsList.Add("IsBundle");
            _AllFieldsList.Add("ItemURL");
            _AllFieldsList.Add("HarmonizedCode");

            _FieldDbTypes = new Dictionary<string, DbType>(26);
            _FieldDbTypes.Add("pk", DbType.Int32);
            _FieldDbTypes.Add("ID", DbType.Int64);
            _FieldDbTypes.Add("ProfileID", DbType.Int64);
            _FieldDbTypes.Add("OrderID", DbType.Int64);
            _FieldDbTypes.Add("ProductID", DbType.Int64);
            _FieldDbTypes.Add("SiteOrderItemID", DbType.AnsiString);
            _FieldDbTypes.Add("SellerOrderItemID", DbType.AnsiString);
            _FieldDbTypes.Add("SiteListingID", DbType.AnsiString);
            _FieldDbTypes.Add("Sku", DbType.AnsiString);
            _FieldDbTypes.Add("ReferenceSku", DbType.AnsiString);
            _FieldDbTypes.Add("ReferenceProductID", DbType.AnsiString);
            _FieldDbTypes.Add("Title", DbType.AnsiString);
            _FieldDbTypes.Add("Quantity", DbType.Int32);
            _FieldDbTypes.Add("UnitPrice", DbType.Currency);
            _FieldDbTypes.Add("TaxPrice", DbType.Currency);
            _FieldDbTypes.Add("ShippingPrice", DbType.Currency);
            _FieldDbTypes.Add("ShippingTaxPrice", DbType.Currency);
            _FieldDbTypes.Add("RecyclingFee", DbType.Currency);
            _FieldDbTypes.Add("UnitEstimatedShippingCost", DbType.Currency);
            _FieldDbTypes.Add("GiftMessage", DbType.AnsiString);
            _FieldDbTypes.Add("GiftNotes", DbType.AnsiString);
            _FieldDbTypes.Add("GiftPrice", DbType.Currency);
            _FieldDbTypes.Add("GiftTaxPrice", DbType.Currency);
            _FieldDbTypes.Add("IsBundle", DbType.Boolean);
            _FieldDbTypes.Add("ItemURL", DbType.AnsiString);
            _FieldDbTypes.Add("HarmonizedCode", DbType.AnsiString);

            _FieldEnums = new BusinessLayerFieldEnumDictionary(27);
            _FieldEnums.Add("pk", StagingOrderItemsBOFieldNames.pk);
            _FieldEnums.Add("ID", StagingOrderItemsBOFieldNames.ID);
            _FieldEnums.Add("ProfileID", StagingOrderItemsBOFieldNames.ProfileID);
            _FieldEnums.Add("OrderID", StagingOrderItemsBOFieldNames.OrderID);
            _FieldEnums.Add("ProductID", StagingOrderItemsBOFieldNames.ProductID);
            _FieldEnums.Add("SiteOrderItemID", StagingOrderItemsBOFieldNames.SiteOrderItemID);
            _FieldEnums.Add("SellerOrderItemID", StagingOrderItemsBOFieldNames.SellerOrderItemID);
            _FieldEnums.Add("SiteListingID", StagingOrderItemsBOFieldNames.SiteListingID);
            _FieldEnums.Add("Sku", StagingOrderItemsBOFieldNames.Sku);
            _FieldEnums.Add("ReferenceSku", StagingOrderItemsBOFieldNames.ReferenceSku);
            _FieldEnums.Add("ReferenceProductID", StagingOrderItemsBOFieldNames.ReferenceProductID);
            _FieldEnums.Add("Title", StagingOrderItemsBOFieldNames.Title);
            _FieldEnums.Add("Quantity", StagingOrderItemsBOFieldNames.Quantity);
            _FieldEnums.Add("UnitPrice", StagingOrderItemsBOFieldNames.UnitPrice);
            _FieldEnums.Add("TaxPrice", StagingOrderItemsBOFieldNames.TaxPrice);
            _FieldEnums.Add("ShippingPrice", StagingOrderItemsBOFieldNames.ShippingPrice);
            _FieldEnums.Add("ShippingTaxPrice", StagingOrderItemsBOFieldNames.ShippingTaxPrice);
            _FieldEnums.Add("RecyclingFee", StagingOrderItemsBOFieldNames.RecyclingFee);
            _FieldEnums.Add("UnitEstimatedShippingCost", StagingOrderItemsBOFieldNames.UnitEstimatedShippingCost);
            _FieldEnums.Add("GiftMessage", StagingOrderItemsBOFieldNames.GiftMessage);
            _FieldEnums.Add("GiftNotes", StagingOrderItemsBOFieldNames.GiftNotes);
            _FieldEnums.Add("GiftPrice", StagingOrderItemsBOFieldNames.GiftPrice);
            _FieldEnums.Add("GiftTaxPrice", StagingOrderItemsBOFieldNames.GiftTaxPrice);
            _FieldEnums.Add("IsBundle", StagingOrderItemsBOFieldNames.IsBundle);
            _FieldEnums.Add("ItemURL", StagingOrderItemsBOFieldNames.ItemURL);
            _FieldEnums.Add("HarmonizedCode", StagingOrderItemsBOFieldNames.HarmonizedCode);
            _FieldEnums.Add("CUSTOM_FIELD", StagingOrderItemsBOFieldNames.CUSTOM_FIELD);

            _FieldLengths = new Dictionary<string, int>(26);
            _FieldLengths.Add("pk", 4);
            _FieldLengths.Add("ID", 8);
            _FieldLengths.Add("ProfileID", 8);
            _FieldLengths.Add("OrderID", 8);
            _FieldLengths.Add("ProductID", 8);
            _FieldLengths.Add("SiteOrderItemID", 20);
            _FieldLengths.Add("SellerOrderItemID", 20);
            _FieldLengths.Add("SiteListingID", 20);
            _FieldLengths.Add("Sku", 20);
            _FieldLengths.Add("ReferenceSku", 20);
            _FieldLengths.Add("ReferenceProductID", 20);
            _FieldLengths.Add("Title", 200);
            _FieldLengths.Add("Quantity", 4);
            _FieldLengths.Add("UnitPrice", 8);
            _FieldLengths.Add("TaxPrice", 8);
            _FieldLengths.Add("ShippingPrice", 8);
            _FieldLengths.Add("ShippingTaxPrice", 8);
            _FieldLengths.Add("RecyclingFee", 8);
            _FieldLengths.Add("UnitEstimatedShippingCost", 8);
            _FieldLengths.Add("GiftMessage", -1);
            _FieldLengths.Add("GiftNotes", -1);
            _FieldLengths.Add("GiftPrice", 8);
            _FieldLengths.Add("GiftTaxPrice", 8);
            _FieldLengths.Add("IsBundle", 1);
            _FieldLengths.Add("ItemURL", 200);
            _FieldLengths.Add("HarmonizedCode", 30);

            _FieldNativeDbTypes = new Dictionary<string, int>(26);
            _FieldNativeDbTypes.Add("pk", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("ID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("ProfileID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("OrderID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("ProductID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("SiteOrderItemID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SellerOrderItemID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SiteListingID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("Sku", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ReferenceSku", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ReferenceProductID", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("Title", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("Quantity", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("UnitPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("ShippingPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("ShippingTaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("RecyclingFee", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("UnitEstimatedShippingCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("GiftMessage", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("GiftNotes", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("GiftPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("GiftTaxPrice", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("IsBundle", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("ItemURL", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("HarmonizedCode", (int)System.Data.SqlDbType.VarChar);

            _FieldPermissionKeys = new Dictionary<string, string>(26);

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
        /// A PropertyDescriptor class used to Get and Set the value of fields within the StagingOrderItemsBO business object.
        /// </summary>
        private class FieldDescriptor :
        MicroFour.StrataFrame.Business.FieldPropertyDescriptor<StagingOrderItemsBOFieldNames>
        {
            public FieldDescriptor(StagingOrderItemsBOFieldNames field, Type fieldType) :
            base(field, fieldType)
            { }
            private static Type _ComponentType = typeof(StagingOrderItemsBO);
            public override object GetValue(object component)
            {
                switch (this.Field)
                {
                    case StagingOrderItemsBOFieldNames.pk:
                        return ((StagingOrderItemsBO)component).pk;
                    case StagingOrderItemsBOFieldNames.ID:
                        return ((StagingOrderItemsBO)component).ID;
                    case StagingOrderItemsBOFieldNames.ProfileID:
                        return ((StagingOrderItemsBO)component).ProfileID;
                    case StagingOrderItemsBOFieldNames.OrderID:
                        return ((StagingOrderItemsBO)component).OrderID;
                    case StagingOrderItemsBOFieldNames.ProductID:
                        return ((StagingOrderItemsBO)component).ProductID;
                    case StagingOrderItemsBOFieldNames.SiteOrderItemID:
                        return ((StagingOrderItemsBO)component).SiteOrderItemID;
                    case StagingOrderItemsBOFieldNames.SellerOrderItemID:
                        return ((StagingOrderItemsBO)component).SellerOrderItemID;
                    case StagingOrderItemsBOFieldNames.SiteListingID:
                        return ((StagingOrderItemsBO)component).SiteListingID;
                    case StagingOrderItemsBOFieldNames.Sku:
                        return ((StagingOrderItemsBO)component).Sku;
                    case StagingOrderItemsBOFieldNames.ReferenceSku:
                        return ((StagingOrderItemsBO)component).ReferenceSku;
                    case StagingOrderItemsBOFieldNames.ReferenceProductID:
                        return ((StagingOrderItemsBO)component).ReferenceProductID;
                    case StagingOrderItemsBOFieldNames.Title:
                        return ((StagingOrderItemsBO)component).Title;
                    case StagingOrderItemsBOFieldNames.Quantity:
                        return ((StagingOrderItemsBO)component).Quantity;
                    case StagingOrderItemsBOFieldNames.UnitPrice:
                        return ((StagingOrderItemsBO)component).UnitPrice;
                    case StagingOrderItemsBOFieldNames.TaxPrice:
                        return ((StagingOrderItemsBO)component).TaxPrice;
                    case StagingOrderItemsBOFieldNames.ShippingPrice:
                        return ((StagingOrderItemsBO)component).ShippingPrice;
                    case StagingOrderItemsBOFieldNames.ShippingTaxPrice:
                        return ((StagingOrderItemsBO)component).ShippingTaxPrice;
                    case StagingOrderItemsBOFieldNames.RecyclingFee:
                        return ((StagingOrderItemsBO)component).RecyclingFee;
                    case StagingOrderItemsBOFieldNames.UnitEstimatedShippingCost:
                        return ((StagingOrderItemsBO)component).UnitEstimatedShippingCost;
                    case StagingOrderItemsBOFieldNames.GiftMessage:
                        return ((StagingOrderItemsBO)component).GiftMessage;
                    case StagingOrderItemsBOFieldNames.GiftNotes:
                        return ((StagingOrderItemsBO)component).GiftNotes;
                    case StagingOrderItemsBOFieldNames.GiftPrice:
                        return ((StagingOrderItemsBO)component).GiftPrice;
                    case StagingOrderItemsBOFieldNames.GiftTaxPrice:
                        return ((StagingOrderItemsBO)component).GiftTaxPrice;
                    case StagingOrderItemsBOFieldNames.IsBundle:
                        return ((StagingOrderItemsBO)component).IsBundle;
                    case StagingOrderItemsBOFieldNames.ItemURL:
                        return ((StagingOrderItemsBO)component).ItemURL;
                    case StagingOrderItemsBOFieldNames.HarmonizedCode:
                        return ((StagingOrderItemsBO)component).HarmonizedCode;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override void SetValue(object component, object value)
            {
                switch (this.Field)
                {
                    case StagingOrderItemsBOFieldNames.pk:
                        ((StagingOrderItemsBO)component).pk = (System.Int32)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ID:
                        ((StagingOrderItemsBO)component).ID = (System.Int64)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ProfileID:
                        ((StagingOrderItemsBO)component).ProfileID = (System.Int64)value;
                        break;
                    case StagingOrderItemsBOFieldNames.OrderID:
                        ((StagingOrderItemsBO)component).OrderID = (System.Int64)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ProductID:
                        ((StagingOrderItemsBO)component).ProductID = (System.Int64)value;
                        break;
                    case StagingOrderItemsBOFieldNames.SiteOrderItemID:
                        ((StagingOrderItemsBO)component).SiteOrderItemID = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.SellerOrderItemID:
                        ((StagingOrderItemsBO)component).SellerOrderItemID = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.SiteListingID:
                        ((StagingOrderItemsBO)component).SiteListingID = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.Sku:
                        ((StagingOrderItemsBO)component).Sku = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ReferenceSku:
                        ((StagingOrderItemsBO)component).ReferenceSku = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ReferenceProductID:
                        ((StagingOrderItemsBO)component).ReferenceProductID = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.Title:
                        ((StagingOrderItemsBO)component).Title = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.Quantity:
                        ((StagingOrderItemsBO)component).Quantity = (System.Int32)value;
                        break;
                    case StagingOrderItemsBOFieldNames.UnitPrice:
                        ((StagingOrderItemsBO)component).UnitPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.TaxPrice:
                        ((StagingOrderItemsBO)component).TaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ShippingPrice:
                        ((StagingOrderItemsBO)component).ShippingPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ShippingTaxPrice:
                        ((StagingOrderItemsBO)component).ShippingTaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.RecyclingFee:
                        ((StagingOrderItemsBO)component).RecyclingFee = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.UnitEstimatedShippingCost:
                        ((StagingOrderItemsBO)component).UnitEstimatedShippingCost = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.GiftMessage:
                        ((StagingOrderItemsBO)component).GiftMessage = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.GiftNotes:
                        ((StagingOrderItemsBO)component).GiftNotes = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.GiftPrice:
                        ((StagingOrderItemsBO)component).GiftPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.GiftTaxPrice:
                        ((StagingOrderItemsBO)component).GiftTaxPrice = (System.Decimal)value;
                        break;
                    case StagingOrderItemsBOFieldNames.IsBundle:
                        ((StagingOrderItemsBO)component).IsBundle = (System.Boolean)value;
                        break;
                    case StagingOrderItemsBOFieldNames.ItemURL:
                        ((StagingOrderItemsBO)component).ItemURL = (System.String)value;
                        break;
                    case StagingOrderItemsBOFieldNames.HarmonizedCode:
                        ((StagingOrderItemsBO)component).HarmonizedCode = (System.String)value;
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
