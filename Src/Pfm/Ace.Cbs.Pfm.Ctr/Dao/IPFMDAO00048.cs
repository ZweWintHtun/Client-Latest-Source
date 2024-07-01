using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00048 : IDataRepository<PFMORM00048>
    {
        bool CheckExist(string code, string description, bool isEdit);
        IList<PFMDTO00048> SelectAll();
        PFMDTO00048 SelectByCode(string code);
        IList<PFMDTO00048> CheckExist2(string MessageCode, string desp);
    }
}