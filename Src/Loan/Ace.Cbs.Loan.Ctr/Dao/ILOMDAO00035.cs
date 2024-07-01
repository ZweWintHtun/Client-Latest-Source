using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LOMDAO00035 Interface
    /// </summary>
    public interface ILOMDAO00035 : IDataRepository<LOMVIW00035>
    {
        IList<LOMDTO00035> SelectByLoansType(DateTime startDate, DateTime endDate, string loansType, string cur, string sourceBr);
        IList<LOMDTO00035> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00035> SelectAllByLoansType(DateTime startDate, DateTime endDate, string loansType, string cur, string sourceBr);
        IList<LOMDTO00035> SelectAllLoansOD(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00035> SelectAllLoansDailyPositionByCur(string cur, string sourceBr);
    }
}
