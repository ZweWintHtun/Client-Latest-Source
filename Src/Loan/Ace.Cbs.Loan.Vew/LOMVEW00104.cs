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
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00104 : BaseDockingForm, ILOMVEW00104
    {
        public LOMVEW00104()
        {
            InitializeComponent();
        }

        #region Properties
        private ILOMCTL00086 _controller;
        public ILOMCTL00086 LoanRecordController { get; set; }

        private ILOMCTL00104 controller;
        public ILOMCTL00104 Controller
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
            get { return this.txtAcctNo.Text; }
            set { this.txtAcctNo.Text = value; }
        }

        public decimal TotalOutstanding
        {
            get { return Convert.ToDecimal(this.txtOutstanding.Text); }
            set { this.txtOutstanding.Text = value.ToString(); }
        }

        public decimal RepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtRepaymentAmount.Text); }
            set { this.txtRepaymentAmount.Text = value.ToString(); }
        }

        public decimal TotalInterest
        {
            get { return Convert.ToDecimal(this.txtInterest.Text); }
            set { this.txtInterest.Text = value.ToString(); }
        }

        public decimal Penalties
        {
            get { return Convert.ToDecimal(this.txtPenalties.Text); }
            set { this.txtPenalties.Text = value.ToString(); }
        }

        public string startDate { get; set; }
        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(this.txtTotalAmount.Text); }
            set { this.txtTotalAmount.Text = value.ToString(); }
        }

        #endregion
        
        private void LOMVEW00104_Load(object sender, EventArgs e)
        {
            try
            {
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                this.Text = "Loan Repayment Information";
            }
            catch { }
        }

        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if (txtLoanNo.Text != string.Empty || txtLoanNo.Text != "")
                {
                    if (!this.Controller.checkFarmLoan(this.LoanNo))
                    {
                        this.Failure("MV90055");
                        this.txtLoanNo.Focus();
                        return;
                    }
                }
            }
            catch { }
        }

        #region Methods
        public void Failure(string message)
        {
            try
            {
                CXUIMessageUtilities.ShowMessageByCode(message);
            }
            catch { }
        }
        #endregion

        private void txtInterest_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(this.txtRepaymentAmount.Text) != 0)
            {
                this.txtTotalAmount.Text = string.Empty;
                this.txtTotalAmount.Text = (Convert.ToDecimal(this.txtPenalties.Text) != 0) ? (Convert.ToDecimal(this.txtRepaymentAmount.Text) + Convert.ToDecimal(this.txtInterest.Text) + Convert.ToDecimal(this.txtPenalties.Text)).ToString() : (Convert.ToDecimal(this.txtRepaymentAmount.Text) + Convert.ToDecimal(this.txtInterest.Text)).ToString();                
            }
        }

        private void txtPenalties_KeyDown(object sender, KeyEventArgs e)
        {
            if (Convert.ToDecimal(this.txtRepaymentAmount.Text) != 0)
            {
                this.txtTotalAmount.Text = string.Empty;
                this.txtTotalAmount.Text = (Convert.ToDecimal(this.txtInterest.Text) != 0) ? (Convert.ToDecimal(this.txtRepaymentAmount.Text) + Convert.ToDecimal(this.txtInterest.Text) + Convert.ToDecimal(this.txtPenalties.Text)).ToString() : (Convert.ToDecimal(this.txtRepaymentAmount.Text) + Convert.ToDecimal(this.txtPenalties.Text)).ToString();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.txtLoanNo.Text = string.Empty;
            this.txtAcctNo.Text = string.Empty;
            this.txtOutstanding.Text = "0.00";
            this.txtRepaymentAmount.Text = "0.00";
            this.txtInterest.Text = "0.00";
            this.txtPenalties.Text = "0.00";
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
