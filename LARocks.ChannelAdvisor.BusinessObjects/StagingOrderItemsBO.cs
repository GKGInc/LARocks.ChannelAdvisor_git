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
    public partial class StagingOrderItemsBO : MicroFour.StrataFrame.Business.BusinessLayer
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BusinessObject1 class.
        /// </summary>
        public StagingOrderItemsBO()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the BusinessObject1 class.
        /// </summary>
        /// <param name="container">The IContainer to which this business object will be added.</param>
        public StagingOrderItemsBO(IContainer container)
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
        protected StagingOrderItemsBO(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            InitializeComponent();
        }

        #endregion

        #region Data Retrieval Methods
                
        public void FillByOrderId(Int64 orderId)
        {
            string sql = $"SELECT * FROM {this.TableNameAndSchema} WHERE OrderID = @id";
            var cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", orderId);

            this.FillDataTable(cmd);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Checks the business rules on the current row
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void StagingOrderItemsBO_CheckRulesOnCurrentRow(CheckRulesEventArgs e)
        {

        }

        /// <summary>
        /// Sets the default values for a new row
        /// </summary>
        /// <remarks></remarks>
        private void StagingOrderItemsBO_SetDefaultValues()
        {

        }

        #endregion

    }
}
