using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00063 : IDataRepository<TLMVIW00021>
    {
        IList<PFMDTO00042> SelectDepositListingByAll(string workStation);
        IList<PFMDTO00042> SelectDepositListingByCounterNo(string workStation, string counterNo);
        IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate, decimal minimumAmount, decimal maximumAmount, string acSign, string workStation);
       
    }
}
