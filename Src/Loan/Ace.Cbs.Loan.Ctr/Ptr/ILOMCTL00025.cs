using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Data;

namespace Ace.Cbs.Loan.Ctr.Ptr
{

    public interface ILOMCTL00025 : IPresenter
    {
        ILOMVEW00025 View { get; set; }
        TLMDTO00018 SaveDecrease(int userId,string userName,string branchCode); //Decrease Amt
        TLMDTO00018 SaveIncrease(int userId, string userName, string branchCode);//Increase Amt
        bool GetLoanInfo();
        void CheckRepayAmount(); 
        PFMDTO00028 CheckCBalMinBalAmoutByAcctno();

        //Comment by HMW at 18-05-2023 (No Use. I replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling)
        //TLMDTO00018 GetNewInterestForNewRateLCIncrease(string intRate, string Lno, decimal RepayAmt,string branchCode);
        
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string LoanNo, decimal RepaymentAmount, string BranchCode);//added by SHO [22-Nov-21] for Project loan type separate
        string CheckingCasesBLLimitChange(string blNo, string sourceBr);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
        void Call_AccountInformationEnquiry();
        string GetCustomerName_LinebyLine_Wordbreak(string originalCustomerName);
    }

    public interface ILOMVEW00025
    {
        ILOMCTL00025 Controller { set; get; }

        string RepaymentNo { set; get; }

        string LoanNo { set; get; }
        string AccountNo { set; get; }

        string TypeOfSecurity { set; get; }
        decimal TotalOutstanding { set; get; }
        decimal RepaymentAmount { set; get; }
        //decimal TotalInterest { set; get; }

        decimal InterestOnSamt { set; get; }
        decimal LateFee { set; get; }
        decimal OutstandingInterest { set; get; }
        decimal TotalAmt {set; get; }

        DateTime CurrentSAmtDate { set; get; }
        decimal WithdrawableBalance { set; get; }
        string InterestAccountDesp { set; get; }
        string CreditAccountDesp { set; get; }
        string CustomerName { set; get; }
        string CreditAccountCode { set; get; }
        string InterestAccountCode { set; get; }
        string Currency { set; get; }

        bool FullSettlement { get;set; }
        //bool RepaymentCheck();
        void DataBindAccountList();

        //DataSet Amount { set; get; }
        IList<PFMDTO00072> acctInfoList { get; set; }

        decimal CurrentBal { set; get; }
        decimal CBal { set; get; }
        decimal MinimumBalance { set; get; }
        string BLType { set; get; }

        bool IncreaseAmt { get; set; }
        bool DecreaseAmt { get; set; }
        decimal Rate { get; set; }
        decimal OldIntRate { get; set; }//Added by HMW (18-04-2023)
        decimal NewIntRate { get; set; }//Added by HMW (18-04-2023)
        decimal DocFee { get; set; }
        decimal SCharge { set; get; }
        int TermNo { set; get; }
        string AccountSign { get; set; }

        string LC_ChangeState { get; set; }
    }

}
