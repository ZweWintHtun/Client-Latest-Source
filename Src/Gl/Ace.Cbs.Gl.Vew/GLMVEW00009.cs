using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00009 : BaseDockingForm, IGLMVEW00009
    {
        #region Constructor
        public GLMVEW00009()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public bool IsCheckHomeCurrency
        {
            get
            {                
                return this.chkisHomeCurrency.Checked;               
            }
            set
            {
                this.chkisHomeCurrency.Checked = true;
            }
        }
        public bool IsTransactionDate
        {
            get
            {
                return this.rdoTransactionDate.Checked;
            }
            set
            {
                this.rdoTransactionDate.Checked = true;
            }
        }


        public DateTime StartDate
        {
            get
            {
                return this.dtpStartDate.Value;
            }
            set
            {
                this.dtpStartDate.Text = value.ToString();
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.dtpEndDate.Value;
            }
            set
            {
                this.dtpEndDate.Text = value.ToString();
            }
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
            set
            {
                this.cboCurrency.SelectedValue = value;
            }
        }
        #endregion

        #region Controller
        private IGLMCTL00009 controller;
        public IGLMCTL00009 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Initialize
        private void InitializeControl()
        {
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            this.BindCurrency();
            this.chkisHomeCurrency.Checked = false;
            this.rdoTransactionDate.Checked = true;
            this.controller.ClearErrors();
        }
        #endregion

        #region Bind ComboBox
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }
        #endregion

        #region Event
        private void GLMVEW00009_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitializeControl();            
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Preview();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkisHomeCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (chkisHomeCurrency.Checked)
                this.cboCurrency.Enabled = false;
            else
                this.cboCurrency.Enabled = true;
        }

        #endregion
    }
}
