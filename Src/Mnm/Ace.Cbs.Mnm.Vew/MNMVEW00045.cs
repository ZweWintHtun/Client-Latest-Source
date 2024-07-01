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
    public partial class MNMVEW00045 : BaseForm, IMNMVEW00045
    {
        public MNMVEW00045()
        {
            InitializeComponent();
        }

        #region properties

        #region controller
        private IMNMCTL00045 currentCompanyController;
        public IMNMCTL00045 Controller
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

      
        public string Currency
        {
            get { return cboCurrency.SelectedValue == null ? string.Empty : cboCurrency.SelectedValue.ToString(); }
            set { cboCurrency.SelectedValue = value; }
        }

        public bool IsHomeCurrency
        {
            get { return rdoHomeCurrency.Checked; }
        }

       

        public string DateType
        {
            get { return rdoTransactionDate.Checked ? "T" : "S"; }
        }

        public bool WithReversal
        {
            get { return chkWithReversal.Checked; }
        }

        public DateTime RequiredDate
        {
            get { return Convert.ToDateTime(dtpDate.Text); }
        }

        public bool IsCBMACode
        {
            get { return rdoByCBMAccountCode.Checked; }
        }

        #endregion

        #region Events

        private void MNMVEW00045_Load(object sender, EventArgs e)
        {
            InitializeControls();
            this.dtpDate.Text = DateTime.Now.ToShortDateString();
        }

        
        #region other Events
   

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
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {

            this.cboCurrency.SelectedIndex = 0;
            this.dtpDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.Controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            // Check Date Time
            if (dtpDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpDate.Focus();
                return;
            }
            this.Controller.print();
            //CXUIScreenTransit.Transit("frmMNMVEW00093TrialSheetReport", true, new object[] { this.BranchCode, this.Currency, this.chkWithReversal.Checked, "Trial Sheet" });
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
