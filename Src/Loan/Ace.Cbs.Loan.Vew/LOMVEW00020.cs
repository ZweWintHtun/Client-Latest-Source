//----------------------------------------------------------------------
// <copyright file="LOMVEW00020.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-03</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    //Edit => Loans Interest Editing
    public partial class LOMVEW00020 : BaseDockingForm,ILOMVEW00020
    {
        #region "Constructor"
        public LOMVEW00020()
        {
            InitializeComponent();            
        }
        #endregion

        #region "Properties"
        /// <summary>
        /// Loans No
        /// </summary>
        public string LoansNo
        {
            get { return this.txtLoanNo.Text.Trim(); }
            set { this.txtLoanNo.Text = value; }
        }
        /// <summary>
        /// Account Number
        /// </summary>
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        /// <summary>
        /// Sanction Amount
        /// </summary>
        public decimal SanctionAmount
        {
            get
            {
                if (this.ntxtSanctionAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtSanctionAmount.Text.Trim());
            }

            set { this.ntxtSanctionAmount.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Rate
        /// </summary>
        public decimal Rate
        {
            get
            {
                if (this.ntxtRate.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtRate.Text.Trim());
            }

            set { this.ntxtRate.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Quarter Interest Amount
        /// </summary>
        public decimal QuarterInterestAmount
        {
            get
            {
                if (this.ntxtQuarterAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtQuarterAmount.Text.Trim());
            }

            set { this.ntxtQuarterAmount.Text = Convert.ToString(value); }
        }
    #endregion

        #region "Controller"
        private ILOMCTL00020 loansinteresteditingController;
        public ILOMCTL00020 LoansInterestEditingController
        {
            get
            {
                return this.loansinteresteditingController;
            }
            set
            {
                this.loansinteresteditingController = value;
                loansinteresteditingController.LoansInterestEditingView = this;
            }
        }
        #endregion

        #region "Events"

        private void LOMVEW00020_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        private void LOMVEW00020_Load(object sender, EventArgs e)
        {
            this.Text = "Loans Interest Editing";
            this.lblQuarterAmount.Text = this.lblQuarterAmount.Text;           
            this.InitializedControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            txtLoanNo.Focus();
            
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.LoansInterestEditingController.ClearCustomErrorMessage();
            this.LoansInterestEditingController.ClearErrors();
            this.InitializedControls();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (txtLoanNo.Text == null || txtLoanNo.Text == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);
                txtLoanNo.Focus();
            }

            else
            {     
               
              
               this.LoansInterestEditingController.Update();
              // this.InitializedControls();
             
            }
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);           
        }

        #endregion

        #region "Public Methods"
        public void InitializedControls()
        {
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.ntxtQuarterAmount.Text = "0.00";
            this.ntxtRate.Text = "0.00";
            this.ntxtSanctionAmount.Text = "0.00";
           // this.ntxtQuarterAmount.ReadOnly = true;
            this.DisableTextBox();
            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Enabled = true;
            this.txtLoanNo.Focus();
        }
        public void EnableTextBox()
        {
            this.ntxtRate.Enabled = true;
            this.ntxtSanctionAmount.Enabled = true;
            this.mtxtAccountNo.Enabled = true;
        }
        public void DisableTextBox()
        {
            this.ntxtRate.Enabled = false;
            this.ntxtSanctionAmount.Enabled = false;
            this.mtxtAccountNo.Enabled = false;
            this.txtLoanNo.Enabled = false;
        }
        public void TextFcus()
        {
            this.ntxtQuarterAmount.SelectionStart = this.ntxtQuarterAmount.TextLength;
            this.ntxtQuarterAmount.Focus();
        }
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, "Loan No " + txtLoanNo.Text);          
            this.InitializedControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        #region "Private Method"
        private string GetQuarter()
        {
            string quarter="Q"+this.LoansInterestEditingController.GetInterestQuarter();           
            switch (quarter)
            {
                case "Q1": quarter="First " ; break;
                case "Q2": quarter="Second "; break;
                case "Q3": quarter = "Third " ; break;
                case "Q4": quarter = "Fourth "; break;
            }
            return quarter;
        }
        #endregion

      
    }
}
