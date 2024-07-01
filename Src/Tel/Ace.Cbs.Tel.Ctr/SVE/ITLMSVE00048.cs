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
   public interface ITLMSVE00048 :IBaseService
    {
       IList<TLMDTO00004> HomeIncomeListingByAllBranch(DateTime startDate, DateTime endDate, string sourceBr,string branchcode);
       IList<TLMDTO00004> ActiveIncomeListingByAllBranch(DateTime startDate, DateTime endDate, string sourceBr,string branchcode);
     
    }
}
