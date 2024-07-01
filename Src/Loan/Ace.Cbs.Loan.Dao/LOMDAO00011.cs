using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Dao
{

    /// <summary>
    /// LMT99#00 DAO
    /// </summary>
    public class LOMDAO00011 : DataRepository<LOMORM00011>, ILOMDAO00011
    {
        public bool HasInLMT9900(string lno, string sourceBr)
        { 
            IQuery query = this.Session.GetNamedQuery("LOMORM00011.HasLMT9900");
            query.SetString("lno", lno);
            query.SetString("sourceBr", sourceBr);
            IList<LOMDTO00011> lnoList = query.List<LOMDTO00011>();
            return lnoList.Count > 0 ? true : false;
        }
    }
}
