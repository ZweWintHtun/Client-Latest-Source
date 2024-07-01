using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00027 : BaseForm,ITCMVEW00027
    {
        #region Constructors

        public TCMVEW00027()
        {
            InitializeComponent();
        }
        #endregion

        #region Data Properties
        
        public bool isSchdule
        {
            get
            {
                return this.rdoSchedule.Checked;
            }
            set { this.rdoSchedule.Checked = value; }
        }

        public bool isAbstract
        {
            get { return this.rdoAbstract.Checked; }
            set { this.rdoAbstract.Checked = value; }
        }

        public bool isScroll
        {
            get { return this.rdoScroll.Checked; }
            set { this.rdoScroll.Checked = value; }
        }

        public bool isTransactionDate
        {
            get { return this.rdoTransactionDate.Checked; }
            set { this.rdoTransactionDate.Checked = value; }
        }

        public bool isSettlementDate
        {
            get { return this.rdoSettlementDate.Checked; }
            set { this.rdoSettlementDate.Checked = value; }
        }

        public DateTime SelectedDateTime
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }

        public bool isReserval
        {
            get { return this.chkWithReserval.Checked; }
            set { this.chkWithReserval.Checked = value; }
        }
        public string Currency
        {
            get { return this.cboCurrency.Text; }
            set { this.cboCurrency.Text = value.ToString(); }
        }

        private ITCMCTL00027 _controller;
        public ITCMCTL00027 Controller
        {
            get { return this._controller; }
            set 
            {
                this._controller = value;
                this._controller.View = this;
            }
        }
        #endregion

        #region Methods

        private void BindCurrencyComboBoxes()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        #endregion
        #region Events

        private void TCMVEW00027_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpRequiredDate.Value = DateTime.Now;
            lblCurrency.Visible = true;
            cboCurrency.Visible = true;
            this.BindCurrencyComboBoxes();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoScroll.Checked)
            {
                lblCurrency.Visible = true;
                cboCurrency.Visible = true;
                chkWithReserval.Visible = true;
                this.BindCurrencyComboBoxes();
            }
            else
            {
                lblCurrency.Visible = true;
                cboCurrency.Visible = true;
                this.BindCurrencyComboBoxes();
                chkWithReserval.Visible = false;
            }
        }

        #endregion

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.Print();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.rdoSchedule.Checked = true;
            this.rdoTransactionDate.Checked = true;
            this.dtpRequiredDate.Value = DateTime.Now;
            this.cboCurrency.SelectedIndex = 0;
            this.Controller.ClearingCustomerErrorMessage();
        }
    }
}
