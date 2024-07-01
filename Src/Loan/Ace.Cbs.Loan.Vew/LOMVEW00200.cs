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
    public partial class LOMVEW00200 : BaseForm, ILOMVEW00200
    {
        public static string eno = "";
        public string rentalDiscountRate = "";
        decimal actualRentalChgAmt = 0;

        string totalPrepaidInstallAmount = "";
        string totalPrepaidPricipleAmount = "";
        string totalPrepaidRentalAmount = "";
        string startTerm = "";
        //string totalPrepaid_Install_Rental_Amount = "";

        public LOMDTO00200 dto;
        public LOMVEW00200()
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
            if (string.IsNullOrEmpty(this.HPNo))
            {
                errorProvider1.SetError(txtHPNo, "HPNo");
            }
            if (txtSTerm.TextLength==0)
            {
                errorProvider1.SetError(txtSTerm, "StartTerm");
            }
            if (txtETerm.TextLength == 0)
            {
                errorProvider1.SetError(txtETerm, "StartTerm");
            }
            if (string.IsNullOrEmpty(this.HPNo) || txtSTerm.TextLength == 0 ||txtETerm.TextLength == 0 )
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitailizeControl()
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.txtHPNo.Text = string.Empty;
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
            this.lblEndTermNo.Text = string.Empty;
            //Added by AAM(11_Sep_2018)
            this.lblCAcctNoInt.Text = string.Empty;
            this.lblIntAmt.Text = string.Empty;
            this.lblCustACIntDR.Text = string.Empty;

        }

        public void BindRentalDiscountRate()
        {
            rentalDiscountRate = CXCLE00002.Instance.GetScalarObject<decimal>("RateFile.AccountClose.Select", new object[] { "RENTALDISCOUNTRATE", true }).ToString();
            txtRentalDisRate.Text = rentalDiscountRate.ToString();
        }

        public void Successful(string message, string hpno)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitailizeControl();
        }

        public int StartTerm
        {
            get { return Convert.ToInt32(txtSTerm.Text); }
            set { this.txtSTerm.Text = Convert.ToString(value); }
        }

        public int EndTerm
        {
            //get { return Convert.ToInt32(txtETerm.Text); }
            get { 

                    return Convert.ToInt32(txtETerm.Text); 
                }
            set { this.txtETerm.Text = Convert.ToString(value); }
        }
        public string HPNo
        {
            get { return this.txtHPNo.Text; }
            set { this.txtHPNo.Text= value; }
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

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void LOMVEW00200_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //BindRentalDiscountRate();
            //this.InitailizeControl();
            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");

            this.InitailizeControl();

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                BindRentalDiscountRate();                
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);                
                this.DisableControls("HPManualPrepayment.AllDisable");
            }
            #endregion
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            //Client Requirements.
            #region 
            //string prepayStatus = this.controller.HP_Manual_Pre_Payment_Process(HPNo, StartTerm, EndTerm, TotalPrepaidAmount, TotalRentalChgAmount, RentalDiscountRate,
            //                                                                    eno, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
            //if (!this.ValidationControls())
            //    return;
            //if (prepayStatus == "0")
            //{
            //    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00009) == DialogResult.Yes)
            //    {
            //        this.controller.HP_Manual_Pre_Payment_Process(HPNo, StartTerm, EndTerm, TotalPrepaidAmount, TotalRentalChgAmount, RentalDiscountRate,
            //                                                    eno, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
            //        this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            //    }
            //    else
            //    {
            //        return;
            //        this.InitailizeControl();
            //    }
            //}
            //else this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            #endregion

            //-------------Added at 22-Sep-2017--------------//

            if (!this.ValidationControls())
                return;
            
            string Eno = this.controller.HP_Manual_Pre_Payment_Process_NewLogic(HPNo, StartTerm, EndTerm, InstallmentAmount, TotalPrincipleAmount, TotalRentalChgAmount,
                                                        RentalDiscountRate, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
            
            // Modified by ZMS 19.12.2018 to show eno in successful message .
            if (Eno == "-1") /// Insufficient Balance in HP Customer Ledger!. 
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                //this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00051, "Voucher No", Eno);
                this.InitailizeControl();
            } 
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            txtRentalDisRate.Text = rentalDiscountRate.ToString();
            this.InitailizeControl();
        }

        private void txtHPNo_KeyPress(object sender, KeyPressEventArgs e)
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

        public void Show_Prepayment_Info(string hpNo,int startTerm,int endTerm,string branchCode)
        {
            //string strCheck = this.controller.Get_HP_PrepaymentInfo(HPNo, CurrentUserEntity.BranchCode);

            string strCheck = this.controller.Get_HP_PrepaymentInfo_NewLogic(hpNo, startTerm, endTerm, CurrentUserEntity.BranchCode);

            string acnoHP = "";
            string acnoRental = "";
            string hpCustAcno = "";
            totalPrepaidInstallAmount = "";
            
            //totalPrepaidRentalAmount = "";
            //totalPrepaid_Install_Rental_Amount = "";
            decimal rentalDiscountRate = 0;
            txtRentalDisRate.Text = rentalDiscountRate.ToString();

            string[] strval = strCheck.Split(',');
            acnoHP = strval[1];
            acnoRental = strval[2];
            hpCustAcno = strval[3];

            totalPrepaidInstallAmount = strval[4];

            totalPrepaidPricipleAmount = strval[5];
            totalPrepaidRentalAmount = strval[6];
            startTerm =Convert.ToInt32(strval[7]);

            txtTotalPrincipleAmt.Text = totalPrepaidPricipleAmount;
            txtTotalRentalChgAmt.Text = totalPrepaidRentalAmount;
            txtSTerm.Text = startTerm.ToString();
            txtTotalInstallmentAmount.Text = totalPrepaidInstallAmount;

            //txtSTerm.Text = strval[7];
            //txtETerm.Text = strval[8];

            rentalDiscountRate = Convert.ToDecimal(txtRentalDisRate.Text);
            actualRentalChgAmt = Convert.ToDecimal(totalPrepaidRentalAmount) - Convert.ToDecimal(totalPrepaidRentalAmount) * rentalDiscountRate / 100;

            //totalPrepaid_Install_Rental_Amount = (Convert.ToDecimal(totalPrepaidInstallAmount) + Convert.ToDecimal(actualRentalChgAmt)).ToString();

            lblCAcctNo.Text = hpCustAcno;
            //lblCAmt.Text = Double.Parse(totalPrepaidInstallAmount).ToString("N2");
            lblCAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");


            lblAcctNo.Text = acnoHP;
            lblAmt.Text = Double.Parse(totalPrepaidPricipleAmount).ToString("N2");

            if (totalPrepaidRentalAmount!="0.00")
            {
                lblRentalChgACNO.Text = acnoRental;
                lblRAmt.Text = Double.Parse(totalPrepaidRentalAmount).ToString("N2");
                lblRCR.Text = "CR";
                //Added By AAM(11_Sep_2018)
                lblIntAmt.Text = Double.Parse(totalPrepaidRentalAmount).ToString("N2");
                lblCAcctNoInt.Text = hpCustAcno;
                lblCustACIntDR.Text = "DR";

                this.chkRentalDiscountEdit.Enabled = true;
            }
            else this.chkRentalDiscountEdit.Enabled = false;
            lblDR.Text = "DR";
            lblCR.Text = "CR";
            EnableLabel();
            
        }

        //private void txtHPNo_Leave(object sender, EventArgs e)
        //{
        //    //string strCheck = this.controller.Get_HP_PrepaymentInfo(HPNo, CurrentUserEntity.BranchCode);

        //    string strCheck = this.controller.CheckHPAccountandStartTerm(HPNo, CurrentUserEntity.BranchCode);
        //    string[] str1 = strCheck.Split(',');//Added by AAM(11_Sep_2018)
        //    if (str1[0] == "1")
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90156); //Invalid HP Number. Pls enter valid HP Numeber !
        //        txtHPNo.Focus(); //Added by AAM(11_Sep_2018)
        //        return;
        //    }
        //    //Start of Added by AAM(11_Sep_2018)
        //    else if (str1[0] == "-1")
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90213); //This HP No has OD.Please Run HP Late Fee Auto Pay Process First!
        //        txtHPNo.Focus();
        //        return;
        //    }
        //    else if (str1[0] == "-2")
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //Loans No. Already Closed!
        //        txtHPNo.Focus();
        //        return;
        //    }
        //    //End of Added by AAM(11_Sep_2018)
        //    else
        //    {
        //        string[] strval = strCheck.Split(',');
        //        txtSTerm.Text = strval[1];
        //        lblEndTermNo.Text = strval[2];
        //    }
        //}
       
        /// modified by ZMS 20181227
        private void txtETerm_Leave(object sender, EventArgs e)
        {
            if (txtETerm.Text.ToString() != "")
            {
                if (this.txtETerm.Text != string.Empty || this.txtETerm.Text != "")
                {
                    if (Convert.ToInt16(lblEndTermNo.Text) < Convert.ToInt16(txtETerm.Text))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90224);//Repayment term no should not greater than the total term no!
                        txtETerm.Focus();
                        txtETerm.Text = "";
                        return;
                    }
                    else
                    {
                        Show_Prepayment_Info(HPNo, StartTerm, EndTerm, CurrentUserEntity.BranchCode);
                        this.txtRentalDisRate.Enabled = false;
                    }
                }
            }
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
                lblIntAmt.Text = Double.Parse(totalPrepaidRentalAmount).ToString("N2");//Added By AAM(11_Sep_2018)
            }
            
        }

        //Added by AAM(11_Sep_2018)
        private void EnableLabel()
        {
            lblCAcctNo.Visible = true;
            lblCAmt.Visible = true;
            lblDR.Visible = true;
            lblRentalChgACNO.Visible = true;
            lblRAmt.Visible = true;
            lblRCR.Visible = true;
            lblCAcctNoInt.Visible = true;
            lblIntAmt.Visible = true;
            lblCustACIntDR.Visible = true;
            lblAcctNo.Visible = true;
            lblAmt.Visible = true;
            lblCR.Visible = true;
        }
        private void txtRentalDisRate_Leave(object sender, EventArgs e)
        {
            TotalPrincipleAmount = Convert.ToDecimal(totalPrepaidPricipleAmount);
            TotalRentalChgAmount = Convert.ToDecimal(totalPrepaidRentalAmount);

            RentalDiscountRate = Convert.ToDecimal(txtRentalDisRate.Text);
            decimal actualRentalChgAmt = TotalRentalChgAmount - (TotalRentalChgAmount * RentalDiscountRate / 100);

            //decimal actualInstallmentAmount = TotalPrincipleAmount + actualRentalChgAmt;//Commented by AAM(11_Sep_2018)
            decimal actualInstallmentAmount = TotalPrincipleAmount;//Added by AAM(11_Sep_2018)

            lblCAmt.Text = TotalPrincipleAmount.ToString("N2");
            lblAmt.Text = TotalPrincipleAmount.ToString("N2");

            lblIntAmt.Text = actualRentalChgAmt.ToString("N2");

            if (totalPrepaidRentalAmount != "0.00")
            {
                lblRAmt.Text = actualRentalChgAmt.ToString("N2");
            }
            EnableLabel(); //Added by AAM(11_Sep_2018)
        }

        private void txtHPNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                BindHPInfoByHPNO();

            }
        }

        private void txtHPNo_Leave(object sender, EventArgs e)
        {
            BindHPInfoByHPNO();
        }
        #region
        //private void chkRentalDiscountEdit_Click(object sender, EventArgs e)
        //{
        //    this.txtRentalDisRate.Enabled = true;
        //}

        //private void txtRentalDisRate_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtRentalDisRate_Leave(object sender, EventArgs e)
        //{
        //    Show_Prepayment_Info();
        //}
        #endregion

        #region Helper
        public void BindHPInfoByHPNO()
        {
            if (this.txtHPNo.Text != "null" && this.txtHPNo.Text != "NULL" && this.txtHPNo.Text != string.Empty)
            {
                string strCheck = this.controller.CheckHPAccountandStartTerm(HPNo, CurrentUserEntity.BranchCode);
                string[] str1 = strCheck.Split(',');//Added by AAM(11_Sep_2018)
                if (str1[0] == "1")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90156); //Invalid HP Number. Pls enter valid HP Numeber !
                    txtHPNo.Text = "";
                    txtHPNo.Focus(); //Added by AAM(11_Sep_2018)
                    return;
                }
                //Start of Added by AAM(11_Sep_2018)
                else if (str1[0] == "-1")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90213); //This HP No has OD.Please Run HP Late Fee Auto Pay Process First!
                    txtHPNo.Text = "";
                    txtHPNo.Focus();
                    return;
                }
                else if (str1[0] == "-2")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057); //Loans No. Already Closed!
                    txtHPNo.Text = "";
                    txtHPNo.Focus();
                    return;
                }
                //End of Added by AAM(11_Sep_2018)
                else
                {
                    string[] strval = strCheck.Split(',');
                    txtSTerm.Text = strval[1];
                    lblEndTermNo.Text = strval[2];
                }
            }
        }
        #endregion
    }
}
