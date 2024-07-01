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
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00205 : BaseForm, ILOMVEW00205
    {
        public bool status;
        public LOMVEW00205()
        {
            InitializeComponent();
        }
        private ILOMCTL00205 controller;
        public ILOMCTL00205 Controller
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

        public string CompanyName { get; set; }
        //{
        //    get
        //    {
        //        if (this.cboCompany.SelectedValue == null)
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return this.cboCompany.SelectedValue.ToString();
        //        }
        //    }
        //    set { this.cboCompany.SelectedValue = value; }
        //}

        public void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            OptByDate.Checked = true;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            cboBranch.Enabled = true;
            cboCompany.Enabled = false;
            BindCurrency();
            BindSourceBranch();
            BindCompanyName();
            this.SourceBr = CurrentUserEntity.BranchCode;
            if (!CurrentUserEntity.IsHOUser)
            {
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.cboBranch.Enabled = true;
            }
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
        }

        private void LOMVEW00205_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
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

        private void BindCompanyName()
        {
            IList<string> companyNameList = this.controller.GetAllPersonalLoansCompanyName(CurrentUserEntity.BranchCode);
            cboCompany.ValueMember = "CompanyName";
            cboCompany.DisplayMember = "CompanyName";
            cboCompany.DataSource = companyNameList;
            cboCompany.SelectedIndex = -1;
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
            if (OptByCompanyName.Checked)
            {
               if (cboCompany.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cboCompany, "CompanyName");
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

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "PersonalLoanInfoList";
            this.controller.Print(rptName, StartDate, EndDate, CompanyName);

            //if (OptByDate.Checked) this.controller.Print(rptName, StartDate, EndDate, CompanyName);
            //else this.controller.PrintByCompany(rptName, CompanyName);
            
        }

        //private void OptByCompanyName_CheckedChanged(object sender, EventArgs e)
        //{
        //    dtpStartDate.Enabled = false;
        //    dtpEndDate.Enabled = false;
        //    cboCompany.Enabled = true;
        //}

        //private void OptByDate_CheckedChanged(object sender, EventArgs e)
        //{
        //    dtpStartDate.Enabled = true;
        //    dtpEndDate.Enabled = true;
        //    cboCompany.Enabled = false;
        //}

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();            
        }

        private void OptByCompanyName_Click(object sender, EventArgs e)
        {
           OptByDate.Checked = false;
           cboCompany.Enabled = true;
           cboCompany.SelectedIndex = -1;
        }

        private void OptByDate_Click(object sender, EventArgs e)
        {
            cboCompany.Enabled = false;
            cboCompany.SelectedIndex = -1;
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == false)
                this.CompanyName = (cboCompany.SelectedValue == null) ? "" : cboCompany.SelectedValue.ToString();
        }

    }
}
