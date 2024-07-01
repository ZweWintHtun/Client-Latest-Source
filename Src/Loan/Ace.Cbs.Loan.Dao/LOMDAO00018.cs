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
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{

    /// <summary>
    /// GJType DAO
    /// </summary>
    public class LOMDAO00018 : DataRepository<LOMORM00018>, ILOMDAO00018
    {
        public IList<LOMDTO00018> SelectGoldAndJewelleryTypeInfoByLoanNoandSourcebr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectGoldAndJewelleryTypeInfoByLoanNoandSourcebr");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            IList<LOMDTO00018> gjkDtoList = query.List<LOMDTO00018>();
            return gjkDtoList;
        }
        public bool UpdateGJTInfoByLoanNoAndSourceBr(int id, string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00018.UpdateGJTInfoByLoanNoAndSourceBr");
            query.SetInt32("id", id);
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            return query.ExecuteUpdate() > 0;
        }
       
    }
}
