using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00009 : IDataRepository<LOMORM00009>
    {
        bool CheckExist(string stockNo, string name, bool isEdit);
        IList<LOMDTO00009> SelectAll();
        LOMDTO00009 SelectByCode(string stockNo);
        IList<LOMDTO00009> CheckExist2(string stockNo, string stockName);
    }
}
