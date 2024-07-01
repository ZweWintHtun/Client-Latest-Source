using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00104 : IPresenter
    {
        ILOMVEW00104 View { get; set; }
        bool checkFarmLoan(string loanNo);
        double GetInterestAmount(string LoanNo, string startDate);
        double GetPenalFee();
    }
    public interface ILOMVEW00104
    {
        ILOMCTL00104 Controller { set; get; }

        string LoanNo { set; get; }

        string AccountNo { set; get; }

        decimal TotalOutstanding { set; get; }

        decimal RepaymentAmount { set; get; }

        decimal TotalInterest { set; get; }

        decimal Penalties { set; get; }

        string startDate { get; set; }

        decimal TotalAmount { get; set; }
        void Failure(string message);
    }
}
