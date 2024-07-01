//----------------------------------------------------------------------
// <copyright file="MNMVEW00064.cs" company="ACE Data Systems">
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
    public partial class MNMVEW00064 : BaseForm , IMNMVEW00064
    {
        #region Constructor
        public MNMVEW00064()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public string RequiredYear
        {
            get
            {
                return this.mtxtRequiredYear.Text.ToString();
            }
            set
            {
                this.mtxtRequiredYear.Text = value;
            }
        }
        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        private IMNMCTL00064 controller;
        public IMNMCTL00064 Controller
        {
            get { return controller; }
            set 
            { 
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Method

        public void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (DateTime.Now.Month > 3)
            {
                this.mtxtRequiredYear.Text = DateTime.Now.Year + "" + (DateTime.Now.Year + 1);
            }
            else
            {
                this.mtxtRequiredYear.Text = (DateTime.Now.Year-1) + "" + DateTime.Now.Year;
            }
        }
        #endregion

        private void MNMVEW00064_Load(object sender, EventArgs e)
        {            
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.Print();
        }      
    }
}
