using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00057 : IPresenter
    {
       ITLMVEW00057 View { get; set; }
       IList<TLMDTO00017> ShowDrawingOutstandingReport();
       IList<TLMDTO00017> ShowDrawingOutStandingByIncomeOutstand();
       IList<TLMDTO00017> ShowDrawingOutStandingByDrawingAmountOutstand();
    }

   public interface ITLMVEW00057
   {
       ITLMCTL00057 Controller { get; set; }
   }
}
