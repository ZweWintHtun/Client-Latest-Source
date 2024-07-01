using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00404 : IDataRepository<LOMORM00404>
    {
        bool CheckExist(string businessCode, string desp, string acode, bool isEdit);
        IList<LOMDTO00001> SelectAll();
        LOMDTO00001 SelectByBusinessCode(string businessCode);
        IList<LOMDTO00001> CheckExist2(string businessCode, string acode, string desp);

        string SelectCompanyName(string acctno);
    }
}
