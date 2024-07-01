using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00309 : IBaseService
    {
        ILOMDAO00309 FarmLoanTotalDailyIncomeReportDAO { get; set; }

        IList<LOMDTO00309> SelectAll(LOMDTO00309 dto);
    }
}
