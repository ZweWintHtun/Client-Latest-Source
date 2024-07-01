using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00305 : IDataRepository<LOMVIW00305>
    {
        IList<LOMDTO00305> SelectAll(DateTime withdrawDate, string cur, string sourceBr, string villageCode, string townshipCode);
    }
}
