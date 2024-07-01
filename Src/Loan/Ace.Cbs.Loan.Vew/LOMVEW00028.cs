using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00028 : BaseDockingForm, ILOMVEW00028
    {
        #region Constructor
        public LOMVEW00028()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        private ILOMCTL00028 controller;
        public ILOMCTL00028 Controller
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

        public string LoanNo
        {
            get { return txtLoanNo.Text.ToString(); }
            set { txtLoanNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.txtAccountNo.Text.ToString(); }
            set { this.txtAccountNo.Text = value; }
        }
        public string DrAccountNo
        {
            //get { return this.mtxtAccountNo.Text.ToString(); }
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string TypeOfLoan
        {
            get { return this.txtTypeOfLoan.Text.ToString(); }
            set { this.txtTypeOfLoan.Text = value; }
        }
        public string LegalDate
        {
            get { return this.txtLegalDate.Text.ToString(); }
            set { this.txtLegalDate.Text = value; }
        }

        public decimal CurrentBalance
        {
            get { return this.txtCurrentBalance.Value; }
            set { this.txtCurrentBalance.Text = value.ToString(); }
        }

        public decimal DepositAmount
        {
            get { return this.txtDepositAmount.Value; }
            set { this.txtDepositAmount.Text = value.ToString(); }
        }
        public string Status
        {
            get { return this.lblStatusDesp.Text.ToString(); }
            set { this.lblStatusDesp.Text = value; }
        }      
        #endregion

        #region Method
        public void InitializeControls()
        {
            this.txtLoanNo.Focus();
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtLoanNo.Text = string.Empty;
            this.txtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtTypeOfLoan.Text = string.Empty;
            this.txtLegalDate.Text = string.Empty;
            this.txtCurrentBalance.Text = "0.00";
            this.txtDepositAmount.Text = "0.00";
            this.lblStatusDesp.Text = string.Empty;
            this.lstNames.DataSource = null;
            this.gvLegalODRepayment.DataSource = null;
            
        }
        public void BindNameList(IList<LOMDTO00013> legalList)
        {
            this.lstNames.DataSource = null;
            if (legalList.Count > 0)
            {
                this.lstNames.DataSource = legalList;
                this.lstNames.DisplayMember = "Name";
            }
        }
        public void BindGridView(IList<LOMDTO00013> legalList)
        {
            this.gvLegalODRepayment.AutoGenerateColumns = false;
            this.gvLegalODRepayment.DataSource = null;
            if (legalList.Count > 0)
                this.gvLegalODRepayment.DataSource = legalList;
        }       
        #endregion

        #region Events
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            this.controller.Save();
            this.InitializeControls();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearErrors();
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        #endregion

        private void LOMVEW00028_Load(object sender, EventArgs e)
        {
            this.InitializeControls();            
        }

        //private void txtLoanNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)                
        //        //SendKeys.Send("{TAB}");
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //}

        //private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //       // SendKeys.Send("{TAB}");
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //}

        //private void txtDepositAmount_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        //SendKeys.Send("{TAB}");
        //        this.SelectNextControl(this.ActiveControl, true, true, true, true);
        //}

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void LOMVEW00028_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }
   
    }
}
