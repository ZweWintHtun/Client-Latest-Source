using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00040 : BaseForm , IMNMVEW00040
    {
        #region Constructor
        public MNMVEW00040()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public bool SortByAcctNo
        {
            get { return this.rdoAccountNo.Checked; }
            set { this.rdoAccountNo.Checked = value; }
        }
       
        public bool SortByTime
        {
            get { return this.rdoTime.Checked; }
            set { this.rdoTime.Checked = value; }
        }

        public bool IsReversal
        {
            get { return this.chkWithReversal.Checked; }
            set { this.chkWithReversal.Checked = value; }
        }

        public string CurrencyCode
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

        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }


        #endregion

        #region controller

        private IMNMCTL00040 autoLinkDebitController;
        public IMNMCTL00040 Controller
        {
            get
            {
                return this.autoLinkDebitController;
            }
            set
            {
                this.autoLinkDebitController = value;
                this.autoLinkDebitController.View = this;
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

        public void InitialzeControls()
        {           
           // this.dtpDate.Text = DateTime.Now.ToString("dd/MM/yyyy");            
            this.BindCurrency();
            this.rdoAccountNo.Checked = true;
            this.dtpDate.Value = DateTime.Now;
           this.dtpDate.Focus();
          // this.cboCurrency.Focus();


           
        }
        #endregion


        private void MNMVEW00040_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.InitialzeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpDate.Value = DateTime.Now;
            this.InitialzeControls();

        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.Controller.Print();
        }



        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void MNMVEW00040_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
