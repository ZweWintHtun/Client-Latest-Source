using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// Pledge Interface DAO
    /// </summary>
    public interface ILOMDAO00016 : IDataRepository<LOMORM00016>
    {
        int SelectMaxId();
        IList<LOMDTO00016> SelectPledgeInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdatePledgeInfoByLoanNoAndSourceBr(int id, string lno, string sourcebr);
    }
}
