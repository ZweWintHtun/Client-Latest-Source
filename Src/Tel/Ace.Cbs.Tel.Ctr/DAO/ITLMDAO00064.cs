using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;


namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00064 : IDataRepository<TLMVIW00021>
    {
        IList<PFMDTO00042> SelectDepositListingByAccountNo(string workStation, string accountNo);
    }
}
