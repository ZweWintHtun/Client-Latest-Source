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
    public partial class LOMVEW00051 : BaseForm, ILOMVEW00051
    {
        #region Constructor
        public LOMVEW00051()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public string RequiredYear
        {
            get { return this.txtYear.Text; }
            set { this.txtYear.Text = value.ToString(); }
        }

        public string RequiredMonth
        {
            get
            {
                if (this.cboMonth.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return this.cboMonth.SelectedValue.ToString();
                }

            }
            set { this.cboMonth.SelectedValue = value.ToString(); }
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

        #endregion

        #region Controller
        private ILOMCTL00051 controller;
        public ILOMCTL00051 Controller
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
            this.txtYear.Text = DateTime.Now.Year.ToString();
            this.BindMonth();
            this.BindCurrency();
            this.BindSourceBranch();
            this.txtYear.Focus();
            this.cboMonth.SelectedIndex = (DateTime.Now.Month - 1);
            // this.controller.ClearErrors();
        }
        #endregion

        #region BindComboBox
        private void BindMonth()
        {
            cboMonth.DataSource = new List<string> 
            {
                "January","February","March","April","May","June","July","August","September","Octorber","November","December" 
            };
            cboMonth.SelectedIndex = -1;
        }

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

        #region Events

        private void LOMVEW00051_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = "Expire Loans Listing";
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
        #endregion
    }
}
