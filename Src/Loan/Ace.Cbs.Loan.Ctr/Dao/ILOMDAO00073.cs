using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00073 : IDataRepository<LOMORM00073>
    {
        IList<LOMDTO00073> SelectAll();
        IList<LOMDTO00073> CheckExist2(string umCode, string umDesp);
        bool CheckExist(string umCode, string umDesp, bool isEdit);
        IList<LOMDTO00073> SelectByUMCode(string umCode);
    }
}
