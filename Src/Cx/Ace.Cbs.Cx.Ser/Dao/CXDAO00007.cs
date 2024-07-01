using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Counter Dao
    /// </summary>
    [Serializable]
    public class CXDAO00007 : DataRepository<PFMORM00075>, ICXDAO00007
    {
        public PFMDTO00076 SelectByBranchCodeAndCounter(string branchCode, string counterPhysicalAddress)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00059.SelectByBranchCodeAndCounter");
            query.SetString("branchCode", branchCode);
            query.SetString("counterPhysicalAddress", counterPhysicalAddress);

            PFMDTO00076 result = query.UniqueResult<PFMDTO00076>();
            return result;
        }
    }
}
