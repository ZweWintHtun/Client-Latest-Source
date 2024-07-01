//----------------------------------------------------------------------
// <copyright file="LOMVEW00012" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>09.01.2015</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    //Overdraft Limit Change Entry //
    public partial class LOMVEW00012 : BaseDockingForm , ILOMVEW00012
    {
        #region Constructor
        public LOMVEW00012()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

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

        public decimal OverdraftAmount
        {
            get
            {
                return Convert.ToDecimal(this.txtOverDraftAmount.Text);
            }
            set { this.txtOverDraftAmount.Text = value.ToString(); }
        }

        public decimal PresentODLimit
        {
            get
            {
                return Convert.ToDecimal(this.txtPresentODLimit.Text);
            }
            set { this.txtPresentODLimit.Text = value.ToString(); }
        }

        public decimal NewODLimit
        {
            get
            {
                return Convert.ToDecimal(this.txtNewODLimit.Text);
            }
            set { this.txtNewODLimit.Text = value.ToString(); }
        }

        public decimal TotalODLimit
        {
            get
            {
                return Convert.ToDecimal(this.txtTotalODLimit.Text);
            }
            set { this.txtTotalODLimit.Text = value.ToString(); }
        }

        public decimal NewTotalODLimit
        {
            get
            {
                return Convert.ToDecimal(this.txtNewTotalODLimit.Text);
            }
            set { this.txtNewTotalODLimit.Text = value.ToString(); }
        }

        public string Name
        {
            get { return this.lblName.Text; }//lblName
            set { this.lblName.Text = value; }
        }

        public string Status { get; set; }

        #region "Controller"
        private ILOMCTL00012 controller;
        public ILOMCTL00012 Controller 
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

        #endregion

        #endregion

        #region Method
        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.txtOverDraftAmount.Text = "0.00";
            this.txtPresentODLimit.Text = "0.00";
            this.txtNewODLimit.Text = "0.00";
            this.txtTotalODLimit.Text = "0.00";
            this.txtNewTotalODLimit.Text = "0.00";
          //  this.lblName.Text = string.Empty;
            this.txtLoanNo.Focus();           
        }

        public void SetVisibleDisable(bool status)
        {
            this.lblNewODLimit.Visible = status;
            this.txtNewODLimit.Visible = status;
            this.lblPresentODLimit.Visible = status;
            this.txtPresentODLimit.Visible = status;            
        }
        #endregion

        #region Events
        private void LOMVEW00012_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            tsbCRUD.butSave.TabIndex = 0;
            this.lblDateShow.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.InitializeControls();
            this.lblName.Text = string.Empty;

          
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {           
            this.Controller.Save();
            if (!string.IsNullOrEmpty(this.Status))
            {
                if (this.Status.Contains("err"))
                {
                    if ((this.txtNewODLimit.Text=="0.00") && (!string.IsNullOrEmpty(this.txtLoanNo.Text)))
                    {
                        this.txtNewODLimit.Focus();
                        this.Status = string.Empty; 
                    }
                    else
                    {
                        this.txtLoanNo.Focus();
                        this.Status = string.Empty; 
                    }
                }
            }
            else
                this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        { 
            this.InitializeControls();
            this.controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void txtPresentODLimit_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPresentODLimit.Text) || this.txtPresentODLimit.Text == "0.00" || this.txtPresentODLimit.Text == "0.00")
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00037");   //Invalid Amount
                e.Cancel = true;                
                this.txtPresentODLimit.Focus();                
                return;
            }
            else if (Math.Abs(txtPresentODLimit.Value) > Math.Abs(10000000000))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV90060");   //Sanction amount must be less than 10,000,000,000.
                e.Cancel = true;                
                this.txtPresentODLimit.Focus();                
                return;
            }
        }

        //private void txtNewODLimit_Validating(object sender, CancelEventArgs e)
        //{
        //    if(!string.IsNullOrEmpty(this.txtLoanNo.Text))
        //    {
        //    if (string.IsNullOrEmpty(this.txtNewODLimit.Text) || this.txtNewODLimit.Text == "0.00" || this.txtNewODLimit.Text == "0.00"
        //        || this.txtNewODLimit.Text == this.txtPresentODLimit.Text)
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MV90062");   //Invalid New Amount
        //        e.Cancel = true;
        //        this.txtNewODLimit.Focus();
        //        //return;
        //    }
        //    else
        //        this.txtNewTotalODLimit.Text = this.txtNewODLimit.Text;           
        //    }
        //}

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }    
        #endregion   

        private void txtLoanNo_TextChanged(object sender, EventArgs e)
        {

        }

       // private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
       //{
       //     if (e.KeyCode == Keys.Enter)
       //     {
       //         if (this.Validate())
       //         this.SelectNextControl(this.ActiveControl, true, true, true, true);             
       //     }
       // }            
    }
}
