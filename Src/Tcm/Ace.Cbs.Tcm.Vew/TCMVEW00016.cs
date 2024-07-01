//----------------------------------------------------------------------
// <copyright file="TCMVEW00016.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00016 : BaseForm, ITCMVEW00016
    {

        #region Constractor

        public TCMVEW00016()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties

        /// <summary>
        /// Current SettlementDate
        /// </summary>
        public DateTime CurrentSettlementDate
        {
            get
            {
                return this.dtpCurrentSettlementDate.Value;
            }

            set 
            { 
                this.dtpCurrentSettlementDate.Value = value; 
            }
        }

        /// <summary>
        /// Next SettlementDate
        /// </summary>
        public DateTime NextSettlementDate
        {
            get
            {
                return this.dtpNextSettlementDate.Value;
            }

            set
            {
                this.dtpNextSettlementDate.Value = value;
            }
        }

        public string SourceBranchCode { get; set; }

        #endregion

        #region Presenter
        private ITCMCTL00016 controller;
        public ITCMCTL00016 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #endregion

        #region Events

        private void butProcess_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TCMVEW00016_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataLoadingProgressShow(gbStatus, false);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            DataLoadingProgressShow(gbStatus, true);
            this.Controller.Process();
        }

        delegate void DataLoadingVisibility(GroupBox gpb, bool status);
        private void DataLoadingProgressShow(GroupBox gpb, bool status)
        {
            if (gpb.InvokeRequired)
                gpb.Invoke(new DataLoadingVisibility(DataLoadingProgressShow), gpb, status);
            else
            {
                gpb.Visible = status;
                butProcess.Enabled = !status;
            }
        }

        #endregion

        #region Helpter Methods

        public void ShowInformationMessage(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void InitializeControls()
        {
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.Controller.BindSettlementDate();
            //this.DisableControls("CashClosing.Disable");
        }

        #endregion


    }
}
