using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00063 : IDataRepository<LOMVIW00001>
    {
        IList<LOMDTO00013> SelectNonPerformanceLoansCase(string cur, string sourceBr);
        IList<LOMDTO00013> SelectLegalSueCaseList(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00013> SelectLegalSueCaseClose(DateTime startDate, DateTime endDate, string cur, string sourceBr);
    }
}
