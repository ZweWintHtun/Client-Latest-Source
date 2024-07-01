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
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00405 : BaseForm,ILOMVEW00405
    {
       
        #region Constructor
        public LOMVEW00405()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00405 controller;
        public ILOMCTL00405 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Properties
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
        public string BusinessLoansTypes
        {
            get { return this.cboBLTypes.Text; }
            set { this.cboBLTypes.Text = value.ToString(); }
        }
        public string rptname { get; set; }
        IList<LOMDTO00001> TypeOfBusinessList { get; set; }

        //Added By AAM (11-Dec-2017)
        public string BusinessTypes { get; set; }
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
            this.OptAll.Checked = true;
            this.OptByBLTypes.Checked = false;
            this.cboBLTypes.Enabled = false;

            // Added By AAM (11_Dec_2017)
            this.BusinessTypes = "";
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
        public void BindTypeOfBusiness()
        {
            TypeOfBusinessList = this.Controller.BindLoansBType();
            this.cboBLTypes.ValueMember = "Code";
            this.cboBLTypes.DisplayMember = "Description";
            //this.cboBLTypes.ColumnNames = "Code,Description";
            this.cboBLTypes.DataSource = TypeOfBusinessList;
            this.cboBLTypes.SelectedIndex = -1;
        }
        #endregion
        #endregion

        #region Events
        private void LOMVEW00405_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
            this.BindTypeOfBusiness();
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
            if (this.cboCurrency.SelectedValue.ToString() == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00020");
                this.cboCurrency.Focus();
                return;
            }
            if (this.cboBranch.SelectedValue.ToString() == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00070");
                this.cboBranch.Focus();
                return;
            }
            if (OptAll.Checked == true)
                rptname = "ALL";
            else if (OptByBLTypes.Checked == true)
                rptname = this.BusinessLoansTypes;

            this.Controller.Print(); // Added By AAM (11-Dec-2017) two parameters.
        }
        #endregion

        private void OptAll_Click(object sender, EventArgs e)
        {
            //this.cboBLTypes.Enabled = false;
            //this.cboBLTypes.SelectedValue = "";
            //cboBranch.Text = "";
            //this.OptByBLTypes.Checked = false;

            //Added By AAM (11-Dec-2017)
            this.OptByBLTypes.Checked = false;
            cboBLTypes.Enabled = false;
            cboBLTypes.SelectedIndex = -1;
            this.BusinessTypes = "";

            cboIntPaidStatus.SelectedIndex = 0;
            this.InterestPaidStatus = "-1";
        }

        private void OptByBLTypes_Click(object sender, EventArgs e)
        {
            this.OptAll.Checked = false;
            this.cboBLTypes.Enabled = true;

            //Added By AAM (11-Dec-2017)
            cboBLTypes.SelectedIndex = 0;
            this.BusinessTypes = "-1";

            cboIntPaidStatus.SelectedIndex = 0;
            this.InterestPaidStatus = "-1";
        }

        //Added By AAM (11-Dec-2017)
        private void cboIntPaidStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = cboIntPaidStatus.SelectedIndex;
            if (ind == 0) InterestPaidStatus = "-1"; // "-1" means ALL interest paid status.
            else if (ind == 1) InterestPaidStatus = "Paid";
            else if (ind == 2) InterestPaidStatus = "Absent";
            else InterestPaidStatus = "Need To Pay";

        }

    }
}
