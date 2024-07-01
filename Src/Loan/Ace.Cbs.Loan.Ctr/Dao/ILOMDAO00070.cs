using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00070 : IDataRepository<LOMORM00070>
    {
        IList<LOMDTO00070> SelectAll();
        IList<LOMDTO00070> CheckExist2(string villageCode, string desp);
        bool CheckExist(string villageCode, string desp, bool isEdit);
    }
}
