using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00078 : IBaseService
    {
        IList<PFMDTO00042> GetReportDataListForPORegisterEncash(DateTime startDate, DateTime endDate, string sourceBr);
    }
}
