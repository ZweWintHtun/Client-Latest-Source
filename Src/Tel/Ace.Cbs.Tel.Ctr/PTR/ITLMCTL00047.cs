using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public  interface ITLMCTL00047 : IPresenter
    {
      ITLMVEW00047 View { get; set; }
      IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch();
      IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(string forReversalCase);
    }

  public interface ITLMVEW00047 
  {
      ITLMCTL00047 Controller { get; set; }

      DateTime StartDate { get; set; }
      DateTime EndDate { get; set; }
      string BranchCode { get; set; }
      string SourceBr { get; set; }
      string Branch { get; set; }
  }
}
