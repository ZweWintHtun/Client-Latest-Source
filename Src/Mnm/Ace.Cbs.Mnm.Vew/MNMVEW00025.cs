//----------------------------------------------------------------------
// <copyright file="MNMVEW00025.cs" company="ACE Data Systems">
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
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00025 : BaseForm,IMNMVEW00025
    {
        public MNMVEW00025()
        {
            InitializeComponent();
        }

        #region Controller
        private IMNMCTL00025 controller;
        public IMNMCTL00025 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region properties
        public string RegisterNo
        {
            get { return mtxtRegisterNo.Text; }
            set { mtxtRegisterNo.Text = value; }
        }
        public string DraweeBank
        {
            get { return txtDraweeBank.Text; }
            set { txtDraweeBank.Text = value; }
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
        public string RemitterName
        {
            get { return txtRemitterName.Text; }
            set { txtRemitterName.Text = value; }
        }
        public string RemitterNRC
        {
            get { return txtRemitterNRC.Text; }
            set { txtRemitterNRC.Text = value; }
        }
        public string RemitterPhoneNo
        {
            get { return txtRemitterPhoneNo.Text; }
            set { txtRemitterPhoneNo.Text = value; }
        }
        public bool SaveStatus { get; set; }
        #endregion
        #region  ViewData
        private TLMDTO00001 viewData;
        public TLMDTO00001 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new TLMDTO00001();
                this.viewData.RegisterNo = this.RegisterNo;
                this.viewData.Ebank = this.DraweeBank;
                this.viewData.ToName = this.PayeeName;
                this.viewData.ToNRC = this.PayeeNRC;
                this.viewData.ToAddress = this.PayeeAddress;
                this.viewData.ToPhoneNo = this.PayeePhoneNo;
                this.viewData.Name = this.RemitterName;
                this.viewData.NRC = this.RemitterNRC;
                this.viewData.PhoneNo = this.RemitterPhoneNo;

                return this.viewData;
            }
            set { this.viewData = value; }
        }
        #endregion

        #region Events
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.SaveStatus = true;
            this.Controller.UpdateREInfo(ViewData);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearErrors();

            this.ClearControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MNMVEW00025_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
        }

        private void txtPayeeName_KeyPress(object sender, KeyPressEventArgs e)
       {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPayeeNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPayeeAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRemitterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRemitterNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPayeePhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void txtRemitterPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            { e.Handled = true; }
        }

        private void mtxtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void disablecontrol()
        {
            this.mtxtRegisterNo.Enabled = false;
        }
        #endregion

        #region Methods
        public void ClearControls()
        {
            mtxtRegisterNo.Text = string.Empty;
            txtDraweeBank.Text = string.Empty;
            txtPayeeName.Text = string.Empty;
            txtPayeeNRC.Text = string.Empty;
            txtPayeeAddress.Text = string.Empty;
            txtPayeePhoneNo.Text = string.Empty;
            txtRemitterName.Text = string.Empty;
            txtRemitterNRC.Text = string.Empty;
            txtRemitterPhoneNo.Text = string.Empty;
            this.SaveStatus = false;
            this.mtxtRegisterNo.Enabled = true;
            mtxtRegisterNo.Focus();

        }
        #endregion

        private void MNMVEW00025_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }


        
    }
}
