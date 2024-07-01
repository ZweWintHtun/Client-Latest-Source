//----------------------------------------------------------------------
// <copyright file="MNMVEW00022.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00022 : BaseForm,IMNMVEW00022
    {
        #region Properties
        public string RegisterNo
        {
            get { return mtxtRegisterNo.Text; }
            set { mtxtRegisterNo.Text = value; }
        }
        public string DBank
        {
            get { return txtDraweeBank.Text; }
            set { txtDraweeBank.Text = value; }
        }
        public string PayerAccountNo
        {
            get { return txtPayerAccountNo.Text; }
            set { txtPayerAccountNo.Text = value; }
        }
        public string PayerName
        {
            get { return txtPayerName.Text; }
            set { txtPayerName.Text = value; }
        }
        public string PayerNRC
        {
            get { return txtPayerNRC.Text;}
            set { txtPayerNRC.Text = value; }
        }
        public string PayerAddress
        {
            get { return txtPayerAddress.Text; }
            set { txtPayerAddress.Text = value; }
        }
        public string PayerPhoneNo
        {
            get { return txtPayerPhoneNo.Text; }
            set { txtPayerPhoneNo.Text = value; }
        }
        public string Narration
        {
            get { return txtNarration.Text; }
            set { txtNarration.Text = value; }
        }
        public string PayeeAccountNo
        {
            get { return txtPayeeAccountNo.Text; }
            set { txtPayeeAccountNo.Text = value; }
        }
        public string PayeeName
        {
            get { return txtPayeeName.Text; }
            set { txtPayeeName.Text = value; }
        }
        public string PayeeNRC
        {
            get { return txtPayeeNRC.Text; }
            set { txtPayeeNRC.Text = value; }
        }
        public string PayeeAddress
        {
            get { return txtPayeeAddress.Text; }
            set { txtPayeeAddress.Text = value; }
        }
        public string PayeePhoneNo
        {
            get { return txtPayeePhoneNo.Text; }
            set { txtPayeePhoneNo.Text = value; }
        }
        public bool SaveStatus { get; set; }
        //public string Cur { get; set; }
        #endregion

        private TLMDTO00017 viewData;
        public TLMDTO00017 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00017();

                this.viewData.RegisterNo = this.RegisterNo;
                this.viewData.Dbank = this.DBank;
                this.viewData.AccountNo = this.PayerAccountNo;
                this.viewData.Name = this.PayerName;
                this.viewData.NRC = this.PayerNRC;
                this.viewData.Address = this.PayerAddress;
                this.viewData.PhoneNo = this.PayerPhoneNo;
                this.viewData.Narration = this.Narration;
                this.viewData.ToAccountNo = this.PayeeAccountNo;
                this.viewData.ToName = this.PayeeName;
                this.viewData.ToNRC = this.PayeeNRC;
                this.viewData.ToAddress = this.PayeeAddress;
                this.viewData.ToPhoneNo = this.PayeePhoneNo;
                //this.ViewData.Currency = this.Cur;
                return this.viewData;
            }
            set { this.viewData = value; }
        }
        #region Controller
        private IMNMCTL00022 controller;
        public IMNMCTL00022 Controller
        {
            get { return this.controller; }
            set 
            { 
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        public MNMVEW00022()
        {
            InitializeComponent();
        }

        private void MNMVEW00022_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtPayerAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtPayeeAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            //mtxtRegisterNo.Focus();
            this.ClearControl();
            this.Controller.ClearErrors();
            this.mtxtRegisterNo.Enabled = true;
           
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.SaveStatus = true;
               // AccountNo Checking (Code Format and CheckDigit,etc.)
             Nullable<CXDMD00011> accountType;
            if(!string.IsNullOrEmpty(this.PayerAccountNo))
            {
                if (!CXCLE00012.Instance.IsValidAccountNo(this.PayerAccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
            else if(!string.IsNullOrEmpty(this.PayeeAccountNo))
            {
                if (!CXCLE00012.Instance.IsValidAccountNo(this.PayeeAccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }
            else
            {
                this.Controller.UpdateRDInfo(this.ViewData);
            }
        }

        public void ClearControl()
        {
            this.mtxtRegisterNo.Focus();
            this.RegisterNo = string.Empty;
            this.DBank = string.Empty;
            this.PayerAccountNo = string.Empty;
            this.PayerName = string.Empty;
            this.PayerNRC = string.Empty;
            this.PayerAddress = string.Empty;
            this.PayerPhoneNo = string.Empty;
            this.Narration = string.Empty;
            this.PayeeAccountNo = string.Empty;
            this.PayeeName = string.Empty;
            this.PayeeNRC = string.Empty;
            this.PayeeAddress = string.Empty;
            this.PayeePhoneNo = string.Empty;
            this.SaveStatus = false;
            this.mtxtRegisterNo.Enabled = true;
            mtxtRegisterNo.Focus();

           
        }

        private void mtxtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void DisableControl()
        {
            this.mtxtRegisterNo.Enabled = false;
        }

        private void txtPayeeAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MNMVEW00022_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //private void txtPayerName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtPayerNRC_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtPayerAddress_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtPayeeName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtPayeeNRC_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

        //private void txtPayeeAddress_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.KeyChar = char.ToUpper(e.KeyChar);
        //}

    }
}
