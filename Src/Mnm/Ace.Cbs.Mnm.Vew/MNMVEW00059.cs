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
    public partial class MNMVEW00059 : BaseForm,IMNMVEW00059
    {
        public MNMVEW00059()
        {
            InitializeComponent();
        }

        #region controller

        private IMNMCTL00059 controller;
        public IMNMCTL00059 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

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

        public string AccountNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        private void MNMVEW00059_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCurrency();
            this.cboCurrency.Focus();
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print(this.AccountNo,this.currencyNo);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
            this.mtxtAccountNo.Text = string.Empty;
            this.cboCurrency.Focus();
            this.cboCurrency.SelectedIndex = 0;
        
        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }

    }
}
