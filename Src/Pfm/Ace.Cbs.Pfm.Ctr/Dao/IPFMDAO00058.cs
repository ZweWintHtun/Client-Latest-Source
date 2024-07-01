using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00058 : IDataRepository<PFMORM00058>
    {
        IList<PFMDTO00058> SelectFPrnFileByAccountNo(string accountNo);
        bool DeleteFPrnFileById(int id);
    }
}
