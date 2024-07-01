
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
   public interface ITLMDAO00048:IDataRepository<TLMVIW00006>
    {
      
        IList<TLMDTO00004> HomeIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate);
           
        IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate);
        IList<TLMDTO00004> ActiveIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate);       
        IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate);
        IList<TLMDTO00004> HomeTransactionByBranchListing(DateTime startDate, DateTime endDate);
        IList<TLMDTO00004> ActiveTransactionByBranchListing(DateTime startDate, DateTime endDate);

    }
}
