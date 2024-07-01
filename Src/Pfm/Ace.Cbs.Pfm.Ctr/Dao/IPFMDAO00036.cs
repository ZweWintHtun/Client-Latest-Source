using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00036 : IDataRepository<PFMORM00036>
    {
        PFMDTO00036 GetTopCS99(DateTime datetime, string currency,string sourcebr);
        PFMDTO00036 GetTopCS99WithoutCurrency(DateTime datetime,string sourcebr);
        decimal GetOpeningBalancefromCS99(DateTime datetime, string sourcebr); // call from TCMSVE00028
        bool DeleteForCashClosing(string branchCode, DateTime fromDate, DateTime toDate, DateTime updatedDate, int updatedUserId);
        PFMDTO00036 GetTopCS99Currency(DateTime datetime, string sourcebr);
        IList<PFMDTO00036> SelectByDateTime(DateTime date_time,string sourceBr);
        int SelectMaxId();
    }
}