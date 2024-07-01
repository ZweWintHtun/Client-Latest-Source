﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00079 : IBaseService
    {
        IList<PFMDTO00042> GetReportDataPOWithdrawlEncash(DateTime startDate, DateTime endDate,string sourceBranchCode,string formName);    
    }
}
