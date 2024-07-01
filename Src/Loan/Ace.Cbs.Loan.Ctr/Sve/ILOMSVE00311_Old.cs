using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00311 : IBaseService
    {
        IList<PFMDTO00072> IsValidForLoanAcctno(string acctno);
        string Save_PersonalLoans(LOMDTO00313 personal_GuaranteeDto, LOMDTO00311 loanDto, IList<LOMDTO00012> penalFeeList, string sourceBranch);
        string PLMonthlyAutoPaymentProc(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);
        string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);
        LOMDTO00311 SelectPersonalLoanInfoByLnoAndSourceBr(string lno, string sourcebr);
        //Added by HWKO (13-Oct-2017)
        //For Personal Loans Manual Prepayment
        string CheckPLAccountandStartTerm(string plNo, string sourceBr);
        string Get_PL_PrepaymentInfo_NewLogic(string plNo, int startTerm, int endTerm, string sourceBr);
        string PL_Manual_Pre_Payment_Process_NewLogic(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);
        //Endregion
        string PLLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);//Added by HWKO (16-Oct-2017)
        string GetPLNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (26-Oct-2017)
        IList<LOMDTO00311> GetPLVrOutstandingListing(LOMDTO00311 dto);//Added by HWKO (27-Oct-2017) //For Personal Loans Voucher Outstanding Listing
        IList<TLMDTO00018> GetBLVrOutstandingListing(TLMDTO00018 dto);//Added by HWKO (07-Nov-2017) //For Business Loans Voucher Outstanding Listing
        IList<LOMDTO00311> GetPLLFOutstandingListing(LOMDTO00311 dto);//Added by HWKO (09-Nov-2017) //For Personal Loans Late Fees Outstanding Listing
        
        IList<LOMDTO00334> GetHPInfoForContractPrinting(LOMDTO00334 dto);//Added by HWKO (08-Dec-2017)
        string GetHPNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (08-Dec-2017)
        IList<LOMDTO00334> GetCustInfoByAcctNo(string acctNo, string sourceBr);//Added by HWKO (11-Dec-2017)
        IList<LOMDTO00336> GetPLInfoForContractPrinting(LOMDTO00336 dto);//Added by HWKO (12-Dec-2017)
        IList<LOMDTO00338> GetBLHPInfoForContractPrinting(LOMDTO00338 dto);//Added by HWKO (13-Dec-2017)
        IList<LOMDTO00338> GetBLLBInfoForContractPrinting(LOMDTO00338 dto); //Added by HWKO (13-Dec-2017)
        IList<LOMDTO00338> GetBLPGInfoForContractPrinting(LOMDTO00338 dto);//Added by HWKO (13-Dec-2017)
        string GetBLNoByACNoAndSourceBr(string acctNo, string sourceBr);//Added by HWKO (14-Dec-2017)
    }
}
