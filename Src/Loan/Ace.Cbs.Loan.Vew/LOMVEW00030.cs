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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00030 : BaseDockingForm, ILOMVEW00030
    {
        #region Properties
        private ILOMCTL00030 controller;
        public ILOMCTL00030 Controller
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
            get { return this.txtLoanNo.Text; }
            set { this.txtLoanNo.Text = value; }
        }
        public string AccountNo
        {
            get { return this.txtAccountNo.Text; }
            set { this.txtAccountNo.Text = value; }
        }
        public string LastRepaymentNo
        {
            get { return this.txtLastRepaymentNo.Text; }
            set { this.txtLastRepaymentNo.Text = value; }
        }
        public decimal LastRepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtLastRepaymentAmount.Text); }
            set { this.txtLastRepaymentAmount.Text = value.ToString(); }
        }
        public decimal BeforeLastRepaymentSanctionAmount
        {
            get { return Convert.ToDecimal(this.txtBeforeLastRepaymentSanctionAmount.Text); }
            set { this.txtBeforeLastRepaymentSanctionAmount.Text = value.ToString(); }
        }
        public decimal AfterLastRepaymentSanctionAmount
        {
            get { return Convert.ToDecimal(this.txtAfterLastRepaymentSanctionAmount.Text); }
            set { this.txtAfterLastRepaymentSanctionAmount.Text = value.ToString(); }
        }
        public decimal AfterNewRepaymentSanctionAmount
        {
            get { return Convert.ToDecimal(this.txtAfterNewRepaymentSanctionAmount.Text); }
            set { this.txtAfterNewRepaymentSanctionAmount.Text = value.ToString(); }
        }
        public string CustomerName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }
        public decimal Interest
        {
            get { return Convert.ToDecimal(this.txtTotalInterest.Text); }
            set { this.txtTotalInterest.Text = value.ToString(); }
        }
        public decimal FirstSanctionAmount { get; set; }
        public decimal PrevTotalSanctionAmount { get; set; }
        public bool FullSettlement { get; set; }
        public decimal NewRepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtNewRepaymentAmount.Text); }
            set { this.txtNewRepaymentAmount.Text = value.ToString(); }
        }
        //public decimal WithdrawableBalance { set; get; }
        public string InterestAccountDesp { set; get; }
        public string CreditAccountDesp { set; get; }
        public string CreditAccountCode { set; get; }
        public string InterestAccountCode { set; get; }

        #endregion

        public LOMVEW00030()
        {
            InitializeComponent();
        }

        private void LOMVEW00030_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(true, false, false, false, false, false, true);
            ClearControls();
            this.txtLoanNo.Focus();
            this.Text = "Loan Repayment Editing";
          this.txtAccountNo.Mask   = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        private void LOMVEW00025_KeyDown(object sender, KeyEventArgs e)
         
    {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        private void ClearControls()
        {
            gvAccountList.Rows.Clear();
            gvAccountList.DataSource = null;
            gvAccountList.Refresh();
            this.txtTotalInterest.Text = "0.00";
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtLoanNo.Text = string.Empty;
            this.txtAccountNo.Text = string.Empty;
            this.txtTotalInterest.Text = string.Empty;
            this.txtLastRepaymentNo.Text = string.Empty;
            this.txtLastRepaymentAmount.Text = "0.00";
            this.txtBeforeLastRepaymentSanctionAmount.Text = "0.00";
            this.txtAfterLastRepaymentSanctionAmount.Text = "0.00";
            this.txtAfterNewRepaymentSanctionAmount.Text = "0.00";
            this.txtNewRepaymentAmount.Text = "0.00";
            this.txtNewRepaymentAmount.Enabled = false;
            this.txtLoanNo.Focus();
        }
     
        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.controller.Save())
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);
                this.ClearControls();
            }
         
            {
             
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90026);
            }
        }

        private void BindGridView()
        {
            gvAccountList.AutoGenerateColumns = false;
            gvAccountList.Rows.Clear();
            CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { "LOANS", this.controller.Currency, CurrentUserEntity.BranchCode, true });
            CreditAccountDesp = "Loans To Construction";
            object[] debitRow = { "1", AccountNo, NewRepaymentAmount, 0.00, CustomerName };
            object[] creditRow = { "2", CreditAccountCode, 0.00, NewRepaymentAmount, CreditAccountDesp };

            gvAccountList.Rows.Add(debitRow);
            gvAccountList.Rows.Add(creditRow);
            if (FullSettlement)
            {
                object[] interestRow = { "3", InterestAccountCode, 0.00, Interest, InterestAccountDesp };
                gvAccountList.Rows.Add(interestRow);
            }

            gvAccountList.Refresh();
        }

        public void RepaymentCheck()
        {
            if (this.NewRepaymentAmount <= 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90079);
                this.txtNewRepaymentAmount.Focus();
                return;
            }
            else if (NewRepaymentAmount > BeforeLastRepaymentSanctionAmount)
            {
                CXUIMessageUtilities.ShowMessageByCode("MV90095"); //Repayment Amount should not be greater than Sanction Amount!.
                txtNewRepaymentAmount.Focus();
                return;
            }
            else
            {
                BindGridView();
                tsbCRUD.butSave.Focus();
            }
        }
    }     

}
