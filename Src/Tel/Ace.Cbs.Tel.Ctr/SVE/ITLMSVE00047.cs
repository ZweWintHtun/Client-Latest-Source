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
  public  interface ITLMSVE00047 :IBaseService
    {
      IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branchCode, string sourceBranch);
      IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate,string branchCode,string sourceBranch, string forReversalCase);
    }
}
