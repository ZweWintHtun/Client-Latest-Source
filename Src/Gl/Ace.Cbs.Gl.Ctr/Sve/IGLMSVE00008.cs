using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Gl.Ctr.Sve
{
    public interface IGLMSVE00008 : IBaseService
    {
        MNMDTO00010 GetCCOAandCOA_ByACodeAndCurrency(MNMDTO00010 DataDTO);
    }
}
