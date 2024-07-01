using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00446 
    {
        ILOMVEW00446 View { get; set; }
        IList<LOMDTO00423> GetNeedToExtendAccountInfo();
        decimal GetAccountCurBalance(string AccountNo);
        string SaveLimitExtendInfo(string UserID, string SourceBr);
        DateTime GetSystemDate(string sourceBr);//Added by HMW at 29-Oct-2019        
        bool HasOverDrawn(string accountNo, string sourceBr);//Added by HMW at 29-11-2019 : To check has overdrawn or not.
        LOMDTO00423 GetSanctionAmountInfo(string accountNo, string sourceBr);//Added by HMW at 29-11-2019
        PFMDTO00009 SelectByCode(string code);
    }

    public interface ILOMVEW00446
    {
        ILOMCTL00446 Controller { get; set; }
        string AccountNo { get; set; }
        string TotalExtendDuration { get; set; }
        string DocFeeNew { get; set; } 
        string IntRateNew { get; set; } 
        string UserID { get; set; }
        string SChargeNew { get; set; }
        string PreExtend { get; set; }
    }
}
