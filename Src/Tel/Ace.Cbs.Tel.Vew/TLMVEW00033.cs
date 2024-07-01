//----------------------------------------------------------------------
// <copyright file="TLMVEW00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-07-17 </CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Report => IBL Reconsile
    /// </summary>
    public partial class TLMVEW00033 : BaseDockingForm,ITLMVEW00033
    {
        #region "Properties"
        public DateTime Date
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }

        public string TransactionType
        {
            get
            {
                if (this.rdoDrawing.Checked)
                {
                    return "Drawing";
                }
                else if (this.rdoEncash.Checked)
                {
                    return "Encash";
                }
                else
                {
                    return "Transaction";
                }
            }
            set
            {
                if (value == "Drawing")
                {
                    this.rdoDrawing.Checked = true;
                    
                }

                else if (value == "Encash")
                {
                    this.rdoEncash.Checked = true;
                }

                else
                {
                    this.rdoTransaction.Checked = true;
                }
            }
        }
        public IList<BranchDTO> Branches { get; set; }
        #endregion

        #region Constructor
        public TLMVEW00033()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITLMCTL00033 iblReconcileController;
        public ITLMCTL00033 IBLReconcileController
        {
            get
            {
                return this.iblReconcileController;
            }
            set
            {
                this.iblReconcileController = value;
                this.iblReconcileController.IBLReconsileView = this;
            }
        }
        #endregion

        #region Events
        private void butReconcile_Click(object sender, EventArgs e)
        {
            IList<BranchDTO> BranchList = this.Branches.Where<BranchDTO>(x => x.IsCheck == true).ToList();
            if (BranchList.Count > 0)
            {
                this.iblReconcileController.Reconcile(BranchList, this.Date.Date, this.TransactionType);
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00041");//Select at least one branch to continue processing
            }
        }

        private void TLMVEW00033_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.InititalizeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoEncash_CheckedChanged(object sender, EventArgs e)
        {
            this.InititalizeControls();
        }

        private void rdoTransaction_CheckedChanged(object sender, EventArgs e)
        {
            //this.BindGridView();
            this.InititalizeControls();
        }

        private void rdoDrawing_CheckedChanged(object sender, EventArgs e)
        {
            this.InititalizeControls();
        }
        #endregion

        #region Methods
        private void InititalizeControls()
        {
            this.lblSourceBranch.Text = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BranchName);
            this.BindGridView();
        }


        public void BindGridView()
        {
            this.gvBranch.DataSource = null;
            this.gvBranch.AutoGenerateColumns = false;
            this.Branches = IBLReconcileController.GetReconsileDTOList();
            this.gvBranch.DataSource = this.Branches;

        }
        #endregion
    }
}
