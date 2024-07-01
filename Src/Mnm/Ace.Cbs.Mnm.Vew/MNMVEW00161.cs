//----------------------------------------------------------------------
// <copyright file="MNMVEW00161.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-13</CreatedDate>
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    //.listing--> Interest(payment)--> Fixed Deposit Interest--> Interst Withdrawal Listing
    public partial class MNMVEW00161 : BaseForm,IMNMVEW00161
    {
        public MNMVEW00161()
        {
            InitializeComponent();
        }
        public string TransactionStatus
        {
            get { return this.FormName; }
        }
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }       
        private void InitializeControls()
        {
            this.rdoTransactionDate.Checked = true;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);          
        }
        #region "Controllers"
        private IMNMCTL00161 controller;
        public IMNMCTL00161 FixedDepositInterestWithdrawListingController //WithdrawalListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.FixedDepositInterestWithdrawListingView = this;
            }
        }

        #endregion

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
            string datetype = string.Empty;
            if (this.CheckDate())
            {
                datetype=rdoTransactionDate.Checked? "Transaction":"Settlement";
             this.FixedDepositInterestWithdrawListingController.MainPrint(datetype);            
            }
            else
            {
               Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");                
            }
        }
        private bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);  
            return date;
        }

        private void MNMVEW00158_Load(object sender, EventArgs e)
        {
            this.Text = "Interest Withdrawal Listing";
            this.InitializeControls();
        }
    }
}
