using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00237 : IPresenter
    {
        ILOMVEW00239 View { get; set; }
        string HP_Registration_Reversal(string hpNo, string reversalEno, int createdUserId, string sourceBr);
        string Get_HPInfo_ByHPNo(string hpNo);
        string Get_PLInfo_ByPLNo(string plNo);
        string PL_Registration_Reversal(string plNo, int createdUserId, string sourceBr, string formatCode
                                                , int valueCount, string valueStr);
        
        // For Year End Income Voucher, added by AAM (28-Mar-2018)        
        string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC, string sourceBr);
        IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr);
        string PNL_Zerorization_Income_Voucher(string pnlAC, int createdUserId, string sourceBr);//Modified by HMW at 19-Sept-2019 : ENO will generate from script side directly (for both actual date and back date transactions)
        string Check_AlreadyZerorizationForIncomeAC(string ProfitAndLossAC);//Added by HMW at 23-Sept-2019
        
        // For Year End Expense Voucher, added by AAM (28-Mar-2018)
        IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr);
        string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr);
        string Expn_Zerorization_Expense_Voucher(string expnAC, int createdUserId, string sourceBr);//Modified by HMW at 20-Sept-2019 : ENO will generate from script side directly (for both actual date and back date transactions)
        string Check_AlreadyZerorizationForExpenseAC(string ProfitAndLossAC);//Added by HMW at 23-Sept-2019

        string Get_BLInfo_ByBLNo(string blNo);
        string BL_Registration_Reversal(string blNo, string formatCode, int createdUserId, string sourceBr);//Modify by HMW at 27-Aug-2019
        IList<LOMDTO00241> Get_HPList_For_Interest_Prepay_ByDealer(LOMDTO00241 hpListBydealer);
        string Dealer_Interest_Prepaid_ForHP(LOMDTO00241 hpListBydealer);
        //IList<LOMDTO00242> HPInterestPrepaidByDealer_Listing(LOMDTO00242 hpIntPrepaidList);
        void Print(LOMDTO00242 hpIntPrepaidList);

        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
        
    }
    public interface ILOMVEW00239
    {
        ILOMCTL00237 Controller { get; set; }
    }
}
