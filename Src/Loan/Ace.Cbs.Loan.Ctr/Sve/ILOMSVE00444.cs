using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00444
    {
        IList<LOMDTO00444> GetLimitExtendList(DateTime date, string sortby);
        IList<LOMDTO00423> GetNeedToExtendAccountInfo(string acctno);
        string SaveLimitExtendInfo(string totalExtendDuration, string accountNo, string docFeeNew, string IntRateNew, string UserID, string SourceBr, string preExtend, string sChargeNew);
        LOMDTO00423 Get_BL_SanctionAmountInfo(string accountNo, string sourceBr);
        PFMDTO00009 SelectByCode(string code);

    }
}
