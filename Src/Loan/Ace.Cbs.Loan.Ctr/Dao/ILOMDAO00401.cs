using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00401 : IDataRepository<LOMORM00401>
    {
        int SelectMaxId();
        bool UpdateFirstDueDate(string lno, string soucrBr, decimal curSamtAmt, DateTime currentSamtDate, DateTime firstDueDate, DateTime updatedDate, int updatedUserId);
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string loanNo, decimal RepayAmount, string sourceBr);
        LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(string loanNo, decimal RepayAmount, decimal rate, string sourceBr);//Modified by HMW [27-03-2023]:For Interest Rate Binding
        
        //Comment and Modified by HMW at 30-08-2019 : To remove no need updating fields
        /*
        bool UpdateOutstandingBalByRepaymentAmt(string lno, string acctno, string soucrBr, decimal curSamtAmt, DateTime currentSamtDate, decimal totalInt,
                                                DateTime intPaidDate, decimal totalLateFee, DateTime latefeePaidDate, decimal tODAmt, DateTime tODPaidDate,
                                                DateTime firstDueDate, DateTime updatedDate, int updatedUserId);
        */
        bool UpdateOutstandingBalByRepaymentAmt(string lno, string acctno, string soucrBr, decimal curSamtAmt,
                                                decimal repayInt, DateTime intPaidDate, DateTime updatedDate, int updatedUserId);
        IList<LOMDTO00401> SelectBusinessLoansDueForInterest(DateTime Date,DateTime eDate,string branchCode);
    }
}
