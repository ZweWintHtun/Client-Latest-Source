using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00303 : IDataRepository<LOMVIW00303>
    {
        IList<LOMDTO00303> SelectAll(DateTime dueDate, string cur, string sourceBr, string villageCode, string townshipCode);
        object CalculateFarmLoanInterest(string lno, decimal samt, string withdrawDate, string todayDate, string sourceBr);
        object CalculateFarmLoanPenalFee(string lno, decimal samt, string sourceBr);
    }
}
