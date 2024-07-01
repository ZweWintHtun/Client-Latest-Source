//----------------------------------------------------------------------
// <copyright file="TLMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ya Min Phyu,Htet Zar Chi Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Ye Mann Aung</UpdatedUser>
// <UpdatedDate>2013-07-10</UpdatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00008 : BaseDockingForm, ITLMVEW00008
    {
        #region Constructor

        public TLMVEW00008()
        {
            InitializeComponent();
        }

        public TLMVEW00008(string parentFromId, decimal amount)
        {
            InitializeComponent();
            this.ParentFormId = parentFromId;
            this.Amount = this.RemittanceAmount = amount;
        }

        #endregion

        #region Properties

        public string ParentFormId { get; set; }

        private ITLMCTL00008 controller;
        public ITLMCTL00008 Controller
        {
            get { return controller; }
            set 
            { 
                controller = value; 
                controller.View =this;
            }
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

        public string BranchCode
        {
            get
            {
                if (this.cboBranchNo.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranchNo.Text.ToString();
                }
            }
            set
            {
                this.cboBranchNo.Text = value;
                this.cboBranchNo.SelectedValue = value;
            }
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

        public bool TakeIncomeSeperately
        {
            get { return rdoTakeIncomeSeperately.Checked; }
            set { rdoTakeIncomeSeperately.Checked = value; }
        }

        public decimal RemittanceAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtRemittanceAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtRemittanceAmount.Text = value.ToString(); }
        }

        public decimal Income
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtIncome.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtIncome.Text = value.ToString(); }
        }

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

        #endregion

        #region Methods

        private void TLMVEW00008_Load(object sender, EventArgs e)
        {
            //this.tsbCRUD.ButtonEnableDisabled(firstButtonEnabled, previousButtonEnabled, nextButtonEnabled, lastButtonEnabled, newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled, cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);

            cboCurrencyDataBind();
            cboBranchNoDataBind();
        }

        private void cboCurrencyDataBind()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });//5.2
            cboCurrency.DisplayMember = "Cur";//6.1
            cboCurrency.ValueMember = "Cur";//6.1
            cboCurrency.DataSource = CurrencyList;//6.1
            cboCurrency.SelectedIndex = 0;
        }

        private void CleaningForm()
        {
            cboBranchNo.SelectedIndex = -1;
            cboCurrency.SelectedIndex = 0;
            this.Controller.Clearing();
            this.cboBranchNo.Focus();
        }

        private void cboBranchNoDataBind()
        {
            cboBranchNo.DisplayMember = "BranchCode";//6.2
            cboBranchNo.ValueMember = "BranchCode";//6.2	
            cboBranchNo.DataSource = this.Controller.GetAllBranchList();//6.2

            //Added by HMW at 24-Aug-2019
            if (cboBranchNo.DataBindings.Count == 0)//If there is only one branch
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00024);//Cannot find other branch information.
            }
            else
            {
                cboBranchNo.SelectedIndex = 0;
            }
        }

        #endregion

        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butCalculate_Click(object sender, EventArgs e)
        {
            this.Controller.CalculateCharges(Amount, BranchCode, Currency, TakeIncomeSeperately);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.CleaningForm();
        }

        #endregion


    }
}
