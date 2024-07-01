using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00066 : BaseForm, ITCMVEW00066
    {
        #region Constructor
        public TCMVEW00066()
        {
            InitializeComponent();
        }
        #endregion
        
        #region Controller
        private ITCMCTL00066 controller;
        public ITCMCTL00066 Controller
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

        #region Properties
        public string transactionType { get; set; }
        public string currencyType { get; set; }
        public string typeofSort { get; set; }
       
        public DateTime StartDate
        {
            get
            {
                return Convert.ToDateTime(dtpStartDate.Text);
            }
            set
            {
                this.dtpStartDate.Value = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return Convert.ToDateTime(this.dtpEndDate.Text);
            }
            set
            {
                this.dtpEndDate.Value = value;
            }
        }
      
        public string currency
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

        #region Method
        public void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        public void InitializeControl()
        {
            this.BindCurrency();
            this.cboCurrency.Enabled = false;
            this.rdoAll.Checked = true;
            this.rdoHomeCurrency.Checked = true;
            this.rdoAccountNo.Checked = true;
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
        }
        #endregion

        #region Events
        private void TCMVEW00066_Load(object sender, EventArgs e)
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
            if (this.rdoSourceCurrency.Checked)
            {
                if (cboCurrency.SelectedIndex == -1 || this.currency == null)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00020);  //Invalid Currency Code
                    this.cboCurrency.Focus();
                }
                else
                {
                    if (this.controller.CheckDate())
                    {
                        this.controller.Preview();
                    }
                }
            }
            else
            {
                if (this.controller.CheckDate())
                {
                    this.controller.Preview();
                }
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                transactionType = "All";
            }
            else if (rdoBusinessLoans.Checked == true)
            {
                transactionType = "BL";
            }
            else if (rdoHirePurchase.Checked == true)
            {
                transactionType = "HP";
            }
            else if (rdoPersonalLoans.Checked == true)
            {
                transactionType = "PL";
            }
            else if (rdoDealerAccount.Checked == true)
            {
                transactionType = "DL";
            }
            //else if (rdoCurrentAccount.Checked == true)
            //{
            //    transactionType = "Current";
            //}
            //else if (rdoSavingAccount.Checked == true)
            //{
            //    transactionType = "Saving";
            //}
            //else if (rdoFixedDepoAccount.Checked == true)
            //{
            //    transactionType = "Fix";
            //}
            else if (rdoOverDrawn.Checked == true)
            {
                transactionType = "OverDrawn";
            }
        }

        private void rdoCurrencyType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoHomeCurrency.Checked == true)
            {
                currencyType = "Home Currency";
                this.cboCurrency.Enabled = false;
            }
            else if (this.rdoSourceCurrency.Checked == true)
            {
                currencyType = "Source Currency";
                this.cboCurrency.Enabled = true;
            }
        }

        private void rdoSortingType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoAccountNo.Checked == true)
            {
                typeofSort = "ACCTNO";
            }
            else if (this.rdoAmount.Checked == true)
            {
                typeofSort = "CBAL";
            }
        }
        #endregion        
    }
}
