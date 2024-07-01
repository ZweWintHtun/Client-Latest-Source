﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00063 : IBaseService
    {
        IList<MNMDTO00040> GetReportData(MNMDTO00040 dto, bool isCheckCurrency, string isrdoCurrentAccount);
    }
}
