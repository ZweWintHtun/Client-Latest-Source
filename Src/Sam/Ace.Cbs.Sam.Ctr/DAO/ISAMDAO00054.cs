using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Ctr.Dao
{
    public interface ISAMDAO00054 : IDataRepository<SAMORM00054>
    {
        bool CheckExist(int Id, string StateCode, string TownshipCode, string TownshipDesp, bool isEdit);
        IList<SAMDTO00054> SelectAll();
        IList<SAMDTO00054> SelectByStateCode(string StateCodeCode);
        IList<SAMDTO00054> CheckExist2(string StateCode, string TownshipCode);
    }
}
