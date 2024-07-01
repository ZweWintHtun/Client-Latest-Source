using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00069 : IDataRepository<LOMORM00069>
    {
        IList<LOMDTO00069> SelectAll();
        IList<LOMDTO00069> CheckExist2(string groupCode, string subCode, string description);
        bool CheckExist(string groupCode, string desp, string subCode, bool isEdit);
    }
}
