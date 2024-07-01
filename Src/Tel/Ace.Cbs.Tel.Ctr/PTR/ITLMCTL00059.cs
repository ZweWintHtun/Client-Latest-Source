using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00059 :IPresenter
    {
       ITLMVEW00059 View { get; set; }
       IList<TLMDTO00001> ShowEncashOutstandingReport(string sourceBr);

    }

   public interface ITLMVEW00059 
   {
      ITLMCTL00059 Controller { get; set; }


   }
}
