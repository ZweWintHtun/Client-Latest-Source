using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00314 : IBaseService
    {
        ILOMDAO00314 ExpireLandLeaseListingDAO { get; set; }

        IList<LOMDTO00314> SelectAll(LOMDTO00314 dto);
    }
}
