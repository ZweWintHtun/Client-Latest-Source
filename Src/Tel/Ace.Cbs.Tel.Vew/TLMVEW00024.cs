//----------------------------------------------------------------------
// <copyright file="TLMVEW00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-01</CreatedDate>
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
    /// Listing => Transaction Listing => Deposit Listing By Account Type and Withdrawal Listing By Account Type
    /// </summary>
    public partial class frmTLMVEW00024 : BaseDockingForm
    {
        #region "Properties"

        public string TransactionStatus { get; set; }

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

        #endregion

        #region "Private Variables"
        private string depositListByAcctType = "Deposit Listing By Account Type";
        private string depositListByCurrentAcctType = "Deposit Listing By Account Type (Current)";
        private string depositListBySavingAcctType = "Deposit Listing By Account Type (Saving)";
        private string depositListByFixedDepositAcctType = "Deposit Listing By Account Type (Fixed)";
        private string depositListByCallDepositAcctType = "Deposit Listing By Account Type (CallDeposit)";


        private string depositListByBLAcctType = "Deposit Listing By Account Type (Business Loans)";
        private string depositListByHPAcctType = "Deposit Listing By Account Type (HirePurchase)";
        private string depositListByPLAcctType = "Deposit Listing By Account Type (Personal Loans)";
        private string depositListByDLAcctType = "Deposit Listing By Account Type (Dealer)";
        #endregion

        #region "Constructor"
        public frmTLMVEW00024()
        {
            InitializeComponent();
        }       

        public frmTLMVEW00024(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }

        public frmTLMVEW00024(bool isMainMenu, string parentFormId, string formName)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.Text = formName;
        }
        #endregion      

        #region "Methods"

        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.BindAccountFormType();
        }

        private void BindAccountFormType()
        {
            IList<PFMDTO00015> AccountTypeList = CXCLE00002.Instance.GetListObject<PFMDTO00015>("AccountType.Client.Select", new object[] { true });
            this.cboAccountType.DisplayMember = "Description";
            this.cboAccountType.ValueMember = "Code";
            this.cboAccountType.DataSource = AccountTypeList;
            this.cboAccountType.SelectedIndex = -1;
        }
        #endregion

        #region "Events"

        private void butContinue_Click(object sender, EventArgs e)
        {
                if (this.Text == depositListByAcctType)
                {
                   
                    switch (cboAccountType.SelectedIndex)
                    {
                        case -1:
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00073);
                            this.cboAccountType.Focus();
                            break;

                        //case 1:

                        //    if (CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListBySavingAcctType}) == DialogResult.OK)
                        //        return;
                        //    break;

                        //case 2:

                        //    if (CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByFixedDepositAcctType }) == DialogResult.OK)
                        //        return;
                        //    break;
                        //case 3:


                        //    if (CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByCallDepositAcctType }) == DialogResult.OK)
                        //        return;
                        //    break;

                        /*Updated by ZMS For Pristine BL,HP,DL*/
                        case 0: // BL                           
                            CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByBLAcctType });                          
                            break;
                        case 1://HP
                            CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByHPAcctType });
                            break;
                        case 2://PL
                            CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByPLAcctType });
                            break;
                        case 3://DL
                            CXUIScreenTransit.Transit("frmTLMVEW00025", true, new object[] { false, this.Name, depositListByDLAcctType });
                            break;                        
                    }                   
                }
                else
                {
                    switch (cboAccountType.SelectedIndex)
                    {
                        case -1:
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00073);
                            this.cboAccountType.Focus();
                            break;

                        //case 0:

                        //    CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByCurrent", true, new object[] { false, this.Name});
                        //    break;


                        //case 1:

                        //    CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalBySaving", true, new object[] { false, this.Name });
                        //    break;

                        //case 2:

                        //    CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByFixed", true, new object[] { false, this.Name});
                        //    break;

                        /*Updated by ZMS For Pristine BL,HP,DL*/
                        case 0: // BL
                            CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByBL", true, new object[] { false, this.Name });
                            break;
                        case 1: // HP

                            CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByHP", true, new object[] { false, this.Name});
                            break;
                        case 2: // PL

                            CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByPL", true, new object[] { false, this.Name});
                            break;
                        case 3: // DL

                            CXUIScreenTransit.Transit("frmTLMVEW00027WithdrawalByDL", true, new object[] { false, this.Name });
                            break;
                    }                    
                }  
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TLMVEW00024_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
        #endregion
    }
}

