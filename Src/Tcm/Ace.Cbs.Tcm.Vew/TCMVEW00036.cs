//----------------------------------------------------------------------
// <copyright file="TLMVEW00036.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-6</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Dmd;
namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Clearing Delivered Reversal Listing Enquiry
    /// </summary>
    public partial class TCMVEW00036 : BaseForm,ITCMVEW00036
    {
        #region Properties
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set{this.dtpStartDate.Text=value.ToString(); }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }
        #endregion

        #region Constructor
        public TCMVEW00036()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private ITCMCTL00036 clearingdeliveredreversalController;
        public ITCMCTL00036 ClearingDeliveredReversalController
        {
            get
            {
                return this.clearingdeliveredreversalController;
            }
            set
            {
                this.clearingdeliveredreversalController = value;
                this.clearingdeliveredreversalController.ClearingdeliveredReversalView = this;
            }
        }

        #endregion

        #region Events

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {            
            this.Close();            
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.clearingdeliveredreversalController.CheckDate())
            {
                this.clearingdeliveredreversalController.GetClearingDeliveredReversalListing();
            }
        }
        
        private void TCMVEW00036_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
        #endregion

        #region Public Methods
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
        }
        #endregion
        
    }
}
