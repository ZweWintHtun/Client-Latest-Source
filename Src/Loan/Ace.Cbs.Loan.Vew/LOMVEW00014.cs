//----------------------------------------------------------------------
// <copyright file="LOMVEW00014" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>13.01.2015</CreatedDate>
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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00014 : BaseDockingForm , ILOMVEW00014
    {
        #region Constructor
        public LOMVEW00014()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private ILOMCTL00014 controller;
        public ILOMCTL00014 Controller
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
        public decimal SanctionAmount
        {
            get { return Convert.ToDecimal(this.txtSanctionAmount.Text); }
            set { this.txtSanctionAmount.Text = value.ToString(); }
        }
        public decimal IntRateUsed
        {
            get { return Convert.ToDecimal(this.txtIntRateUsed.Text); }
            set { this.txtIntRateUsed.Text = value.ToString(); }
        }
        public decimal IntRateUnused
        {
            get { return Convert.ToDecimal(this.txtIntRateUnused.Text); }
            set { this.txtIntRateUnused.Text = value.ToString(); }
        }

        public string UserName
        {
            get { return this.lblNPLUser.Text; }
            set { this.lblNPLUser.Text = value; }
        }
        #endregion

        #region Method
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtAdvanceType.Text = string.Empty;
            this.txtSanctionAmount.Text = string.Empty;
            this.txtIntRateUsed.Text = string.Empty;
            this.txtIntRateUnused.Text = string.Empty;
            //this.lblNPLUser.Text = this.lblNPLUser.Text + "  " + CurrentUserEntity.CurrentUserName;            
            this.txtLoanNo.Focus();
        }
        #endregion

        #region Events
        private void LOMVEW00014_Load(object sender, EventArgs e)
        {
            this.lblNPLUser.Text = this.lblNPLUser.Text + "  " + CurrentUserEntity.CurrentUserName;            
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
            this.InitializeControls();
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion 

        //private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //        SendKeys.Send("{TAB}");
        //}

        public void SetFocus()
        {
            this.tsbCRUD.butSave.TabIndex = 0;
            this.tsbCRUD.butCancel.TabIndex = 1;            
            
            this.tsbCRUD.butSave.Focus();
        }

        private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LOMVEW00014_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
        
        //private void LOMVEW00014_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //SendKeys.Send("{TAB}");
        //        if (this.Validate())
        //            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //    }
        //}


    }
}
