//----------------------------------------------------------------------
// <copyright file="LOMVEW00016" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>15.01.2015</CreatedDate>
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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    //Legal Sue Case 
    public partial class LOMVEW00016 : BaseForm, ILOMVEW00016
    {
        #region Constructor
        public LOMVEW00016()
        {
            InitializeComponent();
        }
        #endregion

        #region Legal Properties
        
        private ILOMCTL00016 controller;
        public ILOMCTL00016 Controller
        {
             get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
           
        }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public string LoanNo
        {
            get { return this.txtLoanNo.Text; }
            set { this.txtLoanNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string AdvanceType
        {
            get { return this.txtAdvanceType.Text; }
            set { this.txtAdvanceType.Text = value; }
        }
        public decimal InterestRate
        {
            get { return Convert.ToDecimal(this.txtInterestRate.Text); }
            set { this.txtInterestRate.Text = value.ToString(); }
        }
        public decimal ServicesCharges
        {
            get { return Convert.ToDecimal(this.txtServicesCharges.Text); }
            set { this.txtServicesCharges.Text = value.ToString(); }
        }
        public decimal LedgerBalance
        {
            get { return Convert.ToDecimal(this.txtLedgerBalance.Text); }
            set { this.txtLedgerBalance.Text = value.ToString(); }
        }
        public decimal SanctionAmount
        {
            get { return Convert.ToDecimal(this.txtSanctionAmount.Text); }
            set { this.txtSanctionAmount.Text = value.ToString(); }
        }
        public decimal Interest
        {
            get { return Convert.ToDecimal(this.txtInterest.Text); }
            set { this.txtInterest.Text = value.ToString(); }
        }
        public decimal ExtraCharges
        {
            get { return Convert.ToDecimal(this.txtExtraCharges.Text); }
            set { this.txtExtraCharges.Text = value.ToString(); }
        }
        public string LegalCaseLawyer
        {
            get { return txtLegalCaseLawyer.Text.ToString() ; }
            set { this.txtLegalCaseLawyer.Text = value; }
        }

        public string UserName
        {
            get { return this.lblLegalUser.Text; }
            set { this.lblLegalUser.Text = value; }
        }

        //private TLMDTO00018 viewData;
        //public TLMDTO00018 ViewData
        //{
        //    get
        //    {
        //        if (this.viewData == null) this.viewData = new TLMDTO00018();

        //        LoanEntity.Lno = this.view.LoanNo;
        //        LoanEntity.LegaLawer = this.view.LegalCaseLawyer;
        //        return viewData;

        //        return this.viewData;
        //    }
        //    set { this.viewData = value; }
        //}

        public string Status { get; set; }
        #endregion

        #region Legal Release Properties

        //public string ReleaseLoanNo
        //{
        //    get { return this.txtLoanNo2.Text; }
        //    set { this.txtLoanNo2.Text = value; }
        //}
        //public string ReleaseAccountNo
        //{
        //    get { return this.mtxtAccountNo2.Text; }
        //    set { this.mtxtAccountNo2.Text = value; }
        //}
        //public string ReleaseAdvanceType
        //{
        //    get { return this.txtAdvanceType2.Text; }
        //    set { this.txtAdvanceType2.Text = value; }
        //}
        public string MakingDate
        {
            get { return this.txtMakingDate.Text; }
            set { this.txtMakingDate.Text = value; }
        }
        public string AcceptanceDate
        {
            get { return this.txtAcceptanceDate.Text; }
            set { this.txtAcceptanceDate.Text = value; }
        }
        public string LegalReleaseLawyer
        {
            get { return this.txtLegalCaseLawyer2.Text; }
            set { this.txtLegalCaseLawyer2.Text = value; }
        }
        #endregion

        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            bool IsLegal = true ;
            bool IsRelease = true ;

            if (this.FormName.Contains("Release Legal Sue Case (Loan/OD)"))
            {
                IsRelease = true;
                IsLegal = false;
            }
            else
            {
                IsRelease = false;
                IsLegal = true;
            }
                this.txtLoanNo.Text = string.Empty;
                this.mtxtAccountNo.Text = string.Empty;
                this.txtAdvanceType.Text = string.Empty;
                
                this.lblMakingDate.Visible = IsRelease;
                this.txtMakingDate.Visible = IsRelease;
                this.txtMakingDate.Text = string.Empty;
                this.lblAcceptanceDate.Visible = IsRelease;
                this.txtAcceptanceDate.Visible = IsRelease;
                this.txtAcceptanceDate.Text = string.Empty ;
                this.lblLegalCaseLawyer2.Visible = IsRelease;
                this.txtLegalCaseLawyer2.Visible = IsRelease;                
                this.txtLegalCaseLawyer2.Text = string.Empty;
                this.lblUser2.Visible = IsRelease;
                this.lblUserName2.Visible = IsRelease;
                this.lblUserName2.Text = CurrentUserEntity.CurrentUserName;
            
                //this.gbLegalSueCaseRelease.Visible = false;
                //this.gbLegalSueCase.Visible = true;
                this.lblInterestRate.Visible = IsLegal;
                this.txtInterestRate.Visible = IsLegal;
                this.txtInterestRate.Text = string.Empty;

                this.lblServicesCharges.Visible = IsLegal;
                this.txtServicesCharges.Visible = IsLegal;
                this.txtServicesCharges.Text = string.Empty;

                this.lblLedgerBalance.Visible = IsLegal;
                this.txtLedgerBalance.Visible = IsLegal;
                this.txtLedgerBalance.Text = string.Empty;

                this.lblSanctionAmount.Visible = IsLegal;
                this.txtSanctionAmount.Visible = IsLegal;
                this.txtSanctionAmount.Text = string.Empty;

                this.lblInterest.Visible = IsLegal;
                this.txtInterest.Visible = IsLegal;
                this.txtInterest.Text = string.Empty;

                this.lblExtraCharges.Visible = IsLegal;
                this.txtExtraCharges.Visible = IsLegal;
                this.txtExtraCharges.Text = string.Empty;

                this.lblLegalCaseLawyer.Visible = IsLegal;
                this.txtLegalCaseLawyer.Visible = IsLegal;
                this.txtLegalCaseLawyer.Text = string.Empty;                

                this.lblUser.Visible = IsLegal;
                this.lblLegalUser.Visible = IsLegal;
                this.lblLegalUser.Text = CurrentUserEntity.CurrentUserName;
             
            //if(IsRelease)
            //    this.Size = new System.Drawing.Size(531, 259);
            //else
            //    this.Size = new System.Drawing.Size(531, 227);
        }

        #region Events
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtLoanNo.Focus();
            this.controller.ClearErrors();

            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.FormName.Contains("Release Legal Sue Case (Loan/OD)"))
                this.controller.Release();
            else
            {
                if (!string.IsNullOrEmpty(this.txtLoanNo.Text))
                {
                    if (string.IsNullOrEmpty(this.txtLegalCaseLawyer.Text))
                    {
                        MessageBox.Show("Lawyer cannot be blank.");
                        this.txtLegalCaseLawyer.Focus();
                        return;
                    }
                    else
                    {
                        this.controller.Save();
                        this.txtLoanNo.Focus();
                        this.InitializeControls();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Loan No.");
                    this.txtLoanNo.Focus();
                    this.InitializeControls();
                    return;
                }

                
            }
                 
         }
                
        

        private void LOMVEW00016_Load(object sender, EventArgs e)
        {            
            if (this.FormName.Contains("Release Legal Sue Case (Loan/OD)"))
                this.Text = "Release Legal Sue Case (Loan/OD)";
            else
                this.Text = "Making Legal Sue Case(Loan/OD)";
            this.txtLoanNo.Focus();
            this.InitializeControls();
           this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        #endregion

        private void LOMVEW00016_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        private void txtLegalCaseLawyer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //private void txtLegalCaseLawyer_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (!string.IsNullOrEmpty(this.txtLegalCaseLawyer.Text))
        //        {
        //            this.tsbCRUD.butSave.TabIndex = 0;
        //            this.tsbCRUD.butSave.Focus();
        //        }
        //    }
        //}
               
        //private void txtLegalCaseLawyer_Validating(object sender, CancelEventArgs e)
        //{
        //    if (this.txtLegalCaseLawyer.Visible == true)
        //    {
        //        if (string.IsNullOrEmpty(this.txtLegalCaseLawyer.Text))
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode("MV90072");   //Lawyer cannot be Blank.
        //            this.txtLegalCaseLawyer.Focus();
        //        }
        //        else
        //        {
        //            this.tsbCRUD.butSave.TabIndex = 0;
        //            this.tsbCRUD.butSave.Focus();
        //        }
        //    }
        //}

        //private void txtLegalCaseLawyer_Leave(object sender, EventArgs e)
        //{
        //    if (this.txtLegalCaseLawyer.Visible == true)
        //    {
        //        if (string.IsNullOrEmpty(this.txtLegalCaseLawyer.Text))
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode("MV90072");   //Lawyer cannot be Blank.
        //            this.txtLegalCaseLawyer.Focus();
        //        }
        //        else
        //        {
        //            this.tsbCRUD.butSave.TabIndex = 0;
        //            this.tsbCRUD.butSave.Focus();
        //        }
        //    }
        //}
    }
}
