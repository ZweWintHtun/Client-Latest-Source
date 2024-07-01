using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00311 : IDataRepository<LOMORM00311>
    {
        LOMDTO00311 AddPLRegTermAndVouUpdate(string PLNo, string AcctNo, int NoOfTerms, decimal SanAmt, decimal IntRate, decimal DocumentFee,
            int PaymentDuration, string PaymentOptionId, string UserNo, string SourceBr, string Cur, int CreatedUserId, string ENo, DateTime SDate
            , string BType, DateTime ExpireDate, string Assessor, string Lawer, decimal MonthlyIncome, string CompanyName,
             bool isSCharge, decimal SCharges, bool isLateFee, string GuaCompanyName, string GuaName, string GuaNrc, string GuaPhone,
            decimal NYIntRate, int gracePeriod);//Updated By HWKO (02-Oct-2017)
        int GetLegalCaseFromPersonalLoansByAccountNo(string accountNo);
        string PLMonthlyAutoPaymentProc(string eno, string sourceBr, int createdUserId, string userName);
        string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);
        LOMDTO00311 GetPersonalLoansByLnoAndSourceBr(string loanNo, string sourceBr);
        LOMDTO00311 PersonalLoanVoucherEntry(string eno, string plno, string sourceBr);//Added by HWKO (28-Jul-2017)
        //Added by HWKO (13-Oct-2017)
        //For Personal Loans Manual Prepayment
        string CheckPLAccountandStartTerm(string plNo, string sourceBr);
        string Get_PL_PrepaymentInfo_NewLogic(string plNo, int startTerm, int endTerm, string sourceBr);
        string PL_Manual_Pre_Payment_Process_NewLogic(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                             decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);
        //Endregion
        string PLLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName);//Added by HWKO (16-Oct-2017)
        string GetPLNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (26-Oct-2017)
        IList<LOMDTO00311> GetPLVrOutstandingListing(string sourceBr, string cur);//Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing
        IList<TLMDTO00018> GetBLVrOutstandingListing(string sourceBr, string cur);//Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        IList<LOMDTO00311> GetPLLFOutstandingListing(string sourceBr, string cur);//Added by HWKO (09-Nov-2017) //For Personal Loans Late Fees Outstanding Listing
        
        IList<LOMDTO00334> GetHPInfoForContractPrinting(string hpNo, string sourceBr);//Added by HWKO (08-Dec-2017)
        string GetHPNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (08-Dec-2017)
        IList<LOMDTO00334> GetCustInfoByAcctNo(string acctNo, string sourceBr);//Added by HWKO (11-Dec-2017)
        IList<LOMDTO00336> GetPLInfoForContractPrinting(string plNo, string sourceBr);//Added by HWKO (12-Dec-2017)
        IList<LOMDTO00338> GetBLHPInfoForContractPrinting(string lno, string sourceBr);//Added by HWKO (13-Dec-2017)
        IList<LOMDTO00338> GetBLLBInfoForContractPrinting(string lno, string sourceBr); //Added by HWKO (13-Dec-2017)
        IList<LOMDTO00338> GetBLPGInfoForContractPrinting(string lno, string sourceBr);//Added by HWKO (13-Dec-2017)
        string GetBLNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (14-Dec-2017)
        string Get_CustomerName_PLVoucher(string plNo);//Added by AAM (27-Feb-2017)
    }
}
