//----------------------------------------------------------------------
// <copyright file="TCMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khaing Su Wai</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
using Ace.Cbs.Cx.Cle;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Tcm.Vew
{
   
    public partial class TCMVEW00004 : BaseForm,ITCMVEW00004
    {
        #region "Constractor"
        public TCMVEW00004()
        {
            InitializeComponent();
        }
        #endregion

        #region "Variables"
        public string SourceBranchCode { get; set; }
        #endregion

        #region "Controls Input Output"

        public string BudgetYear
        {
            get { return this.txtBudgetYear.Text.Trim(); }
            set { this.txtBudgetYear.Text = value; }
        }

        public string RegisterNo
        {
            get { return this.txtRegisterNo.Text.Trim(); }
            set { this.txtRegisterNo.Text = value; }
        }

        public string Name
        {
            get { return this.txtName.Text.Trim(); }
            set { this.txtName.Text = value; }
        }

        public string Currency
        {
            get { return this.txtCurrency.Text.Trim(); }
            set { this.txtCurrency.Text = value; }
        }

        public string PONo
        {
            //get { return this.txtPaymentOrderNo.Text.Trim(); }
            set { this.txtPaymentOrderNo.Text = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Value); }
            set { this.txtAmount.Text = Convert.ToString(value); }
        }

      


        #endregion

        #region "Controller"
        private ITCMCTL00004 poIssueForEncashmentController;
        public ITCMCTL00004 Controller
        {
            get
            {
                return this.poIssueForEncashmentController;
            }
            set
            {
                this.poIssueForEncashmentController = value;
                this.poIssueForEncashmentController.View = this;
            }
        }



        #endregion

        #region "Method"

        private void InitializeControls()
        {
            this.txtRegisterNo.Focus();
            this.SourceBranchCode = CurrentUserEntity.BranchCode;
            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);            
            txtCurrency.ReadOnly = true;
            txtPaymentOrderNo.ReadOnly = true;
            txtBudgetYear.ReadOnly = true;
            txtName.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtName.Text = "";
            txtAmount.Text = "0.00";
        }

        
        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            // Clear all controls
            this.Controller.ClearControls();
            this.Controller.ClearTextBox();
            this.InitializeControls();
      
        }
        public void SetFocusOnRegisterNo()
        {
            txtRegisterNo.Focus();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message, string registerNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { registerNo });
        }
        public void ClearErrors()
        {

        }

        #endregion

        #region Event
        private void TCMVEW00004_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            Controller.ClearControls();
            InitializeControls();
           
        }


        private void txtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            Controller.ClearControls();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }

        private void txtRegisterNo_Validated(object sender, EventArgs e)
        {

        }

        #endregion

        private void TCMVEW00004_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void cxC00062_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

      
       

    }
}
