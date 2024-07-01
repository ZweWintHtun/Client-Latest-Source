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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00245: BaseForm, ILOMVEW00200
    {
        public static string eno = "";
        public string interestDiscountRate = "";
        decimal actualInterestAmt = 0;

        string totalPrepaidInstallAmount = "";
        string totalPrepaidPricipleAmount = "";
        string totalPrepaidInterestAmount = "";
        string startTerm = "";
        public string formatCode;
        public int valueCount;
        public string valueStr;

        public LOMDTO00200 dto;
        public LOMVEW00245()
        {
            InitializeComponent();
        }

        private ILOMCTL00200 controller;
        public ILOMCTL00200 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
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
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitailizeControl(int status)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            if (status == 1)
            {
                this.txtPLNo.Text = string.Empty;
                this.txtSTerm.Text = string.Empty;
                this.txtPLNo.Focus();
                this.lblEndTermNo1.Text = string.Empty;
            }
            else
            {
                txtETerm.Focus();
                txtETerm.Text = "";
            }
            this.txtTotalInstallAmt.Text = string.Empty;

            this.txtTotalPrinAmt.Text = string.Empty;
            this.txtTotalIntAmt.Text = string.Empty;

            this.txtIntDisRate.Text = string.Empty;
            this.txtIntDisRate.Enabled = false;
            
            this.txtETerm.Text = string.Empty;

            this.lblCAcctNo.Text = string.Empty;
            this.lblAcctNo.Text = string.Empty;
            this.lblInterestACNO.Text = string.Empty;

            this.lblCAmt.Text = string.Empty;
            this.lblAmt.Text = string.Empty;
            this.lblIntAmt.Text = string.Empty;

            this.lblDR.Text = string.Empty;
            this.lblCR.Text = string.Empty;
            this.lblIntCR.Text = string.Empty;

            this.chkIntDiscountEdit.Checked = false;

            this.lblPLACForInt.Text = string.Empty;
            this.lblPLAmtForInt.Text = string.Empty;
            this.lblPLDrForInt.Text = string.Empty;
        }

        public void BindInterestDiscountRate()
        {
            interestDiscountRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "PLINTDISCOUNTRATE", true }).ToString();
            txtIntDisRate.Text = interestDiscountRate.ToString();
        }

        public void Successful(string message, string hpno)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitailizeControl(1);
        }

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

        public decimal InstallAmt
        {
            get { return Convert.ToDecimal(txtTotalInstallAmt.Value); }
            set { this.txtTotalInstallAmt.Value = value; }
        }

        public decimal TotalPrinAmt
        {
            get { return Convert.ToDecimal(txtTotalPrinAmt.Value); }
            set { this.txtTotalPrinAmt.Value = value; }
        }

        public decimal TotalIntAmt
        {
            get { return Convert.ToDecimal(txtTotalIntAmt.Value); }
            set { this.txtTotalIntAmt.Value = value; }
        }

        public decimal IntDisRate
        {
            get
            {
                if (string.IsNullOrEmpty(txtIntDisRate.Text.ToString()))
                {
                    txtIntDisRate.Text = "0";

                }
                return Convert.ToDecimal(txtIntDisRate.Text);
            }
            set { this.txtIntDisRate.Text = Convert.ToString(value); }
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void LOMVEW00245_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //this.ActiveControl = txtPLNo;
            //BindInterestDiscountRate();
            //this.InitailizeControl(1);
            #endregion


            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            this.InitailizeControl(1);

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                this.ActiveControl = txtPLNo;
                BindInterestDiscountRate();                    
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.DisableControls("PLManualPrepayment.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            // For generating entry no.
            formatCode = "NormalVoucher";
            valueStr = DateTime.Now.ToString("dd,MM,yy");
            valueCount = 3;

            string prepayStatus = this.controller.PL_Manual_Pre_Payment_Process(PLNo, StartTerm, EndTerm, InstallAmt, TotalPrinAmt
                                        ,TotalIntAmt,IntDisRate,CurrentUserEntity.BranchCode,CurrentUserEntity.CurrentUserID
                                        , CurrentUserEntity.CurrentUserName, formatCode, valueCount, valueStr);
            string[] strResult = prepayStatus.Split('#');
            string retCode = strResult[0];
            string retDesp = strResult[1];

            // Modified by ZMS to show eno in successful message 
            if (retCode == "0")
            {
                //this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                //this.InitailizeControl();

                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00051, "Voucher No", retDesp);
                this.InitailizeControl(1);
            }
            else if (retCode == "-2")//This PL No has OD.Please Run PL Late Fee Auto Pay Process First!
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitailizeControl(1);
            }
            else if (retDesp.Contains("Invalid"))
            {
                MessageBox.Show(retDesp);
                return;
            }
            else
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                //this.InitailizeControl(1);
                return;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            txtIntDisRate.Text = interestDiscountRate.ToString();
            this.InitailizeControl(1);
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

        public void Show_Prepayment_Info(string plNo, int startTerm, int endTerm, string branchCode)
        {
            string strCheck = this.controller.Get_PL_PrepaymentInfo(plNo, startTerm, endTerm, CurrentUserEntity.BranchCode);

            string acnoPL = "";
            string acnoRental = "";
            string plCustAcno = "";
            totalPrepaidInstallAmount = "";

            decimal interestDiscountRate = 0;
            txtIntDisRate.Text = interestDiscountRate.ToString();

            string[] strval = strCheck.Split(',');
            acnoPL = strval[1];
            acnoRental = strval[2];
            plCustAcno = strval[3];

            totalPrepaidInstallAmount = strval[4];

            totalPrepaidPricipleAmount = strval[5];
            totalPrepaidInterestAmount = strval[6];
            startTerm = Convert.ToInt32(strval[7]);

            txtTotalPrinAmt.Text = totalPrepaidPricipleAmount;
            txtTotalIntAmt.Text = totalPrepaidInterestAmount;
            txtSTerm.Text = startTerm.ToString();
            txtTotalInstallAmt.Text = totalPrepaidInstallAmount;

            interestDiscountRate = Convert.ToDecimal(txtIntDisRate.Text);
            actualInterestAmt = Convert.ToDecimal(totalPrepaidInterestAmount) - Convert.ToDecimal(totalPrepaidInterestAmount) * interestDiscountRate / 100;

            lblCAcctNo.Text = plCustAcno;
            lblCAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");

            lblAcctNo.Text = acnoPL;
            lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");

            if (totalPrepaidInterestAmount != "0.00")
            {
                lblPLACForInt.Text = plCustAcno;
                lblPLAmtForInt.Text = Double.Parse(totalPrepaidInterestAmount).ToString("N2");
                lblPLDrForInt.Text = "DR";

                lblInterestACNO.Text = acnoRental;
                lblIntAmt.Text = Double.Parse(totalPrepaidInterestAmount).ToString("N2");
                lblIntCR.Text = "CR";

                chkIntDiscountEdit.Enabled = true;
            }
            else chkIntDiscountEdit.Enabled = false;
            lblDR.Text = "DR";
            lblCR.Text = "CR";

        }
        private void txtETerm_Leave(object sender, EventArgs e)
        {
            if (this.txtETerm.Text != string.Empty && this.txtETerm.Text != "" && this.txtETerm.Text != "0")
            {
                if (Convert.ToInt16(lblEndTermNo1.Text) < Convert.ToInt16(txtETerm.Text))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90224);//Repayment term no should not greater than the total term no!
                    txtETerm.Focus();
                    txtETerm.Text = "";
                    return;
                }
                else
                {
                    Show_Prepayment_Info(PLNo, StartTerm, EndTerm, CurrentUserEntity.BranchCode);
                    this.txtIntDisRate.Enabled = false;
                }
            }
            else if (this.txtETerm.Text == "0")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90227);//Invalid term no !
                InitailizeControl(0);               
                return;
            }
        }

        private void chkIntDiscountEdit_Click(object sender, EventArgs e)
        {
            if (chkIntDiscountEdit.Checked)
            {
                txtIntDisRate.Enabled = true;
            }
            else
            {
                txtIntDisRate.Enabled = false;
                txtIntDisRate.Text = "0.00";

                //Modified by ZMS
                //lblCAmt.Text = Double.Parse(totalPrepaidInstallAmount).ToString("N2");
                //lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");
                //lblIntAmt.Text = Double.Parse(totalPrepaidInterestAmount).ToString("N2");

                lblCAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");
                lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");
                if (totalPrepaidInterestAmount != "0.00")
                {
                    lblIntAmt.Text = actualInterestAmt.ToString("N2");
                    lblPLAmtForInt.Text = actualInterestAmt.ToString("N2");
                }
            }

        }

        private void txtIntDisRate_Leave(object sender, EventArgs e)
        {
            TotalPrinAmt = Convert.ToDecimal(totalPrepaidPricipleAmount);
            TotalIntAmt = Convert.ToDecimal(totalPrepaidInterestAmount);

            IntDisRate = Convert.ToDecimal(txtIntDisRate.Text);
            decimal actualInterestAmt = TotalIntAmt - (TotalIntAmt * IntDisRate / 100);

            decimal actualInstallmentAmount = TotalPrinAmt + actualInterestAmt;

            //modified by ZMS
            //lblCAmt.Text = actualInstallmentAmount.ToString("N2");
            lblCAmt.Text = TotalPrinAmt.ToString("N2");
            lblAmt.Text = TotalPrinAmt.ToString("N2");

            if (totalPrepaidInterestAmount != "0.00")
            {
                lblIntAmt.Text = actualInterestAmt.ToString("N2");
                lblPLAmtForInt.Text = actualInterestAmt.ToString("N2");
            }
        }

        public void PLInfoBind()
        {
            if (this.txtPLNo.Text != string.Empty || this.txtPLNo.Text != "")
            {
                string strCheck = this.controller.CheckPLAccountandStartTerm(PLNo, CurrentUserEntity.BranchCode);
                if (strCheck.Substring(0, 1) == "3")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90223); //This PL No has OD.Please Run PL Late Fee Auto Pay Process First!
                    txtPLNo.Text = "";
                    txtPLNo.Focus();
                    return;
                }
                else if (strCheck.Substring(0, 1) == "2")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //Loans No. Already Closed!
                    txtPLNo.Text = "";
                    txtPLNo.Focus();
                    return;
                }
                else if (strCheck.Substring(0, 1) == "1" || strCheck.Substring(0, 1) == "NULL")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90187); //Invalid PL Number. Pls enter valid PL Numeber !
                    txtPLNo.Text = "";
                    txtPLNo.Focus();
                    return;
                }
                else
                {
                    string[] strval = strCheck.Split(',');
                    txtSTerm.Text = strval[1];
                    lblEndTermNo1.Text = strval[2];
                }
            }
        }

        private void txtPLNo_Leave(object sender, EventArgs e)
        {
            PLInfoBind();
        }

        private void txtPLNo_Enter(object sender, EventArgs e)
        {
            PLInfoBind();
        }

        private void txtPLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
