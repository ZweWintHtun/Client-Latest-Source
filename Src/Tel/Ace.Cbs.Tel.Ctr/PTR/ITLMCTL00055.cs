using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00055 : IPresenter
    {
        ITLMVEW00055 View { get; set; }
        IList<TLMDTO00058> SelectDomesticDayBook();
        IList<TLMDTO00058> SelectDomesticReversalDayBook();
        IList<TLMDTO00058> SelectDomesticHomeDayBook();
        IList<TLMDTO00058> SelectDomesticHomeReversalDayBook();
    }

    public interface ITLMVEW00055
    {
        ITLMCTL00055 Controller { get; set; }
        DateTime RequireDate { get; set; }
        string CurrencyCode { get; set; }
        string BranchCode { get; set; }
        string AccountSign { get; set; }
        bool IsSettlementDate { get; set; }
        bool SortByTime { get; set; }
    }
}
