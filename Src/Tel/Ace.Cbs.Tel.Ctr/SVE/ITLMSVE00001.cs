using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;


namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00001:IBaseService
    {
        string SaveDomesticVoucher(TLMDTO00041 domesticVoucherDTO);
    }
}
