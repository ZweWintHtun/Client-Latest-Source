using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00446 : BaseDockingForm, ILOMVEW00446
    {

        Decimal CBalAmount = 0;
        DateTime NextEndDate;
        int NextTermPeriod = 0;
        decimal OutstandingAmt = 0;
        int ExtendTerm = 0;
        string preExtend = "";
        DateTime systemDate;
        decimal bl_ServiceChargesRate;

        public LOMVEW00446()
        {
            InitializeComponent();
        }

        public string AccountNo
        {
            get { return this.mtxtAcctNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAcctNo.Text = value; }
        }

        public string TotalExtendDuration
        {
            get { return this.txtExtendDuration.Text; }
            set { this.txtExtendDuration.Text = value; }
        }
        public string DocFeeNew
        {
            get { return this.txtDocFee.Text; }
            set { this.txtDocFee.Text = value; }
        } 
        public string IntRateNew
        {
            get { return this.txtNewInterestRate.Text; }
            set { this.txtNewInterestRate.Text = value; }
        }
        public string UserID
        {
            get; set;
        }
        public string SChargeNew
        {
            get { return this.txtServiceCharges.Text; }
            set { this.txtServiceCharges.Text = value; }
        }

        public string PreExtend
        {
            get { return this.preExtend; }
            set { this.preExtend = value; }
        }

        public void InitializeControls()
        {
            this.mtxtAcctNo.Text = "";
            this.mtxtAcctNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtLNo.Text = "";
            //this.txtName.Text = "";
            this.lblCustomerName.Text = "";
            //this.dtpRegisterDate.Value = Convert.ToDateTime(this.lblTransactionDate.Text); //DateTime.Now;
            //this.dtpLastExpiredDate.Value = Convert.ToDateTime(this.lblTransactionDate.Text.ToString()); //DateTime.Now;
            //this.dtpNewExpiredDate.Value = Convert.ToDateTime(this.lblTransactionDate.Text.ToString()); //DateTime.Now;
            this.dtpRegisterDate.Value = systemDate;
            this.dtpLastExpiredDate.Value = systemDate;
            this.dtpNewExpiredDate.Value = systemDate;
            this.txtFirstSanctionAmount.Text = "";
            this.txtIncreaseSanctionAmount.Text = "";
            this.txtTotalSanctionAmount.Text = "";
            this.txtOutstandingLoanAmount.Text = "";
            this.txtOldInterestRate.Text = "";
            this.txtNewInterestRate.Text = "";
            this.txtExtendDuration.Text = "";
            this.txtServiceCharges.Text = "";
            this.txtDocFee.Text = "";
            this.chkEditRate.Checked = false;
            this.chkEditDocFee.Checked = false;
            this.chkEditDuration.Checked = false;
            this.chkEditServiceCharges.Checked = false;
            this.OutstandingAmt = 0;
            this.ExtendTerm = 0;
            this.PreExtend = "PRE"; //set Default
            this.mtxtAcctNo.Focus();
        }

        private ILOMCTL00446 controller;
        public ILOMCTL00446 Controller
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

        
        private void LOMVEW00446_Load(object sender, EventArgs e)
        {
            //DateTime systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            systemDate = this.controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");
            bl_ServiceChargesRate=this.controller.SelectByCode("BLNYRSCHGRATE").Rate;
            bl_ServiceChargesRate = (bl_ServiceChargesRate == null ? 0 : bl_ServiceChargesRate);

            this.dtpRegisterDate.Value = systemDate;
            this.dtpLastExpiredDate.Value = systemDate;
            this.dtpNewExpiredDate.Value = systemDate;

            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            InitializeControls();
            this.mtxtAcctNo.Select();
        }

        private void chkEditRate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditRate.Checked == true)
            {
                this.txtNewInterestRate.ReadOnly = false;
                this.txtNewInterestRate.Focus();
            }
            else
                this.txtNewInterestRate.ReadOnly = true;
        }

        private void chkEditDocFee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditDocFee.Checked == true)
            {
                this.txtDocFee.ReadOnly = false;
                this.txtDocFee.Focus();
            }
            else
                this.txtDocFee.ReadOnly = true;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            bool HasOverDrawn=this.controller.HasOverDrawn(this.mtxtAcctNo.Text.Replace("-", "").Trim(),CurrentUserEntity.BranchCode);
            if (HasOverDrawn == true)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90208);//Please repay the OD and late fee amount first!
            }
            else
            {

                CBalAmount = this.Controller.GetAccountCurBalance(this.mtxtAcctNo.Text.Replace("-", "").Trim());
                if (CBalAmount < Convert.ToDecimal(txtDocFee.Text) + Convert.ToDecimal(txtServiceCharges.Text))//Checking Insufficient Amount
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);  //Insufficient Balance                    
                    return;
                }

                NextEndDate = NextEndDate.AddMonths(1);
                if (NextEndDate > DateTime.Now)//Checking Installment Auto Pay has been run or not for the first limit extend term
                {
                    string result = this.Controller.SaveLimitExtendInfo(CurrentUserEntity.CurrentUserID.ToString(), CurrentUserEntity.BranchCode);
                    if (result == "000")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90147);  //Limit Extend Successfully!
                        InitializeControls();
                    }
                    else if (result == "222")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);  //Insufficient Balance.
                    }
                    else
                    {
                        //if saving in error
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90163);  //Process Fail!
                    }
                }
                else
                {
                    string result = this.Controller.SaveLimitExtendInfo(CurrentUserEntity.CurrentUserID.ToString(), CurrentUserEntity.BranchCode);
                    if (result == "000")
                    {
                        NextTermPeriod = NextTermPeriod + 1;
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90148, NextTermPeriod, NextTermPeriod);    //Installment Auto Pay Process has been run for the "Term-{0}"\nPlease inform to System Administrator to do manual instruction for "Term-{1}".\nLoan limit will extend successfully!
                        this.InitializeControls();//Clear >> Added by HMW at 04/04/2023
                    }
                    else if (result == "222")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);  //Insufficient Balance.
                    }
                    else
                    {
                        //if saving in error
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90163);  //Process Fail!
                    }
                }
            }
        }

        public void GetAccountInfo()
        {
            this.AccountNo = mtxtAcctNo.Text.Replace("-", "").Trim();
            this.txtLNo.Text = "";
            //this.txtName.Text = "";
            this.lblCustomerName.Text = "";
            this.dtpRegisterDate.Value = systemDate; //DateTime.Now;
            this.dtpLastExpiredDate.Value = systemDate; //DateTime.Now;
            this.dtpNewExpiredDate.Value = systemDate; //DateTime.Now;
            this.txtFirstSanctionAmount.Text = "";
            this.txtIncreaseSanctionAmount.Text = "";
            this.txtTotalSanctionAmount.Text = "";
            this.txtOutstandingLoanAmount.Text = "";
            this.txtOldInterestRate.Text = "";
            this.txtNewInterestRate.Text = "";
            this.chkEditRate.Checked = false;
            this.chkEditDocFee.Checked = false;
            this.chkEditDuration.Checked = false;
            this.chkEditServiceCharges.Checked = false;
            this.txtExtendDuration.Text = "";
            this.txtServiceCharges.Text = "";
            this.txtDocFee.Text = "";
            this.OutstandingAmt = 0;
            this.ExtendTerm = 0;
            this.PreExtend = "";

            IList<LOMDTO00423> AccountInfo = Controller.GetNeedToExtendAccountInfo();
            LOMDTO00423 SanctionAmountInfo = Controller.GetSanctionAmountInfo(this.mtxtAcctNo.Text,CurrentUserEntity.BranchCode);
            if (AccountInfo.Count > 0 )
            {
                foreach (LOMDTO00423 item in AccountInfo)
                {
                    //this.mtxtAcctNo.Text = item.Caccount;
                    this.txtLNo.Text = item.BLNo;
                    //this.txtName.Text = item.NAME;
                    this.lblCustomerName.Text = item.NAME;
                    this.dtpRegisterDate.Value = item.CreatedDate;
                    this.dtpLastExpiredDate.Value = item.ExpiredDate;                    
                    this.NextEndDate = item.ExpiredDate;
                    this.NextTermPeriod = item.TermNo;
                    this.txtFirstSanctionAmount.Text = item.LoanAmount.ToString("#,0.00"); //##,###.00
                    this.txtIncreaseSanctionAmount.Text = SanctionAmountInfo.IncreaseSanctionAmount.ToString("#,0.00"); //##,###.00
                    this.txtTotalSanctionAmount.Text = SanctionAmountInfo.TotalSanctionAmount.ToString("#,0.00"); //##,###.00
                    this.txtOutstandingLoanAmount.Text = item.OutstandingBalance.ToString("#,0.00"); //##,###.00
                    this.OutstandingAmt = item.OutstandingBalance;
                    this.txtOldInterestRate.Text = item.OldInterestRate.ToString("##.00"); //##.00
                    this.txtNewInterestRate.Text = item.NewInterestRate.ToString("##.00"); //##.00
                    this.txtDocFee.Text = item.DocFee.ToString("#,0.00"); //##,###.00
                    this.txtExtendDuration.Text = item.DEFAULTEXTENDTERM.ToString();
                    ExtendTerm = item.DEFAULTEXTENDTERM; //Added by HMW at 29-Oct-2019
                    this.PreExtend = item.PREEXTEND.ToString();
                    //this.txtServiceCharges.Text = "";
                    //this.txtDocFee.Select();
                    
                    //int extendDays = Convert.ToInt32(this.txtExtendDuration.Text)*30;
                    //this.dtpNewExpiredDate.Value = item.ExpiredDate.AddDays(extendDays);// e.g. If extend duration is 12 ==> Last Expired Date + (12*30)
                    GetNextExpiredDate();
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                this.mtxtAcctNo.Select();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void txtExtendDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '\t' || e.KeyChar == '\r')
            //{
            //    GetAccountInfo();
            //    GetServiceChargesInfo(); 
            //}
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }            
        }

        private void chkEditDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditDuration.Checked == true)
            {
                this.txtExtendDuration.ReadOnly = false;
                this.txtExtendDuration.Focus();
                this.txtExtendDuration.Select();
            }
            else
                this.txtExtendDuration.ReadOnly = true;
        }        

        private void chkEditServiceCharges_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditServiceCharges.Checked == true)
            {
                this.txtServiceCharges.ReadOnly = false;
                this.txtServiceCharges.Focus();
            }
            else
                this.txtServiceCharges.ReadOnly = true;
        } 

        private void mtxtAcctNo_Leave(object sender, EventArgs e)
        {
            mtxtAcctNo_Check();
        }

        private void mtxtAcctNo_Check()
        {
            if (mtxtAcctNo.Text.Length + 2 != mtxtAcctNo.Mask.Length) return;

            if (this.mtxtAcctNo.Text.Replace("-", "").Trim() != "" || this.mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty || this.mtxtAcctNo.Text.Replace("-", "").Trim().Length > 6)
            {
                GetAccountInfo();
                GetServiceChargesInfo(); 
            }
        }
        
        private void mtxtAcctNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                mtxtAcctNo_Check();                
            }
        }

        //private void txtExtendDuration_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == 9 || e.KeyValue == 13)//Tab Key || Enter Key
        //    {
                  //ExtendTerm = Convert.ToInt32(this.txtExtendDuration.Text);
        //        GetNextExpiredDate();
        //        GetServiceChargesInfo();
        //    }
        //}

        //Added by khin khin thet at 16-Nov-2020
        private void GetServiceChargesInfo()
        {
            this.txtServiceCharges.Text = (((OutstandingAmt * (bl_ServiceChargesRate / 100)) / 12) * ExtendTerm).ToString();

            #region Old Added by HMW at 13-Nov-2019
            //if (this.PreExtend == "PRE")
            //{
            //    this.txtServiceCharges.Text = (((OutstandingAmt * (bl_ServiceChargesRate / 100.00)) / 12.00) * ExtendTerm).ToString();// 1 Month Service Charges * Duration
            //}
            //else
            //{
            //    if (txtExtendDuration.Text != "3")//3 Terms has been auto extended by BL Installment Auto Pay Process
            //        this.txtServiceCharges.Text = (((OutstandingAmt * (1.00 / 100.00)) / 12.00) * (ExtendTerm - 3)).ToString();
            //    else
            //        this.txtServiceCharges.Text = "";
            //}
            #endregion
        }

        //Added by HMW at 13-Nov-2019
        private void GetNextExpiredDate()
        {
            //int extendDays = Convert.ToInt32(this.txtExtendDuration.Text) * 30;
            //this.dtpNewExpiredDate.Value = this.dtpLastExpiredDate.Value.AddDays(extendDays);// e.g. If extend duration is 12 ==> Last Expired Date + (12*30)
            this.dtpNewExpiredDate.Value = this.dtpLastExpiredDate.Value.AddMonths(Convert.ToInt32(this.txtExtendDuration.Text));
        }

        private void txtExtendDuration_Leave(object sender, EventArgs e)
        {
            ExtendTerm = Convert.ToInt32(this.txtExtendDuration.Text);
            GetNextExpiredDate();
            GetServiceChargesInfo();                
        }
        
    }
}
