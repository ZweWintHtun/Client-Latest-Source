using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00078 : IDataRepository<LOMORM00078>
    {
        IList<LOMDTO00078> SelectByGroupNo(string groupNo);
        IList<LOMDTO00078> SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(string acctNo, string lno, DateTime withdrawDate, DateTime repaymentDate);
        bool UpdateLastIntDate(DateTime lastIntDate, DateTime updatedDate, int updatedUserId, string lno, string acctno, string sourceBr);
        IList<LOMDTO00085> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth);
        IList<LOMDTO00078> SelectFarmLoanByAcctNoAndLNoAndWithdrawDate(string acctNo, string lno, DateTime emonth);
        #region LoanRepayment Methods
        bool checkFarmLoan(string loanNo);
        LOMDTO00078 GetLoansAccountInformationWithInterest(string loanNo, string sourceBr);
        LOMDTO00078 RepayFarmLoan(string lno, string accountNo, decimal repaymentAmount, decimal interest, decimal penalties, string userNo, int userId, string sourceBr, string vouno, string accountCreditCode, string interestCode, string penaltiesCode);
        IList<LOMDTO00078> getLoanAcctNo(string loanType, string sourceBr, string type);
        double GetInterestAmount(string LoanNo, string startDate, decimal repaymentAmount, string budgetYear);
        double GetHomeAmount(string vrNo);
        double GetPenalFee(string LoanNo, decimal repaymentAmount, string sourceBr);
        #endregion    

        LOMDTO00078 GetFarmLoansByLnoAndSourceBr(string loanNo, string sourceBr);
        bool UpdateFarmLoanByLnoAndSourceBr(LOMDTO00078 loanDto);
        IList<LOMDTO00078> CheckDataForDeleteLSProductType(string landType, string businessType);
    }
}
