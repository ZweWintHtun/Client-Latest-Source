using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using NHibernate;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00102 : DataRepository<LOMDTO00102>, ILOMDAO00102
    {
        public IList<LOMDTO00102> GetLoanRecordList(string townshipCode, DateTime startDate, DateTime endDate, string type)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("ProcGetAllLoanRecord");
                query.SetString("townshipCode", townshipCode);
                query.SetDateTime("startDate", startDate);
                query.SetDateTime("endDate", endDate);
                query.SetString("type", type);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00102)));
                IList<LOMDTO00102> allLoanRecordList = query.List<LOMDTO00102>();
                return allLoanRecordList;
            }
            catch { return null; }
        }
    }
}
