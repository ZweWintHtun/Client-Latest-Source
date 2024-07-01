using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00059 : IBaseService
    {
        IList<LOMDTO00059> SelectODLimitChangeByDate(LOMDTO00059 dto);
        IList<LOMDTO00059> SelectODLimitChangeByAccount(LOMDTO00059 dto);
    }
}
