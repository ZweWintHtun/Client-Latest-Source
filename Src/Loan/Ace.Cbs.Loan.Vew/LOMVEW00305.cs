using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00305 : BaseForm, ILOMVEW00305
    {
        //Created By HWKO (04-Apr-2017)
        #region Constructor
        public LOMVEW00305()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00305 controller;
        public ILOMCTL00305 Controller
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

        public string Village
        {
            get
            {
                if (this.cboVillageGroup.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboVillageGroup.SelectedValue.ToString();
                }

            }
            set { this.cboVillageGroup.SelectedValue = value.ToString(); }
        }

        public string Township
        {
            get
            {
                if (this.cboTownship.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboTownship.SelectedValue.ToString();
                }
            }
            set { this.cboTownship.SelectedValue = value; }
        }

        public DateTime WithdrawDate
        {
            get { return this.dtpWithdrawDate.Value; }
            set { this.dtpWithdrawDate.Text = value.ToString(); }
        }

        public string BudgetYear
        {
            get { return this.lblBudgetYear.Text; }
            set { this.lblBudgetYear.Text = value.ToString(); }
        }

        #endregion

        #region Method
        #region Initialize
        private void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.dtpWithdrawDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.BindVillageGroupCombobox();
            this.BindTownshipCodeCombobox();
            this.cboCurrency.Focus();
            // this.controller.ClearErrors();
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
            cboBranch.SelectedIndex = -1;
        }

        public void BindVillageGroupCombobox()
        {
            IList<LOMDTO00070> VillageGroupList = CXCLE00002.Instance.GetListObject<LOMDTO00070>("LOMORM00070.SelectAllVillageGroupCode", new object[] { true });
            this.cboVillageGroup.ValueMember = "VillageCode";
            this.cboVillageGroup.DisplayMember = "Desp";
            this.cboVillageGroup.DataSource = VillageGroupList;
            this.cboVillageGroup.SelectedIndex = -1;
        }

        /// <summary>
        /// Bind Township Code Combobox
        /// </summary>
        private void BindTownshipCodeCombobox()
        {
            IList<TownshipDTO> TownshipCodeList = CXCLE00002.Instance.GetListObject<TownshipDTO>("TownshipCode.Client.Select", new object[] { true });

            cboTownship.ValueMember = "TownshipCode";
            cboTownship.DisplayMember = "Description";
            cboTownship.DataSource = TownshipCodeList;
            cboTownship.SelectedIndex = -1;

        }
        #endregion        
        #endregion

        private void LOMVEW00305_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

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
            this.Controller.Print();
        }

    }
}
