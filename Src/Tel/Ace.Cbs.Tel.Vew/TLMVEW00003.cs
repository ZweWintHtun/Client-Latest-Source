//----------------------------------------------------------------------
// <copyright file="TLMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Kswin</UpdatedUser>
// <UpdatedDate></UpdatedDate>
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
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00003 : BaseDockingForm, ITLMVEW00003
    {
        IList<PFMDTO00001> lst;
        #region Constrator

        public TLMVEW00003()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private ITLMCTL00003 controller;
        public ITLMCTL00003 Controller
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

        private TLMDTO00038 DenoEntity;

        private IList<TLMDTO00038> denoCollection;
        public IList<TLMDTO00038> DenoCollection
        {
            get
            {
                if (this.denoCollection == null)
                    this.denoCollection = new List<TLMDTO00038>();

                return this.denoCollection;
            }
            set
            {
                this.denoCollection = value;
            }
        }

        public int SerialNo { get; set; }

        public string Status { get; set; }

        public bool LocationTransactions { get; set; }

        public string LocalBranchCode { get; set; }

        public string VoucherNo
        {
            get { return this.txtVoucherNo.Text; }
            set { this.txtVoucherNo.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public bool IsVIP
        {
            get
            {
                if (this.chkVIP.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkVIP.Checked = value; }
        }

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

        public string Currency
        {
            get
            {
                if (this.cboCurrency.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public string AccountSign { get; set; }

        public string ChequeNo
        {
            get { return this.txtChequeNo.Text; }
            set { this.txtChequeNo.Text = value; }
        }

        public decimal Amount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }
        
        public decimal TotalAmount { get; set; }

        public decimal LinkAmount { get; set; }

        public string BranchCode { get; set; }

        public decimal CommunicationCharges
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtCommunicationCharges.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtCommunicationCharges.Text = value.ToString(); }
        }

        public decimal Commissions
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtCommissions.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtCommissions.Text = value.ToString(); }
        }

        public bool InputIncomeAmount
        {
            get
            {
                if (this.chkInputIncomeAmount.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkInputIncomeAmount.Checked = value; }
        }

        public bool PrintTransactions
        {
            get
            {
                if (this.chkPrintTransaction.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkPrintTransaction.Checked = value; }
        }

        public decimal CurrentBalance { get; set; }
        
        public bool IsIncomeByCash
        {
            get
            {
                if (this.rdoIncomeByCash.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoIncomeByCash.Checked = value; }
        }

        public bool IsDomesticAccount { get; set; }

        public bool IsIncomeByTransfer
        {
            get
            {
                if (this.rdoIncomeByTransfer.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoIncomeByTransfer.Checked = value; }
        }

        public bool IsDebitTransaction
        {
            get
            {
                if (this.rdoDebit.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoDebit.Checked = value; }
        }

        public bool IsCreditTransaction
        {
            get
            {
                if (this.rdoCredit.Checked)
                    return true;
                else
                    return false;
            }
            set { this.rdoCredit.Checked = value; }
        }

        public bool IsCurrentAccount { get; set; }

        public bool IsAutoLink { get; set; }

        public bool AllowedPrinting { get; set; }

        public string condition { get; set; }

        public string FormName { get; set; }

        public DateTime TransactionDate { get; set; }//For Print Voucher Date 

        #endregion

        #region Entity

        private TLMDTO00038 transferEntity;
        public TLMDTO00038 TransferEntity
        {
            get
            {
                if (this.transferEntity == null)
                {
                    this.transferEntity = new TLMDTO00038();
                }
                this.transferEntity.IsVIP = this.IsVIP;
                this.transferEntity.AccountNo = this.AccountNo;
                this.transferEntity.Amount = this.Amount;
                this.transferEntity.Narration = this.Narration;
                this.transferEntity.Currency = this.Currency;
                this.transferEntity.ChequeNo = this.ChequeNo;
                this.transferEntity.IsCurrentAccount = this.IsCurrentAccount;
                this.transferEntity.IsDebit = this.IsDebitTransaction;
                this.transferEntity.IsCredit = this.IsCreditTransaction;
                this.transferEntity.BranchCode = this.BranchCode;
                this.transferEntity.IsDomesticAccount = this.IsDomesticAccount;
                this.transferEntity.IsAutoLink = this.IsAutoLink;

                return this.transferEntity;
            }
            set
            {
                this.transferEntity = value;
            }
        }

      //  public CXDTO00001 DenoInfo { get; set; }

        #endregion

        #region Method

        public void TransactionForControls(bool isDebit,bool isLocal,bool isPrinting)
        {
            if (this.AccountNo.Length.Equals(6))
            {
                this.DisableControls("Transfer.Disable.COAAccount");
            }
            else
            {
                this.EnableControls("Transfer.Enable.COAAccount");
            }
            if (isDebit)
            {
                this.EnableControls("Transfer.Enable.OnlineDebit");
                if (isLocal)
                {
                    this.DisableControls("Transfer.Disable.LocalDebit");
                    if(!string.IsNullOrEmpty(condition))
                    this.DisableControls("Transfer.Disable.LocalAccount");


                    if (this.FormName == "TrOnline") //add by ksw
                    {
                        this.EnableControls("Transfer.Enable.OnlineAccount");
                        if (IsCurrentAccount)
                            this.EnableControls("Transfer.Enable.Cheque");
                        else
                            this.DisableControls("Transfer.Disable.Cheque");
                    }
                    else
                        this.DisableControls("Transfer.Disable.Cheque");
                    //if (IsCurrentAccount)
                    //    this.EnableControls("Transfer.Enable.Cheque");
                    //else
                    //    this.DisableControls("Transfer.Disable.Cheque");

                }
                else
                {
                    if (this.FormName == "TrOnline")
                    {
                        if (IsCurrentAccount)
                            this.EnableControls("Transfer.Enable.Cheque");
                        else
                            this.DisableControls("Transfer.Disable.Cheque");
                    }
                    else
                    {
                        this.DisableControls("Transfer.Disable.Cheque");
                        this.DisableControls("Transfer.Disable.LocalAccount");
                        
                    }

                }
            }
            else if (!isLocal)
            {
                this.EnableControls("Transfer.Enable.OnlineDebit");
                this.DisableControls("Transfer.Disable.OnlineCredit");
            }
            else
                this.DisableControls("Transfer.Disable.Credit");

            if (!isPrinting)
                this.DisableControls("Transfer.Disable.Printing");
            else
                this.EnableControls("Transfer.Enable.Printing");
        }


        #region addition
        public void DisableEnableControl(bool onlineTransaction)
        {
            if (onlineTransaction)
            { 
                this.EnableControls("Transfer.Enable.OnlineAccount");
                this.condition = " ";
            }
            else
            { 
                this.DisableControls("Transfer.Disable.LocalAccount");
                this.condition = "Local Account";
                butCalculate.Enabled = false; //Pristine Customize (They don't use for charges collection)
            } 
        }
        #endregion

        public void EnableControlsforView(string name)
        {
            this.EnableControls(name);
        }

        public void DisableControlsforView(string name)
        {
            this.DisableControls(name);
        }

        private void InitializeControls()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue);
            this.LocalBranchCode = CurrentUserEntity.BranchCode;
            this.Status = "Add";
            this.BindComboBoxes();
            this.DisableControls("Transfer.Disable.Load");
            this.Controller.ClearControls(true);
            this.TransferEntity.IsCheckCustomAccountValidation = true;
            this.TransferEntity.IsCheckGridview = true;
            this.condition = " ";
        }

        public void SetCursor(string txt)
        {
            if (txt == "Currency")
                cboCurrency.Focus();
            else if (txt == "Amount")
                txtAmount.Focus();
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            //cboCurrency.SelectedIndex = 1;
        }

        public void Successful(string message, string name ,string VoucherNo)
        {
            //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Voucher No",VoucherNo });
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { name, VoucherNo });
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private TLMDTO00038 BindDataToEntity()
        {
            DenoEntity = new TLMDTO00038();
            DenoEntity.AccountNo = this.AccountNo;
            DenoEntity.AccountSign = this.AccountSign;
            DenoEntity.Currency = this.Currency;
            DenoEntity.Description = this.Description;
            DenoEntity.IsVIP = this.IsVIP;
            DenoEntity.ChequeNo = this.ChequeNo;
            DenoEntity.Narration = this.Narration;
            DenoEntity.Amount = this.Amount;
            DenoEntity.LinkAmount = this.LinkAmount;
            //DenoEntity.Commissions = this.Commissions;
            //DenoEntity.CommunicationCharges = this.CommunicationCharges;
            DenoEntity.TotalAmount = this.Amount;// +this.Commissions + this.CommunicationCharges;
            DenoEntity.IsIncomeByCash = this.IsIncomeByCash;
            DenoEntity.IsIncomeByTransfer = this.IsIncomeByTransfer;
            DenoEntity.IsCredit = this.IsCreditTransaction;
            DenoEntity.IsDebit = this.IsDebitTransaction;
            DenoEntity.VoucherType = this.IsCreditTransaction == true ? "Credit" : "Debit";
            DenoEntity.AllowedPrinting = this.AllowedPrinting;
            DenoEntity.IsPrintTransaction = this.PrintTransactions;
            DenoEntity.BranchCode = this.BranchCode;
            DenoEntity.CurrentBalance = this.CurrentBalance;
            DenoEntity.IsDomesticAccount = this.IsDomesticAccount;
            DenoEntity.IsPrintTransaction = this.PrintTransactions;
            DenoEntity.IsAutoLink = this.IsAutoLink;
            DenoEntity.TransactionDate = this.TransactionDate;

            return DenoEntity;
        }

        private void AddData()
        {
            if (this.Status == "Update")
                this.DenoCollection.RemoveAt(this.SerialNo);

            this.DenoCollection.Add(this.BindDataToEntity());
            this.BindData();
            this.condition = " ";
        }

        public void BindData()
        {
            if (DenoCollection.Count > 0)
            {
                this.gvTransferInformation.DataSource = null;
                this.gvTransferInformation.AutoGenerateColumns = false;
                this.gvTransferInformation.DataSource = this.DenoCollection;
            }
            else
            {
                this.gvTransferInformation.DataSource = null;
                this.EnableControls("Curreny.Enable");
            }
            this.Status = "Add";
            this.TransferEntity.IsCheckGridview = true;
            this.TransferEntity.IsCheckCustomAccountValidation = true;

        }

        public void DisableControl(bool enable)
        {
            this.gbIncomeType.Enabled = enable;
            this.rdoIncomeByCash.Enabled = enable;
            this.rdoIncomeByTransfer.Enabled = enable;
            this.txtChequeNo.Enabled = enable;
        }

        #endregion

        #region Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00003_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");
            this.TransactionDate = systemDate;//For Print Voucher Date
        }

        private void butCalculate_Click(object sender, EventArgs e)
        {
            this.Controller.Call_RemittanceCalculator();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.denoCollection.Count > 2)
            {
                //     CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90046);
                //     return;

                if (!Controller.CheckAmount(this.DenoCollection))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00166);
                    return;
                }
                else
                {
                    this.TransferEntity.IsCheckGridview = true;
                    this.TransferEntity.IsCheckCustomAccountValidation = false;
                    if (Controller.Save())
                    {
                        //Controller.Printing();
                        Controller.ClearControls(true);
                    }
                }
            }
            else
            {
                if (!Controller.CheckAmount(this.DenoCollection))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00166);
                    return;
                }
                else
                {
                    this.TransferEntity.IsCheckGridview = true;
                    this.TransferEntity.IsCheckCustomAccountValidation = false;
                    if (Controller.Save())
                    {
                        //Controller.Printing();
                        Controller.ClearControls(true);
                    }
                }
            }
            this.condition = " ";
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            this.Controller.Call_Enquiry();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls(true);
            this.cboCurrency.Focus();
            this.DisableControl(true);
            this.condition = " ";
        }

        private void chkInputIncomeAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (InputIncomeAmount == true)
            {
                this.EnableControls("Transfer.Enable.Load");
                this.txtCommunicationCharges.Focus();
            }
            else
                this.DisableControls("Transfer.Disable.Charges");
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            //Added By AAM (31_July_2018)
            if (AccountNo.Length==15)
            {
                lst = this.controller.SelectByAccountNumber_ForNotAllowDrTrans(AccountNo, DateTime.Now);
                if (lst == null && IsDebitTransaction == true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90059);
                    return;
                }
               else if (lst == null && IsCreditTransaction == true)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90059);
                    return;
                }
            }

            this.condition = " ";
            this.TransferEntity.IsCheckGridview = false;
            IsAutoLink = false;
            //this.TransferEntity.IsCheckCustomAccountValidation = false;
            if (this.FormName == "TrLocal")   //add by ksw
            {
                if (this.Controller.ChecKLocalDrCr())
                {
                    if (!this.LocationTransactions && this.DenoCollection.Count == 2 && this.Status == "Add")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90046);
                        return;
                    }
                    else if (!this.Controller.ValidateAdd())
                        return;
                    //Need to check it only in Debit Transaction for DebitAccountInformationChecking()   ////Update By NLH
                    else if (IsDebitTransaction && !this.Controller.DebitAccountInformationChecking())
                        return;
                    else
                    {
                        this.AddData();
                        this.Controller.ClearControls(false);
                    }
                    this.mtxtAccountNo.Focus();
                }

            }
            else
            {
                if (this.Controller.ChecKOnlineDrCr())
                {
                    if (!this.LocationTransactions && this.DenoCollection.Count == 2 && this.Status == "Add")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90046);
                        return;
                    }
                    else if (!this.Controller.ValidateAdd())
                        return;
                    //Need to check it only in Debit Transaction for DebitAccountInformationChecking()   ////Update By NLH
                    else if (IsDebitTransaction && !this.Controller.DebitAccountInformationChecking())
                        return;
                    else
                    {
                        this.AddData();
                        this.Controller.ClearControls(false);
                        this.mtxtAccountNo.Focus();
                    }
                }
            }
           
        }         

        private void gvTransferInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            else if (e.ColumnIndex == 1)
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                {
                    this.DenoCollection.RemoveAt(e.RowIndex);

                    this.BindData();
                    this.Status = "Add";
                }
            }
            else if (e.ColumnIndex == 0)
            {
                TLMDTO00038 transferEntity = this.gvTransferInformation.Rows[e.RowIndex].DataBoundItem as TLMDTO00038;
                this.SerialNo = e.RowIndex;
                this.AccountNo = transferEntity.AccountNo;
                this.Description = transferEntity.Description;
                this.Narration = transferEntity.Narration;
                this.ChequeNo = transferEntity.ChequeNo;
                this.IsCurrentAccount = string.IsNullOrEmpty(this.ChequeNo) ? false : true;
                this.IsCreditTransaction = transferEntity.IsCredit;
                this.IsDebitTransaction = transferEntity.IsDebit;
                this.IsIncomeByCash = transferEntity.IsIncomeByCash;
                this.IsIncomeByTransfer = transferEntity.IsIncomeByTransfer;
                this.IsVIP = transferEntity.IsVIP;
                this.AccountSign = transferEntity.AccountSign;
                this.Amount = transferEntity.Amount;
                //this.CommunicationCharges = transferEntity.CommunicationCharges;
                //this.Commissions = transferEntity.Commissions;
                this.PrintTransactions = transferEntity.IsPrintTransaction;
                this.TransactionForControls(this.IsDebitTransaction, this.LocationTransactions,false);
                this.TransferEntity.IsCheckCustomAccountValidation = true;
                this.TransactionForControls(transferEntity.IsDebit, this.LocationTransactions, transferEntity.AllowedPrinting);
                this.Status = "Update";
            }
        }

        private void gvTransferInformation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        
        private void rdoDebit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.LocationTransactions)
            {
                this.EnableControls("Transfer.Enable.OnlineDebit");
                this.DisableControls("Transfer.Disable.LocalDebit");                
            }
            else
                this.EnableControls("Transfer.Enable.OnlineDebit");
            if (IsCurrentAccount && this.FormName == "TrOnline")
                this.EnableControls("Transfer.Enable.Cheque");
        }

        private void rdoCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.LocationTransactions)
            {
                this.EnableControls("Transfer.Enable.OnlineDebit");
                this.DisableControls("Transfer.Disable.OnlineCredit");
            }
            else
            {
                this.DisableControls("Transfer.Disable.Credit");
                butCalculate.Enabled = false; //Pristine Customize Requirement
            }
        }
        
        private void txtChequeNo_Validated(object sender, EventArgs e)
        {
            if(this.ChequeNo!=string.Empty)
                this.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
        }

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
