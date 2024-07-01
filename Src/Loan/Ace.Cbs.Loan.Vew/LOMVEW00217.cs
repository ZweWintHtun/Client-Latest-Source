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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00217 : BaseForm, ILOMVEW00217
    {
        public string sourceBr;
        public string accountNo;
        public LOMVEW00217()
        {
            InitializeComponent();
        }
        public LOMVEW00217(bool isMainMenu, string parentFormId)
        {
            InitializeComponent();

            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
        }

        #region Controls Input Output

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }
        private string parentFormId = string.Empty;

        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
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

        public string AcctNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        sourceBr = CurrentUserEntity.BranchCode;
                        return sourceBr;
                    }
                    else return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }

            }
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }

        #endregion
        private ILOMCTL00217 controller;
        public ILOMCTL00217 Controller
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

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        public bool ValidationControls()
        {
            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboBranch, "Branch");
            }

            if (cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitailizeControl()
        {
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindSourceBranch();
            if (!CurrentUserEntity.IsHOUser)
            {
                this.SourceBr = CurrentUserEntity.BranchCode;
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
        }

        private void LOMVEW00217_Load(object sender, EventArgs e)
        {
            this.InitailizeControl();
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.Text = string.Empty;
            this.dtpStartDate.Enabled = true;
            this.dtpEndDate.Enabled = true;
            this.lblAcctNo.Enabled = false;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "PLAbsentHistoryList";
            this.controller.Print(rptName, StartDate, EndDate, AcctNo, CurrentUserEntity.BranchCode);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptByAcctNo_Click(object sender, EventArgs e)
        {
            this.OptAll.Checked = false;
            this.lblAcctNo.Enabled = true;
            this.mtxtAccountNo.Enabled = true;
            accountNo = this.mtxtAccountNo.ToString();
            this.dtpStartDate.Enabled = false;
            this.dtpEndDate.Enabled = false;
        }

        private void OptAll_Click(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Enabled = false;
            this.mtxtAccountNo.Text = string.Empty;
            this.dtpStartDate.Enabled = true;
            this.dtpEndDate.Enabled = true;
            this.lblAcctNo.Enabled = false;
        }

    }
}
