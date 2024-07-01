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
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00301 : BaseDockingForm,ILOMVEW00301
    {
        #region Constructor
        public LOMVEW00301()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00301 controller;
        public ILOMCTL00301 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }
        #endregion

        #region Properties
        public string LoansNo
        {
            get { return this.txtLoanNo.Text.Trim(); }
            set { this.txtLoanNo.Text = value; }
        }

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public decimal SanctionAmount
        {
            get
            {
                if (this.ntxtSanctionAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtSanctionAmount.Text.Trim());
            }

            set { this.ntxtSanctionAmount.Text = Convert.ToString(value); }
        }

        public decimal Rate
        {
            get
            {
                if (this.ntxtRate.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtRate.Text.Trim());
            }

            set { this.ntxtRate.Text = Convert.ToString(value); }
        }

        public decimal InterestAmount
        {
            get
            {
                if (this.ntxtQuarterAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.ntxtQuarterAmount.Text.Trim());
            }

            set { this.ntxtQuarterAmount.Text = Convert.ToString(value); }
        }

        #endregion

        #region "Public Methods"
        public void InitializedControls()
        {
            this.txtLoanNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.ntxtQuarterAmount.Text = "0.00";
            this.ntxtRate.Text = "0.00";
            this.ntxtSanctionAmount.Text = "0.00";
            // this.ntxtQuarterAmount.ReadOnly = true;
            this.DisableTextBox();
            this.tlspCommon.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Enabled = true;
            this.txtLoanNo.Focus();
        }
        public void EnableTextBox()
        {
            this.ntxtRate.Enabled = true;
            this.ntxtSanctionAmount.Enabled = true;
            this.mtxtAccountNo.Enabled = true;
        }
        public void DisableTextBox()
        {
            this.ntxtRate.Enabled = false;
            this.ntxtSanctionAmount.Enabled = false;
            this.mtxtAccountNo.Enabled = false;
            this.txtLoanNo.Enabled = false;
        }
        public void TextFcus()
        {
            this.ntxtQuarterAmount.SelectionStart = this.ntxtQuarterAmount.TextLength;
            this.ntxtQuarterAmount.Focus();
        }
        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, "Loan No " + txtLoanNo.Text);
            this.InitializedControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        #region "Private Method"
        private string GetMonthNo()
        {
            string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(budgetYear, DateTime.Now));
            string intMonth = "M" + Convert.ToString(initialMonth);
            return intMonth;
        }
        #endregion

        private void LOMVEW00301_Load(object sender, EventArgs e)
        {
            this.Text = "Farm Loan Interest Editting";
            this.InitializedControls();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            txtLoanNo.Focus();
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.ClearCustomErrorMessage();
            this.Controller.ClearErrors();
            this.InitializedControls();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlspCommon_SaveButtonClick(object sender, EventArgs e)
        {
            if (txtLoanNo.Text == null || txtLoanNo.Text == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);
                txtLoanNo.Focus();
            }
            else
            {
                this.Controller.Update();
            }
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void LOMVEW00301_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
    }
}
