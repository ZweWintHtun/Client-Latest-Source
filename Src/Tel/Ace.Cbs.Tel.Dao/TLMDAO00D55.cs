using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Tel.Dao
{
   public class TLMDAO00D55 : DataRepository<TLMVIW00D13>, ITLMDAO00D55
    {
       public IList<TLMDTO00058> SelectDayBookDomesticHomeReversal(string workStation, string sourceCur, DateTime requireDate)
       {
           IQuery query = this.Session.GetNamedQuery("TLMDAO00055.SelectDayBookDomesticHomeReversal");
           query.SetString("workStation", workStation);
           query.SetString("sourceCur", sourceCur);
           query.SetDateTime("requireDate", requireDate);

           IList<TLMDTO00058> dayBookDTO = query.List<TLMDTO00058>();
           return dayBookDTO;
       }
    }
}
