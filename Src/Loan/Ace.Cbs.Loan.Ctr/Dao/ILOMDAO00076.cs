using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00076 : IDataRepository<LOMORM00076>
    {
        bool CheckExist(string lsBusinessCode, string desp, bool isEdit);
        IList<LOMDTO00076> SelectAll();
        LOMDTO00076 SelectByLsBusinessCode(string lsBusinessCode);
        IList<LOMDTO00076> CheckExist2(string lsBusinessCode, string desp);
    }
}
