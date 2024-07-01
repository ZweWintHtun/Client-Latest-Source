using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
  public  interface ITLMDAO00A54 : IDataRepository<TLMVIW00A12>
    {
      IList<TLMDTO00058> SelectDayBookSavings(string workStation, string sourceCur, DateTime requireDate);
    }
}
