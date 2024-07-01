using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00028 : BaseForm, IGLMVEW00028
    { 
        #region Constructor
        public GLMVEW00028()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private IGLMCTL00028 controller;
        public IGLMCTL00028 Controller
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

        public string RequireYear
        {
            get { return this.txtYear.Text; }
            set { this.txtYear.Text = value; }
        }

        public string RequireMonth
        {
            get { return txtMonth.Text; }
            set { txtMonth.Text = value; }
        }

        public string BudgetYear
        {
            get { return this.lblBudgetYear.Text; }
            set { this.lblBudgetYear.Text = value.ToString(); }
        }
        
        public string CurrentBCode { get; set; }
        #endregion

        #region Methods

        private void InitailizeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            this.CurrentBCode = CurrentUserEntity.BranchCode;

            // Modified by ZMS For Year End Flexible 2018/09/21
            //this.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.BudgetYear = this.Controller.GetBudYear();

            this.setNormalControl();
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
        }

        private void setNormalControl()
        {
            txtMonth.Text = DateTime.Now.ToString("MM");
            txtYear.Text = DateTime.Now.ToString("yyyy");
        }

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
        #endregion
        #endregion

        #region Events
        private void GLMVEW00028_Load(object sender, EventArgs e)
        {
            this.InitailizeControls();
        }

        #endregion

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
