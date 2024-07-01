using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
//using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Gl.Ctr.Ptr;


namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00008 : BaseForm ,IGLMVEW00008
    {
        #region Properties

        public string AccountNo
        {
            get
            {
                return this.cboAccountNo.Text.ToString();
            }
            set
            {
                this.cboAccountNo.Text = value;
                this.cboAccountNo.SelectedValue = value;
            }
        }
        public string Currency
        {
            get
            {
                return this.cboCurrency.Text.ToString();
            }
            set
            {
                this.cboCurrency.Text = value;
                this.cboCurrency.SelectedValue = value;
            }
        }
          
        public string AccountName
        {
            get 
            {
                return txtAccountName.Text.ToString() ;
            }
            set
            {
                this.txtAccountName.Text = value;
            }
        }
   
        public string Balance
        {
            get 
            {
                return this.txtBalance.Text.ToString() ;
            }
            set
            {
                this.txtBalance.Text = value;
            }
        }
        
        #endregion

        #region controller
        private IGLMCTL00008 LedgerController;
        public IGLMCTL00008 Controller
        {
            get
            {
                return this.LedgerController;
            }
            set
            {
                this.LedgerController = value;
                this.LedgerController.View = this;
            }
        }
        #endregion

        #region Constructor
        public GLMVEW00008()
        {
            InitializeComponent();
        }
        #endregion

        #region Method

        private void BindAccountNo()
        {
            IList<ChargeOfAccountDTO> ChargeOfAccountList = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COADAO.SelectByBranchDetail", new object[] { CurrentUserEntity.BranchCode, true });
            this.cboAccountNo.DisplayMember = "ACode";
            this.cboAccountNo.ValueMember = "ACode";
            this.cboAccountNo.DataSource = ChargeOfAccountList;
            this.cboAccountNo.SelectedIndex = -1;        
        }

        public void BindCurrency()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            this.cboCurrency.SelectedIndex = 0;
        }

        public void InitializeControls()
        {
            //Enable Disable Menu Controls
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);           
            this.BindAccountNo();
            this.BindCurrency();
            //this.cboAccountNo.SelectedIndex = -1;
            //this.cboCurrency.SelectedIndex = 0;
            this.txtAccountName.Text = "";
            this.txtBalance.Text = "";
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        #endregion

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        //private void cboCurrency_Leave(object sender, EventArgs e)
        //{
        //    this.Controller.DisplayData();
        //}

        private void GLMVEW00008_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void GLMVEW00008_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                //SendKeys.Send("{Tab}");
                this.Close();
            }         
        }

        //private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboCurrency.SelectedIndex != -1)
        //    {
        //        this.Controller.DisplayData();
        //    }
        //    else
        //    {
        //        this.Failure("Invalid Currency");
        //    }
        //}

        
    }
}
