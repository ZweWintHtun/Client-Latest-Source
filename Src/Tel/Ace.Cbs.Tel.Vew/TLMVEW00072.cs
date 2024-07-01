//----------------------------------------------------------------------
// <copyright file="TLMVEW00072" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00072 : BaseForm,ITLMVEW00072
    {
        #region Constructor
        public TLMVEW00072()
        {
            InitializeComponent();
        }

        public TLMVEW00072(string accountNo)
        {
            InitializeComponent();
            this.AccountNo = accountNo;
        }
        #endregion

        #region Controller
        private ITLMCTL00072 controller;
        public ITLMCTL00072 Controller
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
        #endregion

        #region Controls Input Output
        public string AccountNo
        {
            get
            {
                return this.mtxtAccountNo.Text;
            }
            set
            {
                this.mtxtAccountNo.Text = value;
            }
        }
        #endregion

        #region "Methods"
        public void BindTransactionGridView(IList<PFMDTO00043> prnFileList)
        {
            this.gvPrintRemainTransaction.DataSource = null; 
            this.gvPrintRemainTransaction.AutoGenerateColumns = false;
            this.gvPrintRemainTransaction.DataSource = prnFileList; 
           

        }

        public void ClearControls()
        {
            this.controller.clear();
            this.gvPrintRemainTransaction.DataSource = null;           
            this.mtxtAccountNo.Focus();
            
        }
        #endregion

        #region Events
        private void TLMVEW00072_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.mtxtAccountNo.Focus();         
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.mtxtAccountNo.Text))
            {
                this.controller.PrintRemainTransaction();
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00046"); //Invalid Account No.
                this.mtxtAccountNo.Focus();
                return;
            }
            
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
         
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }

        }


        #endregion

        private void TLMVEW00072_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
