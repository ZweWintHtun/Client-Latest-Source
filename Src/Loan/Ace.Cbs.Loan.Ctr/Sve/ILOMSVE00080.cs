using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00080 : IBaseService
    {
        IList<LOMDTO00080> GetAllDealerInformation(string sourceBr);
        IList<LOMDTO00081> GetAllStockItem();
        IList<LOMDTO00082> GetAllStockGroup();
        IList<LOMDTO00083> GetAllInstallmentTypes();

        PFMDTO00067 GetAccountInformation(string accountNo);

        //string CheckPoGenorNot(string dealerNo);
        LOMDTO00084 AddHirePurchaseRegistration(string hpno, string caccount, string dealerAC, string dealerStatus, string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent,// decimal sChgsPercent,
                                                               decimal nextYrRChgsPercent, decimal disAmt, decimal docFees, int gapPeriod, decimal commPercent, string stockGCode, string stockISubCode, string relatedGLACode, decimal productValue, int payDuration, int payOptionId,
                                                               DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string userName);

        string CheckBalance(string caccount, string sourceBr);
        IList<LOMDTO00092> GetHPVoucherDetails(LOMDTO00092 d);
        string CheckAccountExistsOrValid(string caccount, string sourceBr);
        string GetInstallmentAmt(decimal netAmt, int noOfTerms);
        //IList<decimal> GetRateForHPReg();
        IList<string> GetAllPersonalLoansCompanyName(string sourceBr);
        string GetDealerCommission_ByDealerNo(string dealerNo, string sourceBr);
    }
}
