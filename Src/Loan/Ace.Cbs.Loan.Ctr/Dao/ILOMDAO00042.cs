using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LOMDAO00042 Interface
    /// </summary>
    public interface ILOMDAO00042 : IDataRepository<LOMVIW00042>
    {
        IList<LOMDTO00035> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00035> SelectLoansOnly(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00035> SelectODOnly(DateTime startDate, DateTime endDate, string cur, string sourceBr);
    }
}
