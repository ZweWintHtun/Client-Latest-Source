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
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    //Created By HWKO (14-Jul-2017)
    public partial class LOMVEW00318 : BaseForm,ILOMVEW00318
    {
        #region Constructor
        public LOMVEW00318()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00318 controller;
        public ILOMCTL00318 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Properties

        public bool status;//Added by AAM (08-Dec-2017)
        public string SourceBranch
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
            set { this.cboBranch.SelectedValue = value.ToString(); }
        }

        public string Currency
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

        public string BudgetYear
        {
            get { return this.lblBudgetYear.Text; }
            set { this.lblBudgetYear.Text = value.ToString(); }
        }

        // Added By AAM (08-Dec-2017)

        public string CompanyName { get; set; }
        public string InterestPaidStatus { get; set; }

        #endregion

        #region Method
        #region Initialize
        private void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.BindCompanyName();// Added By AAM (08-Dec-2017)
            
            this.cboCurrency.Focus();
            // this.controller.ClearErrors();
            this.SourceBranch = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
            // Added By AAM (08-Dec-2016)
            this.OptByCompany.Checked = false;
            cboCompanyName.Enabled = false;
            cboCompanyName.SelectedIndex = -1;
            this.CompanyName = "";
            cboIntPaidStatus.SelectedIndex = 0;
        }
        #endregion

        #region BindComboBox

        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        private void BindCompanyName()
        {
            IList<string> companyNameList = this.controller.GetAllPersonalLoansCompanyName(CurrentUserEntity.BranchCode);
            cboCompanyName.ValueMember = "CompanyName";
            cboCompanyName.DisplayMember = "CompanyName";
            cboCompanyName.DataSource = companyNameList;
            cboCompanyName.SelectedIndex = -1;
        }


        #endregion
        #endregion

        #region Events

        private void LOMVEW00318_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.Print(CompanyName,InterestPaidStatus);
        }

        #endregion

        // Added By AAM (08-Dec-2017)

        private void OptByCompany_Click(object sender, EventArgs e)
        {
            this.OptALL.Checked = false;
            cboCompanyName.Enabled = true;
            cboCompanyName.SelectedIndex = 0;
            this.CompanyName = "-1";

            cboIntPaidStatus.SelectedIndex = 0;
            this.InterestPaidStatus = "-1";
        }

        private void OptALL_Click(object sender, EventArgs e)
        {
            this.OptByCompany.Checked = false;
            cboCompanyName.Enabled = false;
            cboCompanyName.SelectedIndex = 0;
            this.CompanyName = "";

            cboIntPaidStatus.SelectedIndex = 0;
            this.InterestPaidStatus = "-1";
        }
       
        private void cboIntPaidStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = cboIntPaidStatus.SelectedIndex;
            if (ind == 0) InterestPaidStatus = "-1"; // "-1" means ALL interest paid status.
            else if (ind == 1) InterestPaidStatus = "Paid";
            else if (ind == 2) InterestPaidStatus = "Absent";
            else InterestPaidStatus = "Need To Pay";

        }

        private void cboCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == false)
                this.CompanyName = (cboCompanyName.SelectedValue == null) ? "" : cboCompanyName.SelectedValue.ToString();
        }

    }
}
