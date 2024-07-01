using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00313 : DataRepository<LOMORM00313>, ILOMDAO00313
    {
        public LOMDTO00313 SelectPL_GuanInfoByLoanNoAndSourceBr(string lno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectPL_GuanInfo");
            query.SetString("lno", lno);
            query.SetString("sourcebr", sourcebr);
            LOMDTO00313 pl_guanDto = query.UniqueResult<LOMDTO00313>();
            return pl_guanDto;
        }
    }
}
