using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.CBM.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;


namespace Ace.Cbs.CBM.Vew
{
    public partial class frmCBMVEW00001 : BaseForm, ICBMVEW00001
    {
        public frmCBMVEW00001()
        {
            InitializeComponent();
        }

        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set
            {
                if (value == null)
                {
                    this.dtpDate.CustomFormat = " ";
                }
                else
                {
                    this.dtpDate.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
                    this.dtpDate.Value = value;
                }
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
            set { this.cboCurrency.SelectedValue = value; }
        }

        #region "Controller"

        private ICBMCTL00001 controller;
        public ICBMCTL00001 Controller
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

        private void tsc_CancelButtonClick(object sender, EventArgs e)
        {
            this.Date = System.DateTime.Now;
        }

        private void CBMVEW00001_Load(object sender, EventArgs e)
        {
            //New , Edit, Save, Delete, Cancel, Print,Exit
            tsc.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Date = System.DateTime.Now;
            if (this.FormName.Contains("InHand"))
                this.Text = "Cash In Hand Position";
            else if(this.FormName.Contains("Flow"))
                this.Text = "Cash Flow";
            else if (this.FormName.Contains("Position"))
                this.Text = "Daily Position";
            else if (this.FormName.Contains("DailyImprovement"))
                this.Text = "Daily Improvement";
            else if (this.FormName.Contains("DailyProgress"))
                this.Text = "Daily Progress Statement";
            else if (this.FormName.Contains("LiquidityRatio"))
                this.Text = "Liquidity Ratio";
            else if (this.FormName.Contains("Financial"))
                this.Text = "Financial Statement";
               
            BindCurrency();
        }

        private void tsc_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsc_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print(this.FormName);
            this.Date = System.DateTime.Now;
        }
        private void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        
       
    }
}
