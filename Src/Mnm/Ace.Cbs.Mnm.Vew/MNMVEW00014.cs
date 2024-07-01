//----------------------------------------------------------------------
// <copyright file="MNMVEW00014.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00014 : BaseForm,IMNMVEW00014
    {
        #region Constructor
        public MNMVEW00014()
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

        public decimal Charges
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtCharges.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtCharges.Text = value.ToString(); }
        }

        public string Date
        {
            get { return this.txtDate.Text; }
            set { this.txtDate.Text = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }

        private string status = string.Empty;
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

      
        public bool MultiCheck { get; set; }
        #endregion

        #region Controller
        private IMNMCTL00014 controller;
        public IMNMCTL00014 Controller
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
        private void MNMVEW00014_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            this.InitializeControls();
            this.txtAmount.ReadOnly = true;
        }

        private void rdoSinglePO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSinglePO.Checked)
            {
                this.MultiCheck = false;
                this.VisibleGroupNo(false);
            }
        }

        private void rdoMultiPO_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMultiPO.Checked)
            {
                this.MultiCheck = true;
                this.VisibleGroupNo(true);
                this.txtGroupNo.Focus();
            }
        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Edit())
            {
                this.txtCurrency.Visible = true;
                this.txtAmount.ReadOnly = false;
                this.EnableControls(false);
                tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            }
            else
            {
                if (this.MultiCheck == true)
                {
                    //this.InitializeControls();
                    this.VisibleGroupNo(true);
                    this.EnableControls(true);
                    this.rdoMultiPO.Checked = true;
                    this.txtCurrency.Visible = false;
                    this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                }
                else
                {
                    //this.InitializeControls();
                    this.VisibleGroupNo(false);
                    this.EnableControls(true);
                    this.rdoSinglePO.Checked = true;
                    this.txtCurrency.Visible = false;
                    this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                }

            }
        }

        private void txtAmount_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Status))
            {
                if (this.Amount > 0)
                { Charges = CXCLE00010.Instance.CalculatePOrate(this.Amount, this.Currency); }
                else
                { 
                    CXUIMessageUtilities.ShowMessageByCode("MV00037");//Invalid Amount.
                }
            }          
            
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
            tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            this.InitializeControls();
            this.txtAmount.ReadOnly = true;           
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)//Are you sure you want to delete?
            {
                this.controller.Delete();
                this.InitializeControls();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            this.controller.ClearControls();
            this.controller.ClearErrors();
            this.InitializeControls();
            this.EnableControls(true);
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
            this.EnableControls(true);
            this.rdoSinglePO.Checked = true;
            this.txtCurrency.Visible = false;
            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void VisibleGroupNo(bool enable)
        {
            this.lblGroupNo.Visible = enable;
            this.txtGroupNo.Visible = enable;
            //this.txtCurrency.Visible = enable;
        }

        public void EnableControls(bool enable)
        {
            this.txtGroupNo.Enabled = enable;
            this.txtPaymentOrderNo.Enabled = enable;
        }
        #endregion

        private void MNMVEW00014_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

     }
}
