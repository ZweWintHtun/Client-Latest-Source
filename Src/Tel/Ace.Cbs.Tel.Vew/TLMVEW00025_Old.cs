// <copyright file="TLMVEW00025.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using System.Linq;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00025 : BaseDockingForm, ITLMVEW00025
    {

        #region CONSTRUCTOR
        public TLMVEW00025()
        {
            InitializeComponent();
        }

        public TLMVEW00025(bool isMainMenu, string parentFormId, string depositName)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.DepositName = depositName;
        }
        #endregion

        #region CONTROLLER
        private ITLMCTL00025 controller;
        public ITLMCTL00025 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region CONTROLS INPUT OUTPUT
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

        private string depositName = string.Empty;
        public string DepositName
        {
            get { return this.depositName; }
            set { this.depositName = value; }
        }

        public string CounterNo
        {
            get { return txtCounterNo.Text; }
            set { this.txtCounterNo.Text = value; }
        }

        public string AccountNo
        {
            get { return mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
        }
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
        }
        #endregion

        #region METHODS
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            if (this.depositName == "DepositListingByAll")
            {
                this.Text = "Deposit Listing By All";
                this.HideControls("DepositListingByAll.VisibleHiddenControls");
            }

            else if (this.depositName == "DepositListingByAccountNo")
            {
                //this.mtxtAccountNo.TabIndex = 0;
                //this.dtpStartDate.TabIndex = 70;
                //this.mtxtAccountNo.Focus();
                this.dtpStartDate.Focus();
                this.mtxtAccountNo.Clear();
                this.Text = "Deposit Listing By Account No";
                this.HideControls("DepositListingByAccountNo.VisibleHiddenControls");


            }

            else if (this.depositName == "DepositListingByCounterNo")
            {
                //this.txtCounterNo.TabIndex = 0;
                //this.dtpStartDate.TabIndex = 70;
                this.dtpStartDate.Focus();
                this.Text = "Deposit Listing By Counter";
                this.HideControls("DepositListingByCounterNo.VisibleHiddenControls");


            }

            else if (this.depositName == "Deposit Listing By Account Type (Current)" || this.depositName == "Deposit Listing By Account Type (Business Loans)"  
                || this.depositName == "Deposit Listing By Account Type (HirePurchase)" || this.depositName == "Deposit Listing By Account Type (Personal Loans)" 
                || this.depositName == "Deposit Listing By Account Type (Dealer)" 
                || this.depositName == "Deposit Listing By Account Type (Saving)" || this.depositName == "Deposit Listing By Account Type (Fixed)")
            {
                switch (this.depositName)
                {
                    case "Deposit Listing By Account Type (Current)": this.Text = "Deposit Listing By Current Account Type";
                        break;                   
                    case "Deposit Listing By Account Type (Saving)": this.Text = "Deposit Listing By Saving Account Type";
                        break;
                    case "Deposit Listing By Account Type (Fixed)": this.Text = "Deposit Listing By Fixed Account Type";
                        break;

                    /*Updated by ZMS For Pristine BL,HP,DL*/
                    case "Deposit Listing By Account Type (Business Loans)": this.Text = "Deposit Listing By Business Loans Account Type";
                        break;
                    case "Deposit Listing By Account Type (HirePurchase)": this.Text = "Deposit Listing By HirePurchase Account Type";
                        break;
                    case "Deposit Listing By Account Type (Personal Loans)": this.Text = "Deposit Listing By Personal Loans Account Type";
                        break;
                    case "Deposit Listing By Account Type (Dealer)": this.Text = "Deposit Listing By Dealer Account Type";
                        break;
                }

                this.HideControls("DepositListingByAll.VisibleHiddenControls");
            }


            else

                this.HideControls("DepositListingByAll.VisibleHiddenControls");

        }

        public bool CheckDate()
        {

            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.StartDate, this.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }

            return date;

        }

        #endregion

        #region EVENTS
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00025_Load(object sender, EventArgs e)
        {        
            this.InitializeControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
    
            
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.CheckDate())
            {
                string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
                string userNo = Convert.ToString(CurrentUserEntity.CurrentUserID);

                if (this.depositName == "DepositListingByAll")
                {
                    IList<PFMDTO00042> depositListingByall = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByAll(this.StartDate, this.EndDate, CurrentUserEntity.CurrentUserID, workstation, CurrentUserEntity.BranchCode));
                    if (depositListingByall.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00063", true, new object[] { this.Name, this.StartDate, this.EndDate, this.CounterNo, this.DepositName, depositListingByall });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
                else if (this.depositName == "DepositListingByCounterNo")
                {
                    if (CXClientWrapper.Instance.Invoke<ITLMSVE00027, bool>(x => x.IsValidUserNo(this.CounterNo, CurrentUserEntity.BranchCode)))
                    {
                        IList<PFMDTO00042> depositListingByCounterNo = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByCounter(this.StartDate, this.EndDate, CurrentUserEntity.CurrentUserID, workstation, this.CounterNo, CurrentUserEntity.BranchCode));
                        //  DateTime startDate, DateTime endDate, int createdUserId, string workStation, string counterNo
                        if (depositListingByCounterNo.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00063", true, new object[] { this.Name, this.StartDate, this.EndDate, this.CounterNo, this.DepositName, depositListingByCounterNo });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90021");//Invalid User.
                    }
                    
                }

                else if (this.depositName == "DepositListingByAccountNo")
                {
                     IList<PFMDTO00042> depositListingByAccountNo =CXClientWrapper.Instance.Invoke<ITLMSVE00064, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountNo(this.AccountNo, this.StartDate, this.EndDate, workstation,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));

                    if (depositListingByAccountNo.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00064", true, new object[] { this.Name, this.StartDate, this.EndDate, this.AccountNo, depositListingByAccountNo });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }

                else if (this.depositName == "Deposit Listing By Account Type (Current)")
                {
                    string currentaccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign); 
                    IList<PFMDTO00042> depositListingByCurrentAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, currentaccountsign, CurrentUserEntity.BranchCode,CurrentUserEntity.CurrentUserID));
                    if (depositListingByCurrentAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign), depositListingByCurrentAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (Business Loans)")
                {
                    string blAccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BusinessLoanAccountSign);
                    IList<PFMDTO00042> depositListingByCurrentAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, blAccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingByCurrentAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BusinessLoanAccountSign), depositListingByCurrentAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (HirePurchase)")
                {
                    string hpAccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HirePurchaseLoanAccountSign);
                    IList<PFMDTO00042> depositListingByCurrentAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, hpAccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingByCurrentAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HirePurchaseLoanAccountSign), depositListingByCurrentAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (Personal Loans)")
                {
                    string plAccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PersonalLoanAccountSign);
                    IList<PFMDTO00042> depositListingByCurrentAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, plAccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingByCurrentAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PersonalLoanAccountSign), depositListingByCurrentAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (Dealer)")
                {
                    string dlAccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DealerAccountSign);
                    IList<PFMDTO00042> depositListingByCurrentAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, dlAccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingByCurrentAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DealerAccountSign), depositListingByCurrentAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (Saving)")
                {
                    string savingaccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign);
                    IList<PFMDTO00042> depositListingBySavingAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, savingaccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingBySavingAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign), depositListingBySavingAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }

                }
                else if (this.depositName == "Deposit Listing By Account Type (Fixed)")
                {
                    string fixedaccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedAccountSign);
                    IList<PFMDTO00042> depositListingByFixedAccounType = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, fixedaccountsign, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                    if (depositListingByFixedAccounType.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, fixedaccountsign, depositListingByFixedAccounType });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }

                else if (this.depositName == "Deposit Listing By Account Type (CallDeposit)")
                {


                    string fixedaccountsign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedAccountSign);
                    if (CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.StartDate, this.EndDate, "L", CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID)).Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00065", true, new object[] { this.Name, this.StartDate, this.EndDate, "L" });
                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    }
                }
            }

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Text = string.Empty;
            this.txtCounterNo.Text = string.Empty;
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.controller.ClearCustomErrorMessage();
        }

        #endregion

        private void txtCounterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
