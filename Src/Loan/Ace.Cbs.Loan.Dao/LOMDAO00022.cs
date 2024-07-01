using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00022 : DataRepository<LOMORM00022>, ILOMDAO00022
    {
        //Select Max Id
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00022.SelectMaxId");
            return query.UniqueResult<LOMDTO00013>().Id;
        }
    }
}
