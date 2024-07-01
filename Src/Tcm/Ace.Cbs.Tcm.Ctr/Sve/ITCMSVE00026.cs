using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00026:IBaseService
    {
        IList<PFMDTO00042> GetReportData(PFMDTO00042 DataDTO);
    }
}
