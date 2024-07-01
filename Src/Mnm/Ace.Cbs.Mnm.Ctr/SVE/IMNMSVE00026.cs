using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00026:IBaseService
    {
        TLMDTO00001 GetReInfo(string registerNo, string SourceBr);
        IList<PFMDTO00054> Save(TLMDTO00001 entity);
        void Delete(TLMDTO00001 entity);
    }
}
