using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00092 : IPresenter
    {
        ILOMVEW00092 View { get; set; }       
        bool checkFarmLoan(string loanNo);
        LOMDTO00078 Save(decimal penalties);
        IList<LOMDTO00078> getLoanAcctNo(string loanNo, string sourceBr, string type);
        double GetInterestAmount(string LoanNo, string startDate);
        double GetHomeAmount(string vrNo);
        double GetPenalFee();
        //bool GetLoanInfo();
    }
    public interface ILOMVEW00092
    {
        ILOMCTL00092 LoanRepaymentController { set; get; }

        string RepaymentNo { set; get; }

        string VrNo { get; set; }

        string LoanNo { set; get; }

        string AccountNo { set; get; }

        decimal TotalOutstanding { set; get; }

        decimal RepaymentAmount { set; get; }

        decimal TotalInterest { set; get; }

        string Penalties { set; get; }

        decimal WithdrawableBalance { set; get; }
        string InterestAccountDesp { set; get; }
        string CreditAccountDesp { set; get; }
        string CustomerName { set; get; }
        string CreditAccountCode { set; get; }
        string DebitAccountCode { set; get; }
        string InterestAccountCode { set; get; }
        string Currency { set; get; }
        string PenalitesAccountCode { get; set; }
        string PenalitiesAccountDesp { get; set; }

        string startDate { get; set; }

        void RepaymentCheck();
        void Successful(string message);
        void Failure(string message);
        void BindInterestAcctNo();
        void BindPenalties();
        void BindAcctNo();
    }
}
