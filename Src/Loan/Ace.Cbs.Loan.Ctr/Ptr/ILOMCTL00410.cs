using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00410 : IPresenter
    {
        ILOMVEW00410 View { get; set; }
        void Print();
        IList<LOMDTO00001> BindLoansBType();
    }
    public interface ILOMVEW00410
    {
        ILOMCTL00410 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BudgetYear { get; set; }
        string BusinessLoansTypes { get; set; }
        string rptname { get; set; }
    }
}
