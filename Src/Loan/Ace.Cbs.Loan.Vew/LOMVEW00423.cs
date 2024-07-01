using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00423 : BaseForm, ILOMVEW00423
    {
        #region Constructor
        public LOMVEW00423()
        {
            InitializeComponent();
        }
        private ILOMCTL00423 controller;
        public ILOMCTL00423 Controller
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
        public string bCode
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboBranch.SelectedValue = value;
            }
        }
        public string cur
        {
            get
            {
                if (this.cboCurrency.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.SelectedValue.ToString();
                }
            }
            set { this.cboCurrency.SelectedValue = value; }
        }
        public string loanGroup
        {
            get { return this.cboLGroup.Text; }
            set { this.cboLGroup.Text = value.ToString(); }
        }
        public string sourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser == null)
                    {
                        sourceBr = CurrentUserEntity.BranchCode;
                        return CurrentUserEntity.BranchCode;
                    }
                    else return null;
                }
                else
                {
                    return this.cboBranch.SelectedValue.ToString();
                }
            }
            set
            {
                this.cboBranch.SelectedValue = value.ToString();
            }
        }
        #endregion


        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "BLDailyPositionListing";

            //this.controller.Print(rptName, StockGroup,StartDate,EndDate, SourceBr);
            if (OptALL.Checked == true)
            {
                this.controller.Print(rptName, bCode, cur, "");
            }
            else this.controller.Print(rptName, bCode, cur, loanGroup);

        }
        private void LOMVEW00423_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }
        private void OptALL_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void OptByBLType_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }
        private void opBAll_CheckedChanged(object sender, EventArgs e)
        {
            ChangeViewForBranch();
        }
        private void optBranch_CheckedChanged(object sender, EventArgs e)
        {
            ChangeViewForBranch();
        }
        #endregion

        #region Methods

        public void ClearControl()
        {
            this.OptALL.Checked = true;
            BindBranchCode();
            BindCurrency();
            BindBLType();
        }
        public void ChangeView()
        {
            if (this.OptALL.Checked == true)
            {
                this.OptByBLType.Checked = false;
                cboLGroup.Enabled = false;
                cboLGroup.Visible = false;
                lblLoanGroup.Visible = false;
                loanGroup = "";
                cboLGroup.SelectedValue = "";
            }
            else if (this.OptByBLType.Checked == true)
            {
                this.OptByBLType.Checked = true;
                cboLGroup.Enabled = true;
                cboLGroup.Visible = true;
                lblLoanGroup.Visible = true;
            }
        }

        public void ChangeViewForBranch()
        {
            if (this.optBAll.Checked == true)
            {
                this.optBranch.Checked = false;
                this.optBAll.Checked = true;
                cboBranch.Enabled = false;                
            }
            else if (this.optBranch.Checked == true)
            {
                this.optBranch.Checked = true;
                this.optBAll.Checked = false;
                cboLGroup.Enabled = true;
            }
        }
        public void BindBranchCode()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });

            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        public void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;

        }
        public void BindBLType()
        {
            IList<LOMDTO00001> TypeOfBusinessList = Controller.GetAllBLTypes();
            cboLGroup.ValueMember = "Code";
            this.cboLGroup.DisplayMember = "Description";
            this.cboLGroup.DataSource = TypeOfBusinessList;
            this.cboLGroup.SelectedIndex = 0;
        }
        public bool ValidationControls()
        {
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCurrency, "Currency");
                return false;
            }

            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboBranch, "Branch");
                return false;
            }

            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            if (OptALL.Checked == false)
            {
                if (cboLGroup.Text == "")
                {
                    errorProvider1.SetError(cboLGroup, "Business Loans Group");
                    return false;
                }
            }

            return true;
        }
        public void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            BindBranchCode();
            BindCurrency();
            BindBLType();
            this.sourceBr = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
                this.cboBranch.Text = CurrentUserEntity.BranchCode;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
            this.OptALL.Checked = true;
            this.OptByBLType.Checked = false;
            cboLGroup.Visible = false;
            lblLoanGroup.Visible = false;
            cboLGroup.Text = "";
            this.loanGroup = "";
        }
        #endregion

    }
}
