using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00101 : IDataRepository<LOMORM00101>
    {
        bool CheckExist(string Code, string desp, bool isEdit);
        IList<LOMDTO00101> SelectAll();
        LOMDTO00101 SelectBySubProductType(string Code);
        IList<LOMDTO00101> CheckExist2(string Code, string desp);
    }
}
