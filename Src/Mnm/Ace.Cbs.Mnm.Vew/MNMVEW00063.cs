//----------------------------------------------------------------------
// <copyright file="MNMVEW00063.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00063 : BaseForm, IMNMVEW00063
    {
        #region Constructor
        public MNMVEW00063()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public decimal StartAmount
        {
            get { return Convert.ToDecimal(this.txtStartAmount.Text); }
            set { this.txtStartAmount.Text = value.ToString(); }
        }

        public decimal EndAmount
        {
            get { return Convert.ToDecimal(this.txtEndAmount.Text); }
            set { this.txtEndAmount.Text = value.ToString(); }
        }

        public string Currency
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

        public bool IscheckAllCurrency
        {
            get
            {
                return this.chkAllCurrency.Checked;
            }
            set
            {
                this.chkAllCurrency.Checked = true;
            }
        }

        public string IsrdoCurrent
        {            
            get
            {
                if (this.rdoCurrentAccount.Checked == true)
                {
                    return "Current Account";
                }

                else
                {
                    return "Saving Account";
                }
            }

            set
            {
                if (value == "Current Account")
                {
                    this.rdoCurrentAccount.Checked = true;
                }
                else
                {
                    this.rdoSavingAccount.Checked = true;
                }
            }
        }

        private string parentFormName = string.Empty;
        public string ParentFormName
        {
            get { return this.parentFormName; }
            set { this.parentFormName = value; }
        }
        #endregion

        #region Controller
        private IMNMCTL00063 controller;
        public IMNMCTL00063 Controller
        {
            get { return controller; }
            set 
            { 
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region BindComboBox
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }
        #endregion

        #region InitializeControl
        private void InitizlizeControl()
        {
            this.rdoCurrentAccount.Checked = true;
            this.txtStartAmount.Text = "0.00";
            this.txtEndAmount.Text = "0.00";
            this.chkAllCurrency.Checked = false;
            this.cboCurrency.Enabled = true;
            this.BindCurrency();
            this.rdoCurrentAccount.Focus();
            this.controller.ClearErrors();
        }
        #endregion

        private void MNMVEW00063_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = "Ledger Balance By Grade";
            //if (this.FormName.Equals("LedgerBalanceByGrade.ByCurrent"))
            //{
            //    this.parentFormName = "LedgerBalanceByGrade.ByCurrent";
            //}
            //else
            //{
            //    this.parentFormName = "LedgerBalanceByGrade.BySaving";
            //}
            this.InitizlizeControl();
        }



        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitizlizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void chkAllCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllCurrency.Checked == true)
            {
                this.cboCurrency.Text = string.Empty;
                this.cboCurrency.Enabled = false;
            }
            else
            {
                this.cboCurrency.Enabled = true;
            }
        }
    }
}
