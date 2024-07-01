//----------------------------------------------------------------------
// <copyright file="TCMVEW00037.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/02/2014</CreatedDate>
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
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00037 : BaseForm, ITCMVEW00037
    {
        #region Constructor

        public TCMVEW00037()
        {
            InitializeComponent();
        }

        #endregion

        #region controller
        
        ITCMCTL00037 controller;
        public ITCMCTL00037 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Properties

        private DateTime startdate;
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        private DateTime enddate;
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        #endregion

        #region Events

        private void TCMVEW00037_Load(object sender, EventArgs e)
        {
            //ButtonEnableDisabled(newEnabled,editEnabled,saveEnabled,deleteEnabled,cancelEnabled,printEnabled, exitEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControls();
            this.dtpStartDate.Focus();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.dtpStartDate.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate())
            {
                this.controller.GetClearingReceiptReversalListing();
            }                
        }

        #endregion

        #region Methods

        private void InitializeControls()
        {
            this.Text = "Clearing Receipt Reversal Listing";
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
        }
             
        #endregion

      

    }
}
