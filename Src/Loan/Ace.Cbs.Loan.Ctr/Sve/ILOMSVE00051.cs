using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00051 : IBaseService
    {
        IList<LOMDTO00035> SelectExpireLoansByCur(LOMDTO00035 dto);
    }
}
