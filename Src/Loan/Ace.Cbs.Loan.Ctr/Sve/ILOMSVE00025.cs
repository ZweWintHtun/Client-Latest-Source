using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Data;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00025 : IBaseService
    {
        TLMDTO00018 isValidLoanNo(string lno, string sourceBr);
        //TLMDTO00018 RepayLoan(TLMDTO00018 loanDto, bool fullSettlement, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo, int userId, string sourceBr);
        
        TLMDTO00018 RepayDecreaseAmount(TLMDTO00018 loanDto, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo,
            IList<PFMDTO00072> acctInfoList, int userId, string sourceBr, decimal cBal, DateTime curSamtDate, int termNo);
        
        TLMDTO00018 RepayIncreaseAmount(TLMDTO00018 loanDto, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo,
           decimal interestOnSamt, decimal repayAmt, int userId, string sourceBr, decimal cBalLatest, DateTime curSamtDate, int termNo, decimal SCharge, decimal rate, decimal docFee);
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(string LoanNo, decimal RepaymentAmount, decimal Rate, string BranchCode);//Modified by HMW [27-03-2023]:For Interest Rate Binding
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string LoanNo, decimal RepaymentAmount, string BranchCode);//added by SHO [22-Nov-21] for Project loan type separate
        PFMDTO00028 CheckCBalMinBalAmoutByAcctno(string acctno);

        //Comment by HMW at 18-05-2023 (No Use. I replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling)        
        //TLMDTO00018 GetNewInterestForNewRateLCIncrease(string intRate, string Lno, decimal RepayAmt, string sourceBr);

        string CheckingCasesBLLimitChange(string blNo, string sourceBr);
    }
}
