using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
  public interface ITCMSVE00065:IBaseService
    {
      TCMDTO00052 SelectDailyReport(TCMDTO00052 dailyreportDTO, DateTime datetime, string currency,string budgetMonth,int createdUserId);
      void SaveorUpdateDailyReport(TCMDTO00052 dailyreportDTO, DateTime datetime, string currency, string budgetMonth, bool isFormLoad, int createdUserId);
    }
}
