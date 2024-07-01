using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00305 : IBaseService
    {
        ILOMDAO00305 FarmLoanOSTByWithdrawDateReportDAO { get; set; }

        IList<LOMDTO00305> SelectAll(LOMDTO00305 dto);
    }
}
