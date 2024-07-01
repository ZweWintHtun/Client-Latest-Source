//----------------------------------------------------------------------
// <copyright file="TLMVEW00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Clearing Voucher Entry
    /// </summary>

    public partial class TLMVEW00021 : BaseDockingForm, ITLMVEW00021
    {
        #region CONSTRUCTOR
        public TLMVEW00021()
        {
            InitializeComponent();
        }
        #endregion

        #region CONTROLLER
        private ITLMCTL00021 controller;
        public ITLMCTL00021 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region CONTROLS INPUT OUTPUT
       
        public string VoucherNo
        {
            get { return this.txtVoucherNo.Text; }
            set { this.txtVoucherNo.Text = value; }
        }
      
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
      
        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }
       
        public decimal Amount
        {
            get { return this.txtAmount.Value; }
            set { this.txtAmount.Text = value.ToString(); }
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
       
        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public string VoucherType
        {
            get { return rdoDebit.Checked ? CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DebitVoucherType) : CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CreditVoucherType); }
            set { this.VoucherType = value; }
        }

        public string TransactionCode
        {
            get { return rdoDebit.Checked ? CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitVoucher) : CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingCreditVoucher); }
            set { this.VoucherType = value; }
        }

        #endregion

        #region METHODS

        private void InitializeControls()
        {
            this.DisableControls("ClearingVoucher.SwitchButton.Disable");
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);  
            this.txtVoucherNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.VoucherNoFormat);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DomesticAccountFormat);
            this.txtAmount.Text = "0.00";
            this.BindCurrencyComboBox();
            this.cboCurrency.Focus();
            this.rdoDebit.Select();
        }

        private void BindCurrencyComboBox()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;           
        }

        public void gvClearing_DataSourceNull()
        {
            this.gvClearingVoucher.DataSource = null;
        }

        public void gv_ClearingVoucherDataBind(IList<PFMDTO00054> tlfDTOList)
        {
            gvClearingVoucher.DataSource = null;
            gvClearingVoucher.AutoGenerateColumns = false;
            gvClearingVoucher.DataSource = tlfDTOList;
        }

        public void Successful(string message, string voucherNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Clearing Voucher No", voucherNo });          
        }
     
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region EVENTS

        private void TLMVEW00021_Load(object sender, EventArgs e)
        {
            this.InitializeControls();            
        }

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tsbCRUD_NewButtonClick(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.EnableControls("ClearingVoucher.Enable");
            cboCurrency.Focus();
        }

        private void butSwitch_Click(object sender, EventArgs e)
        {
            if (this.controller.InsertClearingVoucher().Count > 0)
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

                this.mtxtAccountNo.Focus();
            }
            
           
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.gvClearing_DataSourceNull();
            this.controller.ClearErrors();
            this.InitializeControls();         
        }

        private void txtNarration_Validated(object sender, EventArgs e)
        {
            this.EnableControls("ClearingVoucher.SwitchButton.Enable");
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
           
                this.controller.SaveClearingVoucher();
                this.InitializeControls();
            
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            this.EnableControls("ClearingVoucher.Enable");           
           
        }

        #endregion
        
    }
}

       

    
    

