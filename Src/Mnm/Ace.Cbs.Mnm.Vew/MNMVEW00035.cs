using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00035 : BaseForm, IMNMVEW00035
    {
        public MNMVEW00035()
        {
            InitializeComponent();
        }
        #region properties
        #region controller
        private IMNMCTL00035 currentCompanyController;
        public IMNMCTL00035 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }
        #endregion

        public string DateType
        {
            get
            {
                if (this.rdoSettlementDate.Checked == true)
                {
                    return "Settlement Date";
                }

                else
                {
                    return "Transaction Date";

                }
            }

            set
            {
                if (value == "Settlement Date")
                {
                    this.rdoSettlementDate.Checked = true;
                }
                else
                {
                    this.rdoTransactionDate.Checked = true;
                }
            }
        }

        public DateTime RequiredDate
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }

        public bool IsAllBranches
        {
            get { return chkBranch.Checked; }
            set { this.chkBranch.Checked = true; }
        }

        public bool IsWithReversal
        {
            get { return chkWithReversal.Checked; }
            set { this.chkWithReversal.Checked = true; }
        }

        public bool IsHomeCurrency
        {
            get { return rdoHomeCurrency.Checked; }
            set { this.rdoHomeCurrency.Checked = true; }
        }

        //public string Branch
        //{
        //    set { this.cboBranchNo.SelectedValue = value; }
        //    get { return this.cboBranchNo.SelectedValue == null ? string.Empty : this.cboBranchNo.SelectedValue.ToString(); }
        //}
        //public string BranchNo
        //{            
        //    get
        //    {
        //        return this.lblBranchNo.Text.ToString();
        //    }
        //    set
        //    {
        //        this.lblBranchNo.Text = value;
        //    }
        //}
        public string BranchCode
        {
            get
            {
                return this.lblBranchNo.Text.ToString();
            }
            set
            {
                this.lblBranchNo.Text = value;
            }
        }
        public string BranchNo
        {
            get
            {
                if (this.cboBranchNo.Text == null)
                {
                    return this.lblBranchNo.Text.ToString();
                }
                else
                {
                    return this.cboBranchNo.Text;
                }
            }
            set
            {
                this.cboBranchNo.Text = value;
            }
        }

        public string Currency
        {
            get { return this.cboCurrency.Text; }
            set
            {
                this.cboCurrency.SelectedValue = value;
            }
        }

        public string CurrencyType
        {
            get
            {
                if (this.rdoHomeCurrency.Checked == false)
                {
                    return "Source Currency";
                }

                else
                {
                    return "Home Currency";
                }
            }

            set
            {
                if (value == "Source Currency")
                {
                    this.rdoHomeCurrency.Checked = false;
                }
                else
                {
                    this.rdoHomeCurrency.Checked = true;
                }
            }

        }
        #endregion

        #region Events
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpDate.Text = DateTime.Now.ToString();
            //this.cboBranchNo.SelectedIndex = -1;
            this.cboCurrency.SelectedIndex = 0;
            this.rdoHomeCurrency.Checked = true;
            this.chkWithReversal.Checked = false;
            this.Controller.ClearCustomErrorMessage();
            this.rdoTransactionDate.Checked = true;
            InitializeControls();
        }

        private void MNMVEW00035_Load(object sender, EventArgs e)
        {
            InitializeControls();
            this.dtpDate.Text = DateTime.Now.ToShortDateString();
            this.rdoHomeCurrency.Checked = true;
        }
        //private void chkAllBranches_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (this.chkAllBranches.Checked)
        //    //{
        //    //    cboBranchNo.SelectedIndex = -1;
        //    //    this.DisableControls("TransferScroll.cboBranchNo.DisableControls");
        //    //}
        //    else
        //        this.EnableControls("TransferScroll.cboBranchNo.EnableControls");

        //}

        private void rdoSourceCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSourceCurrency.Checked)
            {

                this.EnableControls("TransferScroll.cboCurrency.EnableControls");
            }
            else
            {
                cboCurrency.SelectedIndex = 0;
                this.DisableControls("TransferScroll.cboCurrency.DisableControls");
            }
        }

        private void rdoHomeCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHomeCurrency.Checked)
            {
                cboCurrency.SelectedIndex = 0;
                this.DisableControls("TransferScroll.cboCurrency.DisableControls");
            }
            else
                this.EnableControls("TransferScroll.cboCurrency.EnableControls");
        }
        
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.Validate_Form())
            {
                // Check Branch No
                if (chkBranch.Checked)
                {
                    if (cboBranchNo.SelectedIndex == -1)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00070");
                        this.cboBranchNo.Focus();
                        return;
                    }
                }
                // Check Currency COde
                else if (!rdoHomeCurrency.Checked && cboCurrency.SelectedIndex == -1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00020");
                    this.cboCurrency.Focus();
                    return;
                }
                // Check Currency COde
                else if (dtpDate.Value.Date > DateTime.Now.Date)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                    this.dtpDate.Focus();
                    return;
                }

                Controller.Print();

            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked)
            {
                this.cboBranchNo.Enabled = false;
                this.cboBranchNo.SelectedValue = "";
            }
            else this.cboBranchNo.Enabled = true;
        }
        #endregion


        #region Helper Method
        public void InitializeControls()
        {
            //Enable Disable Menu Controls

            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            if (CurrentUserEntity.IsHOUser)
            {
                this.cboBranchNo.Visible = true;
                this.chkBranch.Visible = true;
                this.BindBranchCode();//Edited by HOW
                this.BranchCode = CurrentUserEntity.BranchCode;
                this.lblBranchNo.Visible = false;
            }
            else
            {
                this.lblBranchNo.Visible = true;
                //this.lblBranchNo.Text = this.Controller.GetViewData().SourceBranch + " (" + this.Controller.GetViewData().BranchName + ")";
                this.lblBranchNo.Text = CurrentUserEntity.BranchCode ;/**/
                this.cboBranchNo.Visible = false;
            }
            this.BindCurrency();
            //this.BindBranchCode();
        }
        private void BindBranchCode()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranchNo.ValueMember = "BranchCode";
            cboBranchNo.DisplayMember = "BranchCode";
            cboBranchNo.DataSource = branches;
            cboBranchNo.SelectedIndex = 0;

        }
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }
        #endregion

    }
}
