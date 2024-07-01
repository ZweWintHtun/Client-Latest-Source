using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00071 : IDataRepository<LOMORM00071>
    {
        bool CheckExist(string code,string desp,bool isEdit);
        IList<LOMDTO00071> SelectAll();
        LOMDTO00071 SelectBySeasonCode(string seasonCode);
        IList<LOMDTO00071> CheckExist2(string seasonCode,string desp);
    }
}
