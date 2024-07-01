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
    public partial class LOMVEW00224 : BaseForm, ILOMVEW00224
    {
        public bool status;
        IList<LOMDTO00001> TypeOfBusinessList;
        public LOMVEW00224()
        {
            InitializeComponent();
        }
        private ILOMCTL00224 controller;
        public ILOMCTL00224 Controller
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

        public string BusinessType { get; set; }
        public string SortType { get; set; }

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
            TypeOfBusinessList = this.controller.BindLoansBType();
            this.cboBusinessType.ValueMember = "Code";
            this.cboBusinessType.DisplayMember = "Description";
            this.cboBusinessType.DataSource = TypeOfBusinessList;
            this.cboBusinessType.SelectedIndex = -1;
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

            this.OptByBusinessType.Checked = false;
            cboBusinessType.Enabled = false;
            cboBusinessType.SelectedIndex = -1;
            this.BusinessType = "";
            this.SortType = "AC";
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
            if (OptByBusinessType.Checked)
            {
                if (cboBusinessType.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cboBusinessType, "BusinessType");
                }
            }
            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void OptALL_Click(object sender, EventArgs e)
        {
            this.OptByBusinessType.Checked = false;
            cboBusinessType.Enabled = false;
            cboBusinessType.SelectedIndex = -1;
            this.BusinessType = "";
        }

        private void OptByBusinessType_Click(object sender, EventArgs e)
        {
            OptALL.Checked = false;
            cboBusinessType.Enabled = true;
            cboBusinessType.SelectedIndex = -1;
            this.BusinessType = "''";
        }

        private void cboBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == false)
                this.BusinessType = (cboBusinessType.SelectedValue == null) ? "" : cboBusinessType.SelectedValue.ToString();
        }

        private void LOMVEW00224_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            BindCurrency();
            BindSourceBranch();
            BindTypeOfBusiness();
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            BindCurrency();
            BindSourceBranch();
            BindTypeOfBusiness();
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "BLInstallmentList";
            this.controller.Print(rptName, Currency, SourceBr, BusinessType);
        }

        private void rdoByAC_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void rdoByBLNo_CheckedChanged(object sender, EventArgs e)
        {
            ChangeView();
        }
        private void ChangeView()
        {
            if (rdoByAC.Checked == true)
            {
                this.SortType = "AC";
            }
            else if (rdoByBLNo.Checked == true)
            {
                this.SortType = "BLNO";
            }
        }

    }
}
