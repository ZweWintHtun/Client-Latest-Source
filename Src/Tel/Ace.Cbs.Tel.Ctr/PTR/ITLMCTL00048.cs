using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
  public interface ITLMCTL00048 :IPresenter
    {
      ITLMVEW00048 View { get; set; }
      IList<TLMDTO00004> HomeIncomeListingByAllBranch();
      IList<TLMDTO00004> ActiveIncomeListingByAllBranch();

    }

  public interface ITLMVEW00048 
  {
      ITLMCTL00048 Controller { get; set; }
      string BranchCode { get; set; }
      DateTime StartDate { get; set; }
      DateTime EndDate { get; set; }     
  }


}
