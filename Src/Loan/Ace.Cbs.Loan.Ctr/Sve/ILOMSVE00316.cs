using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00316 : IBaseService
    {
        ILOMDAO00316 PLRepaymentScheduleListingDAO { get; set; }

        IList<LOMDTO00316> SelectByPLNO(LOMDTO00316 dto);
        IList<LOMDTO00316> SelectByDueDateForPLIntDuePreListing(LOMDTO00316 dto);
        IList<LOMDTO00316> SelectPLOverdrawnListing(LOMDTO00316 dto);
        IList<LOMDTO00316> SelectPLOverdrawnListingByCompanyName(LOMDTO00316 dto);
        IList<LOMDTO00316> SelectCompanyName();
        IList<LOMDTO00316> SelectPLRepaymentListing(LOMDTO00316 dto);
        
    }
}
