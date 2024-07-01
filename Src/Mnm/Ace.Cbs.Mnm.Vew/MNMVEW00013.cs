//----------------------------------------------------------------------
// <copyright file="MNMVEW00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>10/23/2013</CreatedDate>
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
using Ace.Cbs.Cx.Com.Utt;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    /// <summary>
    /// Saving Interest Withdrawal Reversal View 
    /// </summary>
    public partial class MNMVEW00013 : BaseForm, IMNMVEW00013
    {
        #region "Constructor"

        public MNMVEW00013()
        {
            InitializeComponent();
        }

        #endregion "Constructor"

        #region "Controller"
        private IMNMCTL00013 controller;
        public IMNMCTL00013 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

       #region Controls Input Output
        public string EntryNo
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }
        public string Narration
        { 
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; } 
        }    
        public string WithdrawBy
        {
            get { return this.lblWithdrawBy.Text; }
            set { this.lblWithdrawBy.Text = value; }
        }
        public string InterestAccount
        {
            get { return this.lblInterestAccount.Text; }
            set { this.lblInterestAccount.Text = value; }
        }
        public IList<PFMDTO00054> GridViewDatasource { get; set; }
       #endregion

        #region Methods

        public void EnableDisablePrintButton(bool isCash)
        {
            if (isCash)
            {
                this.tsbCRUD.butPrint.Enabled = false;
            }
            else
            {
                this.tsbCRUD.butPrint.Enabled = true; 
            }
 
        }

        public void SetGridViewDataSourceNull()
        {
            this.gvSavingInterestWithReversal.DataSource = null;
        }
        public void BindgvSavingInterestWithReversalGridView()
        {
            this.gvSavingInterestWithReversal.AutoGenerateColumns = false;
            this.gvSavingInterestWithReversal.DataSource = null;
            if(this.GridViewDatasource.Count>0)
            this.gvSavingInterestWithReversal.DataSource = this.GridViewDatasource;
        }
        private void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtEntryNo.Focus();          
        }
        #endregion

        #region Events
        private void MNMVEW00013_Load(object sender, EventArgs e)
        {
            #region Old_Logic

            //this.InitializeControls();
            
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.InitializeControls();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("SavingInterestWithdrawReverse.AllDisable");
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.txtEntryNo.Focus();
            this.gvSavingInterestWithReversal.DataSource = null;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
            this.gvSavingInterestWithReversal.DataSource = null;
        }

        private void MNMVEW00013_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        #endregion

        

    }
}