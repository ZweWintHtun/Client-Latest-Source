using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00303 : IBaseService
    {
        ILOMDAO00303 FarmLoanOSTReportDAO { get; set; }

        IList<LOMDTO00303> SelectAll(LOMDTO00303 dto);
        object CalculateFarmLoanInterest(LOMDTO00303 dto);
        object CalculateFarmLoanPenalFee(LOMDTO00303 dto);
    }
}
