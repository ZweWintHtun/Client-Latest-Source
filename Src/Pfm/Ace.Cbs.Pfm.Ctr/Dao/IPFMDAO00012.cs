using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00012 : IDataRepository<PFMORM00012>
    {
        bool CheckExist(string cityCode, string desp, bool isEdit);
        IList<PFMDTO00012> SelectAll();
        PFMDTO00012 SelectByCityCode(string cityCode);
    }
}