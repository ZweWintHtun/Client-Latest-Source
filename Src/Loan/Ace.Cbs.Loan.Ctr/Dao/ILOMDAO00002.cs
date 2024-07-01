using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00002 : IDataRepository<LOMORM00002>
    {
        bool CheckExist(string code, string desp, bool isEdit);
        IList<LOMDTO00002> SelectAll();
        LOMDTO00002 SelectByAdvanceCode(string advanceCode);
        IList<LOMDTO00002> CheckExist2(string advanceCode, string desp);
    }
}
