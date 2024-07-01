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
    /// Penal Fee DAO
    /// </summary>
    public class LOMDAO00012 : DataRepository<LOMORM00012>, ILOMDAO00012
    {
        public IList<LOMDTO00012> SelectPenalFeeInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectPenalFeeInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            IList<LOMDTO00012> pledgeDtoList = query.List<LOMDTO00012>();
            return pledgeDtoList;
        }
    }
}
