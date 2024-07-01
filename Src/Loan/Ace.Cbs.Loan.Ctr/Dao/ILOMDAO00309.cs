using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00309 : IDataRepository<LOMVIW00309>
    {
        IList<LOMDTO00309> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);
    }
}
