//----------------------------------------------------------------------
// <copyright file="TLMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>01/08/2013</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using System.Linq;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Entry -> Clearing -> Delivered Entry & Entry -> Clearing -> Receipt Entry
    /// </summary>
    public partial class TLMVEW00006 : BaseForm, ITLMVEW00006
    {
        #region "Constructor"
        public TLMVEW00006()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private ITLMCTL00006 clearingDeliveredReceiptController;
        public ITLMCTL00006 Controller
        {
            get
            {
                return this.clearingDeliveredReceiptController;
            }
            set
            {
                this.clearingDeliveredReceiptController = value;
                this.clearingDeliveredReceiptController.View = this;
            }
        }
        #endregion

        #region "Controls Input Output"

        public string TransactionStatus
        {
            get { return this.FormName; }
        }

        public string BankDescriptionLabel
        {
            set { this.lblBankDescription.Text = value; }            
        }
        public string AccountName
        {
            set 
            {
                this.lvName.Items.Clear();
                this.lvName.Items.Add(value); 
            }
            get
            {
                if (this.lvName.Items.Count > 0)
                    return this.lvName.Items[0].Text;
                else 
                    return string.Empty;
            }
        }
        public string OtherBankLabel
        {
            set { this.lblOtherBank.Text = value; }
        }
        public string ChequeNoLabel
        {
            set { this.lblChequeNo.Text = value; }
        }
        public string AccountNoLabel
        {
            set { this.lblAccountNo.Text = value; }
        }
        public string PayInSlipNo
        {
            set { this.txtPaySlip.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string ChequeNo
        {
            get { return this.txtChequeNo.Text; }
            set { this.txtChequeNo.Text = value; }
        }
        public string ReceiptAccountNo
        {
            get
            {
                return this.mtxtReceiptAccountNo.Text.Trim();
            }

            set
            { this.mtxtReceiptAccountNo.Text = value; }
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

            set 
            {            
                this.cboCurrency.SelectedValue = value;
            }

        }       

        public string OtherBank
        {
            get
            {
                if (this.cboOtherBank.SelectedValue == null)
                {
                    return null;
                }

                else
                {
                    return this.cboOtherBank.SelectedValue.ToString();
                }
            }

            set
            {
                this.cboOtherBank.SelectedValue = value;
            }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Value); }
            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        public bool isDeliver { get; set; }
        #endregion

        #region "Variable"
        public IList<TLMDTO00040> BCodeList { get; set; }
        #endregion

        #region "Methods"

        public void FoucsCursorOnChequeNo()
        {
            this.txtChequeNo.Focus();
        }

        private void InitializeControls()
        {
            switch (this.TransactionStatus)
            {
                case "Clearing.Receipt":
                    this.Text = "Clearing Receipt Entry";                                  
                    this.AccountNoLabel = "Paid Account No:";
                    this.isDeliver = false;
                    break;

                case "Clearing.Delivered":
                    this.Text = "Clearing Delivered Entry";
                    this.OtherBankLabel = "Paid Bank";
                    this.ChequeNoLabel = "Other Bank Cheque No:";
                    this.isDeliver = true;
                    break;
            }
            this.BindComboBoxes();
            this.Controller.ClearControls();
            this.txtPaySlip.ReadOnly = true;
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtChequeNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ChequeNoMaximumValue); 
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Focus();
        }

        public void EnableDisableCurrencyCombo(bool enable)
        {
            this.cboCurrency.Enabled = enable;
        }

        public void EnableDisableControlForDomesticReceipt(bool enable)
        {           
            this.txtAmount.Enabled = enable;
            this.cboOtherBank.Enabled = enable;

        }

        public void EnableDisableControls(bool enable)
        {
            this.txtChequeNo.Enabled = enable;
            this.txtAmount.Enabled = enable;
            this.cboOtherBank.Enabled = enable;
            this.mtxtReceiptAccountNo.Enabled = enable;
        }

        private void BindComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;

            this.BCodeList = CXCLE00002.Instance.GetListObject<TLMDTO00040>("BCode.Client.Select",new object[] {true});
            this.cboOtherBank.ValueMember = "BCode";
            this.cboOtherBank.DisplayMember = "BCode";
            cboOtherBank.DataSource = this.BCodeList;
        }

        public void Successful(string message, string paySilpNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Payment Slip No",paySilpNo });
            this.InitializedState();
        }
       
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void InitializedState()
        {
            this.Controller.ClearControls();
            this.EnableDisableControls(false);
            this.EnableDisableCurrencyCombo(true);
            this.mtxtAccountNo.Focus();
            if (this.isDeliver)
            {
                this.txtChequeNo.Enabled = true;
            }
        }

        public void IsDomestic(bool enable)
        {
            this.txtChequeNo.Enabled = enable;
            this.mtxtReceiptAccountNo.Enabled = enable;
            if (!enable)
            {
                this.cboCurrency.Enabled = true;
                this.CurrencyCode = string.Empty;
                this.ChequeNo = string.Empty;
                this.ReceiptAccountNo = string.Empty;
                this.OtherBank = string.Empty;
                this.BankDescriptionLabel = string.Empty;
                this.Amount = 0;
                this.cboCurrency.Focus();
            }
        }

        public void DeliverDomesticFormCleaning()
        {
            this.cboCurrency.Enabled = true;
            this.cboCurrency.SelectedIndex = 0;
            this.ChequeNo = string.Empty;
            this.ReceiptAccountNo = string.Empty;
            this.Amount = 0;
            this.OtherBank = string.Empty;
            this.cboCurrency.Focus();
            this.BankDescriptionLabel = string.Empty;
        }
        #endregion

        #region "Events"

        private void TLMVEW00006_Load(object sender, EventArgs e)
        {
            //this.ActiveControl = this.mtxtAccountNo;
            // Set Initialize Controls
            this.InitializeControls();
            // Enable / Disable Controls
            this.EnableDisableControls(false);
            //Hide Controls
            if (this.TransactionStatus == "Clearing.Delivered")
            {
                this.HideControls(this.TransactionStatus);
                this.txtChequeNo.Enabled = true;
            }
        }
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedState();
            this.mtxtAccountNo.Focus();
        }
        
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void mtxtReceiptAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            
        }

        private void TLMVEW00006_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
