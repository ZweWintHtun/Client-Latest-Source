using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (27-Oct-2017)
    public interface ILOMCTL00330
    {
        ILOMVEW00330 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00330
    {
        ILOMCTL00330 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        string BudgetYear { get; set; }
    }
}
