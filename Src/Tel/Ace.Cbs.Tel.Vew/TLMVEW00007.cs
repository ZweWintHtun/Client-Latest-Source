//----------------------------------------------------------------------
// <copyright file="TLMVEW00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
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
    /// Entry -> PO Receipt Entry
    /// </summary>
    public partial class frmTLMVEW00007 : BaseForm,ITLMVEW00007
    {
        #region "Constructor"
        public frmTLMVEW00007()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private ITLMCTL00007 controller;
        public ITLMCTL00007 POReceiptController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.POReceiptView = this;
            }
        }
        #endregion

        #region "Controls Input Output"       

        public string PaySlipNo
        {
            get { return this.txtPaySlipNo.Text.Trim(); }
            set { this.txtPaySlipNo.Text = value; }
        }

        public string PaymentOrderNo
        {
            get { return this.txtPaymentOrderNo.Text.Trim(); }
            set { this.txtPaymentOrderNo.Text = value; }
        }

        public string BudgetYear
        {
            get { return this.txtBudgetYear.Text.Trim(); }
            set { this.txtBudgetYear.Text = value; }
        }

        public string ReceivedAccountNo
        {
            get { return this.mtxtReceivedAccountNo.Text.Trim(); }
            set { this.mtxtReceivedAccountNo.Text = value; }
        }

        public string OtherBank
        {
            get
            {
                if (this.cboReceivedBank.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboReceivedBank.SelectedValue.ToString();
                }
            }

            set { this.cboReceivedBank.SelectedValue = value; }
        }

        public string Currency
        {
            get
            {
                return this.txtCurrency.Text.Trim();
            }
            set { this.txtCurrency.Text = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Text.Trim()); }
            set { this.txtAmount.Text = value.ToString(); }
        }
       
        public string CurrentBCode { get; set; }

        #endregion

        #region "Public Methods"
        public void InitializeControls()
        {
            this.EnableDisableControls();
            this.txtPaymentOrderNo.Focus();
            this.txtPaymentOrderNo.Text = "PO";
            this.txtPaymentOrderNo.SelectionStart = 2;
            this.txtPaySlipNo.Enabled = false;

            // Modified by ZMS For Year End Flexible 2018/09/21
            //this.txtBudgetYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.txtBudgetYear.Text = this.POReceiptController.GetBudYear();

            this.mtxtReceivedAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.BindReceivedBankCombobox();
        }

        public void BudgetYearInitializeControls()
        {
            this.txtBudgetYear.SelectionStart = 9;
        }
        public void Successful(string message, string payslipNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { payslipNo });
            this.controller.ClearControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }       

        #endregion

        #region "Private Methods"
        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void BindReceivedBankCombobox()
        {
            IList<TLMDTO00040> BCodeList = CXCLE00002.Instance.GetListObject<TLMDTO00040>("BCode.Client.Select", new object[] { true });
            this.cboReceivedBank.ValueMember = "BCode";
            this.cboReceivedBank.DisplayMember = "BDesp";
            this.cboReceivedBank.DataSource = BCodeList;
            this.cboReceivedBank.SelectedIndex = -1;
        }
        #endregion

        #region "Events"
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TLMVEW00007_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
            this.txtPaymentOrderNo.Focus();
            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }
           
        private void txtBudgetYear_Leave_1(object sender, EventArgs e)
        {
            this.txtCurrency.Enabled = false;           
        }      
        #endregion 

        private void mtxtReceivedAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmTLMVEW00007_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
}
}
