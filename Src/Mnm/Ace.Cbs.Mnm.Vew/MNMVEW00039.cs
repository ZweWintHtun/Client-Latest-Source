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
    public partial class MNMVEW00039 : BaseForm,IMNMVEW00039
    {
        #region Properties
        public bool IsTransactionDate 
        {
            get{return this.rdoTransactionDate.Checked;}
            set{this.rdoTransactionDate.Checked = true ;}
        }

        public bool IsSettlementDate 
        { 
            get{return this.rdoSettlementDate .Checked;}
            set{this.rdoSettlementDate.Checked = true;}
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

        public DateTime RequiredDate
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }
        //public int Status;
        IList<CurrencyDTO> CurrencyList { get; set; }
        #endregion

        #region controller
                
        private IMNMCTL00039 controller;
        public IMNMCTL00039 Controller
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

        #region Constructor
        public MNMVEW00039()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        private void BindCurrency()
        {
            CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }
        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpDate.Value = DateTime.Now;
            this.BindCurrency();
            this.chkWithReversal.Checked = false;
            this.rdoTransactionDate.Checked = true;
        }
        #endregion

        #region Events

        private void MNMVEW00039_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.dtpDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpDate.Focus();
                return;
            }
            else
            {
                this.Controller.Print();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearCustomErrorMessages();
        }
        #endregion       
    }
}
