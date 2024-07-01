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
    public partial class LOMVEW00249 : BaseForm, ILOMVEW00240
    {
        List<LOMDTO00244> lst=new List<LOMDTO00244>();
        IList<BranchDTO> BranchList=null;

        public LOMVEW00249()
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
        public string ACTypeFilter { get; set; }
        public string SortBy { get; set; }

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

            this.OptByAccountType.Checked = false;
            cboAccountType.Enabled = false;
            cboAccountType.SelectedIndex = 0;
            this.ACTypeFilter = "";
            this.SortBy = "";
            cboSortBy.SelectedIndex = 0;
            
            dtpStartDate.Text = DateTime.Now.ToString();
            dtpEndDate.Text = DateTime.Now.ToString();
            ACTypeFilter = "0";
        }

        private void LOMVEW00249_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            InitializeControls();
            ACTypeFilter = "5";
        }

        private void OptALL_Click(object sender, EventArgs e)
        {
            if (OptALL.Checked == true)
            {
                CheckChangeEvent();
            }
        }

        private void OptByAccountType_Click(object sender, EventArgs e)
        {
            if (OptByAccountType.Checked == true)
            {
                CheckChangeEvent();
            }
        }
        private void CheckChangeEvent()
        {
             if (OptALL.Checked == true)
             {
                OptByAccountType.Checked = false;
                cboAccountType.Enabled = false;
                cboAccountType.SelectedIndex = -1;
                ACTypeFilter = "5";
                OptByAccountType.Checked = false;
            }
            else
            {
                OptByAccountType.Checked = true;
                OptALL.Checked = false;
                cboAccountType.Enabled = true;
                cboAccountType.SelectedIndex = -1;
                //ACTypeFilter = "0";
            }
        }
        private void cboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indx = cboAccountType.SelectedIndex;
            if (indx == 0) ACTypeFilter = "0"; // BL
            else if (indx == 1) ACTypeFilter = "1";//HP
            else if (indx == 2) ACTypeFilter = "2";//PL
            else ACTypeFilter = "5";//ALL
        }
        private void cboSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortBy = "";
            int sortId = cboSortBy.SelectedIndex;
            if (sortId == 0) SortBy = "CLD"; // AccountNo
            else if (sortId == 1) SortBy = "AC";//PL
            else if (sortId == 2) SortBy = "CBAL";//PL
        }
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.controller.CheckDate(dtpStartDate.Value, dtpEndDate.Value))
            {
                if (!this.ValidationControls())
                    return;
                LOMDTO00244 dto = new LOMDTO00244();
                dto.StartDate = dtpStartDate.Value;
                dto.EndDate = dtpEndDate.Value;
                dto.SourceBr = SourceBr;
                dto.Currency = Currency;
                //dto.ACTypeFilter = Convert.ToString(Convert.ToInt16(ACTypeFilter) + 1);
                dto.ACTypeFilter = ACTypeFilter;
                dto.SortBy = SortBy;
                dto.StartDate = StartDate;
                dto.EndDate = EndDate;
                dto.NAME = cboBranch.Text + "(" + BranchList[cboBranch.SelectedIndex].BranchAlias + ")";

                lst.Add(dto);
                dto.rptName = "AccountCLosedList";
                this.controller.ExportToExcel(dto);
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            dtpStartDate.Text = DateTime.Now.ToString();
            dtpEndDate.Text = DateTime.Now.ToString();
        }
    }
}


