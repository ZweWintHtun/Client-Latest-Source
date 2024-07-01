using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00073 : IBaseService
    {
        IList<PFMDTO00042> GetReportDataListForPOAndIR(DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate, string sourceBranchCode);       
    }
}
