using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00013 : IDataRepository<PFMORM00013>
    {
        bool CheckExist(string stateCode, string desp, bool isEdit);
        IList<PFMDTO00013> SelectAll();
        PFMDTO00013 SelectByStateCode(string stateCode);
    }
}