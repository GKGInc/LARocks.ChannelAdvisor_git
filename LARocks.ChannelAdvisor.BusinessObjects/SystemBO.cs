using MicroFour.StrataFrame.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;

namespace LARocks.ChannelAdvisor.BusinessObjects
{
    [Serializable()]
    public partial class SystemBO : MicroFour.StrataFrame.Business.BusinessLayer
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BusinessObject1 class.
        /// </summary>
        public SystemBO()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the BusinessObject1 class.
        /// </summary>
        /// <param name="container">The IContainer to which this business object will be added.</param>
        public SystemBO(IContainer container)
            : base()
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the BusinessObject1 class.
        /// </summary>
        /// <param name="info">The SerializationInfo for the object to create.</param>
        /// <param name="context">The StreamingContext for the source stream.</param>
        protected SystemBO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            InitializeComponent();
        }

        #endregion

        #region Data Retrieval Methods


        public string this[string s]
        {
            get
            {
                return this.RetrieveSetting(s);
            }
        }

        public void FillAll()
        {
            this.FillDataTable("SELECT * FROM " + this.TableName);
        }

        public void FillBySettingName(String settingName)
        {
            this.FillDataTable("SELECT * FROM " + this.TableName + " WHERE SettingName = '" + settingName + "'");
        }

        public string RetrieveSetting(string s)
        {
            if (this.Seek("SettingName = '" + s + "'"))
            {
                return this.SettingValue;
            }
            else
            {
                return String.Empty;
            }
        }

        public string GetSettingValue(String settingName)
        {
            SystemBO setting = new SystemBO();
            setting.FillDataTable("SELECT * FROM " + this.TableName + " WHERE SettingName = '" + settingName + "'");
            return (setting.MoveFirst()) ? setting.SettingValue : "";
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Checks the business rules on the current row
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void SystemBO_CheckRulesOnCurrentRow(CheckRulesEventArgs e)
        {

        }

        /// <summary>
        /// Sets the default values for a new row
        /// </summary>
        /// <remarks></remarks>
        private void SystemBO_SetDefaultValues()
        {

        }

        #endregion

    }
}
