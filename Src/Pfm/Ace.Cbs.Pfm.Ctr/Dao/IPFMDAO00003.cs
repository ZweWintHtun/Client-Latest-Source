using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00003 : IDataRepository<PFMORM00003>
    {
        bool CheckExist(string initial, string description, bool isEdit);
        IList<PFMDTO00003> SelectAll();
        PFMDTO00003 SelectByInitial(string initial);
		IList<PFMDTO00003> CheckExist2(string bCode, string desp);	
    }
}