using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
    public interface ITCMDAO00052 : IDataRepository<TCMORM00052>
    {
        void DeleteData(string currency);
        TCMDTO00052 SelectViewDate(string currency, DateTime datetime);
        TCMDTO00052 SelectDailyReportData(string currency);
        int SelectMaxId();

        TCMDTO00052 SelectAllDailyReport(DateTime postDate, string currency);
        int UpdateDailyReport(TCMDTO00052 dailyreportdto);
    }
}
