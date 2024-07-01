using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00250 : BaseForm, ILOMVEW00240
    {
        IList<BranchDTO> BranchList = null;
        public LOMVEW00250()
        {
            InitializeComponent();
        }
        private ILOMCTL00238 controller;
        public ILOMCTL00238 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        SourceBr = CurrentUserEntity.BranchCode;
                        return CurrentUserEntity.BranchCode;
                    }
                    else return null;
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

        public string TransactionType { get; set; }
        public string VoucherType { get; set; }
        public string OrderBy { get; set; }

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
            BranchList = CXCLE00002.Instance.GetListObject<BranchDTO>("Branch.Client.SelectNotOtherBank", new object[] { false });
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = BranchList;
            cboBranch.SelectedIndex = 0;
        }
        public bool ValidationControls()
        {
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCurrency, "Currency");
            }

            if (cboBranch.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboBranch, "Branch");
            }
            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }
        public void InitializeControls()
        {
            BindCurrency();
            BindSourceBranch();
            this.SourceBr = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }

            this.OptCash.Checked = true;
            cboVoucherType.SelectedIndex = 0;
            this.TransactionType = "CASH";
            this.OrderBy = "ENO";
            this.VoucherType = "CR";
            cboOrderBy.SelectedIndex = 0;

            dtpStartDate.Text = DateTime.Now.ToString();
            dtpEndDate.Text = DateTime.Now.ToString();
        }

        private void LOMVEW00250_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            InitializeControls();
        }
        private void cboOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboOrderBy.SelectedIndex;
            if (idx == 0) OrderBy = "ENO";
            else if (idx == 1) OrderBy = "ACCTNO";
            else if (idx == 2) OrderBy = "DATETIME";
            else if (idx == 3) OrderBy = "ENTERUSER";
        }
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            LOMDTO00245 dto = new LOMDTO00245();
            dto.StartDate = dtpStartDate.Value;
            dto.EndDate = dtpEndDate.Value;
            dto.VoucherType = TransactionType;
            dto.VoucherStatus = VoucherType;
            dto.Currency = cboCurrency.Text;
            dto.SourceBr = cboBranch.Text;
            dto.OptFilter = OrderBy;

            this.controller.Print(dto);
        }

        private void OptCash_CheckedChanged(object sender, EventArgs e)
        {
            if (OptCash.Checked == true)
            {
                this.TransactionType = "CASH";
                OptTransfer.Checked = false;
            }
        }
        private void OptTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (OptTransfer.Checked == true)
            {
                OptCash.Checked = false;
                this.TransactionType = "TRANS";
            }
        }
        private void cboVoucherType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = cboVoucherType.SelectedIndex;
            if (indx == 0) VoucherType = "CR";
            else VoucherType = "DR";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
