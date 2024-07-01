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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00025 : BaseDockingForm, ILOMVEW00025
    {
        #region Properties
        private ILOMCTL00025 controller;
        public ILOMCTL00025 Controller
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

        public string TypeOfSecurity
        {
            get { return this.txtTypeOfSecurity.Text; }
            set { this.txtTypeOfSecurity.Text = value; }
        }

        public string CustomerName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }
        public decimal TotalOutstanding//SAmt
        {
            get { return Convert.ToDecimal(this.txtTotalOutstanding.Text); }
            set { this.txtTotalOutstanding.Text = value.ToString(); }
        }
        public decimal RepaymentAmount
        {
            get { return Convert.ToDecimal(this.txtRepaymentAmount.Text); }
            set { this.txtRepaymentAmount.Text = value.ToString(); }
        }

        public decimal InterestOnSamt
        {
            get { return Convert.ToDecimal(this.txtInterestOnSamt.Text); }
            set { this.txtInterestOnSamt.Text = value.ToString(); }
        }
        public decimal LateFee
        {
            get { return Convert.ToDecimal(this.txtLateFee.Text); }
            set { this.txtLateFee.Text = value.ToString(); }
        }
        //public decimal TotalInterest
        //{
        //    get { return Convert.ToDecimal(this.txtLateFee.Text); }
        //    set { this.txtLateFee.Text = value.ToString(); }
        //}
        public decimal OutstandingInterest
        {
            get { return Convert.ToDecimal(this.txtOutstandingInt.Text); }
            set { this.txtOutstandingInt.Text = value.ToString(); }
        }
        public DateTime CurrentSAmtDate
        {
            get { return Convert.ToDateTime(this.dtpCurSAmtDate.Text); }
            set { this.dtpCurSAmtDate.Text = value.ToString(); }
        }
        public decimal TotalAmt
        {
            get { return Convert.ToDecimal(this.txtTotalAmt.Text); }
            set { this.txtTotalAmt.Text = value.ToString(); }
        }

        public bool IncreaseAmt
        {
            get { return this.rdoIncrease.Checked; }
            set { this.rdoIncrease.Checked = value; }
        }

        public bool DecreaseAmt
        {
            get { return this.rdoDecrease.Checked; }
            set { this.rdoDecrease.Checked = value; }
        }

        public decimal SchargeRate
        {
            get;
            set;
        }
        public decimal Rate
        {
            get { return Convert.ToDecimal(this.txtRate.Text); }
            set { this.txtRate.Text = value.ToString(); }
        }
        public decimal OldIntRate
        {
            get;
            set;
        }
        public decimal NewIntRate
        {
            get { return Convert.ToDecimal(this.txtRate.Text); }
            set { this.txtRate.Text = value.ToString(); }
        }
        public decimal DocFee
        {
            get { return Convert.ToDecimal(this.txtDocumentFee.Text); }
            set { this.txtDocumentFee.Text = value.ToString(); }
        }

        public string LC_ChangeState { get; set; }
        private bool needToCheck = false;
        public decimal WithdrawableBalance { set; get; }
        public string InterestAccountDesp { set; get; }
        public string CreditAccountDesp { set; get; }
        public string CreditAccountCode { set; get; }
        public string InterestAccountCode { set; get; }
        public string Currency { set; get; }

        public decimal CurrentBal { set; get; }
        public decimal CBal { set; get; }
        public decimal MinimumBalance { set; get; }

        public bool FullSettlement { set; get; }

        public PFMDTO00072 loanDto { get; set; }
        public IList<PFMDTO00072> acctInfoList { get; set; }
        public string BLType { set; get; }
        public decimal SCharge { set; get; }
        private decimal Amount;
        public int TermNo { set; get; }
        private bool Cancel;
        public string AccountSign { get; set; }
        #endregion

        public LOMVEW00025()
        {
            InitializeComponent();
        }
        private void LOMVEW00025_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            //tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            if (this.ProgramPath.Contains("Entry"))
            {
                tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                this.Text = "Business Loan Repayment Entry";
                //this.gvAccountList.Visible = true;
                //this.gpLimitIncrease.Visible = false;
               // this.gvAccountList.Location = new Point(5, 391);
                this.Cancel = false;

                gvAccountList.Refresh();
                Amount = 0;
                lblActualCusGetAmt.Visible = false;
                txtActualCusGetAmt.Visible = false;
                LC_ChangeState = "D";
                this.gpLimitIncrease.Visible = false;
                this.gvAccountList.Visible = true;
                //this.gvAccountList.Location = new Point(5, 391);
                //this.Size = new System.Drawing.Size(561, 608);
                txtRepaymentAmount.Text = "";
                txtInterestOnSamt.Text = "";
                txtTotalAmt.Text = "";
                this.txtRepaymentAmountEncode.Text = string.Empty;
                this.txtRepaymentAmount.Text = string.Empty;
                this.SCharge = 0;
                this.txtLoanNo.Focus();
            }
            else if (this.ProgramPath.Contains("Enquiry"))
            {
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                this.Text = "Business Loan Repayment Enquiry";
                this.gvAccountList.Visible = false;
                this.Size = new System.Drawing.Size(563, 350);
                this.Cancel = false;
            }
            ClearControls();
            this.txtDateTime.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            this.txtLoanNo.Focus();

            */
            #endregion

            #region Seperating_EOD_Logic (Added By YMP at 30-07-2019, Modified by HMW at 26-08-2019)
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            
            //DateTime lastSettlementDate = this.controller.GetLastSettlementDate(CurrentUserEntity.BranchCode);

            this.txtDateTime.Text = systemDate.ToString("dd-MM-yyyy");

            //if (systemDate.ToString("dd-MM-yyyy") != lastSettlementDate.ToString("dd-MM-yyyy")) //Show Form
            //{
                if (this.ProgramPath.Contains("Entry"))
                {
                    tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                    this.Text = "Business Loan Repayment Entry";
                    this.Cancel = false;

                    gvAccountList.Refresh();
                    Amount = 0;
                    lblActualCusGetAmt.Visible = false;
                    txtActualCusGetAmt.Visible = false;
                    LC_ChangeState = "D";
                    this.gpLimitIncrease.Visible = false;
                    this.gvAccountList.Visible = true;
                    txtRepaymentAmount.Text = "";
                    txtInterestOnSamt.Text = "";
                    txtTotalAmt.Text = "";
                    this.txtRepaymentAmountEncode.Text = string.Empty;
                    this.txtRepaymentAmount.Text = string.Empty;
                    this.SCharge = 0;
                    this.txtLoanNo.Focus();
                }
                else if (this.ProgramPath.Contains("Enquiry"))
                {
                    tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
                    this.Text = "Business Loan Repayment Enquiry";
                    this.gvAccountList.Visible = false;
                    this.Size = new System.Drawing.Size(563, 350);
                    this.Cancel = false;
                }               
                ClearControls();
                //this.txtDateTime.Text = System.DateTime.Now.ToString("dd/MM/yyyy"); //commented by YMP (31-07-2019)
                this.txtLoanNo.Focus();
            /*
            }
            
            else //Don't show form after cut off
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                this.DisableControls("BLLimitChange.AllDisable");
            }
            */
            #endregion
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
            this.Cancel = true; 
            this.ClearControls();
        }

        private void LOMVEW00025_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    this.SelectNextControl(this.ActiveControl, true, true, true, true);
            //    e.Handled = true;
            //}
        }

        private void txtRepaymentAmount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /* public bool RepaymentCheck()
         {

             if (RepaymentAmount <= 0)
             {
                 CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90079);
                 txtRepaymentAmount.Focus();
                 return false;
             }
             else if (DecreaseAmt==true && RepaymentAmount > TotalOutstanding)
             {
                 CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90094); //Repayment Amount should not be greater than Total Outstanding Amount!.
                 txtRepaymentAmount.Focus();
                 return false;
             }
             else
             {
                 //this.txtRepaymentAmount.Text = txtRepaymentAmount.Text;
                 //DataBindAccountList();
                 //tsbCRUD.butSave.Focus();
                 return true;
             }
         }*/

        private void ClearControls()
        {
            this.txtLoanNo.Focus();
            this.txtRepaymentAmount.Enabled = true;
            this.gvAccountList.DataSource = null;
            this.gvAccountList.Rows.Clear();
            gvAccountList.Refresh();
            this.txtAccountNo.Text = "";
            this.txtTotalOutstanding.Text = "0.00";//SAMT
            //this.txtRepaymentAmount.Text = "0.00";
            this.txtInterestOnSamt.Text = "0.00";
            this.txtLateFee.Text = "0.00";
            this.txtTotalAmt.Text = "0.00";
            //this.txtRepaymentNo.Text = string.Empty;
            this.txtLoanNo.Text = string.Empty;
            this.txtTypeOfSecurity.Text = string.Empty;
            this.lblName.Text = string.Empty;
            this.dtpCurSAmtDate.Text = "";
            this.txtRepaymentAmount.Text = "0.00";
            this.txtRepaymentAmountEncode.Text = "0.00";
            txtRepaymentAmountEncode.Visible = true;
            txtRepaymentAmount.Visible = false;
            chkEdit.Checked = false;
            chkEditDocAmt.Checked = false;
            chkServiceCharges.Checked = false;
            txtDocumentFee.Text = "0.00";
            txtRate.Text = "0.00";
            needToCheck = false;
            this.txtTotalOutstanding.Text = "0.00";
            this.txtOutstandingInt.Text = "0.00";
            this.SCharge = 0;
            if (this.Text.Contains("Entry"))
            {
                this.gvAccountList.DataSource = null;
                gvAccountList.Visible = true;
                rdoDecrease.Checked = true;
                gpLimitIncrease.Visible = false;
                rdoIncrease.Checked = false;
                //this.gvAccountList.Location = new Point(5, 391);
            }
        }
       
        public void DataBindAccountList()
        {
            if (gvAccountList.RowCount > 0)
            {
                gvAccountList.DataSource = null;
                gvAccountList.Refresh();
            }
            if (this.ProgramPath.Contains("Entry") && txtRepaymentAmount.Text != "0.00" && !txtRepaymentAmount.Text.Contains("*") && txtRepaymentAmount.Text!="")
            {
                gvAccountList.AutoGenerateColumns = false;
                gvAccountList.Refresh();
                string Type = "LOANS";
                /*CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                string Acode = CreditAccountCode;*/

                //added by SHO [22-Nov-21] for Project loan type separate
                LOMDTO00401 loanCode = this.controller.GetLoansInterestLateFeeTODByRepayAmt_LCDecrease( txtLoanNo.Text, txtRepaymentAmount.Value, CurrentUserEntity.BranchCode);
                 CreditAccountCode = loanCode.LoanGLCode;
                 string Acode = CreditAccountCode;
                CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                 acctInfoList = new List<PFMDTO00072>();

                #region old for not supporting System.Data.Dataset (when running Deployment)
                ////1.for Repay+LateFee+TOD+outstandingOnTOD
                //decimal totalDrAmt = RepaymentAmount + InterestOnSamt + LateFee + OutstandingInterest;

                //object[] debitRow = { "1", AccountNo, totalDrAmt, 0.00, CustomerName };

                ////Amount = new DataSet();
                ////Amount.Tables.Add();
                ////Amount.Tables[0].Columns.Add("Amount");
                ////Amount.Tables[0].Columns.Add("AccountNo");
                ////Amount.Tables[0].Columns.Add("Desp");

                ////DataRow dr = Amount.Tables[0].NewRow();

                ////dr["Amount"] = Convert.ToString(totalDrAmt);
                ////dr["AccountNo"] = AccountNo;
                ////dr["Desp"] = CustomerName;

                ////Amount.Tables[0].Rows.Add(dr);

                ////2.for Repay
                //object[] creditRow = { "2", CreditAccountCode, 0.00, RepaymentAmount, CreditAccountDesp };

                //dr = Amount.Tables[0].NewRow();
                //dr["Amount"] = Convert.ToString(RepaymentAmount);
                //dr["AccountNo"] = CreditAccountCode;
                //dr["Desp"] = CreditAccountDesp;
                //Amount.Tables[0].Rows.Add(dr);
                //gvAccountList.Rows.Add(debitRow);
                //gvAccountList.Rows.Add(creditRow);

                //#region for InterestOnSamt+OutstandingInterest
                ////if (InterestOnSamt > 0 || OutstandingInterest>0)
                ////{
                ////    Type = "LSINCOME";
                ////    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                ////    Acode = CreditAccountCode;
                ////    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                ////    object[] creditRow1 = { "3", CreditAccountCode, 0.00, InterestOnSamt + OutstandingInterest, CreditAccountDesp };
                ////    gvAccountList.Rows.Add(creditRow1);

                ////    dr = Amount.Tables[0].NewRow();

                ////    dr["Amount"] = Convert.ToString(InterestOnSamt + OutstandingInterest);
                ////    dr["AccountNo"] = CreditAccountCode;
                ////    dr["Desp"] = CreditAccountDesp;
                ////    Amount.Tables[0].Rows.Add(dr);
                ////}
                //#endregion

                ////3.for InterestOnSamt
                //if (InterestOnSamt > 0 )
                //{
                //    Type = "LSINCOME";
                //    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                //    Acode = CreditAccountCode;
                //    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                //    object[] creditRow1 = { "3", CreditAccountCode, 0.00, InterestOnSamt , CreditAccountDesp };
                //    gvAccountList.Rows.Add(creditRow1);

                //    dr = Amount.Tables[0].NewRow();

                //    dr["Amount"] = Convert.ToString(InterestOnSamt);
                //    dr["AccountNo"] = CreditAccountCode;
                //    dr["Desp"] = CreditAccountDesp;
                //    Amount.Tables[0].Rows.Add(dr);
                //}
                ////4.for TOD
                //if ( OutstandingInterest > 0)
                //{
                //    Type = "BLOVERDRAFT";
                //    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                //    Acode = CreditAccountCode;
                //    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                //    object[] creditRow1 = { "4", CreditAccountCode, 0.00,  OutstandingInterest, CreditAccountDesp };
                //    gvAccountList.Rows.Add(creditRow1);

                //    dr = Amount.Tables[0].NewRow();

                //    dr["Amount"] = Convert.ToString(OutstandingInterest);
                //    dr["AccountNo"] = CreditAccountCode;
                //    dr["Desp"] = CreditAccountDesp;
                //    Amount.Tables[0].Rows.Add(dr);
                //}

                ////5.LateFee
                //if (LateFee > 0)
                //{
                //    Type = "BLTODLATEFEE";
                //    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                //    Acode = CreditAccountCode;
                //    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });
                //    object[] creditRow2 = { "5", CreditAccountCode, 0.00, LateFee, CreditAccountDesp };
                //    gvAccountList.Rows.Add(creditRow2);

                //    dr = Amount.Tables[0].NewRow();

                //    dr["Amount"] = Convert.ToString(LateFee);
                //    dr["AccountNo"] = CreditAccountCode;
                //    dr["Desp"] = CreditAccountDesp;
                //    Amount.Tables[0].Rows.Add(dr);
                //} 
                #endregion

                //1.for Repay+LateFee+TOD+outstandingOnTOD
                decimal totalDrAmt = RepaymentAmount + InterestOnSamt + LateFee + OutstandingInterest;

                PFMDTO00072 arr0 = new PFMDTO00072();
                arr0.CreditAccountNo1 = AccountNo; //curcontrol acctno
                arr0.DebitAmount1 = totalDrAmt;
                arr0.CreditAmount1 = 0;
                arr0.BankAccountDescription = CustomerName;
                acctInfoList.Add(arr0);

                //2.for Repay
                PFMDTO00072 arr1 = new PFMDTO00072();
                arr1.CreditAccountNo1 = CreditAccountCode;
                arr1.DebitAmount1 = 0;
                arr1.CreditAmount1 = RepaymentAmount;
                arr1.BankAccountDescription = CreditAccountDesp;
                acctInfoList.Add(arr1);

                //3.for InterestOnSamt
                if (InterestOnSamt > 0)
                {
                    Type = "LSINCOME";
                    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = CreditAccountCode;
                    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    PFMDTO00072 arr2 = new PFMDTO00072();
                    arr2.CreditAccountNo1 = CreditAccountCode;
                    arr2.DebitAmount1 = 0;
                    arr2.CreditAmount1 = InterestOnSamt;
                    arr2.BankAccountDescription = CreditAccountDesp;
                    acctInfoList.Add(arr2);
                }
                //4.for TOD
                if (OutstandingInterest > 0)
                {
                    Type = "LOANSTOD";
                    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = CreditAccountCode;
                    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    PFMDTO00072 arr3 = new PFMDTO00072();
                    arr3.CreditAccountNo1 = CreditAccountCode;
                    arr3.DebitAmount1 = 0;
                    arr3.CreditAmount1 = OutstandingInterest;
                    arr3.BankAccountDescription = CreditAccountDesp;
                    acctInfoList.Add(arr3);
                }

                //5.LateFee
                if (LateFee > 0)
                {
                    Type = "BLTODLATEFEE";
                    CreditAccountCode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { Type, this.Currency, CurrentUserEntity.BranchCode, true });
                    Acode = CreditAccountCode;
                    CreditAccountDesp = CXCLE00002.Instance.GetScalarObject<string>("COA.Client.SelectACName", new object[] { Acode, CurrentUserEntity.BranchCode, true });

                    PFMDTO00072 arr4 = new PFMDTO00072();
                    arr4.CreditAccountNo1 = CreditAccountCode;
                    arr4.DebitAmount1 = 0;
                    arr4.CreditAmount1 = LateFee;
                    arr4.BankAccountDescription = CreditAccountDesp;
                    acctInfoList.Add(arr4);                    
                }
                this.gvAccountList.AutoGenerateColumns = false;
                this.gvAccountList.DataSource = null;
                this.gvAccountList.CausesValidation = false;
                this.gvAccountList.DataSource = acctInfoList;
                this.gvAccountList.ReadOnly = true;
                this.gvAccountList.Refresh();
                tsbCRUD.butSave.Focus();
                Amount = 0;
            }
        }

        private void SetDisableControls()
        {
            this.txtLoanNo.Enabled=false;
            this.txtRepaymentAmount.Enabled = false;
            gbRepayment.Enabled = false;
        }        

        private void chkFullSettlement_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullSettlement.Checked)
            {
                RepaymentAmount = TotalOutstanding;
                DataBindAccountList();
            }
            else
            {
                txtRepaymentAmount.Focus();
                tsbCRUD.ButtonEnableDisabled(true, false, false, false, true, false, true);
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                    if ((RepaymentAmount <= 0) && (!string.IsNullOrEmpty(this.txtLoanNo.Text)))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90079);
                        txtRepaymentAmount.Focus();
                        return;
                    }
                    else if ((RepaymentAmount <= 0) && (string.IsNullOrEmpty(this.txtLoanNo.Text)))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);
                        txtLoanNo.Focus();
                        return;
                    }
                    else
                    {
                        //RepaymentCheck();
                        // return;
                    }
                    needToCheck = false;
                    if (rdoDecrease.Checked)  //Limit Decrease
                    {
                        // Added By AAM(10_Sep_2018)
                        string str=this.controller.CheckingCasesBLLimitChange(this.txtLoanNo.Text, CurrentUserEntity.BranchCode);
                        if (str == "-1")
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90211);
                            return;
                        }
                        //////////////

                        PFMDTO00028 cledgerDTO = Controller.CheckCBalMinBalAmoutByAcctno();
                        decimal bal = cledgerDTO.CurrentBal - cledgerDTO.MinimumBalance;
                        CBal = bal;
                        AccountSign = cledgerDTO.AccountSign;
                        if (bal >= TotalAmt)
                        {
                            TLMDTO00018 dto = this.controller.SaveDecrease(CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName, CurrentUserEntity.BranchCode);
                            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                            {
                                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                ClearControls();
                                return;
                            }
                            if (dto != null && dto.ResultCode == "0000")
                            {
                                //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);//Saving Successful.
                                this.Successful("MI00051", dto.voucherNo);    
                                ClearControls();
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);//Insufficient Balance! 
                            //ClearControls();
                            return;
                        }
                    }
                    else if (rdoIncrease.Checked) //Limit Increase
                    {
                        //Commented By ZMS(2.11.18) for Pristine Requirements
                        //if (txtLateFee.Text == "0.00" && txtOutstandingInt.Text == "0.00")
                        //{
                            decimal bal = this.CurrentBal - this.MinimumBalance;
                            CBal = this.CurrentBal;
                            //if (bal >= TotalAmt)
                            //{
                                TLMDTO00018 dto = this.controller.SaveIncrease(CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName, CurrentUserEntity.BranchCode);
                                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                                {
                                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                                    ClearControls();
                                    return;
                                }
                                if (dto != null && dto.ResultCode == "0000")
                                {
                                    //CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);//Saving Successful.
                                    this.Successful("MI00051", dto.voucherNo);      //Saving Successful.\n Generated {0} is {1}.
                                    ClearControls();
                                }
                            //}
                            //else
                            //{
                            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);//Insufficient Balance! 
                            //    ClearControls();
                            //    return;
                            //}
                        //}

                         //Commented By ZMS(2.11.18)

                        //else
                        //{
                        //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90191);//Do not allow limit change for this loans number!
                        //    ClearControls();
                        //    return;
                        //}
                    }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(ex.Message);                
                return;
            }
        }

        private void chkServiceCharges_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkServiceCharges.Checked)//To get Service Charges or NOt
            {
                PFMDTO00009 ratedto = new PFMDTO00009();
                ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSCHARGERATE", true, true });

                SchargeRate = ratedto.Rate;
                SCharge = ratedto.Rate;
            }
            else //Modify by HMW (8-1-2019)
            {
                SchargeRate = 0;
                SCharge = 0;
            }
        }

        private void chkEditDocAmt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditDocAmt.Checked == true)
            {
                txtDocumentFee.Enabled = true;
                txtDocumentFee.Focus();
            }
            else
            {
                txtDocumentFee.Enabled = false;
                //chkEdit.Focus();
            }
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEdit.Checked == true)
            {
                txtRate.Enabled = true;
                txtRate.Focus();
            }
            else
            {
                txtRate.Enabled = false;
            }
        }
        private void txtDocumentFee_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDocumentFee.Text))
                txtDocumentFee.Text = Double.Parse(txtDocumentFee.Text).ToString("N2");
            else
                txtDocumentFee.Text = "0.00";
        }

       
        public void Successful(string message, string voucherNo)
        {
            //this.txtEntryNo.Text = voucherNo;
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message, new object[] { "Loans Limit Change Voucher No.", voucherNo });
        }

        private void rdoIncrease_Click(object sender, EventArgs e)
        {
            ChangeView();
            if (rdoIncrease.Checked == true)//Added by HMW (06-04-2023) : To bind old interest rate in UI
            {
                this.Controller.CheckRepayAmount();
            }
            //if (rdoIncrease.Checked == true)
            //{
            //    this.gpLimitIncrease.Visible = true;
            //    this.gvAccountList.Visible = false;
            //    this.Size = new System.Drawing.Size(563, 350);
            //    txtRepaymentAmount.Focus();


            //    PFMDTO00009 ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
            //    txtDocumentFee.Text = Convert.ToString(ratedto.Rate);
            //    txtDocumentFee.Enabled = false;

            //    //ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSRATE", true, true });
            //    //txtRate.Text = Convert.ToString(ratedto.Rate);
            //    txtRate.Enabled = false;
            //}
            //else if (rdoIncrease.Checked == false)
            //{
            //    this.gpLimitIncrease.Visible = false;
            //    this.gvAccountList.Visible = true;
            //    //this.gvAccountList.Location = new Point(5, 391);
            //    this.Size = new System.Drawing.Size(561, 608);
            //    txtRepaymentAmount.Focus();

            //}
        }

        private void ChangeView()
        {
            if (rdoIncrease.Checked == true)
            {
                this.txtRepaymentAmount.Text = "0.00";
                this.txtRepaymentAmountEncode.Text = "0.00";
                txtRepaymentAmountEncode.Visible = true;
                txtRepaymentAmount.Visible = false;
                txtRepaymentAmountEncode.PasswordChar = '*';

                //lblActualCusGetAmt.Visible = true;
                //txtActualCusGetAmt.Visible = true;
                LC_ChangeState = "I";
                this.gpLimitIncrease.Visible = true;
                this.gvAccountList.Visible = false;
                //this.Size = new System.Drawing.Size(563, 350);
                //txtRepaymentAmount.Text = "";
                txtInterestOnSamt.Text = "";
                txtTotalAmt.Text = "";
                txtRepaymentAmountEncode.Focus();


                PFMDTO00009 ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
                txtDocumentFee.Text = Convert.ToString(ratedto.Rate);
                txtDocumentFee.Enabled = false;

                //ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSRATE", true, true });
                //txtRate.Text = Convert.ToString(ratedto.Rate);
                txtRate.Enabled = false;
            }
            else if (rdoIncrease.Checked == false)
            {
                this.txtRepaymentAmount.Text = "0.00";
                this.txtRepaymentAmountEncode.Text = "0.00";
                txtRepaymentAmountEncode.Visible = true;
                txtRepaymentAmount.Visible = false;
                txtRepaymentAmountEncode.PasswordChar = '*';

                lblActualCusGetAmt.Visible = false;
                txtActualCusGetAmt.Visible = false;
                LC_ChangeState = "D";
                this.gpLimitIncrease.Visible = false;
                this.gvAccountList.Visible = true;

                this.gvAccountList.DataSource = null;
                this.gvAccountList.Rows.Clear();
                gvAccountList.Refresh();

                //this.gvAccountList.Location = new Point(5, 391);
                //this.Size = new System.Drawing.Size(561, 608);
                txtRepaymentAmount.Text = "";
                txtInterestOnSamt.Text = "";
                txtTotalAmt.Text = "";
                txtRepaymentAmountEncode.Focus();

            }
        }
        private void rdoDecrease_Click(object sender, EventArgs e)
        {
            ChangeView();

            //if (rdoDecrease.Checked == true)
            //{
            //    this.gpLimitIncrease.Visible = false;
            //    this.gvAccountList.Visible = true;
            //    //this.gvAccountList.Location = new Point(5, 391);
            //    this.Size = new System.Drawing.Size(561, 608);
            //    txtRepaymentAmount.Focus();

            //}
            //if (rdoDecrease.Checked == false)
            //{
            //    this.gpLimitIncrease.Visible = true;
            //    this.gvAccountList.Visible = false;
            //    this.Size = new System.Drawing.Size(563, 350);
            //    txtRepaymentAmount.Focus();


            //    PFMDTO00009 ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "DOCFEE", true, true });
            //    txtDocumentFee.Text = Convert.ToString(ratedto.Rate);
            //    txtDocumentFee.Enabled = false;

            //    //ratedto = CXCLE00002.Instance.GetScalarObject<PFMDTO00009>("PFMORM00009.Client.SelectByCodeAndLastModify", new object[] { "LOANSRATE", true, true });
            //    //txtRate.Text = Convert.ToString(ratedto.Rate);
            //    txtRate.Enabled = false;
            //}
        }
        private void txtRepaymentAmount_Leave(object sender, EventArgs e)
        {
            if (needToCheck == false) return;

            if (txtRepaymentAmount.Text != txtRepaymentAmountEncode.Text)
            {
                if (MessageBox.Show("Invalid Amount", "Do You Want to re-enter Repayment amount?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtRepaymentAmount.Clear();
                    txtRepaymentAmountEncode.Clear();
                    txtRepaymentAmountEncode.Visible = true;
                    txtRepaymentAmountEncode.Focus();
                    return;
                }

            }
            else
            {
                txtRepaymentAmount.Text = Double.Parse(txtRepaymentAmount.Text).ToString("N2");
                chkServiceCharges.Focus();
                if (IncreaseAmt == true)
                {
                    // Added By AAM(10_Sep_2018)
                    string str = this.controller.CheckingCasesBLLimitChange(this.txtLoanNo.Text, CurrentUserEntity.BranchCode);
                    if (str == "-2")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90212);
                        return;
                    }
                    //////////////
                    chkServiceCharges.Focus();
                    LC_ChangeState = "I";                    
                    Amount = 0;
                }
                else if (DecreaseAmt == true)
                {
                    // Added By AAM(10_Sep_2018)
                    string str = this.controller.CheckingCasesBLLimitChange(this.txtLoanNo.Text, CurrentUserEntity.BranchCode);
                    if (str == "-2")
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90212);
                        return;
                    }
                    //////////////
                    gvAccountList.Focus();
                    //DataBindAccountList();
                    LC_ChangeState = "D";
                    //this.Controller.CheckRepayAmount();
                    //Amount = 0;
                }
                this.Controller.CheckRepayAmount();//Modify by HMW (06-04-2023)
                Amount = 0;
            }

        }
        private void txtRepaymentAmountEncode_Leave(object sender, EventArgs e)
        {
            needToCheck = true;
            txtRepaymentAmountEncode.Visible = false;
            txtRepaymentAmount.Visible = true;
            txtRepaymentAmount.Focus();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            ReCalculateLCIncreaseInterest();
        }

        private void txtRate_Enter(object sender, EventArgs e)
        {
            ReCalculateLCIncreaseInterest();
        }
        private void ReCalculateLCIncreaseInterest()
        {            
            // Currently, No Use. Htet Mon Win replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling  at 18-05-2023.
            /*
            decimal totalAmt ;
            TLMDTO00018 result = this.controller.GetNewInterestForNewRateLCIncrease(txtRate.Text, txtLoanNo.Text,txtRepaymentAmount.Value,CurrentUserEntity.BranchCode);
            this.txtInterestOnSamt.Text = result.Interest.ToString();
            totalAmt = Convert.ToDecimal(txtInterestOnSamt.Value) + Convert.ToDecimal(txtRepaymentAmount.Value);
            txtTotalAmt.Text = totalAmt.ToString();
            */

            this.Controller.CheckRepayAmount();
        }

        private void butEnquiry_Click(object sender, EventArgs e)
        {
            this.Controller.Call_AccountInformationEnquiry();//Added by HMW at 29-08-2019
        }

        //Added by HMW at 04-Sept-2019 : To clear all control data when Loan No is changed
        private void txtLoanNo_TextChanged(object sender, EventArgs e)
        {
            this.txtAccountNo.Text = "";
            this.lblName.Text = string.Empty;
            this.txtTypeOfSecurity.Text = string.Empty;
            this.txtTotalOutstanding.Text = "0.00";//SAMT

            this.txtRepaymentAmount.Text = "0.00";
            this.txtRepaymentAmount.Enabled = true;
            txtRepaymentAmount.Visible = false;
            this.txtRepaymentAmountEncode.Text = "0.00";
            txtRepaymentAmountEncode.Visible = true;

            this.dtpCurSAmtDate.Text = "";
            this.txtInterestOnSamt.Text = "0.00";
            this.txtLateFee.Text = "0.00";
            this.txtOutstandingInt.Text = "0.00";
            this.txtActualCusGetAmt.Text = "0.00";

            this.txtTotalAmt.Text = "0.00";

            chkEdit.Checked = false;
            chkEditDocAmt.Checked = false;
            chkServiceCharges.Checked = false;
            this.SCharge = 0;
            txtDocumentFee.Text = "0.00";
            txtRate.Text = "0.00";
            needToCheck = false;

            this.gvAccountList.DataSource = null;
            this.gvAccountList.Rows.Clear();
            gvAccountList.Refresh();
            if (this.Text.Contains("Entry"))
            {
                this.gvAccountList.DataSource = null;
                gvAccountList.Visible = true;
                rdoDecrease.Checked = true;
                gpLimitIncrease.Visible = false;
                rdoIncrease.Checked = false;
            }
        }
    }
}
