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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    //Created By HWKO (11-Jul-2017)
    public partial class LOMVEW00314 : BaseForm,ILOMVEW00314
    {
        #region Constructor
        public LOMVEW00314()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00314 controller;
        public ILOMCTL00314 Controller
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

        public DateTime SelectedDate
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
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
            
            this.dtpDate.Value = DateTime.Now;
            //this.BindCurrency();
            this.BindSourceBranch();

            //this.cboCurrency.Focus();
            this.cboBranch.Focus();
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

        //private void BindCurrency()
        //{
        //    IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
        //    cboCurrency.ValueMember = "Cur";
        //    cboCurrency.DisplayMember = "Cur";
        //    cboCurrency.DataSource = CurrencyList;
        //    cboCurrency.SelectedIndex = 0;
        //}

        private void BindSourceBranch()
        {
            IList<BranchDTO> BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }

        #endregion        

        #endregion

        #region Events

        private void LOMVEW00314_Load(object sender, EventArgs e)
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
            this.Controller.Print();
        }

        #endregion

    }
}
