using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00042 : IBaseService
    {
        IList<LOMDTO00035> SelectAll(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectLoansOnly(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectODOnly(LOMDTO00035 dto);
    }
}
