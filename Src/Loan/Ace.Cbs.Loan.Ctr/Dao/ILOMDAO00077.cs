using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00077 : IDataRepository<LOMORM00077>
    {
        IList<LOMDTO00077> SelectAll();
        IList<LOMDTO00077> CheckExist2(string productCode, string lsBusinessCode, string umCode);
        bool CheckExist(string productCode, string lsBusinessCode, string umCode, bool isEdit);
    }
}
