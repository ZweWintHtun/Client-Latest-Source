using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00005 : IDataRepository<PFMORM00005>
    {
        bool CheckExist(string townshipCode, string desp, bool isedit);
        IList<PFMDTO00005> SelectAll();
        PFMDTO00005 SelectByTownshipCode(string townshipCode);
    }
}