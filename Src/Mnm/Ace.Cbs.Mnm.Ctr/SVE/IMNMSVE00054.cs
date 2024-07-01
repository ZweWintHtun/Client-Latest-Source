using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00054 : IBaseService
    {
        IList<MNMDTO00054> GetReportData(PFMDTO00042 DataDto, int workStationId, int createdUserId, string sourceBr);//added sourceBr parameter by ZMS[to ok in Deployment]
    }
}
