using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00407:IPresenter
    {
        ILOMVEW00407 View { get; set; }
        void CalculateInterest();
    }
    public interface ILOMVEW00407
    {
        ILOMCTL00407 Controller { get; set; }

        DateTime WithdrawDate { get; set; }
        DateTime RepaymentDate { get; set; }

        void Successful(string message);
        void Failure(string message);

        string sourceBranch { get; set; }
        int userName { get; set; }
        //string cur { get; set; }
    }
}
