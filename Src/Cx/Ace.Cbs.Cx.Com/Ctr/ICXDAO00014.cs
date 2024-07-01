using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00014 : IDataRepository<CurrencyChargeOfAccount>
    {
        IList<CurrencyChargeOfAccountDTO> SelectAll();
        CurrencyChargeOfAccountDTO SelectByACODE(string aCODE);
        IList<CurrencyChargeOfAccountDTO> SelectAllyearly(string sourcebr);
        bool UpdateBalance(int updatedUserId);
        bool UpdateZeroBalance(string budget, int updatedUserId);
        bool UpdateBlanceNotM1ForDailyPost(string currentMonth, string currentMSRC, string prevMonth, string prevMSRC, string branchCode, int updatedUserId);
        bool UpdateBalanceEqualM1ForDailyPost(string currentMonth, string currentMSRC, string branchCode, int updatedUserId);
        bool UpdateDailyPostingForAcode(string Acode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId);
        bool UpdateDailyPostingForHeadAcode(string HeadAcode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId);
        bool UpdateDailyPostingForGroupAcode(string GroupAcode, string Dcode, string Cur, string currentMonth, string currentMSRC, decimal LocalAmt, decimal homeAmt, int updatedUserId);
        bool UpdateZeroForNullDcode(string currentMonth, string currentMSRC, int updatedUserId);
        IList<CurrencyChargeOfAccountDTO> SelectSumAllDcode(string currentMonth, string currentMSRC, string dcode);
        bool UpdateGroupAcode(string currentMonth, string currentMSRC, decimal totalM, decimal totalMSRC, string acode, string cur, int updatedUserId);
        IList<CurrencyChargeOfAccountDTO> SelectAllByDcodeandCurrentmth(string currentMonth, string currentMSRC, string dcode);
        bool UpdateDcodeNullForCheckStatus(string currentMonth, string currentMSRC, decimal currentAmt, decimal msrcAmt, string acode, string cur, int updatedUserId);
        decimal SelectCurMAmtByAcodeAndDcode(string currentMonth, string acode, string dcode);//Added by HWKO (25-Oct-2017)

        //For Budget End Flexible By ZMS 2018/09/17
        string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return);
    }
}
