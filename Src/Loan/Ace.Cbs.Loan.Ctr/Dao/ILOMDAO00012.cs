using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// Penal Fee DAO Interface
    /// </summary>
    public interface ILOMDAO00012 : IDataRepository<LOMORM00012>
    {
        IList<LOMDTO00012> SelectPenalFeeInfoByLoanNoandSourcebr(string lno, string sourcebr);
    }
}
