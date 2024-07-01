using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using System.Collections.Generic;
using System;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00046 : IBaseService
    {
        IList<TLMDTO00004> HomeTransactionListinByBranch(DateTime startDate, DateTime endDate, string tranType,string branch,string sourceBranch,bool isReversal);
        IList<TLMDTO00004> ActiveTransactionListinByBranch(DateTime startDate, DateTime endDate, string tranType, string branch, string sourceBranch, bool isReversal);
    }
}
