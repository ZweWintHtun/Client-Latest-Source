using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
  public  interface ITLMDAO00D53 :IDataRepository<TLMVIW00D11>
    {

      IList<TLMDTO00058> SelectDayBookCurrentHomeReversal(string workStation, string sourceCur, DateTime requireDate);
    }
}
