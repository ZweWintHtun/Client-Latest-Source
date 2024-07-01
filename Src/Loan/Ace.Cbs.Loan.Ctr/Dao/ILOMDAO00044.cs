using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00044 : IDataRepository<MNMORM00017>
    {
        string CalculateODInterest(LOMDTO00044 dto);
    }
}
