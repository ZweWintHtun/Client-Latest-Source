using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00208 : BaseForm, ILOMVEW00208
    {
        string eno = "";
        string chkCustBal = "";
        string cacctno = "";
        string hpacctno = "";
        string lateFeesAmt = "";
        string message = "";

        public LOMVEW00208()
        {
            InitializeComponent();
        }

        private ILOMCTL00208 controller;
        public ILOMCTL00208 Controller
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

        public string HPNo
        {
            get { return this.txtHPNo.Text; }
            set { this.txtHPNo.Text = value; }
        }
        public int StartTerm
        {
            get { return Convert.ToInt32(txtStartTerm.Text); }
            set { this.txtStartTerm.Text =Convert.ToString(value); }
        }
        public int EndTerm
        {
            get { return Convert.ToInt32(txtEndTerm.Text); }
            set { this.txtEndTerm.Text = Convert.ToString(value); }
        }
        public string TotalLateFeesAmount
        {
            get { return this.txtLateFeesAmount.Text; }
            set { this.txtLateFeesAmount.Text =value; }
        }
        
        public bool ValidationControls()
        {
            if (string.IsNullOrEmpty(this.HPNo))
            {
                errorProvider1.SetError(txtHPNo, "HPNo");
            }
            if (txtStartTerm.TextLength == 0)
            {
                errorProvider1.SetError(txtStartTerm, "StartTerm");
            }
            if (txtEndTerm.TextLength == 0)
            {
                errorProvider1.SetError(txtEndTerm, "EndTerm");
            }
            if (txtLateFeesAmount.TextLength == 0)
            {
                errorProvider1.SetError(txtLateFeesAmount, "TotalLateFeesAmount");
            }
            if (string.IsNullOrEmpty(this.HPNo) || txtStartTerm.TextLength == 0 || txtEndTerm.TextLength == 0 || txtLateFeesAmount.TextLength == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        private void InitializeControls()
        {
            this.txtHPNo.Text = string.Empty;
            this.txtStartTerm.Text = string.Empty;
            this.txtStartTerm.Enabled = false;
            this.txtEndTerm.Text = string.Empty;
            this.txtLateFeesAmount.Text = string.Empty;
            this.txtLateFeesAmount.Enabled = false;
            this.lblAcctNo.Text = string.Empty;
            this.lblCAcctNo.Text = string.Empty;
            this.lblAmt.Text = string.Empty;
            this.lblCAmt.Text = string.Empty;
            this.lblDR.Text = string.Empty;
            this.lblCR.Text = string.Empty;
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        private void LOMVEW00208_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            //InitializeControls();
            #endregion

            #region Seperating_EOD_Logic (By HMW at 29-07-2019)
            DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");
            InitializeControls();

            if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                  
            }
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);               
                this.DisableControls("HPLateFeeRepay.AllDisable");
            }
            #endregion

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void txtHPNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtStartTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtEndTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void GetRepayData()
        {
            string strCheck = this.controller.GetHPLateFeesRepayment_Amount(HPNo, StartTerm, EndTerm, CurrentUserEntity.BranchCode);
            string[] strval = strCheck.Split(',');
            
            chkCustBal=strval[0];
            cacctno = strval[1];
            hpacctno = strval[2];
            lateFeesAmt = strval[3];

            if (chkCustBal=="-1")
	        {
                message= CXMessage.MV90159;
                this.Failure(message);
                return;
	        }

            txtLateFeesAmount.Text = lateFeesAmt;
            lblCAcctNo.Text = cacctno;
            lblCAmt.Text = Double.Parse(lateFeesAmt).ToString("N2");

            lblAcctNo.Text = hpacctno;
            lblAmt.Text = Double.Parse(lateFeesAmt).ToString("N2");

            lblDR.Text = "DR";
            lblCR.Text = "CR";
        }

        private void txtHPNo_Leave(object sender, EventArgs e)
        {
            string chkHPExists = "";
            string startTermNo = "";
            string endTermNo = "";

            string retStr = this.controller.HPAccountExistsOrValid(HPNo, CurrentUserEntity.BranchCode);
            string[] strval = retStr.Split(',');
            chkHPExists = strval[0];
            if (chkHPExists == "-1")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90156);//Invalid HP Account.
                txtHPNo.Focus();
                return;
            }
            if (chkHPExists == "1")
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90170);//This HP account is not TOD,so has no late fees.!
                txtHPNo.Focus();
                return;
            }
            else
            {
                startTermNo = strval[1];
                endTermNo = strval[strval.Length - 1];

                txtStartTerm.Text = startTermNo;
                txtEndTerm.Text = endTermNo;
                txtEndTerm.Focus();
            }
        }

        private void txtEndTerm_Leave(object sender, EventArgs e)
        {
           GetRepayData();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (!this.ValidationControls())
                return;
            this.controller.HPLateFeesRepaymentProcess(HPNo,StartTerm,EndTerm,Convert.ToDecimal(TotalLateFeesAmount),eno,CurrentUserEntity.BranchCode,CurrentUserEntity.CurrentUserID,CurrentUserEntity.CurrentUserName);
            this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            this.InitializeControls();
        }

    }
}
