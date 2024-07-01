//----------------------------------------------------------------------
// <copyright file="MNMVEW00069.cs" company="ACE Data Systems">
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00069 : BaseForm ,IMNMVEW00069
    {

        #region Constructor

        public MNMVEW00069()
        {
            InitializeComponent();
        }

        #endregion

        #region controller

        private IMNMCTL00069 currentCompanyController;
        public IMNMCTL00069 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }

        #endregion

        #region Events

        private void MNMVEW00069_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.rdoAllAccount.Checked = true;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            string type = string.Empty;
            if (rdoAllAccount.Checked)
            {
                type = "All";
                this.Controller.Print(type);
            }
            else
            {
                type = "Excess";
                this.Controller.Print(type);
            }

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoAllAccount.Checked = true;
        }

        #endregion

        
    }
}
