using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
//using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Ctr.Ptr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00029 : BaseDockingForm, ILOMVEW00029
    {
        #region Constrator
        public LOMVEW00029()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private ILOMCTL00029 controller;
        public ILOMCTL00029 Controller
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

        public decimal TotalAmount { get; set; }

        public string BranchCode { get; set; }

        public bool PrintTransactions { get; set; }

        public decimal CurrentBalance { get; set; }

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
        public string LocalBranchCode { get; set; }
        public string Status { get; set; }
        public int SerialNo { get; set; }
        public bool LocationTransactions { get; set; }
        public bool IsCurrentAccount { get; set; }
        public bool IsDomesticAccount { get; set; }
        public string condition { get; set; }
        public bool AllowedPrinting { get; set; }
        private TLMDTO00038 DenoEntity;
        public decimal CurrentBal { get; set; }
        public decimal TransactionCount { get; set; }
        public int PrintLineNo { get; set; }
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
                this.transferEntity.AccountNo = this.AccountNo;
                this.transferEntity.Amount = this.Amount;
                this.transferEntity.Currency = this.Currency;
                this.transferEntity.Narration = this.Narration;
                this.transferEntity.ChequeNo = this.ChequeNo;
                this.transferEntity.IsCurrentAccount = this.IsCurrentAccount;
                this.transferEntity.IsDebit = this.IsDebitTransaction;
                this.transferEntity.IsCredit = this.IsCreditTransaction;
                this.transferEntity.BranchCode = this.BranchCode;
                this.transferEntity.IsDomesticAccount = this.IsDomesticAccount;

                return this.transferEntity;
            }
            set
            {
                this.transferEntity = value;
            }
        }

        #endregion

        #region Method
    
        public void DisableEnableControl(bool isDebit)
        {
            if (isDebit)
            {
                this.EnableControls("SpecialTransfer.Enable.Cheque");
            }
            else
            {
                this.DisableControls("SpecialTransfer.Disable.Cheque");
            }
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
            this.Controller.ClearControls(true);
            this.TransferEntity.IsCheckCustomAccountValidation = true;
            this.TransferEntity.IsCheckGridview = true;
            this.condition = " ";

        }
        public void SetCursor(string txt)
        {
            if (txt == "Currency")
                this.cboCurrency.Focus();
            else if (txt == "Amount")
                txtAmount.Focus();
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Symbol";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        public void Successful(string message, string name, string VoucherNo)
        {
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
            DenoEntity.Currency = this.Currency;
            DenoEntity.AccountSign = this.AccountSign;
            DenoEntity.Description = this.Description;
            DenoEntity.ChequeNo = this.ChequeNo;
            DenoEntity.Narration = this.Narration;
            DenoEntity.Amount = this.Amount;
            DenoEntity.TotalAmount = this.Amount;
            DenoEntity.IsCredit = this.IsCreditTransaction;
            DenoEntity.IsDebit = this.IsDebitTransaction;
            DenoEntity.VoucherType = this.IsCreditTransaction == true ? "Credit" : "Debit";            
            DenoEntity.BranchCode = this.BranchCode;
            DenoEntity.IsCurrentAccount = this.IsCurrentAccount;
            DenoEntity.IsDomesticAccount = this.IsDomesticAccount;
            DenoEntity.IsPrintTransaction = this.PrintTransactions;
            DenoEntity.CurrentBal = this.CurrentBal;
            DenoEntity.TransactionCount = this.TransactionCount;
            DenoEntity.PrintLineNo = this.PrintLineNo;
            if (!this.IsDomesticAccount)
            {
                if (AccountSign.Substring(0, 1).Equals("S") && IsCreditTransaction)

                    DenoEntity.IsPrintTransaction = this.PrintTransactions = true;
                else
                    DenoEntity.IsPrintTransaction = this.PrintTransactions = false;
            }


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
                this.EnableControls("Currency.Enable");
            }
            this.Status = "Add";
            this.TransferEntity.IsCheckGridview = true;
            this.TransferEntity.IsCheckCustomAccountValidation = true;

        }
        #endregion

        #region Event
        private void LOMVEW00029_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            this.lblTransactionDate.Text = System.DateTime.Today.ToShortDateString();
            this.cboCurrency.Select();
        }


        private void txtChequeNo_Validated(object sender, EventArgs e)
        {
            if (this.ChequeNo != string.Empty)
                this.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
        }

        private void gvTransferInformation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls(true);
            this.cboCurrency.Focus();
            this.txtChequeNo.Enabled = true;
            this.condition = " ";
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            this.TransferEntity.IsCheckGridview = false;
            if (!this.Controller.ValidateAdd())
                        return;
            if (IsDebitTransaction && this.controller.checkAccount())
            {
                this.AddData();
                this.Controller.ClearControls(false);
            }
            else if(IsCreditTransaction)
            {
                this.AddData();
                this.Controller.ClearControls(false);
            }
            this.mtxtAccountNo.Focus();
            this.rdoDebit.Checked = true;

        }

        private void gvTransferInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            else if (e.ColumnIndex == 1)
            {
                //if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                {
                    this.DenoCollection.RemoveAt(e.RowIndex);

                    this.BindData();
                    this.Status = "Add";
                    this.mtxtAccountNo.Focus();
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
                this.IsCreditTransaction = transferEntity.IsCredit;
                this.IsDebitTransaction = transferEntity.IsDebit;
                this.AccountSign = transferEntity.AccountSign;
                this.Amount = transferEntity.Amount;
                this.PrintTransactions = transferEntity.IsPrintTransaction;
                this.DisableEnableControl(transferEntity.IsCurrentAccount);
                this.TransferEntity.IsCheckCustomAccountValidation = true;
                this.Status = "Update";
                this.mtxtAccountNo.Focus();
            }
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
                        Controller.Printing();
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
                        Controller.Printing();
                        Controller.ClearControls(true);
                    }
                }
            }
            this.txtChequeNo.Enabled = true;
            this.condition = " ";
        }
        #endregion 

        #region KeyDown & KeyPress

        private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

    }
}
