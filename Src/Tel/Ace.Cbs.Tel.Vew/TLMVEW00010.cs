//----------------------------------------------------------------------
// <copyright file="TLMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
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
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00010 : BaseDockingForm, ITLMVEW00010
    {
        #region Constrator

        public TLMVEW00010()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private ITLMCTL00010 controller;
        public ITLMCTL00010 Controller
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
        public int Count { get; set; }

        public string Status { get; set; }

        public bool LocationTransactions { get; set; }

        public string LocalBranchCode { get; set; }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string VoucherNo
        {
            get { return this.txtVoucherNo.Text; }
            set { this.txtVoucherNo.Text = value; }
        }

        public string VoucherLabel
        {
            get { return this.lblGroupNo.Text; }
            set { this.lblGroupNo.Text = value; }
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

        public string Name
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string AccountSign { get; set; }

        public string NRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
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

        public decimal TotalAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtTotalAmount.Text = value.ToString(); }
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
                if (this.chkPrintTransactions.Checked)
                    return true;
                else
                    return false;
            }
            set { this.chkPrintTransactions.Checked = value; }
        }

        public decimal CurrentBalance { get; set; }

        #endregion

        #region Entity

        private TLMDTO00038 depositEntity;
        public TLMDTO00038 DepositEntity
        {
            get
            {
                if (this.depositEntity == null)
                {
                    this.depositEntity = new TLMDTO00038();
                    //this.depositEntity.Cha = "CBS";// CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CBSChannel);
                }
                this.depositEntity.AccountNo = this.AccountNo;
                this.depositEntity.AccountSign = this.AccountSign;
                this.depositEntity.Amount = this.Amount;
                this.depositEntity.Narration = this.Narration;
                this.depositEntity.Currency = this.Currency;
                this.depositEntity.NRC = this.NRC;
                return this.depositEntity;
            }
            set
            {
                this.depositEntity = value;
            }
        }

        public CXDTO00001 DenoInfo { get; set; }

        #endregion

        #region Method

        private void InitializeControls()
        {
            this.Count = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MultiTransactionCount));
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.LocalBranchCode = CurrentUserEntity.BranchCode;
            this.BindComboBoxes();
            this.DisableControls("Deposit.Disable");
            this.Controller.ClearControls(true);
            this.DepositEntity.IsCheckCustomAccountValidation = true;
            this.DepositEntity.IsCheckGridview = true;
        }
        public void Disable()
        {
            this.chkPrintTransactions.Enabled = false;
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
            cboCurrency.SelectedIndex = 0;
        }

        public void Successful(string message,string name,string VoucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { name, VoucherNo });
            this.cboCurrency.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void EnableControlsforView(string name)
        {
            this.EnableControls(name);
        }

        public void DisableControlsforView(string name)
        {
            this.DisableControls(name);
        }
        public void GetEnablePrintStaus(bool isSaving)
        {
            this.chkPrintTransactions.Enabled = isSaving == true ? true : false;
            
            //this.chkPrintTransactions=isPrint==true?
        }

        private TLMDTO00038 BindDataToEntity()
        {
            DenoEntity = new TLMDTO00038();
            DenoEntity.AccountNo = this.AccountNo;
            DenoEntity.Currency = this.Currency;
            DenoEntity.Name = this.Name;
            DenoEntity.AccountSign = this.AccountSign;
            DenoEntity.NRC = this.NRC;
            DenoEntity.Narration = this.Narration;
            DenoEntity.Amount = this.Amount;
            DenoEntity.Commissions = this.Commissions;
            DenoEntity.CommunicationCharges = this.CommunicationCharges;
            DenoEntity.IsPrintTransaction = this.PrintTransactions;
            DenoEntity.BranchCode = this.BranchCode;
            DenoEntity.CurrentBalance = this.CurrentBalance;            

            return DenoEntity;
        }

        private void AddData()
        {
            if (this.Status == "Update")
                this.DenoCollection.RemoveAt(SerialNo);
            else if (this.Count == this.DenoCollection.Count)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00210);
                return;
            }
            
            this.DenoCollection.Add(this.BindDataToEntity());
            this.BindData();
        }

        public void BindData()
        {
            if (DenoCollection.Count > 0)
            {
                this.gvDepositInformation.DataSource = null;
                this.gvDepositInformation.AutoGenerateColumns = false;
                this.gvDepositInformation.DataSource = this.DenoCollection;
            }
            else
            {
                this.gvDepositInformation.DataSource = null;
                this.EnableControls("Curreny.Enable");
            }
            this.Status = "Add";
            this.DepositEntity.IsCheckGridview = true;
            this.DepositEntity.IsCheckCustomAccountValidation = true;
        }

        #endregion

        #region Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00010_Load(object sender, EventArgs e)
        {
            //Enatble Disable Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            this.lblTransactionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void butCalculate_Click(object sender, EventArgs e)
        {
            this.Controller.Call_RemittanceCalculator();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.DepositEntity.IsCheckGridview = true;
            this.DepositEntity.IsCheckCustomAccountValidation = false;

            if (Controller.Save())            
            {                
                Controller.Printing();
                this.InitializeControls();
                Controller.ClearControls(true);                
            }
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            this.Controller.Call_AccountInformationEnquiry();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearControls(true);
            this.cboCurrency.Focus();
        }

        private void chkInputIncomeAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (InputIncomeAmount == true)
            {
                this.EnableControls("Deposit.EnableTransactions");
                this.txtCommunicationCharges.Focus();
            }
            else
                this.DisableControls("Deposit.OnlieDisable");
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            this.DepositEntity.IsCheckGridview = false;
            this.DepositEntity.IsCheckCustomAccountValidation = false;

            if (this.Controller.ValidateAdd())
            {
                this.AddData();
                this.Controller.CalculateTotalAmount();
                this.Controller.ClearControls(false);
            }
            //this.tsbCRUD.Focus();
       this.mtxtAccountNo.Focus();
        }

        private void gvDeposit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
                {
                    this.DenoCollection.RemoveAt(e.RowIndex);
                    
                    this.BindData();
                    this.Controller.CalculateTotalAmount();
                    this.Status = "Add";
                }
            }
            else if (e.ColumnIndex == 0)
            {
                TLMDTO00038 depositEntity = this.gvDepositInformation.Rows[e.RowIndex].DataBoundItem as TLMDTO00038;
                this.SerialNo = e.RowIndex;
                this.AccountNo = depositEntity.AccountNo;
                this.Name = depositEntity.Name;
                this.NRC = depositEntity.NRC;
                this.Narration = depositEntity.Narration;
                this.Amount = depositEntity.Amount;
                this.CommunicationCharges = depositEntity.CommunicationCharges;
                this.Commissions = depositEntity.Commissions;
                this.PrintTransactions = depositEntity.IsPrintTransaction;
                if (depositEntity.AccountSign.Substring(0, 1) == "C")
                {
                    this.chkPrintTransactions.Enabled = false;
                }
                this.Status = "Update";
            }
        }

        private void gvDepositInformation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion
    }
}
