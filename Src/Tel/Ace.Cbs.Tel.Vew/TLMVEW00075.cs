//----------------------------------------------------------------------
// <copyright file="TLMVEW00075.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-07-14</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    /*Cash Payment Denomination Entry*/
    public partial class TLMVEW00075 : BaseDockingForm, ITLMVEW00075
    {
        #region "Constructor"
        public TLMVEW00075()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controller"
        private ITLMCTL00075 controller;
        public ITLMCTL00075 Controller //Cash Payment Denomination Entry
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

        #region "Control Inputs Outputs" 
     
        public string status { get; set; }
        public PFMDTO00054 tlDTO { get; set; }
        public string Eno
        {
            get { return this.txtEntryNo.Text.Trim(); }
            set { this.txtEntryNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string Description
        {
            get { return this.txtDescription.Text.Trim(); }
            set { this.txtDescription.Text = value; }
        }
        public string PoNo 
        { 
            get{return this.txtPONo.Text.Trim();}
            set {this.txtPONo.Text=value ;}
        }
        public string Currency
        {
            get {return this.txtCurrency.Text.Trim(); }
            set { this.txtCurrency.Text = value; }
        }
        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Value); }
            set { this.txtAmount.Text = Convert.ToString(value); }
        }
        
        #endregion

        #region "Methods"

        public void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true); 
        }        
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message,new object[]{string.Empty});
            this.InitailizeControls();
            this.txtEntryNo.Clear();
           // this.txtEntryNo.Focus();
            this.mtxtAccountNo.Clear();
            this.txtDescription.Clear();
            this.txtPONo.Clear();
            this.txtCurrency.Clear();
            this.txtAmount.Text = "0.00";
        }
        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitailizeControls();
        }   
        #endregion

        #region "Events"
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {            
            this.controller.Save();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;  
            this.controller.ClearErrors();
            this.Close();
        }
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtEntryNo.CausesValidation = false;
            this.controller.ClearErrors();
            this.InitailizeControls();
            this.txtEntryNo.Clear();
            this.txtEntryNo.Focus();
            this.mtxtAccountNo.Clear();
            this.txtDescription.Clear();
            this.txtPONo.Clear();
            this.txtCurrency.Clear();
            this.txtAmount.Text = "0.00";
        }     
       
        private void TLMVEW00075_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();           
            this.txtEntryNo.Focus();
            this.txtEntryNo.CausesValidation = true;                         
        }

        private void TLMVEW00075_KeyDown(object sender, KeyEventArgs e)  
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        #endregion

        private void txtEntryNo_Validated(object sender, EventArgs e)
        {
            // if xml base error does not exist.
            try
            {
                this.txtEntryNo.CausesValidation = true;
                PFMDTO00054 tlDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00075, PFMDTO00054>(x => x.isValidEntryNo(this.Eno,CurrentUserEntity.BranchCode));
                if (tlDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.txtEntryNo.Focus();
                    this.txtEntryNo.CausesValidation = false;
                    return;
                }
                else if (tlDTO.Amount == 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI30016"); //Invalid Entry No.
                    this.txtEntryNo.CausesValidation = false;
                    return;
                }
                else
                {
                    this.AccountNo = tlDTO.AccountNo;
                    this.Description = tlDTO.ReceiptNo;
                    this.PoNo = tlDTO.OtherBankChq;
                    this.Currency = tlDTO.OtherBank;
                    this.Amount = tlDTO.Amount;
                    this.status = tlDTO.TransactionCode;
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30016"); //Invalid Entry No.
            }

            this.txtEntryNo.CausesValidation = false;
            //this.tsbCRUD.Focus();
        }

        private void txtEntryNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEntryNo.Text))
            {
                // CXUIMessageUtilities.ShowMessageByCode("MI30016");
                //this.txtEntryNo.Focus();
                return;
            }
            else
            {
                //PFMDTO00054 tlDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00075, PFMDTO00054>(x => x.isValidEntryNo(this.Eno, "001"));
                //if (tlDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                //{
                //    //this(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                //    CXUIMessageUtilities.ShowMessageByCode("MI30016");
                //    return;
                //}
                this.txtEntryNo.CausesValidation = true;
            }
        }
    }
}
