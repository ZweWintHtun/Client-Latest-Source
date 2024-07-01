//----------------------------------------------------------------------
// <copyright file="LOMVEW00021.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-04</CreatedDate>
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
    //Edit => Legal Process Editing
    public partial class LOMVEW00021 : BaseForm, ILOMVEW00021
    {
        #region "Constructor"
        public LOMVEW00021()
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
        /// Ledger Balance
        /// </summary>
        public decimal LedgerBalance
        {
            get
            {
                if (this.ntxtLedgerBal.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtLedgerBal.Text.Trim());
            }

            set { this.ntxtLedgerBal.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Advance Type
        /// </summary>
        public string AdvanceType
        {
            get { return this.txtAdvanceType.Text.Trim(); }
            set { this.txtAdvanceType.Text = value; }
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
        /// Interest Rate
        /// </summary>
        public decimal InterestRate
        {
            get
            {
                if (this.ntxtIntRate.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtIntRate.Text.Trim());
            }

            set { this.ntxtIntRate.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Interest 
        /// </summary>
        public decimal Interest
        {
            get
            {
                if (this.ntxtInt.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtInt.Text.Trim());
            }

            set { this.ntxtInt.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Service Charges
        /// </summary>
        public decimal ServiceCharges
        {
            get
            {
                if (this.ntxtServiceCharges.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtServiceCharges.Text.Trim());
            }

            set { this.ntxtServiceCharges.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Extra Charges
        /// </summary>
        public decimal ExtraCharges
        {
            get
            {
                if (this.ntxtExtraCharges.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtExtraCharges.Text.Trim());
            }

            set { this.ntxtExtraCharges.Text = Convert.ToString(value); }
        }
        /// <summary>
        /// Legal Case Lwayer
        /// </summary>
        public string LegalCaseLawyer
        {
            get { return this.txtLawyer.Text.Trim(); }
            set { this.txtLawyer.Text = value; }
        }
        /// <summary>
        ///Legal Suit Case
        /// </summary>
        public bool LgSCase
        {
            get { return chkLegalSuitCase.Checked; }
            set { chkLegalSuitCase.Checked = value; }
        }
        #endregion

        #region "Controller"
        private ILOMCTL00021 legalprocesseditingController;
        public ILOMCTL00021 LegalProcessEditingController
        {
            get
            {
                return this.legalprocesseditingController;
            }
            set
            {
                this.legalprocesseditingController = value;
                legalprocesseditingController.LegalProcessEditingView = this;
            }
        }
        #endregion

        #region "Methods"       
        public void EnableControls()
        {
            this.txtLoanNo.ReadOnly = false;
            this.mtxtAccountNo.ReadOnly = false;
            this.ntxtLedgerBal.ReadOnly = false;
            this.txtAdvanceType.ReadOnly = false;
            this.ntxtExtraCharges.ReadOnly = false;
            this.ntxtInt.ReadOnly = false;
            this.ntxtIntRate.ReadOnly = false;
            this.ntxtLedgerBal.ReadOnly = false;
            this.ntxtSanctionAmount.ReadOnly = false;
            this.ntxtServiceCharges.ReadOnly = false;
            this.txtLawyer.ReadOnly = false;

        }
        public void DiableControls()
        {
            this.txtLoanNo.ReadOnly = false;
            this.mtxtAccountNo.ReadOnly = true;
            this.ntxtLedgerBal.ReadOnly = true;
            this.txtAdvanceType.ReadOnly = true;
            this.ntxtExtraCharges.ReadOnly = true;
            this.ntxtInt.ReadOnly = true;
            this.ntxtLedgerBal.ReadOnly = true;
            this.ntxtSanctionAmount.ReadOnly = true;
            this.ntxtServiceCharges.ReadOnly = true;
            this.ntxtIntRate.Focus();         
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, "Loan No. " + txtLoanNo.Text);          
            this.InitializedControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void InitializedControls()
        {
            this.EnableInfo(false);
            this.DiableControls();
            this.lblLonaNo.Text = "Enter Loan No.";
            this.txtLoanNo.Enabled = true;
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.ntxtLedgerBal.Text = string.Empty;
            this.ntxtInt.Text = string.Empty;
            this.ntxtIntRate.Text = string.Empty;
            this.ntxtSanctionAmount.Text = string.Empty;
            this.ntxtServiceCharges.Text = string.Empty;
            this.ntxtExtraCharges.Text = string.Empty;
            this.txtAdvanceType.Text = string.Empty;
            this.txtLawyer.Text = string.Empty;
            this.txtLoanNo.Focus();
        }

        public void EnableInfo(bool isEnable)
        {
            this.mtxtAccountNo.Enabled = isEnable;
            this.txtAdvanceType.Enabled = isEnable;
            this.mtxtAccountNo.Enabled = isEnable;
            this.ntxtIntRate.Enabled = isEnable;
            this.ntxtServiceCharges.Enabled = isEnable;
            this.ntxtLedgerBal.Enabled = isEnable;
            this.ntxtSanctionAmount.Enabled = isEnable;
            this.ntxtInt.Enabled = isEnable;
            this.ntxtExtraCharges.Enabled = isEnable;
            this.txtLawyer.Enabled = isEnable;
        }

        public void GetTitle()
        {
            this.lblLonaNo.Text = "Loan No.";
        }
        #endregion

        #region "Events"

        private void txtLawyer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void LOMVEW00021_Load(object sender, EventArgs e)
        {
            this.Text = "Marking Legal Sue Case Edit";
            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializedControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
          //  if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)
          //  {
            if (txtLoanNo.Text == null || txtLoanNo.Text == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);
                this.txtLoanNo.Focus();
                return;
            }
           
             else if (chkLegalSuitCase.Checked)
                {
                    this.LegalProcessEditingController.Save();
                }
           else 
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90008) == DialogResult.Yes)//Are you sure you want to cancel the legal case loan ?
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90068);// "Legal Case Cancelling Process Complete!
                        this.InitializedControls();
                    }
                    else
                    {
                        this.chkLegalSuitCase.Checked = true;
                    }
                }
           // }
           // else
           // {
                //this.InitializedControls();
           // }
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.LegalProcessEditingController.ClearErrors();
            this.InitializedControls();
        }
       
        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);           
        }
   
        private void LOMVEW00021_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
     
        #endregion      

  
     }
}
