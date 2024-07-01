using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// GJType Interface DAO
    /// </summary>
    public interface ILOMDAO00018 : IDataRepository<LOMORM00018>
    {
        IList<LOMDTO00018> SelectGoldAndJewelleryTypeInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdateGJTInfoByLoanNoAndSourceBr(int id ,string lno, string sourcebr);
        
    }
}
