//----------------------------------------------------------------------
// <copyright file="TLMVEW00002" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
   /// <summary>
   /// ENCASH REMIT REGISTRATION ENTRY
   /// </summary>
    public partial class TLMVEW00002 : BaseDockingForm, ITLVEW00002
    {
        #region CONSTRUCTOR
        public TLMVEW00002()
        {
            InitializeComponent();
        }
        #endregion

        #region CONTROLLER
        private ITLMCTL00002 controller;
        public ITLMCTL00002 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #endregion

        #region CONTROLS INPUT OUTPUT
        public string BranchCode
        {
            get
            {
                if (this.cboPaidBank.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboPaidBank.SelectedValue.ToString();
                }
            }

            set { this.cboPaidBank.SelectedValue = value; }
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

        public decimal Amount
        {
            get
            {
                return Convert.ToDecimal(this.txtEncashAmount.Text);
            }
            set { this.txtEncashAmount.Text = value.ToString(); }
        }

        public string FixRegisterNo
        {
            get { return this.txtFixRegisterNo.Text; }
            set { this.txtFixRegisterNo.Text = value; }
        }

        public string RegisterNo
        {
            get { return this.txtRegisterNo.Text; }
            //get { return this.txtFixRegisterNo.Text+this.txtRegisterNo.Text; }
            set { this.txtRegisterNo.Text = value; }

        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", " "); }
            set { this.mtxtAccountNo.Text = value; }

        }

        public string RemitterName
        {
            get { return this.txtRemitterName.Text; }
            set { this.txtRemitterName.Text = value; }
        }

        public string RemitterNRC
        {
            get { return this.txtRemitterNRCNo.Text; }
            set { this.txtRemitterNRCNo.Text = value; }
        }

        public string RemitterPhoneNo
        {
            get { return this.txtRemitterPhone.Text; }
            set { this.txtRemitterPhone.Text = value; }
        }

        public string PayeeName
        {
            get { return this.txtPayeeName.Text; }
            set { this.txtPayeeName.Text = value; }
        }

        public string PayeeNRC
        {
            get { return this.txtPayeeNRC.Text; }
            set { this.txtPayeeNRC.Text = value; }
        }

        public string PayeeAddress
        {
            get { return this.txtPayeeAddress.Text; }
            set { this.txtPayeeAddress.Text = value; }
        }

        public string PayeePhoneNo
        {
            get { return this.txtPayeePhone.Text; }
            set { this.txtPayeePhone.Text = value; }
        }

        public string PONo
        {
            get { return this.txtPaymentOrderNo.Text; }
            set { this.txtPaymentOrderNo.Text = value; }
        }

        public string BudgetYear
        {
            get { return this.txtBudgetYear.Text; }
            set { this.txtBudgetYear.Text = value; }
        }

        IList<BranchDTO> BranchList { get; set; }
        public string AccountSign { get; set; }
        public bool POStatus { get; set; }
        public string status { get; set; }

        private string transactionStatus;
        public string TransactionStatus
        {
            get
            {
                if (rdoByTelaxTR.Checked == true)
                {
                    return this.transactionStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TelaxTransfer);

                }
                else if (rdoByOnline.Checked == true)
                {
                    return this.transactionStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.InterBranchLinking);

                }
                else
                { return null; }

            }

            set
            {
                this.transactionStatus = value;
            }
        }
        #endregion

        #region METHODS
        private void InitializeControls()
        {
            //Enable Diaable Toolstrip Menu
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.BindCurrencyCombobox();          
                //IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectOtherBank", true);               
            this.BindBranchCode();
          
            this.EnableControls("EncashRemittanceRegistration.PaidBankandCurrency.EnableControls");
            this.HideControls("EncashRemittanceRegistration.PO.HiddenControls");
           this.rdoByTelaxTR.Focus();    
            
        }

        private void BindCurrencyCombobox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void ReadOnlyControls(bool enable)
        {
            this.txtPayeeName.ReadOnly = enable;
            this.txtPayeeNRC.ReadOnly = enable;
            this.txtPayeeAddress.ReadOnly = enable;
            this.txtPayeePhone.ReadOnly = enable;
        }

        public void ClearHistoryPayeeGroupBox()
        {
            this.txtPayeeName.Text = string.Empty;
            this.txtPayeeNRC.Text = string.Empty;
            this.txtPayeeAddress.Text = string.Empty;
            this.txtPayeePhone.Text = string.Empty;
        }

        public void BindBranchCode()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListByCustomHQL<BranchDTO>("BranchCodeAndBranchDesp.SelectAllBranches", new Dictionary<string, object>() { { "sourcebranchcode", CurrentUserEntity.BranchCode } });
            cboPaidBank.ValueMember = "BranchCode";
            cboPaidBank.DisplayMember = "BranchCode";
            cboPaidBank.DataSource = BranchList;
            cboPaidBank.SelectedIndex = -1;
        }

        public void Successful(string message, string PONo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "PO No", PONo });
 
            this.InitializeControls();
            this.ReadOnlyControls(false);
            this.rdoByOnline.Enabled = true;
            this.rdoByTelaxTR.Enabled = true;
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.rdoByTelaxTR.Focus();
            this.txtEncashAmount.Enabled = true;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void ComboValidate(string data)
        {
            if (data == "Paid Bank")
            {
                //if (cboPaidBank.SelectedIndex != -1)
                //{
             //   this.DisableControls("EncashRemittanceRegistration.PaidBank.DisableControls");
              
              //  }
            }
            else
            {
                if (cboCurrency.SelectedIndex != -1)
                {
                    this.DisableControls("EncashRemittanceRegistration.Currency.DisableControls");
                    this.DisableControls("EncashRemittanceRegistration.PaidBank.DisableControls");

                }
            }
        }

        public void RegisterNoFocus()
        {
            this.txtRegisterNo.Focus();
        }

        public void Shows()
        {
            this.ShowControls("EncashRemittanceRegistration.PO.VisibleControl");
        }

        #endregion       

        #region Event
        private void TLMVEW00002_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }
           
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            string voucher = this.controller.Save();
            if (!string.IsNullOrEmpty(voucher) && voucher.Substring(0, 2) == "IR")
            {
                if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)//Are you sure to print?
                {
                    this.controller.Printing();
                }
            }
            this.controller.ClearControls();
            this.chkPOIssueForEncashment.Checked = false;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.ReadOnlyControls(false);
            this.rdoByOnline.Enabled = true;
            this.rdoByTelaxTR.Enabled = true;
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.rdoByTelaxTR.Focus();
            this.txtEncashAmount.Enabled = true;
            
        }

        private void rdoByOnline_CheckedChanged(object sender, EventArgs e)
        {
            this.BindBranchCode();
        }

        private void chkPOIssueForEncashment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPOIssueForEncashment.Checked)
            {
                POStatus = true;
                this.ShowControls("EncashRemittanceRegistration.Budget.VisibleControl");
                this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            }
            else
            {
                POStatus = false;
                gbPOIssue.Visible = false;

            }
        }             

        private void txtPayeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //this.Shows();
        }

        private void txtPayeeNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPayeeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRemitterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRemitterNRCNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void mtxtAccountNo_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.mtxtAccountNo.Text.Trim()))      //account no is not null.
            {
                this.chkPOIssueForEncashment.Visible = false;
                this.chkPOIssueForEncashment.Checked = false;
                this.gbPOIssue.Visible = false;

                if (this.controller.GetCustomerByAccountNo())
                {

                    if (!this.tsbCRUD.butSave.ContainsFocus)
                    {
                        this.txtRemitterName.Focus();
                    }
                    return;
                }
                else
                {
                    this.mtxtAccountNo.Focus();
                }
            }
            else
            {
                this.chkPOIssueForEncashment.Visible = true;
                this.ReadOnlyControls(false);
                this.PayeeName = string.Empty;
                this.PayeeNRC = string.Empty;
                this.PayeeAddress = string.Empty;
                this.PayeePhoneNo = string.Empty;
                //this.mtxtAccountNo.Focus();
                //this.ClearHistoryPayeeGroupBox();
            }
        }

        private void txtEncashAmount_Validated(object sender, EventArgs e)
        {
            if (this.rdoByTelaxTR.Checked == true)
            {
                if (this.txtEncashAmount.Text != "0.00")
                {
                    this.rdoByOnline.Enabled = false;
                }
            }
            else if (this.rdoByOnline.Checked == true)
            {
                if (this.txtEncashAmount.Text != "0.00")
                {
                    this.rdoByTelaxTR.Enabled = false;
                }
            }
        }

        public void Disable()
        {
            this.DisableControls("EncashRemittanceRegistration.DisableControls");
        }

        #endregion

        private void txtPayeePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 60 && e.KeyChar <= 90)

                e.Handled = true;

            if (e.KeyChar >= 97 && e.KeyChar <= 122)
                e.Handled = true;

        }

        private void txtRemitterPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 60 && e.KeyChar <= 90)

                e.Handled = true;

            if (e.KeyChar >= 97 && e.KeyChar <= 122)
                e.Handled = true;

        }

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }

        

    }

}
    
       
    

       
    
        
    