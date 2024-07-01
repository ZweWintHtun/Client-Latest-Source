using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00004 : IDataRepository<PFMORM00004>
    {
        bool CheckExist(string occupationCode, string desp, bool isEdit);
        IList<PFMDTO00004> SelectAll();
        PFMDTO00004 SelectByOccupationCode(string occupationCode);
        IList<PFMDTO00004> CheckExist2(string occupationCode, string desp);
    }
}