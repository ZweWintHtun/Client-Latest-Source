using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00092 : IBaseService
    {
        bool checkFarmLoan(string loanNo);
        LOMDTO00078 isValidLoanNo(string lno, string sourceBr);
        LOMDTO00078 RepayFarmLoan(LOMDTO00078 loanDto, string lno, string accountNo, decimal repaymentAmount, decimal interest, decimal penalties, string userNo, int userId, string sourceBr, string accountCreditCode, string interestCode, string penaltiesCode);
        IList<LOMDTO00078> getLoanAcctNo(string loanNo, string sourceBr, string type);
        double GetInterestAmount(string LoanNo, string startDate, decimal repaymentAmount, string budgetYear);
        double GetHomeAmount(string vrNo);
        double GetPenalFee(string LoanNo, decimal repaymentAmount, string sourceBr);
    }
}
