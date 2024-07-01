//----------------------------------------------------------------------
// <copyright file="MNMVEW00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
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
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00023 : BaseDockingForm,IMNMVEW00023
    {
        #region Properties
        public string RegisterNo
        {
            get { return mtxtRegisterNo.Text; }
            set { mtxtRegisterNo.Text = value; }
        }
        public string DBank
        {
            get { return txtDraweeBank.Text; }
            set { txtDraweeBank.Text = value; }
        }
        public decimal Amount
        {
            get { return string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text); }
            set { txtAmount.Text = value.ToString(); }
        }
        public decimal Commission
        {
            get { return string.IsNullOrEmpty(txtCommission.Text) ? 0 : Convert.ToDecimal(txtCommission.Text); }
            set { txtCommission.Text = value.ToString(); }
        }
        public decimal TelexCharges
        {
            get { return string.IsNullOrEmpty(txtTelexCharges.Text) ? 0 : Convert.ToDecimal(txtTelexCharges.Text); }
            set { txtTelexCharges.Text = value.ToString(); }
        }
        public bool IsIncomeByTransfer
        {
            get { return rdoTransfer.Checked; }
            set { rdoTransfer.Checked = value; }
        }
        public bool IsIncomeByCash
        {
            get { return rdoCash.Checked; }
            set { rdoCash.Checked = value; }
        }
        public bool IsNoIncome
        {
            get { return rdoNoIncome.Checked; }
            set { rdoNoIncome.Checked = value; }
        }
        public string PayerAccountNo
        {
            get { return txtPayerAccountNo.Text; }
            set { txtPayerAccountNo.Text = value; }
        }
        public string PayerName
        {
            get { return txtPayerName.Text; }
            set { txtPayerName.Text = value; }
        }
        public string PayerNRC
        {
            get { return txtPayerNRC.Text; }
            set { txtPayerNRC.Text = value; }
        }
        public string PayerAddress
        {
            get { return txtPayerAddress.Text; }
            set { txtPayerAddress.Text = value; }
        }
        public string PayerPhoneNo
        {
            get { return txtPayerPhoneNo.Text; }
            set { txtPayerPhoneNo.Text = value; }
        }
        public string Narration
        {
            get { return txtNarration.Text; }
            set { txtNarration.Text = value; }
        }
        public string PayeeAccountNo
        {
            get { return txtPayeeAccountNo.Text; }
            set { txtPayeeAccountNo.Text = value; }
        }
        public string PayeeName
        {
            get { return txtPayeeName.Text; }
            set { txtPayeeName.Text = value; }
        }
        public string PayeeNRC
        {
            get { return txtPayeeNRC.Text; }
            set { txtPayeeNRC.Text = value; }
        }
        public string PayeeAddress
        {
            get { return txtPayeeAddress.Text; }
            set { txtPayeeAddress.Text = value; }
        }
        public string PayeePhoneNo
        {
            get { return txtPayeePhoneNo.Text; }
            set { txtPayeePhoneNo.Text = value; }
        }
        public bool GroupNoLabelVisible
        {
            set { lblGroupNoLable.Visible = value; }
        }
        public string GroupNo
        {
            get { return lblGroupNo.Text; }
            set { lblGroupNo.Text = value; }
        }
        public string ChequeNo
        {
            get { return txtChequeNo.Text; }
            set { txtChequeNo.Text = value; }
        }
        public string IncomeType
        {
            get { return rdoCash.Checked ? "CS" : rdoTransfer.Checked ? "TR" : null; }
        }
        public string DrawingType 
        {
            get { return string.IsNullOrEmpty(txtPayerAccountNo.Text) ? "Cash" : "Account"; }
        }
        public string Currency 
        {
            get { return lblCurrency.Text; }
            set { lblCurrency.Text = value; }
        }
        public bool SaveStatus { get; set; }
        public decimal CalculateCommission { get; set; }
        public decimal TlxCharges { get; set; }
        public string OldIncomeType { get; set; }
        public string OldDrawingType { get; set; }
        public string AcSign { get; set; }
        public decimal OldCashAmount { get; set; }
        public string OldChqueNo { get; set; }
        public string OldAccountNo { get; set; }
        public string OCheque { get; set; }
        #endregion

        #region Controller
        private IMNMCTL00023 controller;
        public IMNMCTL00023 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        public MNMVEW00023()
        {
            InitializeComponent();
        }

        public void SetEnableToEdit(bool status)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, status, true, true, false, true);
            txtAmount.Enabled = status;
            txtPayerAccountNo.Enabled = status;
            txtPayerName.Enabled = status;
            txtPayerNRC.Enabled = status;
            txtPayerAddress.Enabled = status;
            txtPayerPhoneNo.Enabled = status;
        }

        public void ClearControl()
        {
            this.RegisterNo = string.Empty;
            this.DBank = string.Empty;
            this.Amount = 0;
            this.Commission = 0;
            this.TelexCharges = 0;
            this.IsIncomeByCash = false;
            this.IsIncomeByTransfer = false;
            this.IsNoIncome = false;
            this.PayerAccountNo = string.Empty;
            this.PayerName = string.Empty;
            this.PayerNRC = string.Empty;
            this.PayerAddress = string.Empty;
            this.PayerPhoneNo = string.Empty;
            this.Narration = string.Empty;
            this.PayeeAccountNo = string.Empty;
            this.PayeeName = string.Empty;
            this.PayeeNRC = string.Empty;
            this.PayeeAddress = string.Empty;
            this.PayeePhoneNo = string.Empty;
            this.SaveStatus = false;
            this.GroupNo = string.Empty;
            this.Currency = string.Empty;
            //this.GroupNoLabelVisible = false;
            this.ChequeNo = string.Empty;

            this.mtxtRegisterNo.Focus();
        }

        public void BindCommession()
        {
            if (rdoNoIncome.Checked)
            {
                txtCommission.Text = "0.00";
                txtTelexCharges.Text = "0.00";
            }
            else
            {
                txtCommission.Text = this.CalculateCommission.ToString();
                txtTelexCharges.Text = this.TlxCharges.ToString();
            }
        }

        public void ChequeEnable()
        {
            this.EnableControls("RDImportantDataEdit.txtChequeNo.EnableControls");
        }

        public void ChequeDisable()
        {
            this.EnableControls("RDImportantDataEdit.txtChequeNo.DisableControls");
        }

        #region Events
        private void MNMVEW00023_Load(object sender, EventArgs e)
        {
            this.txtPayerAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
        }

        private void rdoNoIncome_CheckedChanged(object sender, EventArgs e)
        {
            this.BindCommession();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControl();
            this.controller.ClearErrors();
            this.EnableControl();
            this.mtxtRegisterNo.Focus();
             
            
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.Controller.Delete();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPayerAccountNo.Text))
            {
                if (rdoTransfer.Checked)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30007");  //Please Select Income type (Cash or No Income).
                    return;
                }
            }
            if (!string.IsNullOrEmpty(AcSign) && AcSign[0] == 'C')
            {
                if (string.IsNullOrEmpty(ChequeNo))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV30008");  //Cheque No. cannot be blank.
                    return;
                }
            }
            this.SaveStatus = true;
            this.Controller.Save();
            this.EnableControl();
            //this.mtxtRegisterNo.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //Added by ASDA
        private void MNMVEW00023_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
        //end

        public void DisableControl()
        {
           
            this.txtPayerAccountNo.Enabled = false ;
            this.txtPayerAddress.Enabled = false ;
            this.txtPayerName.Enabled = false ;
            this.txtPayerNRC.Enabled = false ;
            this.txtPayerPhoneNo.Enabled = false;
            this.txtNarration.Enabled = false;
            //this.txtChequeNo.Enabled = false ;
            this.mtxtRegisterNo.Enabled = false;
        }
        public void EnableControl()
        {

            this.txtPayerAccountNo.Enabled = true;
            this.txtPayerAddress.Enabled = true;
            this.txtPayerName.Enabled = true;
            this.txtPayerNRC.Enabled = true;
            this.txtPayerPhoneNo.Enabled = true;
            this.txtNarration.Enabled = true;
            //this.txtChequeNo.Enabled = false ;
            this.mtxtRegisterNo.Enabled = true;
        }
        public void SetFocus()
        {
            this.txtChequeNo.Focus();
        }

        public void SetFocusToRegisterNo()
        {
            this.mtxtRegisterNo.Focus();
        }

        private void txtChequeNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtChequeNo.Text.ToString()) || this.txtChequeNo.Text != "")
            this.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
        }
    }
}
