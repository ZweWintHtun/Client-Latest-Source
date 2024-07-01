using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00046 : IPresenter
    {
        ITLMVEW00046 View { get; set; }
        IList<TLMDTO00004> HomeTransactionListingByBranch();
        IList<TLMDTO00004>  ActiveTransactionListingByBranch();
    }

    public interface ITLMVEW00046
    {
        ITLMCTL00046 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string BranchCode { get; set; }
        string TranType { get; set; }
        bool IsReversal { get; set; }
    }
}
