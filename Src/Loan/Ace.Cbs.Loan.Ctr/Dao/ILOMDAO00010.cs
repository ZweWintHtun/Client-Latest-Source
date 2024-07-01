using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;


namespace Ace.Cbs.Loan.Ctr.Dao
{

    public interface ILOMDAO00010 : IDataRepository<LOMORM00010>
    {

        bool CheckExist(string kstockNo, string desp, bool isEdit);
        IList<LOMDTO00010> SelectAll();
        LOMDTO00010 SelectByCode(string kstockNo);
        IList<LOMDTO00010> CheckExist2(string kstockNo, string kstockName);

    }
}
