using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00B55 : IDataRepository<TLMVIW00B13>
    {
        IList<TLMDTO00058> SelectDayBookDomesticReversal(string workStation, string sourceCur, DateTime requireDate);
    }
}
