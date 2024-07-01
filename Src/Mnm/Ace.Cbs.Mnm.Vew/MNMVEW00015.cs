//----------------------------------------------------------------------
// <copyright file="MNMVEW00015.cs" company="ACE Data Systems">
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
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00015 : BaseForm,IMNMVEW00015
    {
        public MNMVEW00015()
        {
            InitializeComponent();
        }
        #region Controller
        IMNMCTL00015 controller;
        public IMNMCTL00015 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Proeerties
        public string PONo
        {
            get { return this.txtPaymentOrderNo.Text; }
            set { this.txtPaymentOrderNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-",""); }
            set { this.mtxtAccountNo.Text = value; }
        }
        #endregion

        #region Method
        public void ShowData(IList<TLMDTO00016> PO)
        {
            txtAmount.Text = PO[0].Amount.ToString();
            txtCharges.Text = PO[0].Charges.ToString();
            mtxtAccountNo.Text = PO[0].AccountNo;
            lblName.Text = PO[0].CustomerName;
            txtPaymentOrderNo.Enabled = false;
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }
        public void ClearControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            txtYear.Text = this.Controller.GetBudgetYear();
            txtPaymentOrderNo.Text = "PO" + CurrentUserEntity.BranchCode + "/";
            txtAmount.Text = string.Empty;
            txtCharges.Text = string.Empty;
            mtxtAccountNo.Text = string.Empty;
            lblName.Text = string.Empty;
            txtPaymentOrderNo.Enabled = true;
            txtPaymentOrderNo.Focus();
        }
        #endregion

        #region Event
        private void MNMVEW00015_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false,true);
            txtYear.Text = this.Controller.GetBudgetYear();
            txtPaymentOrderNo.Text = "PO" + CurrentUserEntity.BranchCode + "/";
            txtPaymentOrderNo.Focus();          
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.Controller.Save();
        }
        #endregion

        private void MNMVEW00015_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }




    }
}
