//----------------------------------------------------------------------
// <copyright file="TLMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>24/07/2013</CreatedDate>
// <UpdatedUser>Hsu Wai Htoo</UpdatedUser>
// <UpdatedDate>2013-10-11</UpdatedDate>
// <UpdatedUser>Nway Ei Ei Aung</UpdatedUser>
// <UpdatedDate>2013-12-16</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Chief Cashier Entry ->Vault Withdrawl Denomination Entry
    /// </summary>
    public partial class TLMVEW00004 : BaseForm, ITLMVEW00004
    {
        #region "Constructor"
        public TLMVEW00004()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public bool CboToEnable
        {
            set { this.cboTo.Enabled = value; }
        }

        #endregion

        #region "Controller"

        private ITLMCTL00004 vaultWithdrawlDenominationController;
        public ITLMCTL00004 Controller
        {
            get
            {
                return this.vaultWithdrawlDenominationController;
            }
            set
            {
                this.vaultWithdrawlDenominationController = value;
                this.vaultWithdrawlDenominationController.View = this;
            }
        }

        private TLMDTO00015 cashDeno;
        public TLMDTO00015 CashDeno
        {
            get
            {
                if (cashDeno == null)
                     cashDeno = new TLMDTO00015();
                    
                    cashDeno.FromType = this.DebitFrom;
                    cashDeno.DebitAmount = this.DebitAmount;
                    cashDeno.CreditAmount = this.CreditAmount;
                    cashDeno.Currency = this.Currency;
                    cashDeno.ToType = this.CreditTo;
                    cashDeno.VirtualStatus = this.VirtualStatus;
                    return cashDeno;
            }
            set
            {
                cashDeno = value;
            }
        }

        #endregion

        #region "Variable"
        private IList<TLMDTO00013> FromCashSetupList { get; set; }
        private IList<CounterInfoDTO> FromCounterInfoList { get; set; }
        public string BranchCode { get; set; }
        private string _branchAlias = string.Empty;
        private string _centerTableCashCode = string.Empty;
        private string _totalVaultBookCashCode = string.Empty;
        private string _boxBalanceRegisterCashCode = string.Empty;
        private string _receiveCashierTransitBookCashCode = string.Empty;
        private string _paymentCashierTransitBookCashCode = string.Empty;
        private string _receiveCounterType = string.Empty;
        private string _paymentCounterType = string.Empty;
       
        #endregion

        #region "Controls Input Output"
        public string Currency
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboCurrency.SelectedValue = value;
            }
        }
        public string DebitEno
        {            
            set { this.txtDebitEntryNo.Text = value; }
        }
        public string CreditEno
        {
            set { this.txtCreditEntryNo.Text = value; }
        }
        public string DebitFrom
        {
            get
            {
                if (this.cboFrom.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboFrom.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboFrom.SelectedValue = value;
            }
        }
        public string FromTypeSelectedText
        {
            get 
            {
                if (this.cboFrom.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboFrom.SelectedValue.ToString();
                }
            }
            
        }
        public string ToTypeSelectedText
        {
            get {
                if (this.cboTo.SelectedValue == null)
                {
                    return null;
                }
                return this.cboTo.SelectedValue.ToString(); }
            
        }

        public bool isDebitCounterCheck
        {
            get
            { return this.rdoDebitCounter.Checked; }
        }
        public bool isCreditCounterCheck
        {
            get
            { return this.rdoCreditCounter.Checked; }
            set { this.rdoCreditCounter.Checked = value; }
        }

        public bool isBranchCheck
        {
            get
            { return this.rdoCreditBranch.Checked; }
        }

        public bool isCreditVaultCheck
        {
            get{return this.rdoCreditVault.Checked;}
            set{this.rdoCreditVault.Checked=value;}
        }

        public bool isDebitVaultCheck
        {
            get{return this.rdoDebitVault.Checked;}
            set{this.rdoDebitVault.Checked=value;}
        }

        public string CreditTo
        {
            get
            {
                if (this.cboTo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTo.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboTo.SelectedValue = value;
            }
        }
        public decimal DebitAmount
        {
            get { return Convert.ToDecimal(this.ntxtDebitFromAmount.Text); }
            set { this.ntxtDebitFromAmount.Text = Convert.ToString(value); }
        }
        public decimal CreditAmount
        {
            get { return Convert.ToDecimal(this.ntxtCreditToAmount.Text); }
            set { this.ntxtCreditToAmount.Text = Convert.ToString(value); }
        }

        private IList<CounterInfoDTO> tocashsetuplist;
        public IList<CounterInfoDTO> toCashSetupList
        {
            get
            {
                if (this.tocashsetuplist == null)
                    this.tocashsetuplist = new List<CounterInfoDTO>();

                return this.tocashsetuplist;
            }
            set
            {
                this.tocashsetuplist = value;
            }
        }

        private IList<TLMDTO00013> fromCashSetupList;
        public IList<TLMDTO00013> FfromCashSetupList
        {
            get
            {
                if (this.fromCashSetupList == null)
                    this.fromCashSetupList = new List<TLMDTO00013>();

                return this.fromCashSetupList;
            }
            set
            {
                this.fromCashSetupList = value;
            }
        }

        public string VirtualStatus
        {
            get
            {               
                return "Vault";                              
            }
           
        }

        #endregion

        #region "Method"
      

        private void InitializeVariables()
        {            
            this.BranchCode = CXCOM00007.Instance.BranchCode;            
            this.FromCounterInfoList =this.vaultWithdrawlDenominationController.GetAllCounterListBySourceBranchCode(this.BranchCode);
            this._branchAlias = CXCLE00002.Instance.GetClientData<string>("Branch.Client.Alias.Select", new object[] { this.BranchCode, true });
            string nonissueableNote = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupNonissueableNote);
            this.FromCashSetupList = CXCLE00002.Instance.GetClientDataList<TLMDTO00013>("CashSetup.Client.SelectByNotEqualCashCode", new object[] { nonissueableNote });          
            this._centerTableCashCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupCenterTable);
            this._totalVaultBookCashCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupTotalVaultBook);
            this._boxBalanceRegisterCashCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupBoxBalanceRegister);
           
            this._receiveCashierTransitBookCashCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupReceiveCashierTransitBook);
            this._paymentCashierTransitBookCashCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashSetupPaymentCashierTransitBook);
            this._receiveCounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType);
            this._paymentCounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCounterType);
      
        }

        private void InitializeControls()
        {   
            this.txtCreditEntryNo.ReadOnly = true;
            this.txtDebitEntryNo.ReadOnly = true;
            this.rdoCreditCounter.Enabled = false;
            this.rdoCreditVault.Enabled = false;
            this.BindFromComboBox();
            this.Controller.ClearControls();
        }
        
        private void EnableDisabledToCombo(bool enable)
        {
            this.cboTo.Enabled = enable;
        }

        public void EnableDisableSaveButton(bool saveEnable)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, saveEnable, false, true, false, true);
        }       

        private void BindCurrencyCombo()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private IList<BranchDTO> GetBranchList(string branchAlies)
        {
            IList<BranchDTO> branchList = new List<BranchDTO>();
            BranchDTO branch = new BranchDTO();
            branch.BranchAlias = branchAlies;
            branchList.Add(branch);
            return branchList;
        }

        public void BindFromComboBox()
        {
            cboFrom.DataSource = null;
            this.EnableDisableSaveButton(true);
           
                this.EnableDisabledToCombo(false);
            
            if (rdoDebitVault.Checked)
            {                
                cboFrom.ValueMember = "CashCode";
                cboFrom.DisplayMember = "Description";
                cboFrom.DataSource = this.FromCashSetupList;
                this.FfromCashSetupList = this.FromCashSetupList;
            }
            else if (rdoDebitCounter.Checked)
            {               
                cboFrom.ValueMember = "CounterNo";
                cboFrom.DisplayMember = "CounterNo";
                  this.toCashSetupList  = this.FromCounterInfoList;
                  cboFrom.DataSource = this.toCashSetupList;
                 
            }
            this.cboFrom.SelectedIndex = -1;
        }

        public void BindToComboBox()
        {      
                IList<CounterInfoDTO> toCounterInfoList = new List<CounterInfoDTO>();
                CXDMD00012 dataBindType = new CXDMD00012();
                if (CreditAmount <= 0 || DebitAmount > 0)
                {
                    this.EnableDisabledToCombo(true);
                    IList<TLMDTO00013> toCashSetupListToCombo = new List<TLMDTO00013>();
                    this.cboTo.DataSource = null;

                    #region rdoFromVault
                    if (this.rdoDebitVault.Checked)
                    {
                        #region cboFrom "Total Vault Book"
                        if (this.DebitFrom == this._totalVaultBookCashCode)
                        {
                            if (this.rdoCreditBranch.Checked)
                            {
                                dataBindType = CXDMD00012.IBL;
                            }
                            else if (this.rdoCreditVault.Checked)
                            {
                                TLMDTO00013 a = this.GetCashSetupByCashCode(this._boxBalanceRegisterCashCode);
                                toCashSetupListToCombo.Add(a);
                                dataBindType = CXDMD00012.CashSetup;
                            }
                        }
                        #endregion
                        #region cboFrom "Box Balance Register"
                        else if (this.DebitFrom == this._boxBalanceRegisterCashCode)
                        {
                            toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._totalVaultBookCashCode));
                            toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._receiveCashierTransitBookCashCode));
                            toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._paymentCashierTransitBookCashCode));
                            dataBindType = CXDMD00012.CashSetup;
                        }
                        #endregion
                        #region cboFrom "Center Table"
                        else if (this.DebitFrom == this._centerTableCashCode)
                        {
                            toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._boxBalanceRegisterCashCode));
                            dataBindType = CXDMD00012.CashSetup;
                        }
                        #endregion
                        #region cboFrom "Receive Cashier's Transit Book"
                        else if (this.DebitFrom == this._receiveCashierTransitBookCashCode)
                        {
                            toCounterInfoList = this.GetCounterByCounterType(this._receiveCounterType);
                            dataBindType = CXDMD00012.CounterInfo;
                           
                        }
                        #endregion
                        #region cboFrom "Payment Cashier's Transit Book"
                        else if (this.DebitFrom == this._paymentCashierTransitBookCashCode)
                        {
                            if (this.rdoCreditCounter.Checked)
                            {
                                toCounterInfoList = this.GetCounterByCounterType(this._paymentCounterType);
                                dataBindType = CXDMD00012.CounterInfo;
                            }
                            else if (this.rdoCreditVault.Checked)
                            {
                                toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._boxBalanceRegisterCashCode));
                                dataBindType = CXDMD00012.CashSetup;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region rdoFromCounter
                    else if (this.rdoDebitCounter.Checked)
                    {
                        if (this.DebitFrom != null)
                        {
                            if (this.GetCounterTypeByCounterNo(this.DebitFrom) == this._paymentCounterType)
                            {
                                toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._paymentCashierTransitBookCashCode));
                            }
                            else if (this.GetCounterTypeByCounterNo(this.DebitFrom) == this._receiveCounterType)
                            {
                                toCashSetupListToCombo.Add(this.GetCashSetupByCashCode(this._centerTableCashCode));
                            }
                        }
                        dataBindType = CXDMD00012.CashSetup;
                        //cashDeno.VirtualStatus = "Counter";
                    }
                    #endregion

                    #region cboToType DataBind
                    switch (dataBindType)
                    {
                        case CXDMD00012.IBL:

                            cboTo.ValueMember = "BranchAlias";
                            cboTo.DisplayMember = "BranchAlias";
                            cboTo.DataSource = this.GetBranchList(this._branchAlias);
                            break;
                        case CXDMD00012.CashSetup:
                            cboTo.ValueMember = "CashCode";
                            cboTo.DisplayMember = "Description";
                            cboTo.DataSource = toCashSetupListToCombo;
                            break;
                        case CXDMD00012.CounterInfo:
                            cboTo.ValueMember = "CounterNo";
                            cboTo.DisplayMember = "CounterNo";
                            this.toCashSetupList = toCounterInfoList;
                            cboTo.DataSource = this.toCashSetupList;
                            break;
                    }

                    this.cboTo.SelectedIndex = -1;


                }
                else
                {
                    if (DebitAmount <= 0 || this.cboTo.Enabled == false)
                    {
                        if (this.DebitFrom == this._receiveCashierTransitBookCashCode)
                        {
                            toCounterInfoList = this.GetCounterByCounterType(this._receiveCounterType);
                            dataBindType = CXDMD00012.CounterInfo;
                        }
                        else if (this.DebitFrom == this._paymentCashierTransitBookCashCode)
                        {
                            if (this.rdoCreditCounter.Checked)
                            {
                                toCounterInfoList = this.GetCounterByCounterType(this._paymentCounterType);
                                dataBindType = CXDMD00012.CounterInfo;
                            }
                        }

                        switch (dataBindType)
                        {
                            case CXDMD00012.CounterInfo:
                                cboTo.ValueMember = "CounterNo";
                                cboTo.DisplayMember = "CounterNo";
                                this.toCashSetupList = toCounterInfoList;
                                cboTo.DataSource = this.toCashSetupList;
                                break;
                        }
                       this.cboTo.SelectedIndex = -1;
                    }
                }
                    #endregion
           // }
            
        }

        private void Common()
        {
            this.EnableDisabledToCombo(true);
            this.EnableDisableSaveButton(true);
            if (rdoDebitVault.Checked)
            {
                if ((this.DebitFrom == this._boxBalanceRegisterCashCode) || (this.DebitFrom == this._centerTableCashCode))
                {
                    this.rdoCreditVault.Enabled = true;
                    this.rdoCreditVault.Checked = true;
                    BindToComboBox();
                    this.rdoCreditCounter.Enabled = false;
                    this.rdoCreditBranch.Enabled = false;
                }
                else if (this.DebitFrom == this._receiveCashierTransitBookCashCode)
                {
                    this.rdoCreditCounter.Enabled = true;
                    this.rdoCreditCounter.Checked = true;
                    BindToComboBox();
                    this.rdoCreditBranch.Enabled = false;
                    this.rdoCreditVault.Enabled = false;
                }
                else if (this.DebitFrom == this._paymentCashierTransitBookCashCode)
                {

                    this.rdoCreditCounter.Enabled = true;
                    this.rdoCreditCounter.Checked = true;

                    this.rdoCreditBranch.Enabled = false;
                    this.rdoCreditVault.Enabled = true;
                    BindToComboBox();
                    this.rdoCreditVault.Checked = false;
                }
                else if (this.DebitFrom == this._totalVaultBookCashCode)
                {
                    this.rdoCreditVault.Enabled = true;
                    if (this.rdoCreditBranch.Checked == true)
                    {
                        this.rdoCreditBranch.Checked = true;
                    }
                    else
                    {
                        this.rdoCreditVault.Checked = true;
                        this.BindToComboBox();
                        this.EnableDisabledToCombo(true);
                    }
                    this.rdoCreditCounter.Enabled = false;
                    this.rdoCreditBranch.Enabled = true;
                }
            }
            else if (this.rdoDebitCounter.Checked)
            {
                this.rdoCreditVault.Enabled = true;
                this.rdoCreditVault.Checked = true;
                BindToComboBox();
                this.rdoCreditCounter.Enabled = false;
                this.rdoCreditBranch.Enabled = false;

            }

        }               
     
        private string GetCounterTypeByCounterNo(string counterNo)
        {
            var counterType = (from value in this.FromCounterInfoList
                              where value.CounterNo.Equals(counterNo)
                              select value.CounterType).Single();
            return counterType;
        }

        private IList<CounterInfoDTO> GetCounterByCounterType(string counterType)
        {
            var counterInfo = (from value in this.FromCounterInfoList
                              where value.CounterType.Equals(counterType)
                              select value).ToList();
            return counterInfo;
        }

        private TLMDTO00013 GetCashSetupByCashCode(string cashCode)
        {
            var cashSetup = (from value in this.FromCashSetupList
                              where value.CashCode.Equals(cashCode)
                              select value).Single();
            return cashSetup;
           
        }     
              
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.cboCurrency.Focus();
            this.CancelState();
        }

        private void CancelState()
        {
            this.Controller.ClearControls();
            this.Controller.ClearErrors();
            this.rdoDebitVault.Checked = true;
            this.BindToComboBox();
            this.EnableDisabledToCombo(false);
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region "Events"

        private void TLMVEW00004_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            // this.cboCurrency.Focus();
            // Set Initialize Controls
                      
            // Enable / Disable Controls
            this.EnableDisabledToCombo(false);
            this.EnableDisableSaveButton(true);
            this.BindCurrencyCombo();
            this.InitializeVariables();         

            this.InitializeControls();
            this.cboCurrency.Focus();
            this.ntxtDebitFromAmount.Text = "0.00";
            this.ntxtCreditToAmount.Text = "0.00";
            */
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.Controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.EnableDisabledToCombo(false);
                this.EnableDisableSaveButton(true);
                this.BindCurrencyCombo();
                this.InitializeVariables();

                this.InitializeControls();
                this.cboCurrency.Focus();
                this.ntxtDebitFromAmount.Text = "0.00";
                this.ntxtCreditToAmount.Text = "0.00";
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("VaultWithdrawDeno.AllDisable");
            }
        }
     
        private void rdoDebitVault_CheckedChanged(object sender, EventArgs e)
        {
            if (cashDeno.VirtualStatus != "Vault")
             {
                cashDeno.VirtualStatus = "Counter";
             }

            else  if (rdoDebitCounter.Checked==true)
             {
                cashDeno.VirtualStatus = "Counter";            

             }
             this.BindFromComboBox();
        }

        private void rdoDebitCounter_CheckedChanged(object sender, EventArgs e)
        {
            if (cashDeno.VirtualStatus != "Counter")
              {
                 cashDeno.VirtualStatus = "Vault";
              }
           else if (rdoDebitCounter.Checked==false)
             {
               cashDeno.VirtualStatus = "Vault";               
             }
              this.BindFromComboBox();
        }
           
        private void rdoCreditBranch_CheckedChanged(object sender, EventArgs e)
         {
            if (this.rdoCreditBranch.Checked && this.DebitAmount>0)
            {
                this.BindToComboBox();
                this.EnableDisabledToCombo(true);
            }         
        }

        private void rdoCreditVault_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoCreditVault.Checked)
            {
                this.BindToComboBox();
                this.EnableDisabledToCombo(true);
            }            
        }

        private void rdoCreditCounter_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.rdoCreditCounter.Checked && this.DebitAmount > 0)            
            if (this.rdoCreditCounter.Checked)//Updated Code By KKT
            {
                this.BindToComboBox();
                this.EnableDisabledToCombo(true);                
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.CancelState();
        }

        private void cboFrom_Click(object sender, EventArgs e)
        {
            this.cboTo.Enabled = false;
            // this.CreditAmount= 0;
            this.ntxtDebitFromAmount.Text = "0.0";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common();
        }

        #endregion

        #region Validated Event

        private void cboCurrency_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.tsbCRUD.butCancel.ContainsFocus && !this.tsbCRUD.butSave.ContainsFocus && !this.tsbCRUD.butExit.ContainsFocus)
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    //CXUIMessageUtilities.ShowMessageByCode("MV00020");
                    this.cboCurrency.Focus();
                }
            }
            if (!this.tsbCRUD.butSave.ContainsFocus && !this.tsbCRUD.butCancel.ContainsFocus && !this.tsbCRUD.butExit.ContainsFocus)
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    //CXUIMessageUtilities.ShowMessageByCode("MV00020");
                    this.cboCurrency.Focus();
                }

            }

            if (!this.tsbCRUD.butExit.ContainsFocus && this.tsbCRUD.butExit.ContainsFocus)
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00020");
                    this.cboCurrency.Focus();
                }

            }
           
        }

        private void ntxtCreditToAmount_Validated(object sender, EventArgs e)
        {
            if (this.rdoCreditBranch.Checked == true)
            {
                this.rdoCreditBranch.Checked = true;
            }
        }
   
        private void cboFrom_Validated(object sender, EventArgs e)
        {
            if (this.cboCurrency.SelectedValue!=null)
            {
                if (this.DebitFrom == null)
                    return;
                //this.EnableDisabledToCombo(true);
                //this.EnableDisableSaveButton(true);
                //if (this.rdoDebitVault.Checked)
                //{
                //    if ((this.DebitFrom == this._boxBalanceRegisterCashCode) || (this.DebitFrom == this._centerTableCashCode))
                //    {
                //        this.rdoCreditVault.Enabled = true;
                //        this.rdoCreditVault.Checked = true;
                //        this.rdoCreditCounter.Enabled = false;
                //        this.rdoCreditBranch.Enabled = false;
                //    }
                //    else if (this.DebitFrom == this._receiveCashierTransitBookCashCode)
                //    {
                //        this.rdoCreditCounter.Enabled = true;
                //        this.rdoCreditCounter.Checked = true;
                //        this.rdoCreditBranch.Enabled = false;
                //        this.rdoCreditVault.Enabled = false;
                //    }
                //    else if (this.DebitFrom == this._paymentCashierTransitBookCashCode)
                //    {
                //        this.rdoCreditCounter.Enabled = true;
                //        this.rdoCreditCounter.Checked = false;

                //        this.rdoCreditBranch.Enabled = false;
                //        this.rdoCreditVault.Enabled = true;
                //        this.rdoCreditVault.Checked = true;
                //    }
                //    else if (this.DebitFrom == this._totalVaultBookCashCode)
                //    {
                //        this.rdoCreditVault.Enabled = true;
                //        if (this.rdoCreditBranch.Checked == true)
                //        {
                //            this.rdoCreditBranch.Checked = true;
                //        }
                //        else
                //        {
                //            this.rdoCreditVault.Checked = true;
                //        }
                //        this.rdoCreditCounter.Enabled = false;
                //        this.rdoCreditBranch.Enabled = true;
                //    }
                //}
                //else if (this.rdoDebitCounter.Checked)
                //{
                //    this.rdoCreditVault.Enabled = true;
                //    this.rdoCreditVault.Checked = true;
                //    this.rdoCreditCounter.Enabled = false;
                //    this.rdoCreditBranch.Enabled = false;
                //}
                //this.ntxtDebitFromAmount.Focus();
            }
            
        }
           
        private void cboTo_Validated(object sender, EventArgs e)
        {
            this.EnableDisableSaveButton(true);                  
        }                  
                       
        #endregion      

        private void ntxtDebitFromAmount_Leave(object sender, EventArgs e)
        {
            this.Controller.ntxtDebitFromAmount_CustomValidate();
        }

        private void ntxtDebitFromAmount_Validated(object sender, EventArgs e)
        {

        }

        private void ntxtCreditToAmount_Leave(object sender, EventArgs e)
        {
            this.Controller.ntxtCreditToAmount_CustomValidate();
        }
        
    }

}
