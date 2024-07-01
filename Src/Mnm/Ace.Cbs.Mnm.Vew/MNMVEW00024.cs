//----------------------------------------------------------------------
// <copyright file="MNMVEW00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>03/02/2014</CreatedDate>
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00024 : BaseDockingForm ,IMNMVEW00024
    {
        #region Constructor
        public MNMVEW00024()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private string registerNo;
        public string RegisterNo
        {
            get { return this.txtRegisterNo.Text; }
            set { this.txtRegisterNo.Text = value; }
        }

        public string RegisterNo_New
        {
            get { return this.lblNewRegister.Text; }
            set { this.lblNewRegister.Text = value; }
        }

        public string RegisterNo_ToChange
        {
            get { return this.txtRegisterNo_ToChange.Text; }
            set { this.txtRegisterNo_ToChange.Text = value; }
        }

        public string DraweeBank
        {
            get { return this.txtDraweeBank.Text; }
            set { this.txtDraweeBank.Text = value; }
        }

        public decimal Amount
        {
            get
            {
                if (this.txtAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtAmount.Text.Trim());
            }

            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        public string PayerAccountNo
        {
            get { return this.txtPayerAccountNo.Text; }
            set { this.txtPayerAccountNo.Text = value; }
        }

        public string PayerName
        {
            get { return this.txtPayerName.Text; }
            set { this.txtPayerName.Text = value; }
        }

        public string PayerNRC
        {
            get { return this.txtPayerNRC.Text; }
            set { this.txtPayerNRC.Text = value; }
        }

        public string PayerAddress
        {
            get { return this.txtPayerAddress.Text; }
            set { this.txtPayerAddress.Text = value; }
        }

        public string RemitterName
        {
            get { return this.txtRemitterName.Text; }
            set { this.txtRemitterName.Text = value; }
        }

        public string RemitterNRC
        {
            get { return this.txtRemitterNRC.Text; }
            set { this.txtRemitterNRC.Text = value; }
        }

        

        #endregion

        #region "Controller"

        private IMNMCTL00024 controller;
        public IMNMCTL00024 Controller
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

        private void MNMVEW00024_Load(object sender, EventArgs e)
        {
          //ButtonEnableDisabled(newEnabled,editEnabled,saveEnabled,deleteEnabled,cancelEnabled,printEnabled, exitEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.DisableControls();
            this.txtRegisterNo.Select();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            this.txtRegisterNo.Focus();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
        }

        private void txtRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }


        #endregion 

        #region Methods

        private void DisableControls()
        {
            this.txtAmount.Enabled = false;
            this.txtPayerAccountNo.Enabled = false;
            this.txtPayerAddress.Enabled= false;
            this.txtPayerName.Enabled = false;
            this.txtPayerNRC.Enabled = false;
            this.txtDraweeBank.Enabled = false;
            this.txtRemitterName.Enabled = false;
            this.txtRemitterNRC.Enabled = false;
         
        }

        public void InitializeControls()
        {
            this.txtAmount.Text = "0.00";
            this.txtPayerAccountNo.Text = string.Empty;
            this.txtPayerAddress.Text = string.Empty;
            this.txtPayerName.Text = string.Empty ;
            this.txtPayerNRC.Text = string.Empty;
            this.txtDraweeBank.Text = string.Empty;
            this.txtRemitterName.Text = string.Empty;
            this.txtRemitterNRC.Text = string.Empty;
            this.txtRegisterNo.Text = string.Empty;
            this.txtRegisterNo_ToChange.Text = string.Empty;
            this.lblNewRegister.Text = string.Empty;
            this.txtRegisterNo.Focus();

        }

        //public void FocusControl()
        //{
        //    this.txtRegisterNo_ToChange.Focus();
        //}

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion


       
    }
}
