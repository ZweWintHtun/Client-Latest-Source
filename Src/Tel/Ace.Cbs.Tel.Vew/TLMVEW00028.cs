//----------------------------------------------------------------------
// <copyright file="TLMVEW00028.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// IBL Transaction Listing Enquiry
    /// </summary>
    public partial class TLMVEW00028 : BaseForm, ITLMVEW00028
    {
        #region Constructor
        public TLMVEW00028()
        {
            InitializeComponent();
        }
        #endregion

        #region "Controllers"
        private ITLMCTL00028 controller;
        public ITLMCTL00028 Controller
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

        #region Controls Input Output
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
        //public bool AllBranch
        //{
        //    get { return chkAllBranch.Checked; }
        //    set { chkAllBranch.Checked = value; }
        //}
        public string BranchCode
        {
            get
            {
                if (this.cboBranchNo.SelectedValue == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.cboBranchNo.SelectedValue.ToString();
                }
            }
            set { this.cboBranchNo.SelectedValue = value; }
        }
        public string TranType { get; set; }
        public bool isActive
        { 
            get { return this.rdoActiveTransaction.Checked; }
            set { this.rdoActiveTransaction.Checked = value; }
        }
        public bool isReversal 
        { 
            get { return this.chkReversalTransaction.Checked; }
            set { this.chkReversalTransaction.Checked = value; }
        }
        #endregion

        #region Methods
        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            if (this.FormName == "Transaction Listing By Branch")
            {
                this.Text = this.FormName;
                this.HideControls("TransactionListing.VisibleHiddenControls");
            }
            else if (this.FormName == "Online Transaction Listing")
            {
                this.Text = this.FormName;
                this.HideControls("OnlineTransaction.VisibleHiddenControls");
                //this.chkAllBranch.Checked = true;

            }
            else
            {
                this.Text = "Income Listing";
                this.HideControls("IncomeListing.VisibleHiddenControls");
                this.Size = new System.Drawing.Size(500, 254);
                this.gbTransaction.Size = new System.Drawing.Size(337, 169);

                this.lblBranchName.Location = new System.Drawing.Point(27, 66);
                this.label4.Location = new System.Drawing.Point(27, 98);
                this.label2.Location = new System.Drawing.Point(27, 129);

                this.cboBranchNo.Location = new System.Drawing.Point(153, 63);
                this.dtpStartDate.Location = new System.Drawing.Point(153, 95);
                this.dtpEndDate.Location = new System.Drawing.Point(153, 125);

                //this.chkAllBranch.Checked = true;
            }
            this.BindBranchCombobox();
            this.BindTransactionTypeCombobox();
          
        }
       
        public string GetTranType()
        {
            if (cboTransactionType.SelectedIndex == 0)
                this.TranType = "CDW";
            else if (cboTransactionType.SelectedIndex == 1)
                this.TranType = "TDV";
            else if (cboTransactionType.SelectedIndex == 2)
                this.TranType = "TCV";
            else if (cboTransactionType.SelectedIndex == 3
                )
                this.TranType = "CCD";
            else if (cboTransactionType.SelectedIndex == 4)
                this.TranType = "-";          
            else
                this.TranType = string.Empty;
            return this.TranType;
        }

        private void BindBranchCombobox()
        {

            //IList<BranchDTO> branches = CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectOtherBank", new object[] { false });
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllOtherBranchBySourceBranch(CurrentUserEntity.BranchCode);
            cboBranchNo.ColumnNames = "BranchCode,BranchDescription";
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            //cboBranchNo.DisplayMember = "BranchAlias";
            cboBranchNo.DataSource = branches;
            cboBranchNo.SelectedIndex = -1;
        }

        private void BindBranchComboboxForActiveTransaction()
        {

            //IList<BranchDTO> branches = CXCLE00002.Instance.GetListObject<BranchDTO>("BranchCode.Client.SelectOtherBank", new object[] { false });
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranchesBySourceBranch(CurrentUserEntity.BranchCode);
            cboBranchNo.ColumnNames = "BranchCode,BranchDescription";
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            //cboBranchNo.DisplayMember = "BranchAlias";
            cboBranchNo.DataSource = branches;
            cboBranchNo.SelectedIndex = -1;
        }

        private void BindTransactionTypeCombobox()
        {
            Dictionary<string, string> transactionType = SpringApplicationContext.Instance.Resolve<Dictionary<string, string>>("TransactionType");
            BindingSource transactionTypeDS = new BindingSource(transactionType, null);
            cboTransactionType.DisplayMember = "Key";
            cboTransactionType.ValueMember = "Value";
            cboTransactionType.DataSource = transactionTypeDS;
            cboTransactionType.SelectedIndex = -1;
        }
        #endregion

        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TLMVEW00028_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        //private void chkAllBranch_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.DisableControls("IBLTransaction.DisableControls");

        //    if (chkAllBranch.Checked == false)
        //    {
        //        this.EnableControls("IBLTransaction.EnableControls");

        //    }

        //    else if (chkAllBranch.Checked == true)
        //    {
        //        this.BranchCode = string.Empty;
        //    }
        //    this.controller.ClearErrors();
        //}

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.cboBranchNo.SelectedIndex = -1;
            this.cboTransactionType.SelectedIndex = -1;
            this.dtpStartDate.Value = DateTime.Now ;
            this.dtpEndDate.Value = DateTime.Now;
           // this.chkAllBranch.Checked = false;
            this.rdoHomeTransaction.Checked = true;
            this.chkReversalTransaction.Checked = false;
            this.controller.ClearErrors();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {

            string forReversalCase = null;
            if (chkReversalTransaction.Checked == true )
            {
                forReversalCase = "Reversal";
            }
            this.controller.Print(forReversalCase);
        }

        #endregion

        //private void rdoActiveTransaction_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.BindBranchComboboxForActiveTransaction();

        //}
     

        private void rdoActiveTransaction_Click(object sender, EventArgs e)
        {
            this.BindBranchComboboxForActiveTransaction();
        }

        private void rdoHomeTransaction_Click(object sender, EventArgs e)
        {
            this.BindBranchCombobox();
        }
    }
}
    