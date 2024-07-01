using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00025 : BaseForm,ITCMVEW00025
    {
        #region Constructor
        public TCMVEW00025()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString();}
        }

        public string Currency
        {
            get
            {
                if (this.cboCurrency.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCurrency.Text.ToString();
                }
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }

        public bool IsWithReversal
        {
            get { return this.chkWithReversal.Checked; }
            set { this.chkWithReversal.Checked = true; }
        }
    
        #endregion

        #region Controller
        private ITCMCTL00025 controller;
        public ITCMCTL00025 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #endregion     

        #region Method
        private void BindCurrencyCombobox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCurrencyCombobox();
            this.chkWithReversal.Checked = false;
        }

        #endregion

        #region Events
        private void TCMVEW00025_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpDate.Value = DateTime.Now;
            this.InitializeControls();
            this.controller.ClearCustomErrorMessage();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print();
        }

        #endregion

        private void tsbCRUD_Load(object sender, EventArgs e)
        {

        }

    }
}
