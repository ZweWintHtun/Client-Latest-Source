using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00066 : IBaseService
    {
        IList<PFMDTO00042> GetReportData(PFMDTO00042 dataDTO, string sourceBr, int workstationId, int createdUserId);
        IList<PFMDTO00032> GetCheckListForComingAccrue(string currency, string sourceBr);
        IList<PFMDTO00032> GetCheckListForComingInterest(string currency, string sourceBr);
        PFMDTO00042 GetMatureDate(PFMDTO00032 CheckDTO, int createdUserId);
    }
}
