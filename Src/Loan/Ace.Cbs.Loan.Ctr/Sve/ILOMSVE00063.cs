using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00063 : IBaseService
    {
        IList<LOMDTO00013> SelectNonPerformanceLoansCase(LOMDTO00013 dto);
        IList<LOMDTO00013> SelectLegalSueCaseList(LOMDTO00013 dto);
        IList<LOMDTO00013> SelectLegalSueCaseClose(LOMDTO00013 dto);
    }
}
