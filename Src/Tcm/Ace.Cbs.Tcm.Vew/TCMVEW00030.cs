using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00030 : BaseForm, ITCMVEW00030
    {
        #region Constructor
        public TCMVEW00030()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime PostDate
        {
            get
            {
                return Convert.ToDateTime(dtpPostDate.Value);
            }
            set { this.dtpPostDate.Text = value.ToString(); }
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
        #endregion

        #region BindCurrency
        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });

            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }
        #endregion

        #region Controller
        private ITCMCTL00052 controller;
        public ITCMCTL00052 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Event
        private void TCMVEW00030_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.dtpPostDate.Value = DateTime.Now;
            this.BindCurrency();
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            CXUIScreenTransit.Transit("frmTCMVEW00065", true, new object[] { this.PostDate, this.Currency });
        }

        private void butPreview_Click(object sender, EventArgs e)
        {
            this.controller.Preview();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.BindCurrency();
        }

        private void cboCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
