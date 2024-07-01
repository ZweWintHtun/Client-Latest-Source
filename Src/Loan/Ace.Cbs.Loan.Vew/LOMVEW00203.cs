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
    public partial class LOMVEW00203 : BaseForm, ILOMVEW00203
    {
        public string sourceBr;
        public LOMVEW00203()
        {
            InitializeComponent();
        }

        //#region

        //public LOMVEW00203(bool isMainMenu, string parentFormId)
        //{
        //    InitializeComponent();

        //    this.IsMainMenu = isMainMenu;
        //    this.ParentFormId = parentFormId;
        //}
        //#endregion

        //private bool isMainMenu = true;
        //public bool IsMainMenu
        //{
        //    get { return this.isMainMenu; }
        //    set { this.isMainMenu = value; }
        //}
        //private string parentFormId = string.Empty;
        //public string ParentFormId
        //{
        //    get { return this.parentFormId; }
        //    set { this.parentFormId = value; }
        //}

        public string Month
        {
            get { return this.cboMonth.SelectedValue.ToString(); }
            set { this.cboMonth.Text = value; }
        }

        public string SourceBr
        {
            get
            {
                if (this.cboBranch.SelectedValue == null)
                {
                    if (!CurrentUserEntity.IsHOUser)
                    {
                        sourceBr = CurrentUserEntity.BranchCode;
                        return sourceBr;
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


        private ILOMCTL00203 controller;
        public ILOMCTL00203 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
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

        private void InitailizeControl()
        {
            this.BindCurrency();
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

            if (cboMonth.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboMonth, "Month");
            }

            if (cboCurrency.SelectedIndex == -1 || cboBranch.SelectedIndex == -1 || cboMonth.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void LOMVEW00203_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (!CurrentUserEntity.IsHOUser)
            {
                sourceBr = CurrentUserEntity.BranchCode;
                this.cboBranch.Text = sourceBr;
                this.cboBranch.Enabled = false;
            }
            else
            {
                this.BindSourceBranch();
            }
            this.InitailizeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            string rptName = "HPInsufficientList";
            string strmonth = cboMonth.Text;
            string month = Convert.ToString(cboMonth.SelectedIndex + 1);
            if (int.Parse(month) < 10)
            {
                month = "0" + month + strmonth;
            }
            else month = month + strmonth;
            this.controller.Print(rptName, month);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitailizeControl();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

    }
}
