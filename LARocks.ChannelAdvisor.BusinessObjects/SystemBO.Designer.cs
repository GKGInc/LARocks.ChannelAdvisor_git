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
    partial class SystemBO
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

            this.CheckRulesOnCurrentRow += new CheckRulesOnCurrentRowEventHandler(SystemBO_CheckRulesOnCurrentRow);
            this.SetDefaultValues += new SetDefaultValuesEventHandler(SystemBO_SetDefaultValues);
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
                return "[pk],[SettingName],[SettingValue]";
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
                return "System";
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
new DataColumn("SettingName", typeof(System.String)),
new DataColumn("SettingValue", typeof(System.String))};
        }

        /// <summary>
        /// Adds a broken rule to the business object's collection
        /// </summary>
        protected void AddBrokenRule(SystemBOFieldNames Field, string ErrorMessage)
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
        protected void AddBrokenRuleByKey(SystemBOFieldNames Field, string ErrorMessageKey)
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
        /// Setting Name
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description("Setting Name"),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SettingName
        {
            get
            {
                return (System.String)this.CurrentRow["SettingName"];
            }
            set
            {
                this.CurrentRow["SettingName"] = value;
            }
        }

        /// <summary>
        /// Setting Value
        /// </summary>
        [Browsable(false),
         BusinessFieldDisplayInEditor(),
         Description("Setting Value"),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public System.String SettingValue
        {
            get
            {
                return (System.String)this.CurrentRow["SettingValue"];
            }
            set
            {
                this.CurrentRow["SettingValue"] = value;
            }
        }

        #endregion

        #region Field Property Events 

        #endregion

        #region Nested Types & Field Security

        /// <summary>
        /// Contains all of the field names that belong to the business object.
        /// </summary>
        public enum SystemBOFieldNames
        {
            pk,
            SettingName,
            SettingValue,
            CUSTOM_FIELD
        }

        /// <summary>
        /// Gets the System.Type of the enumeration that contains the field names for the business object.
        /// </summary>
        public override System.Type GetFieldEnumType()
        {
            return typeof(SystemBOFieldNames);
        }

        /// <summary>
        /// Creates a new CheckFieldSecurityEventArgs object that can be used with this business object type.
        /// </summary>
        protected override CheckFieldSecurityEventArgsBase CreateNewFieldSecurityEventArgs(System.Enum Field, string CustomField, string PermissionKey, PermissionInfo Perm)
        {
            return new CheckFieldSecurityEventArgs<SystemBOFieldNames>(Field, CustomField, PermissionKey, Perm);
        }

        /// <summary>
        /// Describes a method that will handle the CheckFieldScurity event.
        /// </summary>
        public delegate void CheckFieldSecurityEventHandler(object sender, CheckFieldSecurityEventArgs<SystemBOFieldNames> e);

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
                this.CheckFieldSecurity(this, (CheckFieldSecurityEventArgs<SystemBOFieldNames>)e);
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
        /// Initializes the static members of the SystemBO class.
        /// </summary>
        static SystemBO()
        {
            //-- Create the new shared dictionary and populate it with an 
            //   instance of each property descriptor
            _PropertyDescriptors = new PropertyDescriptorDictionary(8);
            _PropertyDescriptors.Add("pk", new FieldDescriptor(SystemBOFieldNames.pk, typeof(System.Int32)));
            _PropertyDescriptors.Add("SettingName", new FieldDescriptor(SystemBOFieldNames.SettingName, typeof(System.String)));
            _PropertyDescriptors.Add("SettingValue", new FieldDescriptor(SystemBOFieldNames.SettingValue, typeof(System.String)));

            _AllFieldsList = new List<string>(3);
            _AllFieldsList.Add("pk");
            _AllFieldsList.Add("SettingName");
            _AllFieldsList.Add("SettingValue");

            _FieldDbTypes = new Dictionary<string, DbType>(3);
            _FieldDbTypes.Add("pk", DbType.Int32);
            _FieldDbTypes.Add("SettingName", DbType.AnsiString);
            _FieldDbTypes.Add("SettingValue", DbType.AnsiString);

            _FieldEnums = new BusinessLayerFieldEnumDictionary(4);
            _FieldEnums.Add("pk", SystemBOFieldNames.pk);
            _FieldEnums.Add("SettingName", SystemBOFieldNames.SettingName);
            _FieldEnums.Add("SettingValue", SystemBOFieldNames.SettingValue);
            _FieldEnums.Add("CUSTOM_FIELD", SystemBOFieldNames.CUSTOM_FIELD);

            _FieldLengths = new Dictionary<string, int>(3);
            _FieldLengths.Add("pk", 4);
            _FieldLengths.Add("SettingName", 50);
            _FieldLengths.Add("SettingValue", 500);

            _FieldNativeDbTypes = new Dictionary<string, int>(3);
            _FieldNativeDbTypes.Add("pk", (int)System.Data.SqlDbType.Int);
            _FieldNativeDbTypes.Add("SettingName", (int)System.Data.SqlDbType.VarChar);
            _FieldNativeDbTypes.Add("SettingValue", (int)System.Data.SqlDbType.VarChar);

            _FieldPermissionKeys = new Dictionary<string, string>(3);

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
        /// A PropertyDescriptor class used to Get and Set the value of fields within the SystemBO business object.
        /// </summary>
        private class FieldDescriptor :
        MicroFour.StrataFrame.Business.FieldPropertyDescriptor<SystemBOFieldNames>
        {
            public FieldDescriptor(SystemBOFieldNames field, Type fieldType) :
            base(field, fieldType)
            { }
            private static Type _ComponentType = typeof(SystemBO);
            public override object GetValue(object component)
            {
                switch (this.Field)
                {
                    case SystemBOFieldNames.pk:
                        return ((SystemBO)component).pk;
                    case SystemBOFieldNames.SettingName:
                        return ((SystemBO)component).SettingName;
                    case SystemBOFieldNames.SettingValue:
                        return ((SystemBO)component).SettingValue;
                    default:
                        throw new BusinessLayerException("Field not supported.");
                }
            }
            public override void SetValue(object component, object value)
            {
                switch (this.Field)
                {
                    case SystemBOFieldNames.pk:
                        ((SystemBO)component).pk = (System.Int32)value;
                        break;
                    case SystemBOFieldNames.SettingName:
                        ((SystemBO)component).SettingName = (System.String)value;
                        break;
                    case SystemBOFieldNames.SettingValue:
                        ((SystemBO)component).SettingValue = (System.String)value;
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
