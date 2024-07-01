using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00C53 : IDataRepository<TLMVIW00C11>
    {
        IList<TLMDTO00058> SelectDayBookCurrentHome(string workStation, string sourceCur, DateTime requireDate);
    }
}
