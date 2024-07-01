using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00313 : IDataRepository<LOMORM00313>
    {
        LOMDTO00313 SelectPL_GuanInfoByLoanNoAndSourceBr(string lno, string sourcebr);
    }
}
