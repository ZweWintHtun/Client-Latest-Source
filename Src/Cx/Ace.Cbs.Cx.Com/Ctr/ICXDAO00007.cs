using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00007 : IDataRepository<PFMORM00075>
    {
        PFMDTO00076 SelectByBranchCodeAndCounter(string branchCode, string counterPhysicalAddress);
    }
}
