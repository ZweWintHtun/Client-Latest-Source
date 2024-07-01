using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00068 : IDataRepository<LOMORM00068>
    {
        IList<LOMDTO00068> SelectAll();
        IList<LOMDTO00068> CheckExist2(string groupCode, string prefix, string description);
        bool CheckExist(string groupCode, string desp, string prefix, bool isEdit);
    }
}
