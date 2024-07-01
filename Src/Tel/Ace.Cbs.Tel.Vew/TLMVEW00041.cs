//----------------------------------------------------------------------
// <copyright file="TLMVEW00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-08-05 </CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Chief Cashier Entry -> Center Table Deposit(Approve)Entry
    /// </summary>
    public partial class TLMVEW00041 : BaseDockingForm,ITLMVEW00041
    {
        #region "Input Output Controls"

        public IList<TLMDTO00015> CashDenoList { get; set; }

        #endregion

        #region "Constructor"
        public TLMVEW00041()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"

        private ITLMCTL00041 centerTableDepositApproveController;

        public ITLMCTL00041 CenterTableDepositApproveController
        {
            get
            {
                return this.centerTableDepositApproveController;
            }
            set
            {
                this.centerTableDepositApproveController = value;
                this.centerTableDepositApproveController.CenterTableDepositApproveView = this;
              
            }
        }
        #endregion

        #region "Events"
        private void TLMVEW00041_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.CashDenoList = CenterTableDepositApproveController.GetCashDenoList(); 
            this.EnableDisableControls();                                 
            if(this.CashDenoList.Count.Equals(0))
            {
                this.lblNoCashierEntryNo.Show();
                this.lblPressSpaceBar.Hide();
                this.EnableDisableControlsForGridView();
            }
            else
            {
                this.lblNoCashierEntryNo.Hide();
            }
            this.BindGridView();
            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.CenterTableDepositApproveController.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.CenterTableDepositApproveController.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.CashDenoList = CenterTableDepositApproveController.GetCashDenoList();
                this.EnableDisableControls();
                if (this.CashDenoList.Count.Equals(0))
                {
                    this.lblNoCashierEntryNo.Show();
                    this.lblPressSpaceBar.Hide();
                    this.EnableDisableControlsForGridView();
                }
                else 
                {
                    this.lblNoCashierEntryNo.Hide();
                }
                this.BindGridView();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("CenterTableDepositApprove.AllDisable");
            }
            #endregion
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {           
            IList<TLMDTO00015> CashDenoDTOs = this.CashDenoList.Where<TLMDTO00015>(x => x.IsCheck == true).ToList();
            if (CashDenoDTOs.Count > 0)
            {
                this.centerTableDepositApproveController.SaveCashDeno(CashDenoDTOs);
                this.BindGridView();
                if (gvDepositApprove.DataSource == null || this.CashDenoList.Count==0)
                {
                    this.lblNoCashierEntryNo.Visible = true;
                    this.lblPressSpaceBar.Visible = false;
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00044);                
            }
        }
        private void gvDepositApprove_KeyDown(object sender, KeyEventArgs e)
        {
            this.gvDepositApprove.Focus();
            this.gvDepositApprove.CurrentCell = this.gvDepositApprove.Rows[gvDepositApprove.CurrentRow.Index].Cells[6];
        }       
        #endregion

        #region "Methods"
        public void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false,true, false,false, false, true);
        }
        public void Failure(string message, string voucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { voucherNo });
        }
        public void BindGridView()
        {
            this.gvDepositApprove.DataSource = null;
            this.gvDepositApprove.AutoGenerateColumns = false;
            this.CashDenoList = CenterTableDepositApproveController.GetCashDenoList();
            this.gvDepositApprove.DataSource = this.CashDenoList;
        }
        public void EnableNoOfCashierEntryNo()
        {
            this.lblNoCashierEntryNo.Hide();
        }    
        private void EnableDisableControlsForGridView()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }
        #endregion
    }
}
