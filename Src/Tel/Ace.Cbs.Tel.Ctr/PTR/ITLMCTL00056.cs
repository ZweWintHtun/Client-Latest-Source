using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00056 : IPresenter
    {
        ITLMVEW00056 View { get; set; }
        IList<TLMDTO00017> ShowDrawingOutStandingByDrawingAmountOutstand();
    }

    public interface ITLMVEW00056
    {
        ITLMCTL00056 Controller { get; set; }
    }
}
