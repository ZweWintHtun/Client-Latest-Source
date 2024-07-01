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

using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00096 : IBaseService
    {
        IList<LOMDTO00096> GetAllHPRegisterLists(string sourceBr, string cur, DateTime startDate, DateTime endDate, string stockGroup);
        IList<LOMDTO00100> GetHPPaymentSchedule(string sourceBr, string cur, string month, string year);
        LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm, decimal totalRepayAmt, string eno, string sourceBr, int createdUserId, string userName);
        string HPManualRepayment_CheckPaidOrUnpaid(string hpNo, int startTerm, int endTerm, string sourceBr, int createdUserId, string userName);
        string GetRepayAmountPerTerm(string hpno, string sourceBr);
        string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr);
        string HPMonthlyAutoPaymentProc(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);//
        IList<LOMDTO00202> GetHPOverDraftListing(string sourceBr, string cur,DateTime startDate,DateTime endDate);
        IList<LOMDTO00203> GetHPInsufficientListing(string sourceBr, string cur, string month);
        string HPLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00205> GetPLInfoListing(DateTime startDate, DateTime endDate, string companyName, string sourceBr);
        IList<LOMDTO00206> GetBLInterestListing(string month, string year, string sourceBr, int createdUserId);
        IList<LOMDTO00207> GetPersonalLoanNPLCaseListing(DateTime startDate, DateTime endDate, string sourceBr);
        string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr);
        string HPAccountExistsOrValid(string hpNo, string sourceBr);
        string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm, decimal totalLateFeesAmount, string eno, string sourceBr, int createdUserId, string userName);
        IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, DateTime startDate, DateTime endDate, string sourceBr);
        IList<LOMDTO00209> GetHPInformationListing(DateTime startDate, DateTime endDate, string stockGroup, string sourceBr);
        IList<LOMDTO00210> GetHPPaymentListing(DateTime startDate, DateTime endDate, string stockGroup, string cur, string sourceBr);
        IList<LOMDTO00211> GetHPRePaymentListing(DateTime startDate, DateTime endDate, string cur, string sourceBr, string stockGroup);
        IList<LOMDTO00212> GetHPInterest_Due_PreListing(DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup, string interestPaidStatus);// Added interestPaidStatus at (08-Dec-2017)
        IList<LOMDTO00213> Get_HP_Repayment_Schedule_Listing(string acctNo, string currency, string sourceBr);//Updated by HWKO (21-Nov-2017)
        string Get_HP_PrepaymentInfo(string hpNo, string sourceBr);
        string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);

        // Added-22-Sep-2017
        string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                    decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);
        string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr);
        string CheckHPAccountandStartTerm(string hpNo, string sourceBr);
        //Added 29-09-2017
        string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName, IList<DataVersionChangedValueDTO> dvcvList);
        //Added 20-10-2017
        IList<LOMDTO00214> HPAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);
        //Added 23-10-2017
        IList<LOMDTO00215> PLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);
        IList<LOMDTO00216> HPAbsentHistory_Enquiry(string acctno, string sourceBr);
        IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctno, string sourceBr);
        //Added By AAM(06-Nov-2017)
        IList<LOMDTO00218> HP_LateFees_Outstanding_Listing(string currency, string sourceBr);
        IList<LOMDTO00219> BL_LateFees_Outstanding_Listing(string currency, string sourceBr);
        IList<LOMDTO00220> HP_Installment_Listing(string currency, string sourceBr, string stockGroup);
        IList<LOMDTO00221> PL_Installment_Listing(string currency, string sourceBr, string companyName);
        IList<LOMDTO00222> BL_Installment_Listing(string currency, string sourceBr, string businessType);
        IList<LOMDTO00223> PL_DailyPosition_Listing(string sourceBr, string companyName);
        IList<LOMDTO00224> HP_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string stockGroup, string currency, string sourceBr);
        IList<LOMDTO00225> PL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string companyName, string currency, string sourceBr);
        IList<LOMDTO00226> BL_AutoPay_Sufficient_Listing(DateTime startDate, DateTime endDate, string businessType, string currency, string sourceBr);
        IList<LOMDTO00227> BL_Overdrawn_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00228> LOANS_SUMMARY_REPORT_ForBOM(DateTime Date, string currency, string sourceBr);
        IList<LOMDTO00229> LOANS_SUMMARY_REPORT_ForBOM_LiveUnLive(DateTime Date, string currency, string sourceBr);
        IList<LOMDTO00230> HP_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00230> PL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00230> BL_TOD_Repayment_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00231> HP_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00231> PL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00231> BL_AccountClosed_Listing(DateTime startDate, DateTime endDate, string currency, string sourceBr);
        IList<LOMDTO00232> Transfer_Transaction_Listing(string dateOption, DateTime startDate, DateTime endDate, string voucherStatus,
                                                        string requiredType, int reverseStatus, string currency, string sourceBr);
        string GetDealerBusinessName_For_HPLimitVoucher_Printing(string dealerNo);
        IList<LOMDTO00234> Get_HP_LimitVou_Lists(string eno);
        IList<LOMDTO00236> Get_BL_LimitVou_Lists(string eno);
        IList<LOMDTO00235> Get_PL_LimitVou_Lists(string eno);
        IList<LOMDTO00237> Get_HP_Information_For_Enquiry(string acctNo, string sourceBr);
        string HP_Registration_Reversal(string hpNo, string reversalEno, int createdUserId, string sourceBr);
        string Get_HPInfo_ByHPNo(string hpNo);
        IList<LOMDTO00238> Get_COA_Lists(string sourceBr);
        string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData, string eno, int createdUserId
                                                        , string sourceBr, string narration);
		
		// For Year End Income Voucher, added by AAM (28-Mar-2018)
        string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC, string sourceBr);
        IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr);
        string PNL_Zerorization_Income_Voucher(string pnlAC, string eno, int createdUserId, string sourceBr);
        
        // For Year End Expense Voucher, added by AAM (28-Mar-2018)
        IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr);
        string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr);
        string Expn_Zerorization_Expense_Voucher(string expnAC, string eno, int createdUserId, string sourceBr);

    }
}
