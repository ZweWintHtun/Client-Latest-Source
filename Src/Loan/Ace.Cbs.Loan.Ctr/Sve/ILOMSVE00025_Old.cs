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
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt(string LoanNo, decimal RepaymentAmount, string BranchCode);
        PFMDTO00028 CheckCBalMinBalAmoutByAcctno(string acctno);

    }
}
