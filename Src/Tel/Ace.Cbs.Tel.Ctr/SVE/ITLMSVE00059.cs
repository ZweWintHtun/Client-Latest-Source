using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00059 :IBaseService
    {
       IList<TLMDTO00001> SelectEncashOutStanding(string sourceBr);
    }
}
