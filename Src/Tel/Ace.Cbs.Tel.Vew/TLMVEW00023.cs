// <copyright file="TLMVEW00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-05-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
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
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Ptr;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00023 : BaseForm,ITLMVEW00023
    {
        #region Constructor
        public TLMVEW00023()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITLMCTL00023 controller;
        public ITLMCTL00023 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion        

        #region Controls Input Output
        public string Name { get; set; }

        public int Index
        {
            get { return this.lbName.SelectedIndex; }
            set { this.lbName.SelectedIndex = value; }
        }

        #endregion
     
        #region Event
        private void TLMVEW00023_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();          
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.controller.GetTransaction();
        }

        #endregion   

   }
}
