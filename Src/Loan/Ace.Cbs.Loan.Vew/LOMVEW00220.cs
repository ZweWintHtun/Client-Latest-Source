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
    public partial class LOMVEW00220: BaseForm, ILOMVEW00220
    {
        public bool status = true;
        public int searchBy = 0;

        public LOMVEW00220()
        {
            InitializeComponent();
        }

        private ILOMCTL00220 controller;
        public ILOMCTL00220 Controller
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

            //Comment & Added by HMW at 29-07-2019 : [Seperating EOD Process] to show system date (not PC Date) at report
            //this.StartDate = DateTime.Now;
            //this.EndDate = DateTime.Now;

            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.StartDate = systemDate;
            this.EndDate = systemDate;

            this.dtpStartDate.Enabled = false;
            this.dtpEndDate.Enabled = false;
            this.OptALL.Enabled = true;
            this.OptByDate.Enabled = true;
            this.searchBy = 0;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "HPLateFeesOutstandingList";

            this.controller.Print(rptName,Currency,SourceBr,StartDate,EndDate,searchBy);
        }

        private void LOMVEW00220_Load(object sender, EventArgs e)
        {
            this.BindSourceBranch();
            this.BindCurrency();
            InitializeControls();
            this.Size = new System.Drawing.Size(499, 203);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void OptALL_Click(object sender, EventArgs e)
        {
            //this.searchBy = 0;
            //this.dtpStartDate.Enabled = false;
            //this.dtpEndDate.Enabled = false;
            //this.dtpStartDate.Text = DateTime.Now.ToString();
            //this.dtpEndDate.Text = DateTime.Now.ToString();
            ChangeView();
        }

        private void OptByDate_Click(object sender, EventArgs e)
        {
            //this.searchBy = 1;
            //this.dtpStartDate.Enabled = true;
            //this.dtpEndDate.Enabled = true;  
            ChangeView();
        }
        private void ChangeView()
        {
            if (OptALL.Checked == true)
            {
                this.searchBy = 0;
                this.dtpStartDate.Visible = false;
                this.dtpEndDate.Visible = false;
                //this.dtpStartDate.Text = DateTime.Now.ToString();
                //this.dtpEndDate.Text = DateTime.Now.ToString();
                this.Size = new System.Drawing.Size(499, 199);
            }
            else
            {
                this.searchBy = 1;
                this.dtpStartDate.Enabled = true;
                this.dtpEndDate.Enabled = true;
                this.dtpStartDate.Visible = true;
                this.dtpEndDate.Visible = true;
                this.Size = new System.Drawing.Size(499, 263);
            }
        }
    }
}
