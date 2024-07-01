using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// LrpLegalDAO
    /// </summary>
    public interface ILOMDAO00022 : IDataRepository<LOMORM00022>
    {
        int SelectMaxId();
    }
}
