using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00099 : IDataRepository<LOMORM00099>
    {
        IList<LOMDTO00099> GetAll();
        IList<LOMDTO00099> SelectByLoanNo(string lno);
    }
}
