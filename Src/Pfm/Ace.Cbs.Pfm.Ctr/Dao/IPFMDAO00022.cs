using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00022 : IDataRepository<PFMORM00022>
    {
        bool CheckExist(int id, string code, string description);
        bool CheckList(IList<PFMDTO00022> subaccountType, int id, string code, string description);
        IList<PFMDTO00022> SelectAll();
        PFMDTO00022 SelectById(int id);
        PFMDTO00022 SelectByCodeAndAcTypeId(string code, int acTypeId);
    }
}