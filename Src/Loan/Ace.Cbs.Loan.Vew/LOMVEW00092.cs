using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00092 : BaseDockingForm, ILOMVEW00092
    {
        public LOMVEW00092()
        {
            InitializeComponent();
        }

        #region Properties
        /* To Check Vr No */
        private ILOMCTL00086 _controller;
        public ILOMCTL00086 LoanRecordController { get; set; }

        private ILOMCTL00092 controller;
        public ILOMCTL00092 LoanRepaymentController
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

        public string RepaymentNo
        {
            get { return this.txtRepaymentNo.Text; }
            set { this.txtRepaymentNo.Text = value; }
        }

        public string VrNo
        {
            get { return this.txtVrNo.Text; }
            set { this.txtVrNo.Text = value; }
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

        public decimal TotalOutstanding
        {
            get { return Convert.ToDecimal(this.txtTotalOutstanding.Text); }
            set { this.txtTotalOutstanding.Text = value.ToString(); }
        }

        public decimal RepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtRepaymentAmount.Text); }
            set { this.txtRepaymentAmount.Text = value.ToString(); }
        }

        public decimal TotalInterest
        {
            get { return Convert.ToDecimal(this.txtTotalInterest.Text); }
            set { this.txtTotalInterest.Text = value.ToString(); }
        }

        public string Penalties
        {
            get { return this.txtPenalities.Text; }
            set { this.txtPenalities.Text = value; }
        }

        public string CustomerName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }

        public decimal WithdrawableBalance { set; get; }
        public string InterestAccountDesp { set; get; }
        public string CreditAccountDesp { set; get; }

        public string CreditAccountCode
        {
            get
            {
                if (this.cboLoanAcctNo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboLoanAcctNo.SelectedValue.ToString();
                }
            }
            set
            {
                cboLoanAcctNo.SelectedValue = value;
            }
        }

        public string InterestAccountCode
        {
            get
            {
                if (this.cboInterestAccNo.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboInterestAccNo.SelectedValue.ToString();
                }
            }
            set
            {
                cboInterestAccNo.SelectedValue = value;
            }
        }
        public string Currency { set; get; }
        public string DebitAccountCode { set; get; }

        public string PenalitesAccountCode
        {
            get
            {
                if (this.cboPenalties.SelectedValue == null)
                {
                    return null;
                }
                else
                {
                    return cboPenalties.SelectedValue.ToString();
                }
            }
            set
            {
                cboPenalties.SelectedValue = value;
            }
        }

        public string PenalitiesAccountDesp { get; set; }
        public bool FullSettlement { set; get; }

        public string loanType { get; set; }

        public string startDate { get; set; }
        #endregion

        #region Events
        private void txtVrNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if (txtVrNo.Text != string.Empty || txtVrNo.Text != "")
                {
                    if (txtVrNo.Text.Length >= 13)
                    {
                        if (this.LoanRecordController.CheckLoanAccNo(this.VrNo) <= 0)
                        {
                            this.Failure("MV90129");
                            this.txtVrNo.Focus();
                            return;
                        }
                    }
                }
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
                    if (txtLoanNo.Text.Length >=15)
                    {
                    if (!this.LoanRepaymentController.checkFarmLoan(this.LoanNo))
                    {
                        this.Failure("MV90055");
                        this.txtLoanNo.Focus();
                        this.cboLoanAcctNo.Enabled = false;
                        return;
                    }
                    }
                }
            }
            catch { }
        }

        private void txtRepaymentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            catch { }
        }

        private void txtRepaymentAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Tab)
                return;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.ClearControls();
                gvLoanRepaymentList.Rows.Clear();
                this.txtRepaymentNo.Text = string.Empty;
            }
            catch { }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00078 dto = new LOMDTO00078();
                if ((RepaymentAmount <= 0) && (!string.IsNullOrEmpty(this.txtLoanNo.Text)))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90079);
                    txtRepaymentAmount.Focus();
                    return;
                }
                else if (RepaymentAmount > TotalOutstanding)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90138);
                    txtRepaymentAmount.Focus();
                    return;
                }
                else if ((RepaymentAmount <= 0) && (string.IsNullOrEmpty(this.txtLoanNo.Text)))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);
                    txtLoanNo.Focus();
                    return;
                }

                if (this.cboInterestAccNo.Enabled == true && this.cboInterestAccNo.Visible == true && this.cboInterestAccNo.SelectedValue == null)
                {
                    this.cboInterestAccNo.Focus();
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90148);
                    return;
                }
                else if (this.cboPenalties.Enabled == true && this.cboPenalties.Visible == true && this.cboPenalties.SelectedValue == null)
                {
                    this.cboPenalties.Focus();
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90149);
                    return;
                }
                else
                {
                    double homeAmount = this.LoanRepaymentController.GetHomeAmount(this.VrNo);
                    double totalOutstanding = Convert.ToDouble(this.RepaymentAmount) + Convert.ToDouble(this.TotalInterest) + Convert.ToDouble(this.Penalties);
                    if (homeAmount == totalOutstanding)
                        dto = this.LoanRepaymentController.Save(Convert.ToDecimal(this.Penalties));
                    else
                    {
                        this.txtRepaymentAmount.Focus();
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90147);
                        return;
                    }
                }

                if (dto != null && dto.ResultCode == "0000")
                {
                    this.txtRepaymentNo.Text = dto.RepaymentNo;
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);
                    ClearControls();
                    gvLoanRepaymentList.Rows.Clear();
                    lblName.Text = string.Empty;
                }
                else if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return;
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90026);
                    txtRepaymentAmount.Focus();
                }
            }
            catch { }
        }

        private void LOMVEW00092_Load(object sender, EventArgs e)
        {
            try
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.Text = "Agricultural Loans Repayment Entry";
                this.ClearControls();
            }
            catch { }
        }
        #endregion

        #region Methods
        public void BindAcctNo()
        {
            this.cboLoanAcctNo.ValueMember = "AcctNo";
            this.cboLoanAcctNo.DisplayMember = "AcctNo";
            this.cboLoanAcctNo.ColumnNames = "AcctNo, LoanType";
            this.cboLoanAcctNo.DataSource = this.LoanRepaymentController.getLoanAcctNo(this.LoanNo, "", "Loan");
            this.cboLoanAcctNo.SelectedIndex = -1;
        }


        public void BindInterestAcctNo()
        {
            this.cboInterestAccNo.ValueMember = "AcctNo";
            this.cboInterestAccNo.DisplayMember = "AcctNo";
            this.cboInterestAccNo.ColumnNames = "AcctNo, LoanType";
            this.cboInterestAccNo.DataSource = this.LoanRepaymentController.getLoanAcctNo(this.LoanNo, "", "Interest");
            this.cboInterestAccNo.SelectedIndex = -1;
        }

        public void BindPenalties()
        {
            this.cboPenalties.ValueMember = "AcctNo";
            this.cboPenalties.DisplayMember = "AcctNo";
            this.cboPenalties.ColumnNames = "AcctNo, LoanType";
            this.cboPenalties.DataSource = this.LoanRepaymentController.getLoanAcctNo(this.LoanNo, "", "Penalties");
            this.cboPenalties.SelectedIndex = -1;
        }

        public void RepaymentCheck()
        {
            if (cboLoanAcctNo.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90141);
                this.cboLoanAcctNo.Focus();
                return;
            }
            else if (TotalInterest > 0 && cboInterestAccNo.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90142);
                this.cboInterestAccNo.Focus();
                return;
            }
            else if (Convert.ToDecimal(this.Penalties) > 0 && cboPenalties.SelectedIndex == -1)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90143);
                this.cboPenalties.Focus();
                return;
            }
            /* Check Repayment Amount */
            if (RepaymentAmount <= 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90079);
                txtRepaymentAmount.Focus();
                return;
            }
            else if (this.TotalOutstanding < this.RepaymentAmount)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90094);
                txtRepaymentAmount.Focus();
                return;
            }
            else// if (this.TotalOutstanding == this.RepaymentAmount)
            {
                //DialogResult dialog = MessageBox.Show("Do you want to pay the full settlement amount?", "Information", MessageBoxButtons.YesNo);
                //if (dialog == DialogResult.Yes)
                //{
                this.txtTotalInterest.Text = this.LoanRepaymentController.GetInterestAmount(this.LoanNo, this.startDate).ToString();
                if (this.TotalInterest != 0)
                {
                    this.lblTotalInterest.Visible = true;
                    this.txtTotalInterest.Visible = true;
                    this.lblInterestCode.Visible = true;
                    this.cboInterestAccNo.Visible = true;
                    this.txtTotalInterest.Enabled = true;
                    this.cboInterestAccNo.Enabled = true;
                }
                this.BindInterestAcctNo();

                this.txtPenalities.Text = this.LoanRepaymentController.GetPenalFee().ToString();
                if (Convert.ToDecimal(this.Penalties) != 0)
                {
                    this.lblPenalties.Visible = true;
                    this.txtPenalities.Visible = true;
                    this.lblPenaltiesCode.Visible = true;
                    this.cboPenalties.Visible = true;
                    this.txtPenalities.Enabled = true;
                    this.cboPenalties.Enabled = true;
                }
                else
                {
                    this.lblPenaltiesCode.Visible = false;
                    this.cboPenalties.Visible = false;
                    this.txtPenalities.Enabled = false;
                }
                this.BindPenalties();
                //}
                //else if (dialog == DialogResult.No)
                //{
                //    this.lblTotalInterest.Visible = false;
                //    this.txtTotalInterest.Visible = false;
                //    this.lblInterestCode.Visible = false;
                //    this.cboInterestAccNo.Visible = false;
                //    this.txtTotalInterest.Enabled = false;
                //    this.cboInterestAccNo.Enabled = false;
                //    this.lblPenalties.Visible = false;
                //    this.txtPenalities.Visible = false;
                //    this.lblPenaltiesCode.Visible = false;
                //    this.cboPenalties.Visible = false;
                //    this.txtPenalities.Enabled = false;
                //    this.cboPenalties.Enabled = false;
                //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90146);
                //    txtRepaymentAmount.Focus();
                //    return;
                //}
                //}
                DataBindAccountList();
                tsbCRUD.butSave.Focus();
            }
        }

        private void DataBindAccountList()
        {
            if (gvLoanRepaymentList.Rows.Count > 0)
            {
                gvLoanRepaymentList.Rows.Clear();
            }
            decimal creditRepaymentAmount = 0;
            gvLoanRepaymentList.AutoGenerateColumns = false;
            gvLoanRepaymentList.Rows.Clear();

            creditRepaymentAmount = this.RepaymentAmount;
            if (this.TotalInterest > 0)
            {
                creditRepaymentAmount += this.TotalInterest;
            }

            if (Convert.ToDecimal(this.Penalties) > 0)
            {
                creditRepaymentAmount += Convert.ToDecimal(this.Penalties);
            }

            object[] creditRow = { "1", cboLoanAcctNo.SelectedValue.ToString(), 0.00, RepaymentAmount, CreditAccountDesp + cboLoanAcctNo.SelectedValue };
            object[] debitRow = { "2", DebitAccountCode, creditRepaymentAmount, 0.00, CustomerName };

            gvLoanRepaymentList.Rows.Add(debitRow);
            gvLoanRepaymentList.Rows.Add(creditRow);
            gvLoanRepaymentList.Refresh();
        }

        public void Successful(string message)
        {
            try
            {
                CXUIMessageUtilities.ShowMessageByCode(message);
                this.ClearControls();
            }
            catch { }
        }

        public void Failure(string message)
        {
            try
            {
                CXUIMessageUtilities.ShowMessageByCode(message);
            }
            catch { }
        }

        private void ClearControls()
        {
            this.txtVrNo.Text = string.Empty;
            this.txtLoanNo.Text = string.Empty;
            this.txtAccountNo.Text = string.Empty;
            this.txtTotalOutstanding.Text = "0.00";
            this.txtRepaymentAmount.Text = "0.00";
            this.txtTotalInterest.Text = "0.00";
            this.txtPenalities.Text = "0.00";
            this.cboLoanAcctNo.SelectedIndex = -1;
            this.lblTotalInterest.Visible = false;
            this.txtTotalInterest.Visible = false;
            this.lblInterestCode.Visible = false;
            this.cboInterestAccNo.Visible = false;
            this.lblPenalties.Visible = false;
            this.txtPenalities.Visible = false;
            this.lblPenaltiesCode.Visible = false;
            this.cboPenalties.Visible = false;
            this.txtRepaymentNo.Text =string.Empty;
        }
        #endregion

        private void cboInterestAccNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /* For Loan Interest */
                bool flag = false;
                if (this.TotalInterest > 0 && this.txtTotalInterest.Visible == true && this.cboInterestAccNo.SelectedValue != null)
                {
                    foreach (DataGridViewRow dr in gvLoanRepaymentList.Rows)
                    {
                        if (dr.Cells[1].Value.ToString().Substring(0, 2) == cboInterestAccNo.SelectedValue.ToString().Substring(0, 2))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        gvLoanRepaymentList.Rows.RemoveAt(2);
                    }
                    object[] creditInterestRow = { "3", cboInterestAccNo.SelectedValue.ToString(), 0.00, this.TotalInterest, InterestAccountDesp + cboInterestAccNo.SelectedValue };
                    gvLoanRepaymentList.Rows.Add(creditInterestRow);
                    gvLoanRepaymentList.Refresh();
                }
            }
            catch { }
        }

        private void cboPenalties_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /* Loan Penalties */
                bool flag = false;
                if (Convert.ToDecimal(this.Penalties) > 0 && this.txtTotalInterest.Visible == true && this.cboPenalties.SelectedValue != null)
                {
                    foreach (DataGridViewRow dr in gvLoanRepaymentList.Rows)
                    {
                        if (dr.Cells[1].Value.ToString().Substring(0, 2) == cboPenalties.SelectedValue.ToString().Substring(0, 2))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        gvLoanRepaymentList.Rows.RemoveAt(3);
                    }
                    object[] creditPenaltiesRow = { "4", cboPenalties.SelectedValue.ToString(), 0.00, this.Penalties, PenalitiesAccountDesp + cboInterestAccNo.SelectedValue };
                    gvLoanRepaymentList.Rows.Add(creditPenaltiesRow);
                    gvLoanRepaymentList.Refresh();
                }
            }
            catch { }
        }
        private void txtTotalInterest_Leave(object sender, EventArgs e)
        {
            try
            {
                DataBindAccountList();
            }
            catch { }
        }
    }
}
