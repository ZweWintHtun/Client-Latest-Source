using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;




namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00044 : BaseForm, IMNMVEW00044
    {
        public MNMVEW00044()
        {
            InitializeComponent();
        }

        #region properties

        #region controller

        private IMNMCTL00044 currentCompanyController;
        public IMNMCTL00044 Controller
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

        IList<MNMDTO00010> List { get; set; }
       
        public int IsByHomeCurrency { get; set; }


        public string BranchCode
        {
            get
            {
                if (this.cboBranch.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboBranch.Text.ToString();
                }
            }
            set
            {
                this.cboBranch.Text = value;
                this.cboBranch.SelectedValue = value;
            }
        }

        public bool IsAllBranch
        {
            get { return chkBranch.Checked; }
            set { chkBranch.Checked = value; }
        }

        public string currencyNo
        {
            get
            {
                if (this.cboCurrency.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboCurrency.Text;
            }
            set
            {
                this.cboCurrency.Text = value;
            }
        }

        public string Year
        {
            get { return this.txtYear.Text; }
            set { this.txtYear.Text = value; }
        }

        public string Month
        {
            get { return txtMonth.Text; }
            set { txtMonth.Text = value; }
        }

        #endregion

        #region Events

        private void MNMVEW00044_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        #region other Events

        private void FormName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void chkBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBranch.Checked) this.cboBranch.Enabled = false;
            else this.cboBranch.Enabled = true;
        }

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                int I;
                if (!string.IsNullOrEmpty(this.Month) && !int.TryParse(this.Month, out I))
                {
                    // Date time correct Format
                    string date_str = "20," + this.Month + ",2013";
                    System.Globalization.CultureInfo theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                    this.Month = DateTime.ParseExact(date_str, "dd,MMMM,yyyy", theCultureInfo).ToString("MM");
                }
                return;
            }
            catch (Exception exp)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00221");
                txtMonth.Focus();
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

        #endregion

        #region rsb Events

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
           
            if (this.Controller.Validate_Form())
            {
                
                //if (this.Month.Length > 2)
                //    Month = this.Controller.CheckMonth();

                this.IsByHomeCurrency = 0;
               

                // Check Currency Code
                if (!rdoHomeCurrency.Checked && cboCurrency.SelectedIndex == -1)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00020");
                    this.cboCurrency.Focus();
                    return;
                }

                else if (this.rdoHomeCurrency.Checked || this.chkByHomeCurrency.Checked)
                {
                    this.IsByHomeCurrency = 1;
                }

                //string sourceBr = CurrentUserEntity.BranchCode;
                string branchNo = CurrentUserEntity.IsHOUser ? this.IsAllBranch ? string.Empty : this.BranchCode : CurrentUserEntity.BranchCode;
                List = this.Controller.SelectTrialBalanceGroup(branchNo, this.currencyNo, Convert.ToInt16(this.Controller.date_month), this.IsByHomeCurrency);

                if(List.Count > 0 || List == null)
                    CXUIScreenTransit.Transit("frmMNMVEW00092TriBalanceGroupReport", true, new object[] { this.List, branchNo, this.currencyNo, "Trial Balance Group Report", this.Controller.month });
                else
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");

            }
        }

        private void tsbCRUD_CancelButtonClick_1(object sender, EventArgs e)
        {
            if (CurrentUserEntity.IsHOUser)
            {
                this.BranchCode = CurrentUserEntity.BranchCode;
                this.chkBranch.Checked = false;
            }
            this.cboCurrency.SelectedIndex = 0;
            this.Year = DateTime.Now.ToString("yyyy");
            this.Month = DateTime.Now.ToString("MM");
            chkByHomeCurrency.Checked = false;
            rdoHomeCurrency.Checked = false;
            this.Controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

       

        #endregion

        #endregion

        #region helper Method

        public void InitializeControls()
        {
            //Enable Disable Menu Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCurrency();
            if (CurrentUserEntity.IsHOUser)
            {
                this.grpBranch.Visible = true;
                this.cboBranchNoDataBind();
                this.BranchCode = CurrentUserEntity.BranchCode;
            }

            this.Year = DateTime.Now.ToString("yyyy");
            this.Month = DateTime.Now.ToString("MM");
        }

        private void setNormalControl()
        {
            txtMonth.Text = DateTime.Now.ToString("MMMMM");
            txtYear.Text = DateTime.Now.ToString("yyyy");
        }

    

        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void cboBranchNoDataBind()
        {
            IList<BranchDTO> branches = CXCLE00001.Instance.SelectAllBranch();
            cboBranch.ValueMember = "BranchCode";
            cboBranch.DisplayMember = "BranchCode";
            cboBranch.DataSource = branches;
            cboBranch.SelectedIndex = 0;

            if (branches.Count == 1)// Added by HMW at 28-08-2019 
                chkBranch.Enabled = false;
        }  

        #endregion      
    }
}
