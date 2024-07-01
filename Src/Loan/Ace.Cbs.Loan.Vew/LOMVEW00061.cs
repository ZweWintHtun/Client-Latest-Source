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
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00061 : BaseForm, ILOMVEW00061
    {
        #region Constructor
        public LOMVEW00061()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
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

        public string AcctNo
        {
            get { return this.mtxtAccountNo.Text; }
            set { this.mtxtAccountNo.Text = value; }
        }
        #endregion

        #region Controller
        private ILOMCTL00061 controller;
        public ILOMCTL00061 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Method
        #region Initialize
        private void InitailizeControl()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.dtpStartDate.Focus();
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
        #endregion

        #endregion

        private void mtxtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void LOMVEW00061_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = "Overdraft Limit Change Listing By Account";
            this.InitailizeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
