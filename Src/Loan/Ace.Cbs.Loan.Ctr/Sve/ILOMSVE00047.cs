using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00047 : IBaseService
    {
        IList<LOMDTO00047> SelectLoansRepaymentScheduleByDate(LOMDTO00047 dto);
    }
}
