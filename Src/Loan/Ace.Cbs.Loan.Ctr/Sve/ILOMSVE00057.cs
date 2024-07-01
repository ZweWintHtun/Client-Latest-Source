using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00057 : IBaseService
    {
        IList<LOMDTO00057> SelectServiceCharges(LOMDTO00057 dto);
    }
}
