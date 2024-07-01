using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00015 : IDataRepository<PFMORM00015>
    {
        bool CheckExist(int id, string code, string description, string symbol);
        IList<PFMDTO00015> SelectAll();
        PFMDTO00015 SelectById(int id);
        PFMDTO00015 SelectByCode(string code);
    }
}