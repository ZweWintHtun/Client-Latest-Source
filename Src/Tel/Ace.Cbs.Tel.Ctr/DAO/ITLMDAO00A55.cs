using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00A55 : IDataRepository<TLMVIW00A13>
    {
        IList<TLMDTO00058> SelectDayBookDomestic(string workStation, string sourceCur, DateTime requireDate);
    }
}
