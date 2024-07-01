using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
 
    public interface ITCMSVE00004 :IBaseService
    {
        TLMDTO00001 GetREInfoByRegisterNo(string registerNo);
        string[] Save(TLMDTO00043 poForEncashmentEntity);

    }
}
