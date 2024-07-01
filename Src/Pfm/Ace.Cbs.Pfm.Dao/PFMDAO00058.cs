using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    [Serializable]
    public class PFMDAO00058 : DataRepository<PFMORM00058>,IPFMDAO00058
    {
        public IList<PFMDTO00058> SelectFPrnFileByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00058.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00058>();
        }

        //Update PrintLine Number.
        [Transaction(TransactionPropagation.Required)]
        public bool DeleteFPrnFileById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00058.DeleteById");
            query.SetInt32("id", id);
            return query.ExecuteUpdate() > 0;
        }
    }
}
