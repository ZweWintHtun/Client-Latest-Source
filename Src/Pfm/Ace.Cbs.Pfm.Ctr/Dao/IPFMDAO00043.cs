using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// PrnFile Dao Interface
    /// </summary>
    public interface IPFMDAO00043 : IDataRepository<PFMORM00043>
    {
        IList<PFMDTO00043> SelectPrnFileByAccountNo(string accountNo);
        bool DeletePrnFileById(int id);
        bool DeletePrnFileByAccountNo(string accountNo);
    }
}