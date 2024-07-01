using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00007 : IDataRepository<PFMORM00007>
    {
        bool CheckExist(int id, decimal duration, string desc, decimal rate);
        IList<PFMDTO00007> SelectAll();
        PFMDTO00007 SelectById(int id);
        PFMDTO00007 SelectFixRateDescription(decimal duration);
    }
}