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
    partial class StagingOrderFulfillmentsItemsBO
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

            this.CheckRulesOnCurrentRow += new CheckRulesOnCurrentRowEventHandler(StagingOrderFulfillmentsItemsBO_CheckRulesOnCurrentRow);
            this.SetDefaultValues += new SetDefaultValuesEventHandler(StagingOrderFulfillmentsItemsBO_SetDefaultValues);
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
                return "[pk],[ID],[Sku],[ProfileID],[FulfillmentID],[OrderID],[OrderItemID],[Quantity],[ProductID],[SellerFulfillmentItemID],[MarketplaceShippingStatus],[DistributionCenterItemUnitCost],[DistributionCenterShippingCost],[DistributionCenterCalculatedItemUnitCost],[DistributionCenterCalculatedShippingCost],[ReferenceSku],[ReferenceProductID],[WarehouseLocation]";
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
                return "StagingOrderFulfillmentsItems";
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
new DataColumn("ID", typeof(System.Int32)),
new DataColumn("Sku", typeof(System.String)),
new DataColumn("ProfileID", typeof(System.Int64)),
new DataColumn("FulfillmentID", typeof(System.Int64)),
new DataColumn("OrderID", typeof(System.Int64)),
new DataColumn("OrderItemID", typeof(System.Int64)),
new DataColumn("Quantity", typeof(System.Int32)),
new DataColumn("ProductID", typeof(System.Int64)),
new DataColumn("SellerFulfillmentItemID", typeof(System.Int64)),
new DataColumn("MarketplaceShippingStatus", typeof(System.String)),
new DataColumn("DistributionCenterItemUnitCost", typeof(System.Decimal)),
new DataColumn("DistributionCenterShippingCost", typeof(System.Decimal)),
new DataColumn("DistributionCenterCalculatedItemUnitCost", typeof(System.Decimal)),
new DataColumn("DistributionCenterCalculatedShippingCost", typeof(System.Decimal)),
new DataColumn("ReferenceSku", typeof(System.String)),
new DataColumn("ReferenceProductID", typeof(System.Int64)),
new DataColumn("WarehouseLocation", typeof(System.String))};
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected void AddBrokenRule(StagingOrderFulfillmentsItemsBOFieldNames Field, string ErrorMessage)
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
        protected void AddBrokenRuleByKey(StagingOrderFulfillmentsItemsBOFieldNames Field, string ErrorMessageKey)
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
        public System.Int32 ID
        {
            get
            {
                return (System.Int32)this.CurrentRow["ID"];
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
        public System.Int64 FulfillmentID
        {
            get
            {
                return (System.Int64)this.CurrentRow["FulfillmentID"];
            }
            set
            {
                this.CurrentRow["FulfillmentID"] = value;
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
        public System.Int64 OrderItemID
        {
            get
            {
                return (System.Int64)this.CurrentRow["OrderItemID"];
            }
            set
            {
                this.CurrentRow["OrderItemID"] = value;
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
        public System.Int64 SellerFulfillmentItemID
        {
            get
            {
                return (System.Int64)this.CurrentRow["SellerFulfillmentItemID"];
            }
            set
            {
                this.CurrentRow["SellerFulfillmentItemID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String MarketplaceShippingStatus
        {
            get
            {
                return (System.String)this.CurrentRow["MarketplaceShippingStatus"];
            }
            set
            {
                this.CurrentRow["MarketplaceShippingStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal DistributionCenterItemUnitCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["DistributionCenterItemUnitCost"];
            }
            set
            {
                this.CurrentRow["DistributionCenterItemUnitCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal DistributionCenterShippingCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["DistributionCenterShippingCost"];
            }
            set
            {
                this.CurrentRow["DistributionCenterShippingCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal DistributionCenterCalculatedItemUnitCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["DistributionCenterCalculatedItemUnitCost"];
            }
            set
            {
                this.CurrentRow["DistributionCenterCalculatedItemUnitCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal DistributionCenterCalculatedShippingCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["DistributionCenterCalculatedShippingCost"];
            }
            set
            {
                this.CurrentRow["DistributionCenterCalculatedShippingCost"] = value;
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
        public System.Int64 ReferenceProductID
        {
            get
            {
                return (System.Int64)this.CurrentRow["ReferenceProductID"];
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
        public System.String WarehouseLocation
        {
            get
            {
                return (System.String)this.CurrentRow["WarehouseLocation"];
            }
            set
            {
                this.CurrentRow["WarehouseLocation"] = value;
            }
        }

        #endregion

        #region Field Property Events 

        #endregion

        #region Nested Types & Field Security

        /// <summary>
        /// Contains all of the field names that belong to the business object.
        /// </summary>
        public enum StagingOrderFulfillmentsItemsBOFieldNames
        {
            pk,
            ID,
            Sku,
            ProfileID,
            FulfillmentID,
            OrderID,
            OrderItemID,
            Quantity,
            ProductID,
            SellerFulfillmentItemID,
            MarketplaceShippingStatus,
            DistributionCenterItemUnitCost,
            DistributionCenterShippingCost,
            DistributionCenterCalculatedItemUnitCost,
            DistributionCenterCalculatedShippingCost,
            ReferenceSku,
            ReferenceProductID,
            WarehouseLocation,
            CUSTOM_FIELD
        }

        /// <summary>
        /// Gets the System.Type of the enumeration that contains the field names for the business object.
        /// </summary>
        public override System.Type GetFieldEnumType()
        {
            return typeof(StagingOrderFulfillmentsItemsBOFieldNames);
        }

        /// <summary>
        /// Creates a new CheckFieldSecurityEventArgs object that can be used with this business object type.
        /// </summary>
        protected override CheckFieldSecurityEventArgsBase CreateNewFieldSecurityEventArgs(System.Enum Field, string CustomField, string PermissionKey, PermissionInfo Perm)
        {
            return new CheckFieldSecurityEventArgs<StagingOrderFulfillmentsItemsBOFieldNames>(Field, CustomField, PermissionKey, Perm);
        }

        /// <summary>
        /// Describes a method that will handle the CheckFieldScurity event.
        /// </summary>
        public delegate void CheckFieldSecurityEventHandler(object sender, CheckFieldSecurityEventArgs<StagingOrderFulfillmentsItemsBOFieldNames> e);

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
                this.CheckFieldSecurity(this, (CheckFieldSecurityEventArgs<StagingOrderFulfillmentsItemsBOFieldNames>)e);
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
        /// Initializes the static members of the StagingOrderFulfillmentsItemsBO class.
        /// </summary>
        static StagingOrderFulfillmentsItemsBO()
        {
            //-- Create the new shared dictionary and populate it with an 
            //   instance of each property descriptor
            _PropertyDescriptors = new PropertyDescriptorDictionary(23);
            _PropertyDescriptors.Add("pk", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.pk, typeof(System.Int32)));
            _PropertyDescriptors.Add("ID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.ID, typeof(System.Int32)));
            _PropertyDescriptors.Add("Sku", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.Sku, typeof(System.String)));
            _PropertyDescriptors.Add("ProfileID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.ProfileID, typeof(System.Int64)));
            _PropertyDescriptors.Add("FulfillmentID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.FulfillmentID, typeof(System.Int64)));
            _PropertyDescriptors.Add("OrderID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.OrderID, typeof(System.Int64)));
            _PropertyDescriptors.Add("OrderItemID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.OrderItemID, typeof(System.Int64)));
            _PropertyDescriptors.Add("Quantity", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.Quantity, typeof(System.Int32)));
            _PropertyDescriptors.Add("ProductID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.ProductID, typeof(System.Int64)));
            _PropertyDescriptors.Add("SellerFulfillmentItemID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.SellerFulfillmentItemID, typeof(System.Int64)));
            _PropertyDescriptors.Add("MarketplaceShippingStatus", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.MarketplaceShippingStatus, typeof(System.String)));
            _PropertyDescriptors.Add("DistributionCenterItemUnitCost", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterItemUnitCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("DistributionCenterShippingCost", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterShippingCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("DistributionCenterCalculatedItemUnitCost", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedItemUnitCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("DistributionCenterCalculatedShippingCost", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedShippingCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("ReferenceSku", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.ReferenceSku, typeof(System.String)));
            _PropertyDescriptors.Add("ReferenceProductID", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.ReferenceProductID, typeof(System.Int64)));
            _PropertyDescriptors.Add("WarehouseLocation", new FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames.WarehouseLocation, typeof(System.String)));

            _AllFieldsList = new List<string>(18);
            _AllFieldsList.Add("pk");
            _AllFieldsList.Add("ID");
            _AllFieldsList.Add("Sku");
            _AllFieldsList.Add("ProfileID");
            _AllFieldsList.Add("FulfillmentID");
            _AllFieldsList.Add("OrderID");
            _AllFieldsList.Add("OrderItemID");
            _AllFieldsList.Add("Quantity");
            _AllFieldsList.Add("ProductID");
            _AllFieldsList.Add("SellerFulfillmentItemID");
            _AllFieldsList.Add("MarketplaceShippingStatus");
            _AllFieldsList.Add("DistributionCenterItemUnitCost");
            _AllFieldsList.Add("DistributionCenterShippingCost");
            _AllFieldsList.Add("DistributionCenterCalculatedItemUnitCost");
            _AllFieldsList.Add("DistributionCenterCalculatedShippingCost");
            _AllFieldsList.Add("ReferenceSku");
            _AllFieldsList.Add("ReferenceProductID");
            _AllFieldsList.Add("WarehouseLocation");

            _FieldDbTypes = new Dictionary<string, DbType>(18);
            _FieldDbTypes.Add("pk", DbType.Int32);
            _FieldDbTypes.Add("ID", DbType.Int32);
            _FieldDbTypes.Add("Sku", DbType.AnsiString);
            _FieldDbTypes.Add("ProfileID", DbType.Int64);
            _FieldDbTypes.Add("FulfillmentID", DbType.Int64);
            _FieldDbTypes.Add("OrderID", DbType.Int64);
            _FieldDbTypes.Add("OrderItemID", DbType.Int64);
            _FieldDbTypes.Add("Quantity", DbType.Int32);
            _FieldDbTypes.Add("ProductID", DbType.Int64);
            _FieldDbTypes.Add("SellerFulfillmentItemID", DbType.Int64);
            _FieldDbTypes.Add("MarketplaceShippingStatus", DbType.AnsiString);
            _FieldDbTypes.Add("DistributionCenterItemUnitCost", DbType.Currency);
            _FieldDbTypes.Add("DistributionCenterShippingCost", DbType.Currency);
            _FieldDbTypes.Add("DistributionCenterCalculatedItemUnitCost", DbType.Currency);
            _FieldDbTypes.Add("DistributionCenterCalculatedShippingCost", DbType.Currency);
            _FieldDbTypes.Add("ReferenceSku", DbType.AnsiString);
            _FieldDbTypes.Add("ReferenceProductID", DbType.Int64);
            _FieldDbTypes.Add("WarehouseLocation", DbType.AnsiString);

            _FieldEnums = new BusinessLayerFieldEnumDictionary(19);
            _FieldEnums.Add("pk", StagingOrderFulfillmentsItemsBOFieldNames.pk);
            _FieldEnums.Add("ID", StagingOrderFulfillmentsItemsBOFieldNames.ID);
            _FieldEnums.Add("Sku", StagingOrderFulfillmentsItemsBOFieldNames.Sku);
            _FieldEnums.Add("ProfileID", StagingOrderFulfillmentsItemsBOFieldNames.ProfileID);
            _FieldEnums.Add("FulfillmentID", StagingOrderFulfillmentsItemsBOFieldNames.FulfillmentID);
            _FieldEnums.Add("OrderID", StagingOrderFulfillmentsItemsBOFieldNames.OrderID);
            _FieldEnums.Add("OrderItemID", StagingOrderFulfillmentsItemsBOFieldNames.OrderItemID);
            _FieldEnums.Add("Quantity", StagingOrderFulfillmentsItemsBOFieldNames.Quantity);
            _FieldEnums.Add("ProductID", StagingOrderFulfillmentsItemsBOFieldNames.ProductID);
            _FieldEnums.Add("SellerFulfillmentItemID", StagingOrderFulfillmentsItemsBOFieldNames.SellerFulfillmentItemID);
            _FieldEnums.Add("MarketplaceShippingStatus", StagingOrderFulfillmentsItemsBOFieldNames.MarketplaceShippingStatus);
            _FieldEnums.Add("DistributionCenterItemUnitCost", StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterItemUnitCost);
            _FieldEnums.Add("DistributionCenterShippingCost", StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterShippingCost);
            _FieldEnums.Add("DistributionCenterCalculatedItemUnitCost", StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedItemUnitCost);
            _FieldEnums.Add("DistributionCenterCalculatedShippingCost", StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedShippingCost);
            _FieldEnums.Add("ReferenceSku", StagingOrderFulfillmentsItemsBOFieldNames.ReferenceSku);
            _FieldEnums.Add("ReferenceProductID", StagingOrderFulfillmentsItemsBOFieldNames.ReferenceProductID);
            _FieldEnums.Add("WarehouseLocation", StagingOrderFulfillmentsItemsBOFieldNames.WarehouseLocation);
            _FieldEnums.Add("CUSTOM_FIELD", StagingOrderFulfillmentsItemsBOFieldNames.CUSTOM_FIELD);

            _FieldLengths = new Dictionary<string, int>(18);
            _FieldLengths.Add("pk", 4);
            _FieldLengths.Add("ID", 4);
            _FieldLengths.Add("Sku", 20);
            _FieldLengths.Add("ProfileID", 8);
            _FieldLengths.Add("FulfillmentID", 8);
            _FieldLengths.Add("OrderID", 8);
            _FieldLengths.Add("OrderItemID", 8);
            _FieldLengths.Add("Quantity", 4);
            _FieldLengths.Add("ProductID", 8);
            _FieldLengths.Add("SellerFulfillmentItemID", 8);
            _FieldLengths.Add("MarketplaceShippingStatus", 20);
            _FieldLengths.Add("DistributionCenterItemUnitCost", 8);
            _FieldLengths.Add("DistributionCenterShippingCost", 8);
            _FieldLengths.Add("DistributionCenterCalculatedItemUnitCost", 8);
            _FieldLengths.Add("DistributionCenterCalculatedShippingCost", 8);
            _FieldLengths.Add("ReferenceSku", 20);
            _FieldLengths.Add("ReferenceProductID", 8);
            _FieldLengths.Add("WarehouseLocation", 30);

            _FieldNativeDbTypes = new Dictionary<string, int>(18);
            _FieldNativeDbTypes.Add("pk", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("ID", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("Sku", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ProfileID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("FulfillmentID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("OrderID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("OrderItemID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("Quantity", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("ProductID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("SellerFulfillmentItemID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("MarketplaceShippingStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("DistributionCenterItemUnitCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("DistributionCenterShippingCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("DistributionCenterCalculatedItemUnitCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("DistributionCenterCalculatedShippingCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("ReferenceSku", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ReferenceProductID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("WarehouseLocation", (int)System.Data.SqlDbType.VarChar);

            _FieldPermissionKeys = new Dictionary<string, string>(18);

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
        /// A PropertyDescriptor class used to Get and Set the value of fields within the StagingOrderFulfillmentsItemsBO business object.
        /// </summary>
        private class FieldDescriptor :
        MicroFour.StrataFrame.Business.FieldPropertyDescriptor<StagingOrderFulfillmentsItemsBOFieldNames>
        {
            public FieldDescriptor(StagingOrderFulfillmentsItemsBOFieldNames field, Type fieldType) :
            base(field, fieldType)
            { }
            private static Type _ComponentType = typeof(StagingOrderFulfillmentsItemsBO);
            public override object GetValue(object component)
            {
                switch (this.Field)
                {
                    case StagingOrderFulfillmentsItemsBOFieldNames.pk:
                        return ((StagingOrderFulfillmentsItemsBO)component).pk;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ID:
                        return ((StagingOrderFulfillmentsItemsBO)component).ID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.Sku:
                        return ((StagingOrderFulfillmentsItemsBO)component).Sku;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ProfileID:
                        return ((StagingOrderFulfillmentsItemsBO)component).ProfileID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.FulfillmentID:
                        return ((StagingOrderFulfillmentsItemsBO)component).FulfillmentID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.OrderID:
                        return ((StagingOrderFulfillmentsItemsBO)component).OrderID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.OrderItemID:
                        return ((StagingOrderFulfillmentsItemsBO)component).OrderItemID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.Quantity:
                        return ((StagingOrderFulfillmentsItemsBO)component).Quantity;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ProductID:
                        return ((StagingOrderFulfillmentsItemsBO)component).ProductID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.SellerFulfillmentItemID:
                        return ((StagingOrderFulfillmentsItemsBO)component).SellerFulfillmentItemID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.MarketplaceShippingStatus:
                        return ((StagingOrderFulfillmentsItemsBO)component).MarketplaceShippingStatus;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterItemUnitCost:
                        return ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterItemUnitCost;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterShippingCost:
                        return ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterShippingCost;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedItemUnitCost:
                        return ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterCalculatedItemUnitCost;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedShippingCost:
                        return ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterCalculatedShippingCost;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ReferenceSku:
                        return ((StagingOrderFulfillmentsItemsBO)component).ReferenceSku;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ReferenceProductID:
                        return ((StagingOrderFulfillmentsItemsBO)component).ReferenceProductID;
                    case StagingOrderFulfillmentsItemsBOFieldNames.WarehouseLocation:
                        return ((StagingOrderFulfillmentsItemsBO)component).WarehouseLocation;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override void SetValue(object component, object value)
            {
                switch (this.Field)
                {
                    case StagingOrderFulfillmentsItemsBOFieldNames.pk:
                        ((StagingOrderFulfillmentsItemsBO)component).pk = (System.Int32)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ID:
                        ((StagingOrderFulfillmentsItemsBO)component).ID = (System.Int32)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.Sku:
                        ((StagingOrderFulfillmentsItemsBO)component).Sku = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ProfileID:
                        ((StagingOrderFulfillmentsItemsBO)component).ProfileID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.FulfillmentID:
                        ((StagingOrderFulfillmentsItemsBO)component).FulfillmentID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.OrderID:
                        ((StagingOrderFulfillmentsItemsBO)component).OrderID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.OrderItemID:
                        ((StagingOrderFulfillmentsItemsBO)component).OrderItemID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.Quantity:
                        ((StagingOrderFulfillmentsItemsBO)component).Quantity = (System.Int32)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ProductID:
                        ((StagingOrderFulfillmentsItemsBO)component).ProductID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.SellerFulfillmentItemID:
                        ((StagingOrderFulfillmentsItemsBO)component).SellerFulfillmentItemID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.MarketplaceShippingStatus:
                        ((StagingOrderFulfillmentsItemsBO)component).MarketplaceShippingStatus = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterItemUnitCost:
                        ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterItemUnitCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterShippingCost:
                        ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterShippingCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedItemUnitCost:
                        ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterCalculatedItemUnitCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.DistributionCenterCalculatedShippingCost:
                        ((StagingOrderFulfillmentsItemsBO)component).DistributionCenterCalculatedShippingCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ReferenceSku:
                        ((StagingOrderFulfillmentsItemsBO)component).ReferenceSku = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.ReferenceProductID:
                        ((StagingOrderFulfillmentsItemsBO)component).ReferenceProductID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsItemsBOFieldNames.WarehouseLocation:
                        ((StagingOrderFulfillmentsItemsBO)component).WarehouseLocation = (System.String)value;
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
