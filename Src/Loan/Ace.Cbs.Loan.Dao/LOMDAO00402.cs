using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00402 : DataRepository<LOMORM00402>, ILOMDAO00402
    {
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00402.SelectMaxId");
            LOMDTO00402 dto = query.UniqueResult<LOMDTO00402>();
            return dto.Id;
        }
    }
}
