using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00089 : IPresenter
    {
        ILOMVEW00089 View { get; set; }
        void CalculateInterest();
    }

    public interface ILOMVEW00089
    {
        ILOMCTL00089 Controller { get; set; }

        DateTime WithdrawDate { get; set; }
        DateTime RepaymentDate { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
