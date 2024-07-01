using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Ctr.Dao
{
    public interface ISAMDAO00053  : IDataRepository<SAMORM00053>
    {
        bool CheckExist(string nationalityCode, string desp, bool isEdit);
        IList<SAMDTO00053> SelectAll();
        SAMDTO00053 SelectByNationalityCode(string occupationCode);
        IList<SAMDTO00053> CheckExist2(string occupationCode, string desp);
    }
}
