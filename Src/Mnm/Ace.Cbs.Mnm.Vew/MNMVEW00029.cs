//----------------------------------------------------------------------
// <copyright file="MNMVEW00029.cs" company="ACE Data Systems">
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


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00029 : BaseForm,IMNMVEW00029
    {
        #region Data Properties

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
        
        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string CustomerNRC
        {
            get { return this.txtNRC.Text; }
            set { this.txtNRC.Text = value; }
        }

        public string Fathername
        {
            get { return this.txtFatherName.Text; }
            set { this.txtFatherName.Text = value; }
        }

        public string Address
        {
            get { return this.txtAddress.Text; }
            set { this.txtAddress.Text = value; }
        }

        private IMNMCTL00029 _controller { get; set; }
        public IMNMCTL00029 Controller
        {
            get
            {
                return _controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }

        #endregion
        public MNMVEW00029()
        {
            InitializeComponent();
        }

        #region Methods

        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }
        #endregion

        #region Events

        private void MNMVEW00029_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.PrintPassbook();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void MNMVEW00029_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
