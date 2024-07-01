using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00006 : IDataRepository<LOMORM00006>
    {
        bool CheckExist(string code, string desp, bool isEdit);
        IList<LOMDTO00001> SelectAll();
        LOMDTO00001 SelectByCode(string code);
        //void ManualUpdate(LOMORM00006 entity);
        IList<LOMDTO00001> CheckExist2(string code, string desp);
    }
}
