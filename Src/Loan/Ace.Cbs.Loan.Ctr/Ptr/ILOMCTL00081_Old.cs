using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00081 : IPresenter
    {
        ILOMVEW00081 View { get; set; }
        IList<LOMDTO00081> GetAllStockItem();
        IList<LOMDTO00082> GetAllStockGroup();
        IList<LOMDTO00083> GetAllInstallmentTypes();
        void Call_DealerSearch();
        void Call_AccountEnquiry();
        void Call_GuanteeAccountEnquiry();
        //void Call_HPVoucherDetails(IList<LOMDTO00092> lsts);
        void Call_HPVoucherDetails(IList<LOMDTO00092> lsts, string dealerAC); // Added By AAM (11-Jan-2018)
        PFMDTO00067 GetAccountInformation();
        void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e);
        LOMDTO00084 AddHirePurchaseRegistration(string hpno, string caccount, string dealerAC, string dealerStatus, string guanteeAcctNo, decimal downPayPercent, decimal rChgsPercent,// decimal sChgsPercent,
                                           decimal nextYrRChgsPercent, decimal disAmt, decimal docFees, int gapPeriod, decimal commPercent, string stockGCode, string stockISubCode, string relatedGLACode, decimal productValue, int payDuration, int payOptionId,
                                           DateTime repaySDate, DateTime repayExpDate, string sourceBr, string remarks, int createdUserId, string eno, string username);


        string CheckBalance(string caccount, string sourceBr);
        string CheckAccountExistsOrValid(string caccount, string sourceBr);
        IList<LOMDTO00092> GetHPVoucherDetails(LOMDTO00092 d);
        string GetInstallmentAmt(decimal netAmt, int noOfTerms);

        //IList<decimal> GetRateForHPReg();
        IList<LOMDTO00080> GetAllDealerInformation(string sourceBr);
        string GetDealerCommission_ByDealerNo(string dealerNo, string sourceBr);
    }
    public interface ILOMVEW00081
    {
        ILOMCTL00081 Controller { get; set; }
        string DealerAC { get; set; }
        string Caccount { get; set; }
        string SourceBr { get; set; }
        string DealerNo { get; set; }
        string guanacctno { get; set; }
        decimal Commission { get; set; }
        string HPNo { get; set; }
    }

}
