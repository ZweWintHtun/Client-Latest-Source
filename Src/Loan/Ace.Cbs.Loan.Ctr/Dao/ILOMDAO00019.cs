using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// GJKind Interface DAO
    /// </summary>
    public interface ILOMDAO00019 : IDataRepository<LOMORM00019>
    {
        IList<LOMDTO00018> SelectGoldAndJewelleryKindInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdateGJKInfoByLoanNoAndSourceBr(int id ,string lno, string sourcebr);
    }
}
