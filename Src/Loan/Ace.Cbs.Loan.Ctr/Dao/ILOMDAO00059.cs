using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00059 : IDataRepository<LOMVIW00059>
    {
        IList<LOMDTO00059> SelectODLimitChangeByDate(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00059> SelectODLimitChangeByAccount(DateTime startDate, DateTime endDate, string acctNo, string cur, string sourceBr);
    }
}
