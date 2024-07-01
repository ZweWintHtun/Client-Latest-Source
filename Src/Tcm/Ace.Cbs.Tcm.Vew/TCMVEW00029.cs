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
    public partial class TCMVEW00029 : BaseForm, ITCMVEW00029
    {
        #region Data Properties
        public bool IsTransactionDate
        {
            get { return this.rdoTransactionDate.Checked; }
            set { this.rdoTransactionDate.Checked = value; }
        }

        public DateTime SelectedDateTime
        {
            get { return this.dtpRequiredDate.Value; }
            set { this.dtpRequiredDate.Text = value.ToString(); }
        }

        public string Currency
        {
            get { return this.cboCurrency.Text; }
            set { this.cboCurrency.Text = value.ToString(); }
        }

        public bool isReversal
        {
            get { return this.chkWithReserval.Checked; }
            set { this.chkWithReserval.Checked = value; }
        }

        public bool SortByTime
        {
            get { return this.rdoTime.Checked; }
            set { this.rdoTime.Checked = value; }
        }

        private ITCMCTL00029 _controller;
        public ITCMCTL00029 Controller
        {
            get { return this._controller; }
            set
            {
                this._controller = value;
                this._controller.View = this;
            }
        }
        #endregion

        #region Constructor
        public TCMVEW00029()
        {
            InitializeComponent();
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

        private void TCMVEW00029_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpRequiredDate.Value = DateTime.Now;
            BindCurrencyComboBoxes();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.Print();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpRequiredDate.Value = DateTime.Now;
            this.cboCurrency.SelectedIndex = 0;
            this.Controller.ClearErrors();
        }

        #endregion
    }
}
