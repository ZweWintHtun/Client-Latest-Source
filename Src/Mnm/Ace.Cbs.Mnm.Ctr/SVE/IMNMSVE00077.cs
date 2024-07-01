using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;


namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00077 : IBaseService
    {
        IList<TLMDTO00017> GetDrawingRemittanceListing(TLMDTO00001 dataDTO);
        IList<TLMDTO00001> GetEncashRemittanceListing(TLMDTO00001 dataDTO);
    }
}
