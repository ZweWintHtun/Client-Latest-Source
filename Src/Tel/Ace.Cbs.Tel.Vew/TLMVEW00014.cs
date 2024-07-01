//----------------------------------------------------------------------
// <copyright file="TLMVEW00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
// <UpdatedUser>AK</UpdatedUser>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;

namespace Ace.Cbs.Tel.Vew
{
    //Withdrawal Entry Form

    public partial class TLMVEW00014 : BaseDockingForm, ITLMVEW00014
    {
        #region Constructor
        public TLMVEW00014()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITLMCTL00014 controller;
        public ITLMCTL00014 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output
        
        public string GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public decimal Amount
        {
            //get { return this.txtAmount.Value; }
            //set { this.txtAmount.Text = value.ToString(); }
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }

        public string ChequeNo
        {
            get { return this.txtChequeNo.Text; }
            set { this.txtChequeNo.Text = value; }
        }

        public int NoOfPersonSign
        {
            get
            {
                return Convert.ToInt32(this.txtNoOfPersonToSign.Value);
            }
            set { this.txtNoOfPersonToSign.Text = value.ToString(); }
        }
        
        public string JoinType { get; set; }

        public string Name { get; set; }

        public decimal Comissions
        {
            get { return this.txtCommissions.Value; }
            set { this.txtCommissions.Text = value.ToString(); }
        }

        public decimal CommunicationCharges
        {
            get { return this.txtCommunicationCharges.Value; }
            set { this.txtCommunicationCharges.Text = value.ToString(); }
        }

        public bool IsLastWithdrawal { get; set; }

        public bool VIPCustomer
        {
            get
            {
                if (this.chkVIPCustomer.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkVIPCustomer.Checked = value; }
        }

        public bool PrintStatus
        {
            get
            {
                if (this.chkPrintTransactions.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                { this.chkPrintTransactions.Checked = value; }
            }
        }

        public bool InputIncomeAmount
        {
            get
            {
                if (this.chkInputIncomeAmount.Checked)
                {
                    this.Comissions = Convert.ToDecimal(this.txtCommissions.Text);   //added by ASDA
                    this.CommunicationCharges = Convert.ToDecimal(this.txtCommunicationCharges.Text);  //added by ASDA
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                { this.chkInputIncomeAmount.Checked = value; }
            }
        }

        public bool IncomeByCash
        {
            get
            {
                if (this.rdoIncomeByCash.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                { this.rdoIncomeByCash.Checked = value; }
            }
        }

        public string LocalBranchCode
        {
            get { return CXCOM00007.Instance.BranchCode; }
            set { LocalBranchCode = value; }
        }

        public bool IncomeByTransfer
        {
            get
            {
                if (this.rdoIncomeByTransfer.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                { this.rdoIncomeByTransfer.Checked = value; }
            }
        }

        public string ToBranch { get; set; }

        public string CurrencyCode
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }

            set { this.cboCurrency.SelectedValue = value; }
        }

        public bool LocalWithdrawType { get; set; }
        public bool OnlineWithdrawType { get; set; }

        //updated by ZMS 20181015 
        public decimal TotalAmount
        {
            get 
            { 
                //return this.txtTotalAmount.Value; 
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text.ToString().Replace(",", ""), out result);
                return Math.Round(result, 2);
             }
            //set { this.txtTotalAmount.Text = value.ToString(); }
            set { this.txtTotalAmount.Text = string.Format("{0:#,##0.00}", double.Parse(value.ToString())); }
        }
        public decimal TotalCharges
        {
            get
            { //return this.txtTotalCharges.Value; 
                decimal result = 0;
                //decimal.TryParse(this.txtTotalAmount.Text.ToString().Replace(",", ""), out result); // commented by ZMS for pristine requirements (9.11.18)
                decimal.TryParse((Convert.ToDecimal(this.txtCommunicationCharges.Text.ToString().Replace(",", "")) + Convert.ToDecimal(this.txtCommunicationCharges.Text.ToString().Replace(",", "")).ToString()), out result); // Added by ZMS for pristine requirements (9.11.18)
                return Math.Round(result, 2);
            }
            //set { this.txtTotalCharges.Text = value.ToString(); }
            set { this.txtTotalCharges.Text = string.Format("{0:#,##0.00}", double.Parse(value.ToString())); }
        } 

        public int Count { get; set; }
        public int SerialNo { get; set; }
        public string Status { get; set; }

        public string CurrentAccountSign
        {
            get 
            {
                Nullable<CXDMD00011> accountType;
                string currentACSign = string.Empty;
                if (!String.IsNullOrEmpty(this.AccountNo))
                {
                    if (CXCLE00012.Instance.IsValidAccountNo(this.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2) == true)
                    {
                        IList<PFMDTO00001> customer = CXClientWrapper.Instance.Invoke<ITLMSVE00014, IList<PFMDTO00001>>(x => x.GetAccountInfoByAccountNo(this.AccountNo, this.VIPCustomer, this.LocalBranchCode, DateTime.Now));
                        if (customer[0].AccountSign.Contains("B"))
                        {
                            currentACSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BusinessLoanAccountSign);
                        }
                        else if (customer[0].AccountSign.Contains("H"))
                        {
                            currentACSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HirePurchaseLoanAccountSign);
                        }
                        else if (customer[0].AccountSign.Contains("P"))
                        {
                            currentACSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PersonalLoanAccountSign);
                        }
                        else if (customer[0].AccountSign.Contains("D"))
                        {
                            currentACSign = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DealerAccountSign);
                        }
                    }
                }
                return currentACSign;
            }
        }

        public string SavingAccountSign
        {
            get { return CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign); }

        }
        public bool IsCheckGrid { get; set; }
        public bool IsAutoLink { get; set; }
        public bool IsEdit { get; set; }
        public bool IsCloseAccount { get; set; }//Added By AAM(12_Sep_2018)
        #endregion    
       
        #region EntityList       
        private IList<TLMDTO00047> withdrawLists;
        public IList<TLMDTO00047> WithdrawLists
        {
            get
            {
                if (this.withdrawLists == null)
                    this.withdrawLists = new List<TLMDTO00047>();

                return this.withdrawLists;
            }
            set
            {
                this.withdrawLists = value;
            }
        }       
        #endregion

        #region Methods
        public void DisableControlsforView(string name)
        {
            this.DisableControls(name);
        }

        public void DisableInputIncomeForIncomeByTransfer()
        {
            if (this.rdoIncomeByTransfer.Checked)
            {
                this.DisableControls("Withdrw.InputIncome.DisableControls");
            }
        }
        private void BindCurrencyCombobox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        private void InitializeControls()
        {
            this.Count = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MultiTransactionCount));
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
            this.BindCurrencyCombobox();           
            this.Status = string.Empty;
            this.DisableControls("WithdrawEntry.DisableControls");
            this.rdoIncomeByCash.Checked = true;
            //this.cboCurrency.Focus();
        }
        public void SetFocusOnAmount()
        {
            this.txtAmount.Focus();
        }
        public void DisableControlsForController(string name)
        {
            this.ChequeNo = string.Empty;
            this.DisableControls(name);
            if (this.IsCloseAccount == true)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00044);   // Account No has been closed.   
                mtxtAccountNo.Text = "";
                mtxtAccountNo.Focus();
                return;
            }
        }
        public void EnableControlsForController(string name)
        {
            this.EnableControls(name);
        }
        public void BindgvMultiAccountWithdrawlInformation(IList<TLMDTO00047> withdrawList)
        {
            if (withdrawList.Count > 0)
            {
                this.gvMultiAccountWithdrawl.DataSource = null;
                this.gvMultiAccountWithdrawl.AutoGenerateColumns = false;
                this.gvMultiAccountWithdrawl.DataSource = withdrawList;
                this.CalculateTotalAmount(withdrawList);
            }
            else
            {
                this.gvMultiAccountWithdrawl.DataSource = null;
                this.EnableControls("Withdraw.Currency.Enable");
            }
            this.Status = "Add";
          
        }

        public void SetFocusOnCheque()
        {
            this.txtChequeNo.Focus();
        }

        public void SetFocusOnNoOfPersonSign(bool yes)
        {
            if (yes)
                this.txtNoOfPersonToSign.Focus();
            else
                this.butAdd.Focus();
        }
        public void CalculateTotalAmount(IList<TLMDTO00047> withdrawList)
        {
            this.TotalAmount = 0;
            this.TotalCharges = 0;

            foreach (TLMDTO00047 entity in withdrawList)  
            {
                //if(this.IncomeByTransfer)
                //    this.TotalAmount += entity.Amount+entity.Commission+entity.CommunicationCharges;
                //else
                //this.TotalAmount += entity.Amount;

                //if (entity.IncomeByCashStatus)
                //    this.TotalCharges += entity.Comissions + entity.CommunicationCharges;

                    if (entity.IncomeByCashStatus)   //edited by ASDA
                    {                        
                        this.TotalAmount += entity.Amount;
                        this.TotalCharges += entity.Commission + entity.CommunicationCharges;
                    }
                    else
                    {
                        this.TotalAmount += entity.Amount + entity.Commission + entity.CommunicationCharges;
                        //this.TotalCharges += entity.Commission + entity.CommunicationCharges;
                    }
            }        
        }
        public void CheckedJoinType()
        {
            if (this.JoinType == "A")
            {
                this.rdoJointTypeA.Checked = true;
                this.rdoJointTypeB.Checked = false;
            }
            else if (this.JoinType == "B")
            {
                this.rdoJointTypeB.Checked = true;
                this.rdoJointTypeA.Checked = false;
            }
            else
            {
                this.rdoJointTypeA.Checked = false;
                this.rdoJointTypeB.Checked = false;
            }
 
        }
        public void Successful(string message, string name, string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { name, this.GroupNo });
            this.cboCurrency.Focus();
        }
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private bool CounterChecking()
        {
            string counterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCounterType);
            foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
            {
                if (Info.CounterType == counterType)
                {
                    return true;
                }
            }
            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20047);   //Invalid Counter Type          
            return false;
        }
        #endregion

        #region Event  
        private void TLMVEW00014_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.InitializeControls();
            //this.cboCurrency.CausesValidation = false;
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.InitializeControls();
                this.cboCurrency.CausesValidation = false;
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("WithdrawEntry.AllDisable");
            }
            #endregion
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { this.Name, this.AccountNo });
        }
        private void butCalculate_Click(object sender, EventArgs e)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00008", true, new object[] { this.Name, this.Amount }) == DialogResult.OK)
            {
                return;
            }

        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls(true);
            this.controller.ClearErrors();
            this.gvMultiAccountWithdrawl.DataSource = null;
            this.InitializeControls();
            this.EnableControls("Withdraw.Currency.Enable");            
            this.gvMultiAccountWithdrawl.DataSource = null;
            this.rdoJointTypeA.Checked = false;
            this.rdoJointTypeB.Checked = false;
            this.txtTotalAmount.Text = string.Empty;
            this.txtTotalCharges.Text = string.Empty;
            this.cboCurrency.Focus();

            if (this.WithdrawLists.Count > 0)
            {
                this.WithdrawLists = new List<TLMDTO00047>();
            }
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            this.Close();
        }
        private void gvMultiAccountWithdrawlInformation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }       

        private void butAdd_Click(object sender, EventArgs e)
        {
            this.IsEdit = true;
            if (this.Controller.ValidateAdd())
            {
                if (this.Status == "Update")
                    this.WithdrawLists.RemoveAt(SerialNo);
                else if (this.Count == this.WithdrawLists.Count)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00210);
                    return;
                }

                TLMDTO00047 addDTO = this.controller.AddWithdrawInfo();
                if (addDTO != null)
                {
                    this.WithdrawLists.Add(addDTO);
                }
                if (this.controller.View.IsCloseAccount!=true)
                {
                    this.BindgvMultiAccountWithdrawlInformation(WithdrawLists);
                }
                
                if (addDTO == null)
                {
                    this.chkVIPCustomer.Focus();
                }
                else
                {
                    this.Controller.ClearControls(false);
                }
                this.CheckedJoinType();
                this.rdoIncomeByCash.Checked = true;
            }
            this.mtxtAccountNo.Focus();
        }

        private void ckhInputIncomeAmount_CheckedChanged(object sender, EventArgs e)
        {            
            this.EnableControls("WithdrawEntry.gbOnlineInformation.EnableControls");
            if(string.IsNullOrEmpty(this.Status))
                this.txtCommunicationCharges.Focus();
            if (chkInputIncomeAmount.Checked == false)
            {
                this.DisableControls("WithdrawEntry.gbOnlineInformation.DisableControls");
            }
        }  

        private void gvMultiAccountWithdrawlInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;

            DataGridViewRow dataRow = (DataGridViewRow)gvMultiAccountWithdrawl.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (e.ColumnIndex == 1)
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                {
                    this.WithdrawLists.RemoveAt(e.RowIndex);
                    this.BindgvMultiAccountWithdrawlInformation(this.WithdrawLists);
                    this.CalculateTotalAmount(this.WithdrawLists);
                    this.Status = "Add";
                }
            }
            else if (e.ColumnIndex == 0)
            {
                TLMDTO00047 withdrawEntity = this.gvMultiAccountWithdrawl.Rows[e.RowIndex].DataBoundItem as TLMDTO00047;
                this.SerialNo = e.RowIndex;        
                this.AccountNo = withdrawEntity.AccountNo;
                this.Name = withdrawEntity.Name;
                this.ChequeNo = withdrawEntity.ChequeNo;             
                this.NoOfPersonSign = Convert.ToInt32(withdrawEntity.NoOfPerSignJoinType.Substring(0,1));
                this.JoinType = withdrawEntity.NoOfPerSignJoinType.Substring(2);
                this.Amount = withdrawEntity.Amount; 
                this.CommunicationCharges = withdrawEntity.CommunicationCharges;
                this.Comissions = withdrawEntity.Commission;    //edited by ASDA
                this.PrintStatus = withdrawEntity.PrintTransactionStatus;
                this.VIPCustomer = withdrawEntity.IsVIP;
                this.CurrencyCode = withdrawEntity.CurrencyCode;
                this.IsLastWithdrawal = withdrawEntity.IsLastWithdrawal;
                this.Status = "Update";             
                this.IsCheckGrid = true;
                this.CheckedJoinType();
                if (withdrawEntity.AccountSing.Substring(0, 1)=="S")
                {
                    this.txtChequeNo.Enabled = false;
                }
                if (withdrawEntity.IncomeType == "1")
                { this.rdoIncomeByCash.Checked = true; }
                else if (withdrawEntity.IncomeType == "2")
                { this.rdoIncomeByTransfer.Checked = true; }
                else
                {
                    this.rdoIncomeByCash.Checked = false;
                    this.rdoIncomeByTransfer.Checked = false;
                }
            }
            //this.mtxtAccountNo.TabIndex = 4;
            this.mtxtAccountNo.Focus();            
        } 
      
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CounterChecking())
            {
                IList<TLMDTO00047> printDTO = new List<TLMDTO00047>();
                if (this.WithdrawLists.Count == 0)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30039);
                    return;
                }

                if (this.controller.SaveWithdraw(this.WithdrawLists))
                {
                    this.controller.Printing(this.WithdrawLists);

                    this.CurrencyCode = string.Empty;
                    this.gvMultiAccountWithdrawl.DataSource = null;
                    this.txtTotalAmount.Text = string.Empty;
                    this.txtTotalCharges.Text = string.Empty;  //added by ASDA
                    this.InitializeControls();
                    this.EnableControls("Withdraw.Currency.EnableControls");
                }
            }            
        }

        private void gvMultiAccountWithdrawl_Leave(object sender, EventArgs e)
        {
            this.tsbCRUD.Focus();
            //this.mtxtAccountNo.Focus();
        }

        private void TLMVEW00014_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        //private void cboCurrency_Leave(object sender, EventArgs e)
        //{
        //    if (this.Name.Contains("Withdrawal Entry"))
        //    {
        //        if (this.cboCurrency.SelectedIndex != -1)
        //        {
        //            this.DisableControls("Withdraw.Currency.Disable");
        //        }
        //    }
        //    else
        //    {
        //        this.cboCurrency.CausesValidation = false;
        //    }
        //}        

        #endregion

        

        //private void mtxtAccountNo_Enter(object sender, EventArgs e)
        //{
        //    this.Controller.txt
        //    if (this.IsCloseAccount == true)
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00044);   // Account No has been closed.      
        //        return;
        //        mtxtAccountNo.Text = "";
        //        mtxtAccountNo.Focus();
        //    }
        //}

        //private void cboCurrency_Validated(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.cboCurrency.Text))
        //    {
        //        this.cboCurrency.Focus();
        //        return;
        //    }
        //    else
        //        this.cboCurrency.Enabled = false;
        //    this.cboCurrency.CausesValidation = false;
        //}
    }
}
