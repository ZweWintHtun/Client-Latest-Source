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
    public partial class LOMVEW00238 : BaseForm, ILOMVEW00238
    {
        public LOMVEW00238()
        {
            InitializeComponent();
        }

        private ILOMCTL00236 controller;
        public ILOMCTL00236 Controller
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

        public string DateOption;
        public string VoucherStatus;
        public string RequiredType;
        public int ReverseStatus;

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
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
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
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAccountNo.Text = string.Empty;
            chkWithoutReversal.Checked = true;
            OptTransDate.Checked = true;
            cboVoucherStatus.SelectedIndex = 0;
            cboRequiredType.SelectedIndex = 0;
        }

        private void LOMVEW00238_Load(object sender, EventArgs e)
        {
            this.BindSourceBranch();
            this.BindCurrency();
            InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "TransferTransactionLists";
            
            if (cboVoucherStatus.SelectedIndex == 0) VoucherStatus = "ALL";
            else if (cboVoucherStatus.SelectedIndex == 1) VoucherStatus = "TRCR";
            else VoucherStatus = "TRDR";

            if (mtxtAccountNo.Text.Length > 0) RequiredType = mtxtAccountNo.Text; // Specific Account ( Domenstic A/C or Customer A/C).
            else RequiredType = "ALL";

            if (chkWithReversal.Checked) ReverseStatus = 1;
            else ReverseStatus = 0;

            if (OptTransDate.Checked) DateOption = "Transaction Date";
            else DateOption = "Settlement Date";

            this.controller.Transfer_Transaction_Listing(rptName, DateOption, StartDate, EndDate, VoucherStatus,RequiredType,ReverseStatus, Currency, SourceBr);

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptTransDate_Click(object sender, EventArgs e)
        {
            DateOption = "T";
            OptSettleDate.Checked = false;
        }

        private void OptSettleDate_Click(object sender, EventArgs e)
        {
            DateOption = "S";
            OptTransDate.Checked = false;
        }

        private void chkWithReversal_Click(object sender, EventArgs e)
        {
            ReverseStatus = 1;
            chkWithoutReversal.Checked = false;
        }

        private void chkWithoutReversal_Click(object sender, EventArgs e)
        {
            ReverseStatus = 0;
            chkWithReversal.Checked = false;
        }

        private void cboRequiredType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRequiredType.SelectedIndex == 0)
            {
                mtxtAccountNo.Text = string.Empty;
                mtxtAccountNo.Enabled = false;
                lblAcctNo.Enabled = false;
            }
            else mtxtAccountNo.Enabled = true;
        }


    }
}
