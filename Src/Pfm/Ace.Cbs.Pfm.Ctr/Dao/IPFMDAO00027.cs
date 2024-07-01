using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00027 : IDataRepository<PFMORM00027>
    {
        bool CheckExist(string cur, string desp, string symbol, bool isHomeCur, bool isEdit);
        IList<PFMDTO00027> SelectAll();
        PFMDTO00027 SelectByCur(string cur);
        IList<PFMDTO00024> SelectACode();
        bool CheckHomeCur(string cur);
    }
}