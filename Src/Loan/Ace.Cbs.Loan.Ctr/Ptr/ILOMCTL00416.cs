using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00416 : IPresenter
    {
        ILOMVEW00416 View { get; set; }
        void Print();
        IList<LOMDTO00001> BindLoansBType();
    }
    public interface ILOMVEW00416
    {
        ILOMCTL00416 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BudgetYear { get; set; }
        string BusinessLoansTypes { get; set; }
        string rptname { get; set; }
    }
}
