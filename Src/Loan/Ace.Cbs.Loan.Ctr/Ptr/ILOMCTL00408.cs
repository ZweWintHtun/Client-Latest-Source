using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00408 : IPresenter
    {
        ILOMVEW00408 View { get; set; }
        void Print();
        IList<LOMDTO00001> BindLoansBType();

    }
    public interface ILOMVEW00408
    {
        ILOMCTL00408 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        decimal MaximumAmount { get; set; }
        decimal MinimumAmount { get; set; }
        string BudgetYear { get; set; }
        string BusinessLoansTypes { get; set; }
        string rptname { get; set; }
    }
}
