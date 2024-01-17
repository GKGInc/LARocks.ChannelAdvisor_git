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
    partial class StagingOrderFulfillmentsBO
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

            this.CheckRulesOnCurrentRow += new CheckRulesOnCurrentRowEventHandler(StagingOrderFulfillmentsBO_CheckRulesOnCurrentRow);
            this.SetDefaultValues += new SetDefaultValuesEventHandler(StagingOrderFulfillmentsBO_SetDefaultValues);
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
                return "[pk],[ID],[ProfileID],[OrderID],[CreatedDateUtc],[UpdatedDateUtc],[Type],[DeliveryStatus],[TrackingNumber],[ShippingCarrier],[ShippingClass],[DistributionCenterID],[ExternalFulfillmentCenterCode],[ExternalFulfillmentStatus],[ShippingCost],[InsuranceCost],[TaxCost],[ShippedDateUtc],[SellerFulfillmentID],[HasShippingLabel],[HasChannelPackingSlip],[HasReturnLabel],[HasChannelReturnLabel],[ExternalFulfillmentNumber],[ExternalFulfillmentReferenceNumber],[ShippingLabelRequestID],[StagingLocation],[LabelFormat],[ReturnLabelFormat],[ChannelReturnLabelFormat]";
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
                return "StagingOrderFulfillments";
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
new DataColumn("CreatedDateUtc", typeof(System.DateTime)),
new DataColumn("UpdatedDateUtc", typeof(System.DateTime)),
new DataColumn("Type", typeof(System.String)),
new DataColumn("DeliveryStatus", typeof(System.String)),
new DataColumn("TrackingNumber", typeof(System.String)),
new DataColumn("ShippingCarrier", typeof(System.String)),
new DataColumn("ShippingClass", typeof(System.String)),
new DataColumn("DistributionCenterID", typeof(System.Int64)),
new DataColumn("ExternalFulfillmentCenterCode", typeof(System.String)),
new DataColumn("ExternalFulfillmentStatus", typeof(System.String)),
new DataColumn("ShippingCost", typeof(System.Decimal)),
new DataColumn("InsuranceCost", typeof(System.Decimal)),
new DataColumn("TaxCost", typeof(System.Decimal)),
new DataColumn("ShippedDateUtc", typeof(System.DateTime)),
new DataColumn("SellerFulfillmentID", typeof(System.Int64)),
new DataColumn("HasShippingLabel", typeof(System.Boolean)),
new DataColumn("HasChannelPackingSlip", typeof(System.Boolean)),
new DataColumn("HasReturnLabel", typeof(System.Boolean)),
new DataColumn("HasChannelReturnLabel", typeof(System.Boolean)),
new DataColumn("ExternalFulfillmentNumber", typeof(System.String)),
new DataColumn("ExternalFulfillmentReferenceNumber", typeof(System.String)),
new DataColumn("ShippingLabelRequestID", typeof(System.Int64)),
new DataColumn("StagingLocation", typeof(System.String)),
new DataColumn("LabelFormat", typeof(System.String)),
new DataColumn("ReturnLabelFormat", typeof(System.String)),
new DataColumn("ChannelReturnLabelFormat", typeof(System.String))};
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected void AddBrokenRule(StagingOrderFulfillmentsBOFieldNames Field, string ErrorMessage)
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
        protected void AddBrokenRuleByKey(StagingOrderFulfillmentsBOFieldNames Field, string ErrorMessageKey)
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
        public System.String Type
        {
            get
            {
                return (System.String)this.CurrentRow["Type"];
            }
            set
            {
                this.CurrentRow["Type"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String DeliveryStatus
        {
            get
            {
                return (System.String)this.CurrentRow["DeliveryStatus"];
            }
            set
            {
                this.CurrentRow["DeliveryStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String TrackingNumber
        {
            get
            {
                return (System.String)this.CurrentRow["TrackingNumber"];
            }
            set
            {
                this.CurrentRow["TrackingNumber"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingCarrier
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingCarrier"];
            }
            set
            {
                this.CurrentRow["ShippingCarrier"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ShippingClass
        {
            get
            {
                return (System.String)this.CurrentRow["ShippingClass"];
            }
            set
            {
                this.CurrentRow["ShippingClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 DistributionCenterID
        {
            get
            {
                return (System.Int64)this.CurrentRow["DistributionCenterID"];
            }
            set
            {
                this.CurrentRow["DistributionCenterID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ExternalFulfillmentCenterCode
        {
            get
            {
                return (System.String)this.CurrentRow["ExternalFulfillmentCenterCode"];
            }
            set
            {
                this.CurrentRow["ExternalFulfillmentCenterCode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ExternalFulfillmentStatus
        {
            get
            {
                return (System.String)this.CurrentRow["ExternalFulfillmentStatus"];
            }
            set
            {
                this.CurrentRow["ExternalFulfillmentStatus"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal ShippingCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["ShippingCost"];
            }
            set
            {
                this.CurrentRow["ShippingCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal InsuranceCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["InsuranceCost"];
            }
            set
            {
                this.CurrentRow["InsuranceCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Decimal TaxCost
        {
            get
            {
                return (System.Decimal)this.CurrentRow["TaxCost"];
            }
            set
            {
                this.CurrentRow["TaxCost"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.DateTime ShippedDateUtc
        {
            get
            {
                return (System.DateTime)this.CurrentRow["ShippedDateUtc"];
            }
            set
            {
                this.CurrentRow["ShippedDateUtc"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 SellerFulfillmentID
        {
            get
            {
                return (System.Int64)this.CurrentRow["SellerFulfillmentID"];
            }
            set
            {
                this.CurrentRow["SellerFulfillmentID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean HasShippingLabel
        {
            get
            {
                return (System.Boolean)this.CurrentRow["HasShippingLabel"];
            }
            set
            {
                this.CurrentRow["HasShippingLabel"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean HasChannelPackingSlip
        {
            get
            {
                return (System.Boolean)this.CurrentRow["HasChannelPackingSlip"];
            }
            set
            {
                this.CurrentRow["HasChannelPackingSlip"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean HasReturnLabel
        {
            get
            {
                return (System.Boolean)this.CurrentRow["HasReturnLabel"];
            }
            set
            {
                this.CurrentRow["HasReturnLabel"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Boolean HasChannelReturnLabel
        {
            get
            {
                return (System.Boolean)this.CurrentRow["HasChannelReturnLabel"];
            }
            set
            {
                this.CurrentRow["HasChannelReturnLabel"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ExternalFulfillmentNumber
        {
            get
            {
                return (System.String)this.CurrentRow["ExternalFulfillmentNumber"];
            }
            set
            {
                this.CurrentRow["ExternalFulfillmentNumber"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ExternalFulfillmentReferenceNumber
        {
            get
            {
                return (System.String)this.CurrentRow["ExternalFulfillmentReferenceNumber"];
            }
            set
            {
                this.CurrentRow["ExternalFulfillmentReferenceNumber"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.Int64 ShippingLabelRequestID
        {
            get
            {
                return (System.Int64)this.CurrentRow["ShippingLabelRequestID"];
            }
            set
            {
                this.CurrentRow["ShippingLabelRequestID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String StagingLocation
        {
            get
            {
                return (System.String)this.CurrentRow["StagingLocation"];
            }
            set
            {
                this.CurrentRow["StagingLocation"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String LabelFormat
        {
            get
            {
                return (System.String)this.CurrentRow["LabelFormat"];
            }
            set
            {
                this.CurrentRow["LabelFormat"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ReturnLabelFormat
        {
            get
            {
                return (System.String)this.CurrentRow["ReturnLabelFormat"];
            }
            set
            {
                this.CurrentRow["ReturnLabelFormat"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description(""),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String ChannelReturnLabelFormat
        {
            get
            {
                return (System.String)this.CurrentRow["ChannelReturnLabelFormat"];
            }
            set
            {
                this.CurrentRow["ChannelReturnLabelFormat"] = value;
            }
        }

        #endregion

        #region Field Property Events 

        #endregion

        #region Nested Types & Field Security

        /// <summary>
        /// Contains all of the field names that belong to the business object.
        /// </summary>
        public enum StagingOrderFulfillmentsBOFieldNames
        {
            pk,
            ID,
            ProfileID,
            OrderID,
            CreatedDateUtc,
            UpdatedDateUtc,
            Type,
            DeliveryStatus,
            TrackingNumber,
            ShippingCarrier,
            ShippingClass,
            DistributionCenterID,
            ExternalFulfillmentCenterCode,
            ExternalFulfillmentStatus,
            ShippingCost,
            InsuranceCost,
            TaxCost,
            ShippedDateUtc,
            SellerFulfillmentID,
            HasShippingLabel,
            HasChannelPackingSlip,
            HasReturnLabel,
            HasChannelReturnLabel,
            ExternalFulfillmentNumber,
            ExternalFulfillmentReferenceNumber,
            ShippingLabelRequestID,
            StagingLocation,
            LabelFormat,
            ReturnLabelFormat,
            ChannelReturnLabelFormat,
            CUSTOM_FIELD
        }

        /// <summary>
        /// Gets the System.Type of the enumeration that contains the field names for the business object.
        /// </summary>
        public override System.Type GetFieldEnumType()
        {
            return typeof(StagingOrderFulfillmentsBOFieldNames);
        }

        /// <summary>
        /// Creates a new CheckFieldSecurityEventArgs object that can be used with this business object type.
        /// </summary>
        protected override CheckFieldSecurityEventArgsBase CreateNewFieldSecurityEventArgs(System.Enum Field, string CustomField, string PermissionKey, PermissionInfo Perm)
        {
            return new CheckFieldSecurityEventArgs<StagingOrderFulfillmentsBOFieldNames>(Field, CustomField, PermissionKey, Perm);
        }

        /// <summary>
        /// Describes a method that will handle the CheckFieldScurity event.
        /// </summary>
        public delegate void CheckFieldSecurityEventHandler(object sender, CheckFieldSecurityEventArgs<StagingOrderFulfillmentsBOFieldNames> e);

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
                this.CheckFieldSecurity(this, (CheckFieldSecurityEventArgs<StagingOrderFulfillmentsBOFieldNames>)e);
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
        /// Initializes the static members of the StagingOrderFulfillmentsBO class.
        /// </summary>
        static StagingOrderFulfillmentsBO()
        {
            //-- Create the new shared dictionary and populate it with an 
            //   instance of each property descriptor
            _PropertyDescriptors = new PropertyDescriptorDictionary(35);
            _PropertyDescriptors.Add("pk", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.pk, typeof(System.Int32)));
            _PropertyDescriptors.Add("ID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ID, typeof(System.Int64)));
            _PropertyDescriptors.Add("ProfileID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ProfileID, typeof(System.Int64)));
            _PropertyDescriptors.Add("OrderID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.OrderID, typeof(System.Int64)));
            _PropertyDescriptors.Add("CreatedDateUtc", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.CreatedDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("UpdatedDateUtc", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.UpdatedDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("Type", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.Type, typeof(System.String)));
            _PropertyDescriptors.Add("DeliveryStatus", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.DeliveryStatus, typeof(System.String)));
            _PropertyDescriptors.Add("TrackingNumber", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.TrackingNumber, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCarrier", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ShippingCarrier, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingClass", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ShippingClass, typeof(System.String)));
            _PropertyDescriptors.Add("DistributionCenterID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.DistributionCenterID, typeof(System.Int64)));
            _PropertyDescriptors.Add("ExternalFulfillmentCenterCode", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentCenterCode, typeof(System.String)));
            _PropertyDescriptors.Add("ExternalFulfillmentStatus", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentStatus, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingCost", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ShippingCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("InsuranceCost", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.InsuranceCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("TaxCost", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.TaxCost, typeof(System.Decimal)));
            _PropertyDescriptors.Add("ShippedDateUtc", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ShippedDateUtc, typeof(System.DateTime)));
            _PropertyDescriptors.Add("SellerFulfillmentID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.SellerFulfillmentID, typeof(System.Int64)));
            _PropertyDescriptors.Add("HasShippingLabel", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.HasShippingLabel, typeof(System.Boolean)));
            _PropertyDescriptors.Add("HasChannelPackingSlip", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.HasChannelPackingSlip, typeof(System.Boolean)));
            _PropertyDescriptors.Add("HasReturnLabel", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.HasReturnLabel, typeof(System.Boolean)));
            _PropertyDescriptors.Add("HasChannelReturnLabel", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.HasChannelReturnLabel, typeof(System.Boolean)));
            _PropertyDescriptors.Add("ExternalFulfillmentNumber", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentNumber, typeof(System.String)));
            _PropertyDescriptors.Add("ExternalFulfillmentReferenceNumber", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentReferenceNumber, typeof(System.String)));
            _PropertyDescriptors.Add("ShippingLabelRequestID", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ShippingLabelRequestID, typeof(System.Int64)));
            _PropertyDescriptors.Add("StagingLocation", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.StagingLocation, typeof(System.String)));
            _PropertyDescriptors.Add("LabelFormat", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.LabelFormat, typeof(System.String)));
            _PropertyDescriptors.Add("ReturnLabelFormat", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ReturnLabelFormat, typeof(System.String)));
            _PropertyDescriptors.Add("ChannelReturnLabelFormat", new FieldDescriptor(StagingOrderFulfillmentsBOFieldNames.ChannelReturnLabelFormat, typeof(System.String)));

            _AllFieldsList = new List<string>(30);
            _AllFieldsList.Add("pk");
            _AllFieldsList.Add("ID");
            _AllFieldsList.Add("ProfileID");
            _AllFieldsList.Add("OrderID");
            _AllFieldsList.Add("CreatedDateUtc");
            _AllFieldsList.Add("UpdatedDateUtc");
            _AllFieldsList.Add("Type");
            _AllFieldsList.Add("DeliveryStatus");
            _AllFieldsList.Add("TrackingNumber");
            _AllFieldsList.Add("ShippingCarrier");
            _AllFieldsList.Add("ShippingClass");
            _AllFieldsList.Add("DistributionCenterID");
            _AllFieldsList.Add("ExternalFulfillmentCenterCode");
            _AllFieldsList.Add("ExternalFulfillmentStatus");
            _AllFieldsList.Add("ShippingCost");
            _AllFieldsList.Add("InsuranceCost");
            _AllFieldsList.Add("TaxCost");
            _AllFieldsList.Add("ShippedDateUtc");
            _AllFieldsList.Add("SellerFulfillmentID");
            _AllFieldsList.Add("HasShippingLabel");
            _AllFieldsList.Add("HasChannelPackingSlip");
            _AllFieldsList.Add("HasReturnLabel");
            _AllFieldsList.Add("HasChannelReturnLabel");
            _AllFieldsList.Add("ExternalFulfillmentNumber");
            _AllFieldsList.Add("ExternalFulfillmentReferenceNumber");
            _AllFieldsList.Add("ShippingLabelRequestID");
            _AllFieldsList.Add("StagingLocation");
            _AllFieldsList.Add("LabelFormat");
            _AllFieldsList.Add("ReturnLabelFormat");
            _AllFieldsList.Add("ChannelReturnLabelFormat");

            _FieldDbTypes = new Dictionary<string, DbType>(30);
            _FieldDbTypes.Add("pk", DbType.Int32);
            _FieldDbTypes.Add("ID", DbType.Int64);
            _FieldDbTypes.Add("ProfileID", DbType.Int64);
            _FieldDbTypes.Add("OrderID", DbType.Int64);
            _FieldDbTypes.Add("CreatedDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("UpdatedDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("Type", DbType.AnsiString);
            _FieldDbTypes.Add("DeliveryStatus", DbType.AnsiString);
            _FieldDbTypes.Add("TrackingNumber", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCarrier", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingClass", DbType.AnsiString);
            _FieldDbTypes.Add("DistributionCenterID", DbType.Int64);
            _FieldDbTypes.Add("ExternalFulfillmentCenterCode", DbType.AnsiString);
            _FieldDbTypes.Add("ExternalFulfillmentStatus", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingCost", DbType.Currency);
            _FieldDbTypes.Add("InsuranceCost", DbType.Currency);
            _FieldDbTypes.Add("TaxCost", DbType.Currency);
            _FieldDbTypes.Add("ShippedDateUtc", DbType.DateTime);
            _FieldDbTypes.Add("SellerFulfillmentID", DbType.Int64);
            _FieldDbTypes.Add("HasShippingLabel", DbType.Boolean);
            _FieldDbTypes.Add("HasChannelPackingSlip", DbType.Boolean);
            _FieldDbTypes.Add("HasReturnLabel", DbType.Boolean);
            _FieldDbTypes.Add("HasChannelReturnLabel", DbType.Boolean);
            _FieldDbTypes.Add("ExternalFulfillmentNumber", DbType.AnsiString);
            _FieldDbTypes.Add("ExternalFulfillmentReferenceNumber", DbType.AnsiString);
            _FieldDbTypes.Add("ShippingLabelRequestID", DbType.Int64);
            _FieldDbTypes.Add("StagingLocation", DbType.AnsiString);
            _FieldDbTypes.Add("LabelFormat", DbType.AnsiString);
            _FieldDbTypes.Add("ReturnLabelFormat", DbType.AnsiString);
            _FieldDbTypes.Add("ChannelReturnLabelFormat", DbType.AnsiString);

            _FieldEnums = new BusinessLayerFieldEnumDictionary(31);
            _FieldEnums.Add("pk", StagingOrderFulfillmentsBOFieldNames.pk);
            _FieldEnums.Add("ID", StagingOrderFulfillmentsBOFieldNames.ID);
            _FieldEnums.Add("ProfileID", StagingOrderFulfillmentsBOFieldNames.ProfileID);
            _FieldEnums.Add("OrderID", StagingOrderFulfillmentsBOFieldNames.OrderID);
            _FieldEnums.Add("CreatedDateUtc", StagingOrderFulfillmentsBOFieldNames.CreatedDateUtc);
            _FieldEnums.Add("UpdatedDateUtc", StagingOrderFulfillmentsBOFieldNames.UpdatedDateUtc);
            _FieldEnums.Add("Type", StagingOrderFulfillmentsBOFieldNames.Type);
            _FieldEnums.Add("DeliveryStatus", StagingOrderFulfillmentsBOFieldNames.DeliveryStatus);
            _FieldEnums.Add("TrackingNumber", StagingOrderFulfillmentsBOFieldNames.TrackingNumber);
            _FieldEnums.Add("ShippingCarrier", StagingOrderFulfillmentsBOFieldNames.ShippingCarrier);
            _FieldEnums.Add("ShippingClass", StagingOrderFulfillmentsBOFieldNames.ShippingClass);
            _FieldEnums.Add("DistributionCenterID", StagingOrderFulfillmentsBOFieldNames.DistributionCenterID);
            _FieldEnums.Add("ExternalFulfillmentCenterCode", StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentCenterCode);
            _FieldEnums.Add("ExternalFulfillmentStatus", StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentStatus);
            _FieldEnums.Add("ShippingCost", StagingOrderFulfillmentsBOFieldNames.ShippingCost);
            _FieldEnums.Add("InsuranceCost", StagingOrderFulfillmentsBOFieldNames.InsuranceCost);
            _FieldEnums.Add("TaxCost", StagingOrderFulfillmentsBOFieldNames.TaxCost);
            _FieldEnums.Add("ShippedDateUtc", StagingOrderFulfillmentsBOFieldNames.ShippedDateUtc);
            _FieldEnums.Add("SellerFulfillmentID", StagingOrderFulfillmentsBOFieldNames.SellerFulfillmentID);
            _FieldEnums.Add("HasShippingLabel", StagingOrderFulfillmentsBOFieldNames.HasShippingLabel);
            _FieldEnums.Add("HasChannelPackingSlip", StagingOrderFulfillmentsBOFieldNames.HasChannelPackingSlip);
            _FieldEnums.Add("HasReturnLabel", StagingOrderFulfillmentsBOFieldNames.HasReturnLabel);
            _FieldEnums.Add("HasChannelReturnLabel", StagingOrderFulfillmentsBOFieldNames.HasChannelReturnLabel);
            _FieldEnums.Add("ExternalFulfillmentNumber", StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentNumber);
            _FieldEnums.Add("ExternalFulfillmentReferenceNumber", StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentReferenceNumber);
            _FieldEnums.Add("ShippingLabelRequestID", StagingOrderFulfillmentsBOFieldNames.ShippingLabelRequestID);
            _FieldEnums.Add("StagingLocation", StagingOrderFulfillmentsBOFieldNames.StagingLocation);
            _FieldEnums.Add("LabelFormat", StagingOrderFulfillmentsBOFieldNames.LabelFormat);
            _FieldEnums.Add("ReturnLabelFormat", StagingOrderFulfillmentsBOFieldNames.ReturnLabelFormat);
            _FieldEnums.Add("ChannelReturnLabelFormat", StagingOrderFulfillmentsBOFieldNames.ChannelReturnLabelFormat);
            _FieldEnums.Add("CUSTOM_FIELD", StagingOrderFulfillmentsBOFieldNames.CUSTOM_FIELD);

            _FieldLengths = new Dictionary<string, int>(30);
            _FieldLengths.Add("pk", 4);
            _FieldLengths.Add("ID", 8);
            _FieldLengths.Add("ProfileID", 8);
            _FieldLengths.Add("OrderID", 8);
            _FieldLengths.Add("CreatedDateUtc", 7);
            _FieldLengths.Add("UpdatedDateUtc", 8);
            _FieldLengths.Add("Type", 20);
            _FieldLengths.Add("DeliveryStatus", 20);
            _FieldLengths.Add("TrackingNumber", 20);
            _FieldLengths.Add("ShippingCarrier", 20);
            _FieldLengths.Add("ShippingClass", 20);
            _FieldLengths.Add("DistributionCenterID", 8);
            _FieldLengths.Add("ExternalFulfillmentCenterCode", 20);
            _FieldLengths.Add("ExternalFulfillmentStatus", 20);
            _FieldLengths.Add("ShippingCost", 8);
            _FieldLengths.Add("InsuranceCost", 8);
            _FieldLengths.Add("TaxCost", 8);
            _FieldLengths.Add("ShippedDateUtc", 8);
            _FieldLengths.Add("SellerFulfillmentID", 8);
            _FieldLengths.Add("HasShippingLabel", 1);
            _FieldLengths.Add("HasChannelPackingSlip", 1);
            _FieldLengths.Add("HasReturnLabel", 1);
            _FieldLengths.Add("HasChannelReturnLabel", 1);
            _FieldLengths.Add("ExternalFulfillmentNumber", 30);
            _FieldLengths.Add("ExternalFulfillmentReferenceNumber", 30);
            _FieldLengths.Add("ShippingLabelRequestID", 8);
            _FieldLengths.Add("StagingLocation", 30);
            _FieldLengths.Add("LabelFormat", 100);
            _FieldLengths.Add("ReturnLabelFormat", 100);
            _FieldLengths.Add("ChannelReturnLabelFormat", 100);

            _FieldNativeDbTypes = new Dictionary<string, int>(30);
            _FieldNativeDbTypes.Add("pk", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("ID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("ProfileID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("OrderID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("CreatedDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("UpdatedDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("Type", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("DeliveryStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("TrackingNumber", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCarrier", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingClass", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("DistributionCenterID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("ExternalFulfillmentCenterCode", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ExternalFulfillmentStatus", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("InsuranceCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("TaxCost", (int)System.Data.SqlDbType.Money);
            _FieldNativeDbTypes.Add("ShippedDateUtc", (int)System.Data.SqlDbType.DateTime);
            _FieldNativeDbTypes.Add("SellerFulfillmentID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("HasShippingLabel", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("HasChannelPackingSlip", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("HasReturnLabel", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("HasChannelReturnLabel", (int)System.Data.SqlDbType.Bit);
            _FieldNativeDbTypes.Add("ExternalFulfillmentNumber", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ExternalFulfillmentReferenceNumber", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ShippingLabelRequestID", (int)System.Data.SqlDbType.BigInt);
            _FieldNativeDbTypes.Add("StagingLocation", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("LabelFormat", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ReturnLabelFormat", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("ChannelReturnLabelFormat", (int)System.Data.SqlDbType.VarChar);

            _FieldPermissionKeys = new Dictionary<string, string>(30);

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
        /// A PropertyDescriptor class used to Get and Set the value of fields within the StagingOrderFulfillmentsBO business object.
        /// </summary>
        private class FieldDescriptor :
        MicroFour.StrataFrame.Business.FieldPropertyDescriptor<StagingOrderFulfillmentsBOFieldNames>
        {
            public FieldDescriptor(StagingOrderFulfillmentsBOFieldNames field, Type fieldType) :
            base(field, fieldType)
            { }
            private static Type _ComponentType = typeof(StagingOrderFulfillmentsBO);
            public override object GetValue(object component)
            {
                switch (this.Field)
                {
                    case StagingOrderFulfillmentsBOFieldNames.pk:
                        return ((StagingOrderFulfillmentsBO)component).pk;
                    case StagingOrderFulfillmentsBOFieldNames.ID:
                        return ((StagingOrderFulfillmentsBO)component).ID;
                    case StagingOrderFulfillmentsBOFieldNames.ProfileID:
                        return ((StagingOrderFulfillmentsBO)component).ProfileID;
                    case StagingOrderFulfillmentsBOFieldNames.OrderID:
                        return ((StagingOrderFulfillmentsBO)component).OrderID;
                    case StagingOrderFulfillmentsBOFieldNames.CreatedDateUtc:
                        return ((StagingOrderFulfillmentsBO)component).CreatedDateUtc;
                    case StagingOrderFulfillmentsBOFieldNames.UpdatedDateUtc:
                        return ((StagingOrderFulfillmentsBO)component).UpdatedDateUtc;
                    case StagingOrderFulfillmentsBOFieldNames.Type:
                        return ((StagingOrderFulfillmentsBO)component).Type;
                    case StagingOrderFulfillmentsBOFieldNames.DeliveryStatus:
                        return ((StagingOrderFulfillmentsBO)component).DeliveryStatus;
                    case StagingOrderFulfillmentsBOFieldNames.TrackingNumber:
                        return ((StagingOrderFulfillmentsBO)component).TrackingNumber;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingCarrier:
                        return ((StagingOrderFulfillmentsBO)component).ShippingCarrier;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingClass:
                        return ((StagingOrderFulfillmentsBO)component).ShippingClass;
                    case StagingOrderFulfillmentsBOFieldNames.DistributionCenterID:
                        return ((StagingOrderFulfillmentsBO)component).DistributionCenterID;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentCenterCode:
                        return ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentCenterCode;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentStatus:
                        return ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentStatus;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingCost:
                        return ((StagingOrderFulfillmentsBO)component).ShippingCost;
                    case StagingOrderFulfillmentsBOFieldNames.InsuranceCost:
                        return ((StagingOrderFulfillmentsBO)component).InsuranceCost;
                    case StagingOrderFulfillmentsBOFieldNames.TaxCost:
                        return ((StagingOrderFulfillmentsBO)component).TaxCost;
                    case StagingOrderFulfillmentsBOFieldNames.ShippedDateUtc:
                        return ((StagingOrderFulfillmentsBO)component).ShippedDateUtc;
                    case StagingOrderFulfillmentsBOFieldNames.SellerFulfillmentID:
                        return ((StagingOrderFulfillmentsBO)component).SellerFulfillmentID;
                    case StagingOrderFulfillmentsBOFieldNames.HasShippingLabel:
                        return ((StagingOrderFulfillmentsBO)component).HasShippingLabel;
                    case StagingOrderFulfillmentsBOFieldNames.HasChannelPackingSlip:
                        return ((StagingOrderFulfillmentsBO)component).HasChannelPackingSlip;
                    case StagingOrderFulfillmentsBOFieldNames.HasReturnLabel:
                        return ((StagingOrderFulfillmentsBO)component).HasReturnLabel;
                    case StagingOrderFulfillmentsBOFieldNames.HasChannelReturnLabel:
                        return ((StagingOrderFulfillmentsBO)component).HasChannelReturnLabel;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentNumber:
                        return ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentNumber;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentReferenceNumber:
                        return ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentReferenceNumber;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingLabelRequestID:
                        return ((StagingOrderFulfillmentsBO)component).ShippingLabelRequestID;
                    case StagingOrderFulfillmentsBOFieldNames.StagingLocation:
                        return ((StagingOrderFulfillmentsBO)component).StagingLocation;
                    case StagingOrderFulfillmentsBOFieldNames.LabelFormat:
                        return ((StagingOrderFulfillmentsBO)component).LabelFormat;
                    case StagingOrderFulfillmentsBOFieldNames.ReturnLabelFormat:
                        return ((StagingOrderFulfillmentsBO)component).ReturnLabelFormat;
                    case StagingOrderFulfillmentsBOFieldNames.ChannelReturnLabelFormat:
                        return ((StagingOrderFulfillmentsBO)component).ChannelReturnLabelFormat;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override void SetValue(object component, object value)
            {
                switch (this.Field)
                {
                    case StagingOrderFulfillmentsBOFieldNames.pk:
                        ((StagingOrderFulfillmentsBO)component).pk = (System.Int32)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ID:
                        ((StagingOrderFulfillmentsBO)component).ID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ProfileID:
                        ((StagingOrderFulfillmentsBO)component).ProfileID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.OrderID:
                        ((StagingOrderFulfillmentsBO)component).OrderID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.CreatedDateUtc:
                        ((StagingOrderFulfillmentsBO)component).CreatedDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.UpdatedDateUtc:
                        ((StagingOrderFulfillmentsBO)component).UpdatedDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.Type:
                        ((StagingOrderFulfillmentsBO)component).Type = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.DeliveryStatus:
                        ((StagingOrderFulfillmentsBO)component).DeliveryStatus = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.TrackingNumber:
                        ((StagingOrderFulfillmentsBO)component).TrackingNumber = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingCarrier:
                        ((StagingOrderFulfillmentsBO)component).ShippingCarrier = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingClass:
                        ((StagingOrderFulfillmentsBO)component).ShippingClass = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.DistributionCenterID:
                        ((StagingOrderFulfillmentsBO)component).DistributionCenterID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentCenterCode:
                        ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentCenterCode = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentStatus:
                        ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentStatus = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingCost:
                        ((StagingOrderFulfillmentsBO)component).ShippingCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.InsuranceCost:
                        ((StagingOrderFulfillmentsBO)component).InsuranceCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.TaxCost:
                        ((StagingOrderFulfillmentsBO)component).TaxCost = (System.Decimal)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ShippedDateUtc:
                        ((StagingOrderFulfillmentsBO)component).ShippedDateUtc = (System.DateTime)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.SellerFulfillmentID:
                        ((StagingOrderFulfillmentsBO)component).SellerFulfillmentID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.HasShippingLabel:
                        ((StagingOrderFulfillmentsBO)component).HasShippingLabel = (System.Boolean)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.HasChannelPackingSlip:
                        ((StagingOrderFulfillmentsBO)component).HasChannelPackingSlip = (System.Boolean)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.HasReturnLabel:
                        ((StagingOrderFulfillmentsBO)component).HasReturnLabel = (System.Boolean)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.HasChannelReturnLabel:
                        ((StagingOrderFulfillmentsBO)component).HasChannelReturnLabel = (System.Boolean)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentNumber:
                        ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentNumber = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ExternalFulfillmentReferenceNumber:
                        ((StagingOrderFulfillmentsBO)component).ExternalFulfillmentReferenceNumber = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ShippingLabelRequestID:
                        ((StagingOrderFulfillmentsBO)component).ShippingLabelRequestID = (System.Int64)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.StagingLocation:
                        ((StagingOrderFulfillmentsBO)component).StagingLocation = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.LabelFormat:
                        ((StagingOrderFulfillmentsBO)component).LabelFormat = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ReturnLabelFormat:
                        ((StagingOrderFulfillmentsBO)component).ReturnLabelFormat = (System.String)value;
                        break;
                    case StagingOrderFulfillmentsBOFieldNames.ChannelReturnLabelFormat:
                        ((StagingOrderFulfillmentsBO)component).ChannelReturnLabelFormat = (System.String)value;
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
