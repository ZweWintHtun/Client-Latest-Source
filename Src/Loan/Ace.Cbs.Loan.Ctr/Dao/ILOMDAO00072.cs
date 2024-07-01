using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00072 : IDataRepository<LOMORM00072>
    {
        IList<LOMDTO00072> SelectAll();
        IList<LOMDTO00072> CheckExist2(string cropCode, string desp);
        bool CheckExist(string cropCode, string desp, bool isEdit);
    }
}
