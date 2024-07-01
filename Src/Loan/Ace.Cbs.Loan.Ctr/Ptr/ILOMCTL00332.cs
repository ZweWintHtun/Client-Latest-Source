using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    //Created By HWKO (10-Nov-2017)
    public interface ILOMCTL00332
    {
        ILOMVEW00332 View { get; set; }
        void Print();
    }

    public interface ILOMVEW00332
    {
        ILOMCTL00332 Controller { get; set; }

        string SourceBranch { get; set; }
        string Currency { get; set; }
        //string BudgetYear { get; set; }
    }
}
