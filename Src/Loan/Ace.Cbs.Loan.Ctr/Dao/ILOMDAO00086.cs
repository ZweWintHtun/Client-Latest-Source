using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00086 : IDataRepository<LOMORM00086>
    {
        LOMDTO00086 GetLoanRecordByLoanNo(string eno);
        bool UpdateLoanRecord(LOMDTO00086 entity);
        bool DeleteLoanRecord(string eno);
        int CheckLoanAccNo(string acctNo);
    }
}
