//----------------------------------------------------------------------
// <copyright file="LOMVEW00032" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19.01.2015</CreatedDate>
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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00032 : BaseForm , ILOMVEW00032
    {
        #region Constructor
        public LOMVEW00032()
        {
            InitializeComponent();
        }
        #endregion


        #region Properties
        private ILOMCTL00032 controller;
        public ILOMCTL00032 Controller
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
        public string LegalAccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        #endregion 

        //private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        //{
        //    this.controller.Print();
        //}

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Clear();
            this.mtxtAccountNo.Focus();
        }

        private void LOMVEW00032_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);           
            this.mtxtAccountNo.Focus();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        public void SetFocus()
        {
            this.tsbCRUD.butPrint.TabIndex = 0;
        }
    }
}
