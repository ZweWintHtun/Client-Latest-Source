//----------------------------------------------------------------------
// <copyright file="MNMVEW00018.cs" company="ACE Data Systems">
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
using Ace.Cbs.Mnm.Ctr.Ptr;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00018 : BaseForm, IMNMVEW00018
    {

        #region Constructor

        public MNMVEW00018()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        private bool byEncash;
        public bool ByEncash
        {
            get { return this.rdoByEncashment.Checked; }
            set { this.rdoByEncashment.Checked = value; }
        }

        private bool byTransfer;
        public bool ByTransfer
        {
            get { return this.rdobyTransfer.Checked; }
            set { this.rdobyTransfer.Checked = value; }
        }

        private bool byIncome;
        public bool ByIncome
        {
            get { return this.rdoWithIncome.Checked; }
            set { this.rdoWithIncome.Checked = value; }
        }

        private bool byNoIncome;
        public bool ByNoIncome
        {
            get { return this.rdoWithoutIncome.Checked; }
            set { this.rdoWithoutIncome.Checked = value; }
        }

        #endregion

        #region Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls(false);
            this.rdoByEncashment.Checked = true;
            this.rdobyTransfer.Checked = false;
            this.rdoWithIncome.Checked = false;
            this.rdoWithoutIncome.Checked = false;
        }

        private void MNMVEW00018_Load(object sender, EventArgs e)
        {
            //ButtonEnableDisabled(newEnabled,editEnabled,saveEnabled,deleteEnabled,cancelEnabled,printEnabled, exitEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.Text = "PO No. Editting for Generated PO";
            this.InitializeControls(false);
            this.ByEncash = true;
            this.rdoByEncashment.Focus();

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ByEncash)
                CXUIScreenTransit.Transit("frmMNMVEW00019POIssueForEncash", true, new object[] { });
            else
            {
                if(this.rdoWithIncome.Checked)
                    //CXUIScreenTransit.Transit("frmMNMVEW00020POIssueByTransfer.Income", true, new object[] { });
                    CXUIScreenTransit.Transit("frmTCMVEW00003.Income", true, new object[] { });
                else
                    //CXUIScreenTransit.Transit("frmTCMVEW00003.NoIncome", true, new object[] { });
                    CXUIScreenTransit.Transit("frmTCMVEW00003.NoIncome", true, new object[] { });
            }
        }

        private void rdoByEncashment_CheckedChanged(object sender, EventArgs e)
        {
            this.InitializeControls(false);
        }

        private void rdobyTransfer_CheckedChanged(object sender, EventArgs e)
        {
            this.InitializeControls(true);
        }

        #endregion

        #region Methods

        public void InitializeControls(bool isCheck)
        {
            this.rdoWithIncome.Enabled = isCheck;
            this.rdoWithoutIncome.Enabled = isCheck;
        }

        #endregion     

        private void MNMVEW00018_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }


    }
}
