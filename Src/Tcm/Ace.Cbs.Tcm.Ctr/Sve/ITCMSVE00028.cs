using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00028 : IBaseService
    {   
        PFMDTO00042 GetReportData(PFMDTO00042 DataDTO , string workStation);  // Get data from tlf        
        IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string crdr, string workstation, int createduserid, string brCode, string sourcecur);  // Sp_DayBook_SummaryForBranchNew;1        
    }
}
