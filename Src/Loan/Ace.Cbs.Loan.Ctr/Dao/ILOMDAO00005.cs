using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00005 : IDataRepository<LOMORM00005>
    {
        bool CheckExist(string code, string desp, bool isEdit);
        IList<LOMDTO00001> SelectAll();
        LOMDTO00001 SelectByCode(string code);
        void ManualUpdate(LOMORM00005 entity);
        IList<LOMDTO00001> CheckExist2(string code, string desp);
    }
}
