//----------------------------------------------------------------------
// <copyright file="TCMVEW00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
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
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Shut Down Form
    /// </summary>
    public partial class TCMVEW00015 : BaseForm, ITCMVEW00015
    {
        #region Constructor
        public TCMVEW00015()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITCMCTL00015 controller;
        public ITCMCTL00015 Controller
        {
            get
            {
                { return this.controller; }
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output

        public string BankHead
        {
            get { return this.lblBankHead.Text; }
            set { this.lblBankHead.Text = value; }
        }

        public string SystemDate
        {
            get { return this.lblDate.Text; }
            set { this.lblDate.Text = value; }
        }

        public string Status
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = value; }
        }

        public bool ShutDown { get; set; }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        IList<PFMDTO00028> cledgers { get; set; }

        #endregion

        #region Events
        private void TCMVEW00015_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.gvDailyReconsile.Visible = false;
            //this.controller.BindInitialData();
            if (this.controller.BindInitialData() == true)
            {
                this.controller.CheckAutoPayAndLateFeeCalculateProcess();                
            }
            this.butShutDown.Visible = false;            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.lblBankHead.Visible = true;
            this.lblBranchDescription.Visible = true;
            this.lblDate.Visible = true;
            this.lblStatus.Visible = true;
            this.lblSystemDate.Visible = true;
            this.lblSystemStatus.Visible = true;
            this.label1.Visible = false;
            this.gvDailyReconsile.Visible = false;
            this.label1.Visible = true;
            this.butReconsile.Visible = true;
            this.butShutDown.Visible = false;
        }

        public void BindReconsileGrid()
        {
            this.gvDailyReconsile.DataSource = null;
            this.gvDailyReconsile.AutoGenerateColumns = false;
            IList<PFMDTO00028> cledger = this.controller.BindReconsile();
            this.cledgers = cledger;

        }

        public void EnableControls(bool enable)
        {
            this.lblBankHead.Visible = enable;
            this.lblBranchDescription.Visible = enable;
            this.lblDate.Visible = enable;
            this.lblStatus.Visible = enable;
            this.lblSystemDate.Visible = enable;
            this.lblSystemStatus.Visible = enable;
            this.label1.Visible = enable;
        }

        private void StatusChange(IList<PFMDTO00028> cledger)
        {
            this.gvDailyReconsile.DataSource = cledger;
            if (cledger.Count > 0)
            {
                for (int i = 0; i < gvDailyReconsile.Rows.Count; i++)
                {
                    if (cledger[i].Staus == "Agree")
                    {
                        gvDailyReconsile.Rows[i].Cells["colStatus"].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        gvDailyReconsile.Rows[i].Cells["colStatus"].Style.ForeColor = Color.Red;
                    }

                }

            }

        }

        #endregion




        public void CLoseForm()
        { this.Close(); }

        private void butReconsile_Click(object sender, EventArgs e)
        {

            this.controller.ShutDown();

            if (this.cledgers != null)
            {
                this.StatusChange(this.cledgers);
            }

        }

        private void butShutDown_Click(object sender, EventArgs e)
        {
            this.controller.CommonShutDown();

        }

        public void NeedForShutDown()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.EnableControls(false);
            this.butReconsile.Visible = false;
            this.gvDailyReconsile.Visible = true;
            this.butShutDown.Visible = true;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            CXUIScreenTransit.Transit("frmTCMVEW00062", false, new object[] { this.Name });
        }

        private void btnODCalculation_Click(object sender, EventArgs e)
        {
            CXUIScreenTransit.Transit("frmLOMVEW00044", false, new object[] { });
        }
    }
}
