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
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00416 : BaseForm, ILOMVEW00416
    {
        #region Constructor
        public LOMVEW00416()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00416 controller;
        public ILOMCTL00416 Controller
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
            this.SourceBranch = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
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
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.cboCurrency.SelectedValue == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00020");
                this.cboCurrency.Focus();
                return;
            }
            if (this.cboBranch.SelectedValue == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00070");
                this.cboBranch.Focus();
                return;
            }
            if (OptAll.Checked == true)
                rptname = "All";
            else if (OptByBLTypes.Checked == true)
                rptname = this.BusinessLoansTypes;
            this.Controller.Print();
        }

        private void LOMVEW00416_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
            this.BindTypeOfBusiness();
        }
        #endregion

        private void OptAll_Click(object sender, EventArgs e)
        {
            this.cboBLTypes.Enabled = false;
            this.cboBLTypes.SelectedValue = "";
            cboBranch.Text = "";
            this.OptByBLTypes.Checked = false;
        }

        private void OptByBLTypes_Click(object sender, EventArgs e)
        {
             this.OptAll.Checked = false;
            this.cboBLTypes.Enabled = true;
        }
        }
    }