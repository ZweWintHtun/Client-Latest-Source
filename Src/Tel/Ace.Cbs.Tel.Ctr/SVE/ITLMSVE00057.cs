using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00057 :IBaseService
    {
       IList<TLMDTO00017> SelectDrawingOutStanding(string sourceBr);  //edited by ASDA
       
       IList<TLMDTO00017> SelectDrawingOutStandingByIncomeOutstand(string sourceBr);
       IList<TLMDTO00017> SelectDrawingOutStandingByDrawingAmountOutstand(string sourceBr);
    }
}
