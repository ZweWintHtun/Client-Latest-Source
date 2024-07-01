using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
  public interface IMNMSVE00071 :IBaseService
    {
      IList<MNMDTO00071> SelectSavingAccuredInterestAll();
      IList<MNMDTO00071> SelectSavingAccuredInterestByStartDateandEndDate(DateTime startDate, DateTime endDate);
      IList<MNMDTO00071> SelectSavingAccuredByCash(DateTime startDate, DateTime endDate);
      IList<MNMDTO00071> SelectSavingAccuredByTransfer(DateTime startDate, DateTime endDate);
    }
}
