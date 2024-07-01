using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00001 : IDataRepository<LOMORM00001>
    {
        bool CheckExist(string businessCode, string desp, bool isEdit);
        IList<LOMDTO00001> SelectAll();
        LOMDTO00001 SelectByBusinessCode(string businessCode);
        IList<LOMDTO00001> CheckExist2(string businessCode, string desp);
    }
}
