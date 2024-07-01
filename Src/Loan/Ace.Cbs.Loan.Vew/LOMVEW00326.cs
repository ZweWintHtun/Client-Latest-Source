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
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00326 : BaseForm, ILOMVEW00326
    {
        #region Constructor
        public LOMVEW00326()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00326 controller;
        public ILOMCTL00326 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Properties

        public static string eno = "";
        public string rentalDiscountRate = "";
        decimal actualRentalChgAmt = 0;

        string totalPrepaidInstallAmount = "";
        string totalPrepaidPricipleAmount = "";
        string totalPrepaidRentalAmount = "";
        string startTerm = "";
        //string totalPrepaid_Install_Rental_Amount = "";

        public LOMDTO00326 dto;

        public int StartTerm
        {
            get { return Convert.ToInt32(txtSTerm.Text); }
            set { this.txtSTerm.Text = Convert.ToString(value); }
        }

        public int EndTerm
        {
            get { return Convert.ToInt32(txtETerm.Text); }
            set { this.txtETerm.Text = Convert.ToString(value); }
        }
        public string PLNo
        {
            get { return this.txtPLNo.Text; }
            set { this.txtPLNo.Text = value; }
        }

        public decimal InstallmentAmount
        {
            get { return Convert.ToDecimal(txtTotalInstallmentAmount.Value); }
            set { this.txtTotalInstallmentAmount.Value = value; }
        }

        public decimal TotalPrincipleAmount
        {
            get { return Convert.ToDecimal(txtTotalPrincipleAmt.Value); }
            set { this.txtTotalPrincipleAmt.Value = value; }
        }

        public decimal TotalRentalChgAmount
        {
            get { return Convert.ToDecimal(txtTotalRentalChgAmt.Value); }
            set { this.txtTotalRentalChgAmt.Value = value; }
        }

        public decimal RentalDiscountRate
        {
            get
            {
                if (string.IsNullOrEmpty(txtRentalDisRate.Text.ToString()))
                {
                    txtRentalDisRate.Text = "0";

                }
                return Convert.ToDecimal(txtRentalDisRate.Text);
            }
            set { this.txtRentalDisRate.Text = Convert.ToString(value); }
        }

        #endregion

        #region Methods

        public bool ValidationControls()
        {
            if (string.IsNullOrEmpty(this.PLNo))
            {
                errorProvider1.SetError(txtPLNo, "PLNo");
            }
            if (txtSTerm.TextLength == 0)
            {
                errorProvider1.SetError(txtSTerm, "StartTerm");
            }
            if (txtETerm.TextLength == 0)
            {
                errorProvider1.SetError(txtETerm, "StartTerm");
            }
            if (string.IsNullOrEmpty(this.PLNo) || txtSTerm.TextLength == 0 || txtETerm.TextLength == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);//Incomplete data to save !
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitializeControl()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtPLNo.Text = string.Empty;
            this.txtTotalInstallmentAmount.Text = string.Empty;

            this.txtTotalPrincipleAmt.Text = string.Empty;
            this.txtTotalRentalChgAmt.Text = string.Empty;

            this.txtRentalDisRate.Text = string.Empty;
            this.txtRentalDisRate.Enabled = false;

            this.txtSTerm.Text = string.Empty;
            this.txtETerm.Text = string.Empty;

            this.lblCAcctNo.Text = string.Empty;
            this.lblAcctNo.Text = string.Empty;
            this.lblRentalChgACNO.Text = string.Empty;

            this.lblCAmt.Text = string.Empty;
            this.lblAmt.Text = string.Empty;
            this.lblRAmt.Text = string.Empty;

            this.lblDR.Text = string.Empty;
            this.lblCR.Text = string.Empty;
            this.lblRCR.Text = string.Empty;

            this.chkRentalDiscountEdit.Checked = false;
            this.lblEndTermNo1.Text = string.Empty;

        }

        public void BindRentalDiscountRate()
        {
            rentalDiscountRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "RENTALDISCOUNTRATE", true }).ToString();
            txtRentalDisRate.Text = rentalDiscountRate.ToString();
        }

        public void Successful(string message, string plno)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControl();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Show_Prepayment_Info(string plNo, int startTerm, int endTerm, string branchCode)
        {
            //string strCheck = this.controller.Get_PL_PrepaymentInfo(PLNo, CurrentUserEntity.BranchCode);

            string strCheck = this.controller.Get_PL_PrepaymentInfo_NewLogic(plNo, startTerm, endTerm, CurrentUserEntity.BranchCode);

            string acnoPL = "";
            string acnoRental = "";
            string plCustAcno = "";
            totalPrepaidInstallAmount = "";

            //totalPrepaidRentalAmount = "";
            //totalPrepaid_Install_Rental_Amount = "";
            decimal rentalDiscountRate = 0;
            txtRentalDisRate.Text = rentalDiscountRate.ToString();

            string[] strval = strCheck.Split(',');
            acnoPL = strval[1];
            acnoRental = strval[2];
            plCustAcno = strval[3];

            totalPrepaidInstallAmount = strval[4];

            totalPrepaidPricipleAmount = strval[5];
            totalPrepaidRentalAmount = strval[6];
            startTerm = Convert.ToInt32(strval[7]);

            txtTotalPrincipleAmt.Text = totalPrepaidPricipleAmount;
            txtTotalRentalChgAmt.Text = totalPrepaidRentalAmount;
            txtSTerm.Text = startTerm.ToString();
            txtTotalInstallmentAmount.Text = totalPrepaidInstallAmount;

            //txtSTerm.Text = strval[7];
            //txtETerm.Text = strval[8];

            rentalDiscountRate = Convert.ToDecimal(txtRentalDisRate.Text);
            actualRentalChgAmt = Convert.ToDecimal(totalPrepaidRentalAmount) - Convert.ToDecimal(totalPrepaidRentalAmount) * rentalDiscountRate / 100;

            //totalPrepaid_Install_Rental_Amount = (Convert.ToDecimal(totalPrepaidInstallAmount) + Convert.ToDecimal(actualRentalChgAmt)).ToString();

            lblCAcctNo.Text = plCustAcno;
            lblCAmt.Text = Double.Parse(totalPrepaidInstallAmount).ToString("N2");

            lblAcctNo.Text = acnoPL;
            lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");

            if (totalPrepaidRentalAmount != "0.00")
            {
                lblRentalChgACNO.Text = acnoRental;
                lblRAmt.Text = Double.Parse(totalPrepaidRentalAmount).ToString("N2");
                lblRCR.Text = "CR";
            }
            lblDR.Text = "DR";
            lblCR.Text = "CR";

        }

        #endregion

        #region Events

        private void LOMVEW00326_Load(object sender, EventArgs e)
        {
            InitializeControl();
            BindRentalDiscountRate();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            txtRentalDisRate.Text = rentalDiscountRate.ToString();
            this.InitializeControl();            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //Refrence to Sis AAM
            if (!this.ValidationControls())
                return;

            string prepayStatus = this.controller.PL_Manual_Pre_Payment_Process_NewLogic(PLNo, StartTerm, EndTerm, InstallmentAmount, TotalPrincipleAmount, TotalRentalChgAmount,
                                                        RentalDiscountRate, eno, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
            if (prepayStatus == "0")
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitializeControl();
            }
            else this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
        }

        private void txtPLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtSTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtETerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtPLNo_Leave(object sender, EventArgs e)
        {
            //string strCheck = this.controller.Get_PL_PrepaymentInfo(PLNo, CurrentUserEntity.BranchCode);

            string strCheck = this.controller.CheckPLAccountandStartTerm(PLNo, CurrentUserEntity.BranchCode);
            if (strCheck.Substring(0, 4) == "1111")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //Loans No. Already Closed!
                txtPLNo.Focus();
                return;
            }
            else if (strCheck.Substring(0, 1) == "1")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90187); //Invalid PL Number. Pls enter valid PL Numeber !
                return;
            }
            else if (strCheck.Substring(0, 1) == "1111")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //Loans No. Already Closed!
                txtPLNo.Focus();
                return;
            }
            else
            {
                string[] strval = strCheck.Split(',');
                txtSTerm.Text = strval[1];
                lblEndTermNo1.Text = strval[2];
                //Show_Prepayment_Info();
            }
        }

        private void txtETerm_Leave(object sender, EventArgs e)
        {
            Show_Prepayment_Info(PLNo, StartTerm, EndTerm, CurrentUserEntity.BranchCode);
            this.txtRentalDisRate.Enabled = false;
        }

        private void chkRentalDiscountEdit_Click(object sender, EventArgs e)
        {
            if (chkRentalDiscountEdit.Checked)
            {
                txtRentalDisRate.Enabled = true;
            }
            else
            {
                txtRentalDisRate.Enabled = false;
                txtRentalDisRate.Text = "0.00";

                lblCAmt.Text = Double.Parse(totalPrepaidInstallAmount).ToString("N2");
                lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");
                lblRAmt.Text = Double.Parse(totalPrepaidRentalAmount).ToString("N2");
            }
        }

        private void txtRentalDisRate_Leave(object sender, EventArgs e)
        {
            TotalPrincipleAmount = Convert.ToDecimal(totalPrepaidPricipleAmount);
            TotalRentalChgAmount = Convert.ToDecimal(totalPrepaidRentalAmount);

            RentalDiscountRate = Convert.ToDecimal(txtRentalDisRate.Text);
            decimal actualRentalChgAmt = TotalRentalChgAmount - (TotalRentalChgAmount * RentalDiscountRate / 100);

            decimal actualInstallmentAmount = TotalPrincipleAmount + actualRentalChgAmt;

            lblCAmt.Text = actualInstallmentAmount.ToString("N2");
            lblAmt.Text = TotalPrincipleAmount.ToString("N2");

            if (totalPrepaidRentalAmount != "0.00")
            {
                lblRAmt.Text = actualRentalChgAmt.ToString("N2");
            }
        }

        #endregion
    }
}
