using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00025
    {
        IList<PFMDTO00025> SelectAccountNoByAccountName(string accountName);
    }
}