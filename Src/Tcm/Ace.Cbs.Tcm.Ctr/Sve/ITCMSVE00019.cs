using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00019
    {
        //ITLMDAO00015 CashDenoDAO { get; set; }
        List<TLMDTO00015> Save(List<TLMDTO00015> ListCashDenoDTO, string SourceBr);
    }
}
