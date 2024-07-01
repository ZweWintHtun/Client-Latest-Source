using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00D54 : IDataRepository<TLMVIW00D12>
    {
        IList<TLMDTO00058> SelectDayFixedReversal(string workStation, string sourceCur, DateTime requireDate);
    }
}
