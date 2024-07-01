//----------------------------------------------------------------------
// <copyright file="LOMVEW00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> TAK </CreatedUser>
// <CreatedDate> 12-01-2015 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using System.Globalization;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00013 : BaseDockingForm, ILOMVEW00013
    {
        #region "Constructors"
        public LOMVEW00013()
        {
            InitializeComponent();
        }
        #endregion        

        #region "Properties"

        //public TLMDTO00018 loanList = new TLMDTO00018();
        IList<PFMDTO00017> caofList = new List<PFMDTO00017>();
        IList<MNMDTO00012> legalIntList = new List<MNMDTO00012>();
        IList<MNMDTO00011> commitList = new List<MNMDTO00011>();
        IList<LOMDTO00021> liList = new List<LOMDTO00021>();
        IList<MNMDTO00027> schargeList = new List<MNMDTO00027>();
                
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

        public string Type
        {
            get { return this.txtType.Text; }
            set { this.txtType.Text = value; }
        }

        public decimal Amount
        {
            get
            {
                if (this.txtAmount.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtAmount.Text.Trim());
            }

            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        public decimal OutstandingInt
        {
            get
            {
                if (this.txtOutstandingInt.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtOutstandingInt.Text.Trim());
            }

            set { this.txtOutstandingInt.Text = Convert.ToString(value); }
        }

        public decimal OutstandingChg
        {
            get
            {
                if (this.txtOutstandingChg.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtOutstandingChg.Text.Trim());
            }

            set { this.txtOutstandingChg.Text = Convert.ToString(value); }
        }

        public decimal PenlityFees
        {
            get
            {
                if (this.txtPenlityFees.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtPenlityFees.Text.Trim());
            }

            set { this.txtPenlityFees.Text = Convert.ToString(value); }
        }

        public decimal ServiceCharges
        {
            get
            {
                if (this.txtServiceCharges.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtServiceCharges.Text.Trim());
            }

            set { this.txtServiceCharges.Text = Convert.ToString(value); }
        }

        public decimal CommitmentFees
        {
            get
            {
                if (this.txtCommitmentFees.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtCommitmentFees.Text.Trim());
            }

            set { this.txtCommitmentFees.Text = Convert.ToString(value); }
        }

        public decimal Total
        {
            get
            {
                if (this.txtTotal.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtTotal.Text.Trim());
            }

            set { this.txtTotal.Text = Convert.ToString(value); }
        }

        public decimal Interest
        {
            get
            {
                if (this.txtInterest.Text.Trim().Equals(string.Empty))
                    return 0;
                else
                    return Convert.ToDecimal(this.txtInterest.Text.Trim());
            }

            set { this.txtInterest.Text = Convert.ToString(value); }
        }


        #endregion

        #region "Variables & Lists"
        private bool isSaveValidate { get; set; }
        private IList<TLMDTO00018> loansList;
       
        #endregion        

        #region "Controllers"
        private ILOMCTL00013 controller;
        public ILOMCTL00013 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return this.controller; }            
        }        
        #endregion

        #region "Events"
        private void LOMVEW00013_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true;
            }
        }

        //private void txtLoanNo_Leave(object sender, EventArgs e)
        //{
        //    if (!this.isCanExit)
        //    {
        //        if (String.IsNullOrEmpty(this.txtLoanNo.Text))
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);     //Invalid Loan No.
        //            return;
        //        }

        //        loanList = controller.SelectByLoanNo(this.txtLoanNo.Text);

        //        if (loanList != null)
        //        {
        //            caofList = controller.SelectCAOFData(loanList.AccountNo);
        //            legalIntList = controller.SelectlegalIntData(loanList.Lno);
        //            commitList = controller.SelectCommitFeeByLoanNo(loanList.AccountNo, loanList.Lno);
        //            liList = controller.SelectLIByLoanNo(loanList.AccountNo, loanList.Lno);
        //            schargeList = controller.SelectSChargeByLoanNo(loanList.AccountNo, loanList.Lno);


        //            this.txtAccountNo.Text = loanList.AccountNo;
        //            this.txtType.Text = loanList.AType;
        //            this.txtAmount.Text = loanList.SAmount == null ? "0.00" : String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", loanList.SAmount);

        //            if (!legalIntList.Equals(null) && !legalIntList.Count.Equals(0))
        //            {
        //                this.txtOutstandingInt.Text = String.Format(CultureInfo.InvariantCulture,
        //                                                            "{0:0,0.00}",
        //                                                            legalIntList.Where(x => x.Type == "INTEREST" && x.LNo == loanList.Lno).Sum(x => x.Amount).ToString());
        //                this.txtOutstandingChg.Text = String.Format(CultureInfo.InvariantCulture,
        //                                                            "{0:0,0.00}",
        //                                                            legalIntList.Where(x => x.Type == "CHARGES" && x.LNo == loanList.Lno).Sum(x => x.Amount).ToString());
        //                this.txtPenlityFees.Text = String.Format(CultureInfo.InvariantCulture,
        //                                                            "{0:0,0.00}",
        //                                                            (Convert.ToDecimal(txtOutstandingInt.Text) * 13 / 100 / 366 * (DateTime.Now.Subtract(legalIntList[0].Date_Time).Days)).ToString());
        //                this.txtTotal.Text = String.Format(CultureInfo.InvariantCulture,
        //                                                    "{0:0,0.00}",
        //                                                    (
        //                                                        Convert.ToDecimal("0") +         //Where 0 for ODInt
        //                                                        Convert.ToDecimal("0") +         //Where 0 for LoanInt                                                            
        //                                                        Convert.ToDecimal(txtOutstandingInt.Text) +
        //                                                        Convert.ToDecimal(txtOutstandingChg.Text) +
        //                                                        Convert.ToDecimal(txtPenlityFees.Text) +
        //                                                        Convert.ToDecimal(txtServiceCharges.Text) +
        //                                                        Convert.ToDecimal(txtPenlityFees.Text) +
        //                                                        Convert.ToDecimal(txtCommitmentFees.Text)
        //                                                    ).ToString());
        //            }
        //            else
        //            {
        //                this.txtOutstandingInt.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //                this.txtOutstandingChg.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //                this.txtPenlityFees.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //                this.txtTotal.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //            }

        //            if (!commitList.Equals(null) && !commitList.Count.Equals(0))
        //            {
        //                this.txtCommitmentFees.Text = String.Format(CultureInfo.InvariantCulture,
        //                                                            "{0:0,0.00}",
        //                                                            commitList.Where(x => x.LNo == loanList.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12).ToString());
        //            }
        //            else
        //            {
        //                this.txtCommitmentFees.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //            }

        //            if (!liList.Equals(null) && !liList.Count.Equals(0))
        //            {
        //                this.txtInterest.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", liList.Where(x => x.LNo == loanList.Lno).Sum(x => x.Q1 + x.Q2 + x.Q3 + x.Q4).ToString());
        //            }
        //            else
        //            {
        //                this.txtInterest.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //            }

        //            if (!schargeList.Equals(null) && !schargeList.Count.Equals(0))
        //            {
        //                this.txtServiceCharges.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", schargeList.Where(x => x.LNo == loanList.Lno).Sum(x => x.M1 + x.M2 + x.M3 + x.M4 + x.M5 + x.M6 + x.M7 + x.M8 + x.M9 + x.M10 + x.M11 + x.M12).ToString());
        //            }
        //            else
        //            {
        //                this.txtServiceCharges.Text = String.Format(CultureInfo.InvariantCulture, "{0:0,0.00}", 0);
        //            }

        //            this.dgvLoanACClose.DataSource = null;
        //            this.dgvLoanACClose.AutoGenerateColumns = false;
        //            this.dgvLoanACClose.DataSource = caofList;
        //            this.dgvLoanACClose.Refresh();
        //            this.isCanExit = true;
        //          //  this.tsbCRUD.butSave.Focus();
        //        }
        //        else
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057);     //Loans No. Already Closed!
        //            this.txtLoanNo.Focus();
        //            this.isCanExit = true;
        //        }
        //    }
            
        //}

        private void LOMVEW00013_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializedControls();
            this.txtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
        }
        
        private void txtLoanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {           
            this.InitializedControls();
            this.controller.ClearAllCustomErrors();          
        }        

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {           
            this.Close();          
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {       

            if (this.controller.ValidateForm() && LoansCount_Check())
            {
                if (String.IsNullOrEmpty(this.controller.loanDto.AType))
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055); //Invalid Loan No.
                    return;
                }
                
                else if (this.controller.loanDto.AType == "LOANS")
                {
                   // decimal cledgerBal = caofList.Where(x => x.CledgerAccountNo == AccountNo).Sum(x => x.CurrentBal + x.OverdraftLimit - x.MinimumBalance);
                    decimal cledgerBal = caofList.First().CurrentBal + caofList.First().OverdraftLimit - caofList.First().MinimumBalance;
                    //decimal cledgerBal = 0.00M;
                    if (cledgerBal >= (this.Total + this.controller.loanDto.SAmount))
                    {
                        Vou_Update(false, 0);   //To Update Tables                   
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);
                        InitializedControls();
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV90097"); //Insufficient Balance, cannot update!  
                        this.txtLoanNo.Focus();
                    }
                }

                else if (this.controller.loanDto.AType == "OVERDRAFT")
                {
                    decimal cledgerBal = caofList.Where(x => x.CledgerAccountNo == AccountNo).Sum(x => x.CurrentBal);
                    decimal reqAmount = (cledgerBal < 0) ? cledgerBal + Convert.ToDecimal(this.controller.loanDto.SAmount) : Convert.ToDecimal(this.controller.loanDto.SAmount);

                    Vou_Update(true, reqAmount);   //To Update Tables                   

                    if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);
                        InitializedControls();
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);  
                        this.txtLoanNo.Focus();
                    }
                }

            }            
        }

        #endregion

        #region "Methods"        

        public void BindInfo(IList<PFMDTO00017> caof_List)
        {
            this.dgvLoanACClose.DataSource = null;
            this.dgvLoanACClose.AutoGenerateColumns = false;
            this.dgvLoanACClose.DataSource = this.caofList = caof_List;
            this.dgvLoanACClose.Refresh();
        }

        public void InitializedControls()
        {
            this.lblDateDisplay.Text = DateTime.Now.ToString("dd,MM,yyyy");
            this.txtLoanNo.Text = "";
            this.txtAccountNo.Text = "";
            this.txtType.Text = "";
            this.txtAmount.Text = "";
            this.txtInterest.Text = "";
            this.txtCommitmentFees.Text = "";
            this.txtOutstandingInt.Text = "";
            this.txtOutstandingChg.Text = "";
            this.txtPenlityFees.Text = "";
            this.txtTotal.Text = "";
            this.dgvLoanACClose.DataSource = null;
            this.txtLoanNo.Focus();
        }

        private bool LoansCount_Check()
        {
            string acctNo = caofList.Where(x => x.CledgerAccountNo == AccountNo).First().CledgerAccountNo.ToString();
            //if (acctNo != "")
            //{
            //    return true;
            //}
            //else
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90076);  //  MV90076 => INVALID LOAN COUNT!
            //    return false;
            //}
            return acctNo != "";
        }

        private void Vou_Update(bool isOD,decimal reqAmount)
        {
            string acname ="Loans";
            CurrencyDTO currencyDTO = CXCOM00011.Instance.GetScalarObject<CurrencyDTO>("Cur.HomeCur.Select", new object[] { true });
            DateTime SettlementDate = CXCLE00002.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode, true });
            //IList<ChargeOfAccountDTO> CoaInfo = CXCLE00001.Instance.COASelectAccountNoAndAccountName(acname, acname, currencyDTO.Cur, CurrentUserEntity.BranchCode);
            ChargeOfAccountDTO CoaInfo = new ChargeOfAccountDTO();
            CoaInfo.ACode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.AccountClose.Select", new object[] { acname, currencyDTO.Cur, CurrentUserEntity.BranchCode, true });
            CoaInfo.ACName = acname;
            
            string creditTranCode = CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("TranType.Client.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode) }).TransactionCode;
            string debitTranCode = CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("TranType.Client.SelectByStatus", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode) }).TransactionCode;
            string creditVoucher = CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("TranType.Client.SelectByTranCode", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode) }).Status;
            string debitVoucher = CXCLE00002.Instance.GetScalarObject<TLMDTO00005>("TranType.Client.SelectByStatus", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode) }).Status;
            if (currencyDTO == null || SettlementDate == null || CoaInfo == null || creditTranCode == null || debitTranCode == null || creditVoucher == null || debitVoucher == null)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055); //Invalid Loan No.
                return;
            }
            controller.Save(this.controller.loanDto,caofList,legalIntList,commitList,liList,schargeList,currencyDTO.Cur,SettlementDate,CoaInfo,creditVoucher,debitVoucher, creditTranCode,debitTranCode,isOD,reqAmount);
        }

       

        #endregion

    
                
    }
}
