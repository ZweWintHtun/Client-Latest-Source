//----------------------------------------------------------------------
// <copyright file="MNMVEW00012.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Zin Mon Aung</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00012 : BaseForm,IMNMVEW00012
    {
               
        #region Constructor

        public MNMVEW00012()
        {
            InitializeComponent();
        }

        #endregion

        #region Controls

        public PFMDTO00054 PORInformation { get; set; }
        
        public string Eno
        {
            get { return this.txtPaySlipNo.Text; }
            set { this.txtPaySlipNo.Text = value; }
        }

        public string PaymentOrderNo
        {
            get { return this.mtxtPONo.Text; }
            set { this.mtxtPONo.Text = value; }
        }

        public string Budget
        {
            get { return this.txtBudget.Text; }
            set { this.txtBudget.Text = value; }
        }

        public decimal Amount
        {
            get { return Convert.ToDecimal(this.txtAmount.Text); }
            set { this.txtAmount.Text = value.ToString(); }
        }

        public string OtherBank
        {
            get { return this.txtReceivedBank.Text; }
            set { this.txtReceivedBank.Text = value; }
        }

        public TLMDTO00015 cashdeno;
        private PFMDTO00054 viewData;

        public PFMDTO00054 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00054();


                this.viewData.Eno = this.Eno;
                this.viewData.PaymentOrderNo = this.PaymentOrderNo;
                this.viewData.Amount = this.Amount;
                this.viewData.OtherBank = this.OtherBank;
                this.viewData.Budget = this.Budget;

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        #endregion

        #region Controller

        private IMNMCTL00012 controller;
        public IMNMCTL00012 Controller
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

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void MNMVEW00012_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //txtPaySlipNo.Focus();
            #endregion

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                txtPaySlipNo.Focus();
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                //this.InitializeControls();
                this.DisableControls("POReceiptReverse.AllDisable");
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            txtPaySlipNo.Text = "";
            setNormal();
            this.controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            
            this.Controller.Save();

            setNormal();
        }

        private void MNMVEW00012_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        #endregion

        #region helper Event

        private void setNormal() 
        {
            txtPaySlipNo.Text = "";
            mtxtPONo.Text = "PO   /";
            txtAmount.Text = "0.00";
            txtReceivedBank.Text = "";
            txtBudget.Text = "";
            txtPaySlipNo.Focus();
        }

        #endregion

        

    }
}
