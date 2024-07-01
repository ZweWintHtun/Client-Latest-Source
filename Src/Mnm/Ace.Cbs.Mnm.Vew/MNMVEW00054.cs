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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00054 : BaseForm, IMNMVEW00054
    {
        #region Constructor

        public MNMVEW00054()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region controller
        private IMNMCTL00054 currentCompanyController;
        public IMNMCTL00054 Controller
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

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }
      
        public string AccountCode
        {
            get
            {
                return this.cboAccountCode.Text.ToString();               
            }
            set
            {
                this.cboAccountCode.Text = value;
                this.cboAccountCode.SelectedValue = value;
            }
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

        public bool IsHomeCurrency {get;set;}

        public bool IsSourceCurrency { get; set; }

        public bool IsTransactionDate { get; set; }
        
        public bool IsSettlementDate {get; set;}
        
        public string AccountDescription
        {
            get { return txtAccountDescription.Text.ToString(); }
            set { this.txtAccountDescription.Text = value; }
        }

        public string Currency
        {
            get
            {
                if (rdoHomeCurrency.Checked == false)
                {
                    if (this.cboCurrency.Text == string.Empty)
                        return string.Empty;
                    else
                        return this.cboCurrency.Text;
                }
                else
                    return this.cboCurrency.Text = "KYT";
            }
            set
            {              
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
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


        public IList<ChargeOfAccountDTO> AccountTypeList
        {
            get;
            set;
        }

        public IList<CurrencyDTO> CurrencyList
        {
            get;
            set;
        }

        #endregion

        #region Events

        private void MNMVEW00054_Load(object sender, EventArgs e)
        {
            InitializeControls();
            this.cboCurrency.Enabled = false;                
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
        }

        private void rdoSourceCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSourceCurrency.Checked == true)
            {
                this.cboCurrency.Enabled = true;
                this.BindCurrency();
            }            
        }

        private void rdoHomeCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoHomeCurrency.Checked == true)
            {
                this.cboCurrency.Text = "KYT";
                this.cboCurrency.Enabled = false;
            }
        }

        #region rsb Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                this.Controller.Print();
            }  
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtAccountDescription.Text = string.Empty;
            this.cboAccountCode.SelectedIndex = -1;
            this.cboCurrency.SelectedIndex = 0;
            this.cboCurrency.Focus();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.Controller.ClearCustomErrorMessages();
        }

        #endregion

        #endregion

        #region helper Methods

        public void InitializeControls()
        {
            //Enable Disable Menu Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindAccountFormType();
            this.IsHomeCurrency = true;
            this.IsSourceCurrency = false;
            this.IsTransactionDate = true;
            this.IsSettlementDate = false;
        }

        private void BindAccountFormType()
        {
            AccountTypeList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COADAO.SelectByBranchDetail",new object[]{ CurrentUserEntity.BranchCode,true});
            this.cboAccountCode.DisplayMember = "ACode";
            this.cboAccountCode.ValueMember = "ACode";
            this.cboAccountCode.DataSource = AccountTypeList;
            this.cboAccountCode.SelectedIndex = -1;
            //ChargeOfAccountDTO dto = new ChargeOfAccountDTO();
        }

        private void BindCurrency()
        {
            CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private bool CheckDate()
        {    // Check dtpStartDate Date Time
            if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpStartDate.Focus();
                return false;
            }
            // Check dtpEndDate Date Time
            else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpEndDate.Focus();
                return false;
            }
            else if (dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                this.dtpEndDate.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}
