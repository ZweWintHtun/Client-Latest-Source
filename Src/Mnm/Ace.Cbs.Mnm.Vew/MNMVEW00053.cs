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
    public partial class MNMVEW00053 : BaseForm, IMNMVEW00053
    {
        #region Constructor

        public MNMVEW00053()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region controller

        private IMNMCTL00053 currentCompanyController;
        public IMNMCTL00053 Controller
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

        string formName;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        bool aCTypeAll;
        public bool ACTypeAll { get { return this.rdoAll.Checked; } }

        bool aCTypeCurrent;
        public bool ACTypeCurrent { get { return this.rdoCurrentAccount.Checked; } }

        bool aCTypeSaving;
        public bool ACTypeSaving { get { return this.rdoSavingAccount.Checked; } }

        bool aCTypeFixed;
        public bool ACTypeFixed { get { return this.rdoFixedDepoAccount.Checked; } }

        bool aCTypeOD;
        public bool ACTypeOD { get { return this.rdoOverDrawn.Checked; } }

        bool sortAccountNo;
        public bool SortAccountNo { get { return this.rdoAccountNo.Checked; } }

        bool sortAmount;
        public bool SortAmount { get { return this.rdoAmount.Checked; } }

        bool isAllCurrency;
        public bool IsAllCurrency { get { return this.chkIsAllCurrency.Checked; } }

        string currency;
        public string Currency
        {
            get { return this.cboCurrency.SelectedValue == null ? string.Empty : this.cboCurrency.SelectedValue.ToString(); }
            set { this.cboCurrency.SelectedValue = value; }
        }

        #region unUsedCode
        //public DateTime StartDate
        //{
        //    get { return this.dtpStartDate.Value; }
        //    set { this.dtpStartDate.Text = value.ToString(); }
        //}

        //public DateTime EndDate
        //{
        //    get { return this.dtpEndDate.Value; }
        //    set { this.dtpEndDate.Text = value.ToString(); }
        //}
        #endregion

        #endregion

        #region Events

        private void MNMVEW00053_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = this.FormName;

            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;

            this.rdoAll.Checked = true;
            this.rdoAccountNo.Checked = true;
            this.chkIsAllCurrency.Checked = false;
        }

        #region rsb Events

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick_1(object sender, EventArgs e)
        {
            try
            {
                #region unUsedCode
                //// Check dtpStartDate Date Time
                //if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                //    this.dtpStartDate.Focus();
                //    return;
                //}

                //// Check dtpEndDate Date Time
                //else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                //    this.dtpEndDate.Focus();
                //    return;
                //}

                //else if (dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                //    this.dtpEndDate.Focus();
                //    return;
                //}
                #endregion

                //CXUIScreenTransit.Transit("frmMNMVEW00102", true, new object[] { this.StartDate.ToString("dd MMM,yyyy"),this.EndDate.ToString("dd MMM,yyyy") });
                this.Controller.Print();
            }

            catch (Exception ex)
            {
                throw new Exception(CXMessage.ME90043, ex);   //Unexpected Error Occurs
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoAll.Checked = true;
            this.rdoAccountNo.Checked = true;
            this.chkIsAllCurrency.Checked = false;
            this.cboCurrency.SelectedIndex = 0;
        }

        #endregion


        private void chkIsAllCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAllCurrency.Checked)
            {
                cboCurrency.SelectedIndex = 0;
                this.DisableControls("TransferScroll.cboCurrency.DisableControls");
            }
            else
                this.EnableControls("TransferScroll.cboCurrency.EnableControls");
        }
        #region Old Code
        //private void rdoSourceCurrency_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoSourceCurrency.Checked)
        //    {

        //        this.EnableControls("TransferScroll.cboCurrency.EnableControls");
        //    }
        //    else
        //    {
        //        cboCurrency.SelectedIndex = 0;
        //        this.DisableControls("TransferScroll.cboCurrency.DisableControls");
        //    }
        //}

        //private void rdoHomeCurrency_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoHomeCurrency.Checked)
        //    {
        //        cboCurrency.SelectedIndex = 0;
        //        this.DisableControls("TransferScroll.cboCurrency.DisableControls");
        //    }
        //    else
        //        this.EnableControls("TransferScroll.cboCurrency.EnableControls");
        //}
        #endregion
        #endregion

    }
}
