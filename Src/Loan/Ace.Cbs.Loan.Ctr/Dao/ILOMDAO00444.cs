using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00444 : IDataRepository<LOMORM00010>
    {
        IList<LOMDTO00444> GetLimitExtendList(DateTime acctno, string sortby);
        IList<LOMDTO00423> GetNeedToExtendAccountInfo(string acctno);
        string SaveLimitExtendInfo(string totalExtendDuration, string accountNo, string docFeeNew, string IntRateNew, string UserID, string SourceBr, string preExtend, string sChargeNew);
        LOMDTO00423 Get_BL_SanctionAmountInfo(string accountNo, string sourceBr);
    }
}
