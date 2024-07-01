//----------------------------------------------------------------------
// <copyright file="MNMVEW00016.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00016 : BaseForm,IMNMVEW00016
    {
        #region Constructor
        public MNMVEW00016()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string GroupNo
        {
            get { return this.txtGroupNo.Text; }
            set { this.txtGroupNo.Text = value; }
        }

        public string PaymentOrderNo
        {
            get { return this.txtPaymentOrderNo.Text; }
            set { this.txtPaymentOrderNo.Text = value; }
        }

        public string BudgetYear
        {
            get { return this.txtBudgetYear.Text; }
            set { this.txtBudgetYear.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text; }
            set { this.txtCurrency.Text = value; }
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

        public string CreditedAccountNo
        {
            get { return this.mtxtCreditedAccountNo.Text.Replace("-", " "); }
            set { this.mtxtCreditedAccountNo.Text = value; }
        }

        public string Name
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        //private string status = string.Empty;
        //public string Status
        //{
        //    get { return this.status; }
        //    set { this.status = value; }
        //}


        //public bool MultiCheck { get; set; }
        #endregion

        #region Controller
        private IMNMCTL00016 controller;
        public IMNMCTL00016 Controller
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

        #region Events
        private void MNMVEW00016_Load(object sender, EventArgs e)
        {
            #region Old Logic
            /*
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControls();
            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.InitializeControls();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.InitializeControls();
                this.DisableControls("PORefundReverse.AllDisable");
            }
            #endregion
        }

        private void rdoSinglePO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSinglePO.Checked)
            {
                //this.MultiCheck = false;
                this.VisibleGroupNo(false);
            }
        }   

        private void rdoMultiPO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMultiPO.Checked)
            {
                //this.MultiCheck = true;
                this.VisibleGroupNo(true);
                //this.txtGroupNo.Focus();
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGroupNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPaymentOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        #region Methods
        public void InitializeControls()
        {
            this.VisibleGroupNo(false);
            this.VisibleTransferRefund(false);
            //this.EnableControls(true);
            this.rdoSinglePO.Checked = true;
            this.VisibleCurrency(false);
            //this.txtCurrency.Visible = false;
            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }

        public void VisibleGroupNo(bool enable)
        {
            this.lblGroupNo.Visible = enable;
            this.txtGroupNo.Visible = enable;
            //this.txtCurrency.Visible = enable;
        }

        public void VisibleCurrency(bool enable)
        {
            this.txtCurrency.Visible = enable;
        }

        public void VisibleTransferRefund(bool enable)
        {
            this.lblCreditedAccountNo.Visible = enable;
            this.mtxtCreditedAccountNo.Visible = enable;
            this.lblName.Visible = enable;
            this.txtName.Visible = enable;
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            return;
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            return;
        }

        private void MNMVEW00016_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //public void EnableControls(bool enable)
        //{
        //    this.txtGroupNo.Enabled = enable;
        //    this.txtPaymentOrderNo.Enabled = enable;
        //}
        #endregion
    }
}
