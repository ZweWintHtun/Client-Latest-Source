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
    public interface ITCMSVE00008:IBaseService
    {
        PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo, string branchCode);
        //string Save(PFMDTO00006 chequeBookEditingEntity);
        string SaveCheque(PFMDTO00006 chequeBookEditingEntity);
        
    }
}
