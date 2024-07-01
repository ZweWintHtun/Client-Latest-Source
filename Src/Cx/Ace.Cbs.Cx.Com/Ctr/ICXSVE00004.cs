using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXSVE00004
    {
        PFMDTO00054 AmtOamtParameterCheck(string accountNo, decimal actionAmount, CXDMD00002 debitCreditTransaction);
        CXDTO00001 GetDenoString(IList<TLMDTO00012> getDenoInfo, bool cashEnable, string branchCode);
        CXDTO00002 GetDenoExchangeRateString(string currencyCode, string branchCode, string rateType);
        IList<TLMDTO00012> GetDenoCalculateAmount(IList<TLMDTO00012> DenoList, string denoDetail, string denoRefundDetail, string denoStatus);
    }
}
