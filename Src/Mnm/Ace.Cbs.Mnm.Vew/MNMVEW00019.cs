//----------------------------------------------------------------------
// <copyright file="MNMVEW00019.cs" company="ACE Data Systems">
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00019 : BaseDockingForm,IMNMVEW00019
    {
        #region Constructor

        public MNMVEW00019()
        {
            InitializeComponent();
        }

        #endregion

        #region Property

        private string registerNo;
        public string RegisterNo
        {
            get { return this.txtRegisterNo.Text;}
            set { this.txtRegisterNo.Text = value; }
        }

         private decimal amount;
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

         private string poNo;
        public string PoNo
        {
            get { return this.mtxtPaymentOrderNo.Text;}
            set { this.mtxtPaymentOrderNo.Text = value; }
        }

         private string cur;
        public string Currency
        {
            get { return this.txtCurrency.Text;}
            set { this.txtCurrency.Text = value; }
        }

        private string name;
        public string Name_forPO
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        } 

        #endregion 

        #region Controller

        private IMNMCTL00019 controller;
        public IMNMCTL00019 Controller
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

        #region Events

        private void MNMVEW00019_Load(object sender, EventArgs e)
        {
            this.Text = "PO Issue for Encashment";
            //ButtonEnableDisabled(newEnabled,editEnabled,saveEnabled,deleteEnabled,cancelEnabled,printEnabled, exitEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);           
            this.InitializeControls();
        }
                  
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
           this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        #endregion

        #region Methods

        public void InitializeControls()
        {
            this.txtAmount.Enabled = false;
            this.txtName.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.mtxtPaymentOrderNo.Enabled = false;
            this.txtYear.Enabled = false;
            this.txtAmount.Text = "0.00";
            this.txtCurrency.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.txtRegisterNo.Text = string.Empty;
            this.txtRegisterNo.Focus();
        }

        public void Successful(string message, string newpoNo)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] {"PO Editting for Encashment ",newpoNo });
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion
    }
}
