using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
   public interface ITCMDAO00011:IDataRepository<TCMORM00011>
    {
       TCMDTO00052 SelectAllDailyReport(DateTime postDate, string currency);
       int UpdateDailyReport(TCMDTO00052 dailyreportdto);
    }
}
