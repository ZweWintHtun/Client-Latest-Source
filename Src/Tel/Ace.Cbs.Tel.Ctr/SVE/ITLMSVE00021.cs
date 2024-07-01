using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
  public  interface ITLMSVE00021 : IBaseService
    {
      IList<PFMDTO00054> SaveClearingVoucher(IList<PFMDTO00054> tlfListDTO);
    }
}
