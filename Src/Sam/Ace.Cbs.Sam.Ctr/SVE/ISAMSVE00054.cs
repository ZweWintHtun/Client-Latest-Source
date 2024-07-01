using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Sam.Ctr.SVE
{
    public interface ISAMSVE00054 : IBaseService
    {
        IList<BranchDTO> SelectBranch();
        IList<TLMDTO00032> SelectRmitRate();
    }
}
