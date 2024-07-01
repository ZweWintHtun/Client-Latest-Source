using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00143 : IBaseService
    {
        IList<MNMDTO00043> SelectFixedYearEnd(string sourcebr);
        IList<MNMDTO00043> SelectFixedYearEndPrev(string sourcebr);

    }
}
