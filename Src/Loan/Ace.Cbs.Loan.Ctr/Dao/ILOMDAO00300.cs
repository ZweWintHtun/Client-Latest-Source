using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00300 : IDataRepository<LOMORM00300>
    {
        string CalculateFarmLoanPenalFee(string sourceBr);
    }
}
