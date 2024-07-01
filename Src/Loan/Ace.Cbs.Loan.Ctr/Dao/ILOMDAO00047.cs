using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LOMDAO00047 Interface
    /// </summary>
    public interface ILOMDAO00047 : IDataRepository<LOMVIW00047>
    {
        IList<LOMDTO00047> SelectLoansRepaymentScheduleByDate(DateTime startDate, DateTime endDate, string loansNo, string cur, string sourceBr);
    }
}
