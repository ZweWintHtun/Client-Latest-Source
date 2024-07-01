using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00008 : IDataRepository<LOMORM00008>
    {
        bool CheckExist(string kind, string desp, bool isEdit);
        IList<LOMDTO00008> SelectAll();
        LOMDTO00008 SelectByGjKind(string kind);
        void ManualUpdate(LOMORM00008 entity);
        IList<LOMDTO00008> CheckExist2(string kind, string desp);
    }
}
