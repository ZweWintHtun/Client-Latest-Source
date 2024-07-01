using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00014:IBaseService
    {
        IList<TLMDTO00015> GetDepoDenoAndCashDeno(string groupNo, string sourceBranch);
        TLMDTO00016 GetDepoDenoData(string groupNo, string poNo,string budget, string sourceBranch);
        TLMDTO00016 GetPOData(string poNo, string budget,string sourceBranch);

        IList<PFMDTO00054> SaveSinglePO(TLMDTO00016 dto, CXDTO00001 denodto);
        IList<PFMDTO00054> SaveMultiPO(TLMDTO00016 dto, CXDTO00001 denodto);
        IList<PFMDTO00054> DeleteSinglePO(TLMDTO00016 dto);
        IList<PFMDTO00054> DeleteMultiPO(TLMDTO00016 dto, CXDTO00001 denodto);
    }
}
