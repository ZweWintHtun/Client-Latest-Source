using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00074 : IDataRepository<LOMORM00074>
    {
        bool CheckExist(string code, string desp, bool isEdit);
        IList<LOMDTO00074> SelectAll();
        LOMDTO00074 SelectByProductCode(string productCode);
        IList<LOMDTO00074> CheckExist2(string productCode, string desp);
    }
}