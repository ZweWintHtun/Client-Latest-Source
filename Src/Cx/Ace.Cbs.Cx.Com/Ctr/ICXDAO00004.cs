using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00004 : IDataRepository<PFMORM00054>
    {
        int SelectMaxId();
    }
}
