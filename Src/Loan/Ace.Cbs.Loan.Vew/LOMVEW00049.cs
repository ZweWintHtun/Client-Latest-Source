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
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00049 : BaseForm, ILOMVEW00049
    {
        #region Constructor
        public LOMVEW00049()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime RequiredDate
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
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
        private ILOMCTL00049 controller;
        public ILOMCTL00049 Controller
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
            this.dtpRequiredDate.Value = DateTime.Now;
            this.BindCurrency();
            this.BindSourceBranch();
            this.dtpRequiredDate.Focus();
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
        #endregion
        #endregion

        #region Events
        private void LOMVEW00049_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = "Loans Daily Position Listing";
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
