using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
  public interface IMNMCTL00071 : IPresenter
    {
      IMNMVEW00071 View { get; set; }
      IList<MNMDTO00071> SelectSavingAccuredInterestAll();
      IList<MNMDTO00071> SelectSavingAccuredInterestBetweenStartDateandEndDate();
      IList<MNMDTO00071> SelectSavingAccuredInterestByCash();
      IList<MNMDTO00071> SelectSavingAccuredInterestByTransfer();
    }

  public interface IMNMVEW00071 
  {
      IMNMCTL00071 Controller { get; set; }
      DateTime StartDate { get; set; }
      DateTime EndDate { get; set; }
  }

}
