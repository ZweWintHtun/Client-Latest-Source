using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00016:IBaseService
    {
        TLMDTO00016 GetPOData(string poNo, string budget, string sourceBranch);
        TLMDTO00016 GetDepoDenoData(string groupNo, string poNo, string budget, string sourceBranch);
        IList<PFMDTO00054> SaveRefundPO(TLMDTO00041 refundDTO);
        TLMDTO00015 GetCashDenoForPOReversal(string tlfENo , string sourceBranch);
      
    }
}
