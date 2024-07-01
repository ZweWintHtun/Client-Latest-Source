using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00307 : IDataRepository<LOMVIW00307>
    {
        IList<LOMDTO00307> SelectAll(DateTime startDate,DateTime endDate, string cur, string sourceBr);
    }
}
