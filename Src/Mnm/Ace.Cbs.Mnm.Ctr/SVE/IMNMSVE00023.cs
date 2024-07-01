using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00023:IBaseService
    {
        TLMDTO00017 GetRDInfo(string registerNo, string sourceBr);
        IList<PFMDTO00054> Delete(TLMDTO00017 entity, CXDTO00001 denoInfo);
        TLMDTO00017 GetOtherGroupAmount(string groupNo, string registerNo, string sourceBr);
        PFMDTO00001 CheckAccount(string accountNo, string sourceBr, string oldAccountNo);
        PFMDTO00028 GetAccount(string accountNo);
        IList<PFMDTO00054> Save(TLMDTO00017 entity, CXDTO00001 denoInfo, int workstationId, bool voucher);
        string CheckAmount(string accountNo, decimal amount);
    }
}
