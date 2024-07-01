//----------------------------------------------------------------------
// <copyright file="TLMVEW00001" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
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
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00001 : BaseForm, ITLMVEW00001
    {
        #region Constructor
        public TLMVEW00001()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string DomesticAccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string Description
        {
            get { return this.lblDescription.Text; }
            set { this.lblDescription.Text = value; }
        }

        public string Narration
        {
            get { return txtNarration.Text; }
            set { txtNarration.Text = value; }
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

        public string VoucherNo
        {
            get { return this.mtxtVoucherNo.Text; }
            set { this.mtxtVoucherNo.Text = value; }
        }

        public string CurrencyCode
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

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        public string Status
        {
            get { return this.lblAmount.Text; }
            set { this.lblAmount.Text = value; }
        }
        #endregion

        #region Controller
        private ITLMCTL00001 controller;
        public ITLMCTL00001 Controller
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

        #region events
        private void TLMVEW00001_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.EnableDisableControls();
            this.lblAmount.Text = "Credit Amount :";
            this.mtxtVoucherNo.ReadOnly = true;
            this.BindCurrencyComboBoxes();
            this.ParentFormId = this.Name;
            this.InitializeControls();
            if (this.FormName.Equals("DomesticVoucher.Credit"))
            {
                this.Text = "Domestic Credit Voucher Entry";
                this.rdoCreditVoucher.Checked = true;
                this.rdoDebitVoucher.Enabled = false;
            }
            else
            {
                this.Text = "Domestic Debit Voucher Entry";
                this.rdoDebitVoucher.Checked = true;
                this.rdoCreditVoucher.Enabled = false;
            }
             */

            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.EnableDisableControls();
                this.lblAmount.Text = "Credit Amount :";
                this.mtxtVoucherNo.ReadOnly = true;
                this.BindCurrencyComboBoxes();
                this.ParentFormId = this.Name;
                this.InitializeControls();
                if (this.FormName.Equals("DomesticVoucher.Credit"))
                {
                    this.Text = "Domestic Credit Voucher Entry";
                    this.rdoCreditVoucher.Checked = true;
                    this.rdoDebitVoucher.Enabled = false;
                }
                else
                {
                    this.Text = "Domestic Debit Voucher Entry";
                    this.rdoDebitVoucher.Checked = true;
                    this.rdoCreditVoucher.Enabled = false;
                }
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("DomesticVoucher.AllDisable");
            }
            #endregion
        }

        private void rdoCreditVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCreditVoucher.Checked)
            lblAmount.Text = "Credit Amount :";
        }

        private void rdoDebitVoucher_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDebitVoucher.Checked)
            lblAmount.Text = "Debit Amount :";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
            this.InitializeControls();
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        #region Methods
        private void BindCurrencyComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void EnableDisableControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void InitializeControls()
        {
            this.cboCurrency.Focus();
            //this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DomesticAccountFormat);
        }

        public void Successful(string message, string VoucherNo)
        {
            if (Status == "Credit Amount :")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Credit Voucher No", VoucherNo });
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Debit Voucher No", VoucherNo });
            }
            
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        private void TLMVEW00001_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //private void Controls_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Enter))
        //    {
        //        SendKeys.Send("{Tab}");
        //    }
        //}
    }
}
