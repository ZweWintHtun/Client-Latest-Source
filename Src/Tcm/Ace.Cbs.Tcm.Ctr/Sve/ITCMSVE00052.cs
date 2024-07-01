using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00052 : IBaseService
    {
        TCMDTO00052 SelectDailyClosingbySP(string rDATE, string bUDMONTH, string cUR, int createdUserId);
        //void Save(TCMDTO00052 dtoList);
        //void Update(TCMDTO00052 dtoList);
        //void DeleteDailyReport(TCMDTO00052 dto52List);
        //TCMDTO00052 SelectViewData(string currency, DateTime date);
        //void SelectDailyReportData(TCMDTO00052 DTO, string currency);
    }
}
