using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00307 : IBaseService
    {
        ILOMDAO00307 FarmLoanTotalDailyIncomeReportDAO { get; set; }

        IList<LOMDTO00307> SelectAll(LOMDTO00307 dto);
    }
}
