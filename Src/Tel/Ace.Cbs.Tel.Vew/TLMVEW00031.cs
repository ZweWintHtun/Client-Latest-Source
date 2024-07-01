//----------------------------------------------------------------------
// <copyright file="TLMVEW00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-13</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Report ->Bank Statement Listing By Date
    /// </summary>
    public partial class TLMVEW00031 : BaseForm, ITLMVEW00031
    {
        #region "Properties"
      
        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }       
        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }
        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }
        public bool IsAllCustmers
        {
            get { return chkAllCustomers.Checked; }
            set { chkAllCustomers.Checked = value; }
        }

        public bool isFixedAcc { get; set; }

        public bool WithReversal
        {
            get { return chkWithReversal.Checked; }
            set { chkWithReversal.Checked = value; }
        }
        #endregion

        #region "Constructor"

        public TLMVEW00031()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controllers"
        private ITLMCTL00031 controller;
        public ITLMCTL00031 BankstatementListingByDateController //BankStatementListingByAllController
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.BankstatementListingByDateView = this;
            }
        }

        #endregion

        #region "Events"
        private void TLMVEW00031_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate())
            {             
                if (this.chkAllCustomers.Visible == false && this.isFixedAcc==false)
                {
                    this.controller.CLedgerMainPrint();
                }
                else
                {
                    this.controller.FAOFMainPrint();
                }
            }
        }       

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnableDisableControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }
        #endregion


        #region "Private Method"

        private void InitializeControls()
        {
            this.EnableDisableControls();
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.mtxtAccountNo.Clear();
            this.mtxtAccountNo.Focus();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            //this.ForFAOFAccount(false);
        }
       #endregion

    
    }
}
