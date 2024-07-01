using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00003 : IDataRepository<LOMORM00003>
    {
        bool CheckExist(string charaterCode, string desp, bool isEdit);
        IList<LOMDTO00001> SelectAll();
        LOMDTO00001 SelectByCode(string charaterCode);
        IList<LOMDTO00001> CheckExist2(string characterCode, string description);
    }
}
