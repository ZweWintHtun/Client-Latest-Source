//----------------------------------------------------------------------
// <copyright file="PFMVEW00012.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>11/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;

namespace Ace.Cbs.Pfm.Vew
{
    /// <summary>
    /// Current Account Closing View
    /// </summary>
    public partial class frmPFMVEW00011 : BaseForm, IPFMVEW00011
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public frmPFMVEW00011()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties
        public string AccountNo 
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string AccountSignature { get; set; }
        public string CurrencyCode { get; set; }
        public string BranchCode { get; set; }

        public DateTime CloseDate 
        {
            get { return Convert.ToDateTime(this.txtCloseDate.Text); }
            set { this.txtCloseDate.Text = value.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)); }
        }

        public string ChequeNo 
        {
            get 
            {
                return this.txtChequeNo.Text; 
            }
            set { this.txtChequeNo.Text = value; }
        }

        public decimal Balance 
        {
            get { return this.ntxtBalance.Value; }
            set { this.ntxtBalance.Text = value.ToString(); }
        }

        public decimal NetBalance 
        {
            get { return this.ntxtNetBalance.Value; }
            set { this.ntxtNetBalance.Text = value.ToString(); }
        }

        public decimal Charges 
        {
            get { return this.ntxtCharges.Value; }
            set { this.ntxtCharges.Text = value.ToString(); }
        }

        public Dictionary<string, string> Customers { get; set; }

        private bool saveStatus = false;
        public bool SaveStatus
        {
            get { return this.saveStatus; }
            set { this.saveStatus = value; }
        }
        #endregion

        #region Presentor Controller
        private IPFMCTL00011 controller;
        public IPFMCTL00011 Controller 
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

        #region Public Method
        public void BindCustomer()
        {
            this.lstCustomer.ValueMember = "Key";
            this.lstCustomer.DisplayMember = "Value";
            this.lstCustomer.Items.Clear();

            foreach(KeyValuePair<string, string> item in this.Customers)
            {
                this.lstCustomer.Items.Add(item);
            }
        }        
        #endregion        

        #region Event
        private void cxcliC0011_SaveButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AccountNo))
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00058); //Invalid Current Account No.
                this.mtxtAccountNo.Focus();
                return;

            }
            
            this.saveStatus = true;
            this.controller.SaveCurrentAccountClose();          
        }
          
        private void frmPFMVEW00011_Load(object sender, EventArgs e)
        {
            this.controller.ClearControls(true);            
            this.EnableDisableControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.BranchCode = this.controller.GetBranchCode();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {   
            this.controller.ClearControls(true);
            this.mtxtAccountNo.Focus();
            this.Controller.ClearErrors();
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtChequeNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ChequeNo))
            {
                this.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.ChequeNo), CXCOM00009.ChequeBookNoDisplayFormat);
            }
        }

        private void txtChequeNo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion       
 
        #region Helper Methods
        private void EnableDisableControls()
        {
            cxcliC0011.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }
               
        #endregion

        private void frmPFMVEW00011_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void frmPFMVEW00011_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {       //if (this.Validate())
                 this.SelectNextControl(this.ActiveControl, true, true, true, true);
                //SendKeys.Send("{Tab}");
            }
        }


    }
}
