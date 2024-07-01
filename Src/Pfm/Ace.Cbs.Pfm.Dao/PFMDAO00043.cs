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
    public class PFMDAO00043 : DataRepository<PFMORM00043>, IPFMDAO00043
    {
        public IList<PFMDTO00043> SelectPrnFileByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00043.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<PFMDTO00043>();
        }

        //Update PrintLine Number.
        [Transaction(TransactionPropagation.Required)]
        public bool DeletePrnFileById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00043.DeleteById");
            query.SetInt32("id", id);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeletePrnFileByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00043.DeleteByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.ExecuteUpdate() > 0;
        }
    }
}