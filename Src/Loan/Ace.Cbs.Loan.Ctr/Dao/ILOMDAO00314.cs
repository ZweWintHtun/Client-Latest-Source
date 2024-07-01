using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00314 : IDataRepository<LOMVIW00314>
    {
        IList<LOMDTO00314> SelectAll(string sourceBr, DateTime expireddate);
    }
}
