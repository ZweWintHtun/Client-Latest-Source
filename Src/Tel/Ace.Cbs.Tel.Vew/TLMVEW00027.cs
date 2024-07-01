//----------------------------------------------------------------------
// <copyright file="TLMVEW00027.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-03</CreatedDate>
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

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// (Listing -> Transaction Listing) -> Withdrawal Listing By All
    ///(Listing -> Transaction Listing) -> Withdrawal Listing By Acctno
    ///(Listing -> Transaction Listing) -> Withdrawal Listing By Counter No
    ///(Listing -> Transaction Listing) -> (Withdrawal Listing By Account Type) -> Current Account
    ///(Listing -> Transaction Listing) -> (Withdrawal Listing By Account Type) -> Saving Account
    ///(Listing -> Transaction Listing) -> (Withdrawal Listing By Account Type) -> Fixed Account
    /// </summary>

    public partial class TLMVEW00027 : BaseDockingForm, ITLMVEW00027
    {
        #region "Properties"

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.TrimEnd(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string EnterTellerNo
        {
            get { return this.mtxtEnterTellerNo.Text.Trim(); }
            set { this.mtxtEnterTellerNo.Text = value; }
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

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        private string LoansType = string.Empty;
        public string loansType
        {
            get { return this.loansType; }
            set { this.loansType = value; }
        }

        #endregion

        #region "Constructors"

        public TLMVEW00027()
        {
            InitializeComponent();
        }

        public TLMVEW00027(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }
        #endregion

        #region "Controllers"
        private ITLMCTL00027 controller;
        public ITLMCTL00027 WithdrawalListingByAllController //WithdrawalListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.WithdrawalListingByAllView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00027_Load(object sender, EventArgs e)
        {
            this.InitializeControls();

        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
           // this.controller.ClearCustomErrorMessage();
        }
     
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate())
            {
                this.controller.MainPrint();
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Methods"

        private void InitializeControls()
        {
             this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.Text = this.GetFormNameString();
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.dtpStartDate.Focus();
            this.mtxtAccountNo.Clear();
            this.mtxtEnterTellerNo.Clear();
            this.EnableDisableControls();
            this.HideControls(this.TransactionStatus);

        }

        public void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private string GetFormNameString()
        {
            switch (this.FormName)
            {
                case "Withdrawal.All":
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By All ";

                case "Withdrawal.Current":
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Current Account Type";

                /*Added by ZMS For Pristine BL,HP,DL*/
                case "Withdrawal.BL": 
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Business Loans Account Type";

                case "Withdrawal.HP": 
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By HirePurchase Loans Account Type";

                case "Withdrawal.PL": 
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Personal Loans Account Type";

                case "Withdrawal.DL": 
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Dealer Account Type";

                /*Added by ZMS For Pristine BL,HP,DL*/

                case "Withdrawal.Saving":
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Saving Account Type";

                case "Withdrawal.Fixed":
                    mtxtAccountNo.TabStop = false;
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Fixed Deposit Account Type";

                case "Withdrawal.AccountNo":
                    mtxtEnterTellerNo.TabStop = false;
                    return "Withdrawal Listing By Account No";

                case "Withdrawal.Counter":
                    mtxtAccountNo.TabStop = false;
                    this.lblEnterTellerNo.Location = this.lblAccountNo.Location;
                    this.mtxtEnterTellerNo.Location = this.mtxtAccountNo.Location;

                    return "Withdrawal Listing By User No";

                default:
                    return string.Empty;
            }
        }
        #endregion

        private void mtxtEnterTellerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
