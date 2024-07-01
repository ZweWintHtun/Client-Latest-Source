//----------------------------------------------------------------------
// <copyright file="TCMVEW00006.cs" company="Ace Data Systems">
// Copyright (c) Ace Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00006 : BaseForm ,ITCMVEW00006
    {
        #region Constractor

        public TCMVEW00006()
        {
            InitializeComponent();
        }

        #endregion

        #region View Data Properties

        public string VoucherNo
        {
            get
            {
                return this.mtxtVoucherNo.Text.Replace("-", "").Trim();
            }

            set
            {
                this.mtxtVoucherNo.Text = value;
            }
        }

        /// <summary>
        /// Account No
        /// </summary>
        public string AccountNo
        {
            get
            {
                return this.mtxtAccountNo.Text.Replace("-", "").Trim();
            }

            set
            {
                this.mtxtAccountNo.Text = value;
            }
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal AccruedInterest
        {
            get
            {
                return Convert.ToDecimal(this.txtAccruedInterest.Text);
            }

            set
            {
                this.txtAccruedInterest.Text = value.ToString();
            }
        }

        public string Nrc
        {
            get 
            {
                return txtNRC.Text;
            }
            set 
            {
                txtNRC.Text = value;
            }
        }

        public string Name
        {
            get 
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string CurrencyCode { get; set; }

        public string DebitAccountSign { get; set; }

        public string Status { get; set; }

        public string CreditAccountNo
        {
            get
            {
                return this.mtxtCreditAccountNo.Text.Replace("-", "").Trim();
            }

            set
            {
                this.mtxtCreditAccountNo.Text = value;
            }
        }

        public string CreditNrc
        {
            get
            {
                return txtCreditAccountNRC.Text;
            }
            set
            {
                txtCreditAccountNRC.Text = value;
            }
        }

        public string CreditName
        {
            get
            {
                return txtCreditAccountName.Text;
            }
            set
            {
                txtCreditAccountName.Text = value;
            }
        }

        public string SourceBranchCode { get; set; }

        public string FormCaption
        {
            get
            {
                return this.FormName;
            }
        }

        #endregion

        #region Presenter

        private ITCMCTL00006 controller;
        public ITCMCTL00006 Controller
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

        #endregion

        #region Entity

        private PFMDTO00032 entity;
        public PFMDTO00032 Entity
        {
            get
            {
                if (this.entity == null) this.entity = new PFMDTO00032();

                this.entity.AccuredInterest = this.AccruedInterest;
                this.entity.AccountNo = this.AccountNo;
                this.entity.CreditAccountNo = this.CreditAccountNo;
                this.entity.CurrencyCode = this.CurrencyCode;
                this.entity.AccountSign = this.DebitAccountSign;
                this.entity.SourceBranchCode = this.SourceBranchCode;
                this.entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                this.entity.Status = this.FormCaption;

                return this.entity;
            }

            set { this.entity = value; }
        }

        public PFMDTO00028 CledgerInfo { get; set; }

        #endregion

        #region Methods

        public void InitializedControls()
        {
            this.Text = this.FormName;
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.VoucherNo = string.Empty;
            this.AccountNo = string.Empty;
            this.AccruedInterest = 0;
            //this.mtxtAccountNo.Focus();
            this.CreditAccountNo = string.Empty;
            this.Nrc = string.Empty;
            this.Name = string.Empty;
            this.CreditName = string.Empty;
            this.CreditNrc = string.Empty;
            this.Controller.ClearErrors();
            //this.mtxtAccountNo.Focus();
        }

        private void VisibleControls(bool visible)
        {
            gbTransfer.Visible = visible;
        }
        #endregion

        #region Events

        private void TCMVEW00006_Load(object sender, EventArgs e)
        {
            this.InitializedControls();
            if (this.FormName == "Fixed Deposit Interest Withdrawal")
                this.Size = new System.Drawing.Size(506, 231);
            this.gbFormName.Text = this.FormName;
            this.VisibleControls(this.FormCaption.Contains("Transfer") ? true : false);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtCreditAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            if(this.FormCaption.Contains("Transfer"))
                this.mtxtCreditAccountNo.Focus();
            else
                this.mtxtAccountNo.Focus();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializedControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.Save(this.Entity))
            {
                if (this.FormCaption.Contains("Transfer") && CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
                {                    
                    this.Controller.FPRN_FilePrinting(this.AccountNo);
                    this.Controller.PRN_FilePrinting(this.CreditAccountNo);
                }
                this.InitializedControls();
            }
        }

        #endregion

        private void TCMVEW00006_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }


    }
}
