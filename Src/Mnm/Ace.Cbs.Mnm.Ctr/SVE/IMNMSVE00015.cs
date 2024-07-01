using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00015:IBaseService
    {
       IList<TLMDTO00016> CheckPO(string poNo, string sourceBr);
       // void Save(string poNo, int currentUserId, string sourceBr);
       IList<PFMDTO00054> Save(TLMDTO00016 entity);
    }
}
