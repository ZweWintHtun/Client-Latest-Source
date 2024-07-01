using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00053 : IPresenter
    {
        ITLMVEW00053 View { get; set; }
        IList<TLMDTO00058> SelectCurrentDayBook();
        IList<TLMDTO00058> SelectCurrentReversalDayBook();
        IList<TLMDTO00058> SelectCurrentHomeDayBook();
        IList<TLMDTO00058> SelectCurrentHomeReversalDayBook();
    }

    public interface ITLMVEW00053 
    {
        ITLMCTL00053 Controller { get; set; }
        DateTime RequireDate { get; set; }
        string CurrencyCode { get; set; }
        string BranchCode { get; set; }
        string AccountSign { get; set; }
        bool IsSettlementDate { get; set; }
        bool SortByTime { get; set; }

    }
}
