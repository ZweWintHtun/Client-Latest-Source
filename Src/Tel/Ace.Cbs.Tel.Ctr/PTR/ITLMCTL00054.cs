using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00054 : IPresenter
    {
        ITLMVEW00054 View { get; set; }
        IList<TLMDTO00058> SelectSavingDayBook();
        IList<TLMDTO00058> SelectSavingReversalDayBook();
        IList<TLMDTO00058> SelectFixedDayBook();
        IList<TLMDTO00058> SelectFixedReversalDayBook();
    }

    public interface ITLMVEW00054
    {
        ITLMCTL00054 Controller { get; set; }
        DateTime RequireDate { get; set; }
        string CurrencyCode { get; set; }
        string BranchCode { get; set; }

        string AccountSign { get; set; }

        bool IsSettlementDate { get; set; }
    }
}
