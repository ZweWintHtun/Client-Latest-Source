using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00070 : IBaseService
    {
        IList<MNMDTO00039> GetReportData(MNMDTO00039 dto, bool IsByDate);
    }
}
