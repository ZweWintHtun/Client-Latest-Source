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
    /// GJType DAO
    /// </summary>
    public class LOMDAO00019 : DataRepository<LOMORM00019>, ILOMDAO00019
    {
        public IList<LOMDTO00018> SelectGoldAndJewelleryKindInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectGoldAndJewelleryKindInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            IList<LOMDTO00018> gjtDtoList = query.List<LOMDTO00018>();
            return gjtDtoList;
        }
        public bool UpdateGJKInfoByLoanNoAndSourceBr(int id, string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00019.UpdateGJKInfoByLoanNoAndSourceBr");
            query.SetInt32("id", id);
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            return query.ExecuteUpdate() > 0;
        }
    }
}
