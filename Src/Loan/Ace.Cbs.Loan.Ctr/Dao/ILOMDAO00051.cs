using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00051 : IDataRepository<LOMVIW00051>
    {
        IList<LOMDTO00035> SelectExpireLoansByCur(string year, string month, string cur, string sourceBr);
    }
}
