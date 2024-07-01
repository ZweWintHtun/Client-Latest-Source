//----------------------------------------------------------------------
// <copyright file="MNMVEW00028.cs" company="ACE Data Systems">
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
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00028 : BaseForm, IMNMVEW00028
    {
        public MNMVEW00028()
        {
            InitializeComponent();
        }
        #region Controller
        private IMNMCTL00028 controller;
        public IMNMCTL00028 Controller
        {
            get { return this.controller; }
            set 
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Properties
        private bool saveStatus = false;
        public bool SaveStatus
        {
            get { return this.saveStatus; }
            set { this.saveStatus = value; }
        }
        public string RegisterNo
        {
            get { return txtEncashRegisterNo.Text; }
            set { txtEncashRegisterNo.Text = value; }
        }
        #endregion

        #region Events
        private void MNMVEW00028_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, true, true, false, true);
            this.gvEncashRegister.AutoGenerateColumns = false;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControl();
            this.Controller.ClearErrors();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(RegisterNo))
            {
                //this.saveStatus = true;
                this.controller.Save();
                //if (CXUIMessageUtilities.ShowMessageByCode("MC90001") == DialogResult.Yes)    //confirm to Delete or Reverse
                //{
                //    this.saveStatus = true;
                //    this.Controller.Save();
                //}
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00187");
            }
        }
        #endregion

        #region Methods
        public void ClearControl()
        {
            this.gvEncashRegister.DataSource = null;
            this.txtEncashRegisterNo.Text = string.Empty;
            this.saveStatus = false;
            this.txtEncashRegisterNo.Focus();
        }

        public void BindInformation(IList<TLMDTO00001> reList)
        {
            this.gvEncashRegister.DataSource = null;
            this.gvEncashRegister.DataSource = reList;
        }
        #endregion

        private void txtEncashRegisterNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void MNMVEW00028_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
        
    }
}
