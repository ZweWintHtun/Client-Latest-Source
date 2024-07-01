//----------------------------------------------------------------------
// <copyright file="TCMVEW00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// PO Refund By Transfer Entry
    /// </summary>
    public partial class TCMVEW00002 : BaseForm, ITCMVEW00002
    {
        #region Constructor
        public TCMVEW00002()
        {
            InitializeComponent();
        }

        public string CurrentBCode { get; set; }

        #endregion

        #region Controller
        private ITCMCTL00002 controller;
        public ITCMCTL00002 Controller
        {
            get
            {
                { return this.controller; }
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Controls Input Output

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

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text; }
            set { this.txtCurrency.Text = value; }
        }

        public double Amount
        {     
            get { return Convert.ToDouble(this.txtAmount.Value); }
            set { this.txtAmount.Text = Convert.ToDouble(value).ToString("N2"); }
        }

        public string Acode { get; set; }
        #endregion

        #region Methods
        public void InitializeControls()
        {
           
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);

            // Modified by ZMS For Year End Flexible 2018/09/21
            //this.txtBudgetYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.txtBudgetYear.Text = this.Controller.GetBudYear();  
       
            //Commment and Added by HMW at 17-Sept-2019
            //this.rdoInternalRemittancePO.Checked = true;
            //this.txtPaymentOrderNo.Text = "IR";           
            this.rdoCustomerPO.Checked = true;
            this.txtPaymentOrderNo.Text = "PO";

            this.txtPaymentOrderNo.Focus();
            this.txtPaymentOrderNo.SelectionStart = 2;
            this.txtAmount.Text = "0.00";
        }

        public void POFocus()
        {            
            this.txtPaymentOrderNo.SelectionStart = 2;
            this.txtPaymentOrderNo.Focus();
        }

        public void AccountFocus()
        {
            this.mtxtAccountNo.Focus();
        }
        #endregion

        private void TCMVEW00002_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.InitializeControls();
            //this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //this.txtAmount.Text = "0.00";
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.InitializeControls();
                this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
                this.txtAmount.Text = "0.00";                
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("DealerPayOutstandRefund.AllDisable");
            }
            #endregion
        }

        private void TCMVEW00002_KeyDown(object sender, KeyEventArgs e)  //added by ASDA
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtPaymentOrderNo.Text))
            {
                if ((this.txtPaymentOrderNo.Text == "IR") || (this.txtPaymentOrderNo.Text == "PO"))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00219);
                    this.controller.ClearControls();
                    this.InitializeControls();
                }
                else
                {
                    this.controller.Save();
                    this.InitializeControls();
                }
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00219);
                this.controller.ClearControls();
                this.InitializeControls();
            }
        }     

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {          
            this.controller.ClearControls();
            this.InitializeControls();
        }

        #region Comment and Added by HMW at 17-Sept-2019
        //private void txtBudgetYear_Validated(object sender, EventArgs e)
        //{
        //    this.controller.CheckPO();
        //}
        private void txtPaymentOrderNo_Validated(object sender, EventArgs e)
        {
            this.controller.CheckPO();
        }     

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }      
        
        #endregion

        private void rdoCustomerPO_CheckedChanged(object sender, EventArgs e)
        {
            this.PONo = "PO";
            this.POFocus();

            if (rdoInternalRemittancePO.Checked)
            {
                this.PONo = "IR";
                this.POFocus(); 
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void EnableControlsforPrint()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, true, true);
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Printing();
            this.InitializeControls();
        }

        private void TCMVEW00002_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }                                        
    }
}
