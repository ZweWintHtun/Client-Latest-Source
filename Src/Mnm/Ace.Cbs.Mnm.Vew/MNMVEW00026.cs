//----------------------------------------------------------------------
// <copyright file="MNMVEW00026.cs" company="ACE Data Systems">
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


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00026 : BaseForm,IMNMVEW00026
    {
        public MNMVEW00026()
        {
            InitializeComponent();
        }

        #region Controller
        private IMNMCTL00026 controller;
        public IMNMCTL00026 Controller
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
        public decimal Amount
        {
            get { return Convert.ToDecimal(txtAmount.Text); }
            set { txtAmount.Text = value.ToString(); }
        }
        public string PayeeAccountNo
        {
            get { return txtPayeeAccountNo.Text; }
            set { txtPayeeAccountNo.Text = value; }
        }
        public decimal OldAmount { get; set; }
        public bool SaveStatus { get; set; }
        #endregion

        #region Methods
        public void ClearControls()
        {
            mtxtRegisterNo.Text = string.Empty;
            txtDraweeBank.Text = string.Empty;
            txtPayeeAccountNo.Text = string.Empty;
            txtPayeeName.Text = string.Empty;
            txtPayeeNRC.Text = string.Empty;
            txtPayeeAddress.Text = string.Empty;
            txtPayeePhoneNo.Text = string.Empty;
            txtRemitterName.Text = string.Empty;
            txtRemitterNRC.Text = string.Empty;
            txtRemitterPhoneNo.Text = string.Empty;
            txtAmount.Text = string.Empty;
            this.SaveStatus = false;
            this.mtxtRegisterNo.Enabled = true;
            this.mtxtRegisterNo.Focus();
                     
        }

        public void EnableControl(bool isEnable)
        {
            //this.txtPayeeName.ReadOnly = isEnable;
            //this.txtPayeeNRC.ReadOnly = isEnable;
            //this.txtPayeeAddress.ReadOnly = isEnable;
            //this.txtPayeePhoneNo.ReadOnly = isEnable;

            this.mtxtRegisterNo.Enabled = isEnable;
        }

        public void SaveDeleteButtonEnableDisable(bool status)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, status, status, true, false, true);
        }
        #endregion

        #region Events
        private void MNMVEW00026_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.mtxtRegisterNo.Focus();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            this.Controller.Delete();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.OldAmount == Convert.ToDecimal(txtAmount.Text))
            {
                this.ClearControls();
            }
            else
            {
                this.Controller.Save();
            }
        }
        #endregion

        private void mtxtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void disablecontrol()
        {
            this.mtxtRegisterNo.Enabled = false;
            this.mtxtRegisterNo.Focus();
        }
        public void ReadOnlyControl()
        {
            this.txtPayeeAccountNo.ReadOnly = true;
            this.txtPayeeAddress.ReadOnly = true;
            this.txtPayeeName.ReadOnly = true;
            this.txtPayeeNRC.ReadOnly = true;
            this.txtPayeePhoneNo.ReadOnly = true;
        }

        public void SetFocus()
        {
            this.mtxtRegisterNo.Focus();
        }

        private void MNMVEW00026_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}
