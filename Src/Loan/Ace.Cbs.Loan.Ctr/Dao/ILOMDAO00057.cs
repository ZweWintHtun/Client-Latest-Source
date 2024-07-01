using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00057 : IDataRepository<LOMVIW00057>
    {
        IList<LOMDTO00057> SelectServiceCharges(DateTime startDate, DateTime endDate, string cur, string sourceBr);
    }
}
