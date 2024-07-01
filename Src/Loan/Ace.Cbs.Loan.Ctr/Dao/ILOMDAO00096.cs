﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00096 : IDataRepository<LOMORM00026>
    {
        IList<LOMDTO00096> GetAllHPRegisterLists(string sourceBr, string cur, DateTime startDate, DateTime endDate, string stockGroup);
        IList<LOMDTO00100> GetHPPaymentSchedule(string sourceBr, string cur, string month, string year);
        LOMDTO00200 HPManualRepayment(string hpNo, int startTerm, int endTerm, decimal totalRepayAmt, string eno, string sourceBr, int createdUserId, string userName);
        string HPManualRepayment_CheckPaidorUnpaid(string hpNo, int startTerm, int endTerm, string sourceBr, int createdUserId, string userName);
        string GetRepayAmountPerTerm(string hpno, string sourceBr);
        string GetRepayAmountSTermToETerm(string hpno, int startTerm, int endTerm, string sourceBr);
        string HPMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName);
        IList<LOMDTO00202> GetHPOverDraftListing(string sourceBr, string cur, DateTime startDate, DateTime endDate);
        IList<LOMDTO00203> GetHPInsufficientListing(string sourceBr, string cur, string month);
        string HPLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName);
        IList<LOMDTO00204> GetBLInfoListingByDateRange(DateTime startDate, DateTime endDate, string sourceBr, string blType);//Modified(29.11.17)
        IList<LOMDTO00205> GetPLInfoListing(DateTime startDate, DateTime endDate, string companyName,string sourceBr);
        IList<LOMDTO00206> GetBLInterestListing(string month, string year, string sourceBr, int createdUserId);
        IList<LOMDTO00207> GetPersonalLoanNPLCaseListing(DateTime startDate, DateTime endDate, string sourceBr);
        string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr);
        string HPAccountExistsOrValid(string hpNo, string sourceBr);
        string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm, decimal totalLateFeesAmount, string eno, string sourceBr, int createdUserId, string userName);
        //IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, DateTime startDate, DateTime endDate, string sourceBr); // Modified By AAM (25-Oct-2017), Added two date by AAM (01-Feb-2018)
        IList<LOMDTO00208> GetHPDailyPositionListing(string stockGroupCode, string sourceBr); // Modified By AAM (25-Oct-2017), Added two date by AAM (01-Feb-2018)
        IList<LOMDTO00209> GetHPInformationListing(DateTime startDate, DateTime endDate, string stockGroup, string sourceBr);// Modified By AAM (26-Oct-2017)
        IList<LOMDTO00210> GetHPPaymentListing(DateTime startDate, DateTime endDate, string stockGroup, string cur, string sourceBr);// Modified By AAM (27-Oct-2017)
        IList<LOMDTO00211> GetHPRepaymentListing(DateTime startDate, DateTime endDate, string cur, string sourceBr, string stockGroup);// Modified By AAM (08-Nov-2017)
        IList<LOMDTO00212> GetHPInterest_Due_PreListing(DateTime startDate, DateTime endDate, string currency, string sourceBr, string stockGroup, string interestPaidStatus);// Added interestPaidStatus at (08-Dec-2017)
        IList<LOMDTO00213> Get_HP_Repayment_Schedule_Listing(string acctNo, string currency, string sourceBr);//Updated by HWKO (21-Nov-2017)
        string Get_HP_PrepaymentInfo(string hpNo, string sourceBr);
        string HP_Manual_Pre_Payment_Process(string hpNo, int startTerm, int endTerm, decimal totalPaidPrepayAmt, decimal totalPaidRentalChgAmt,
                                             decimal rentalDiscountRate, string eno, string sourceBr, int createdUserId, string userName);

        string GetTotalIntAmtOfAllTermByAcctNo(string acctNo, string sourceBr);//Added by HWKO (14-Sep-2017) // For HP Interest Pre-Payment Voucher Entry
        string UpdateRentalChargesInTermByAcctNo(string acctNo, string sourceBr);//Added by HWKO (14-Sep-2017) // For HP Interest Pre-Payment Voucher Entry
        
        // Added-22-Sep-2017
        string Get_HP_PrepaymentInfo_NewLogic(string hpNo, int startTerm, int endTerm, string sourceBr);// 
        string HP_Manual_Pre_Payment_Process_NewLogic(string hpNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt, decimal totalPaidPrincipleAmt, decimal totalPaidRentalChgAmt,
                                                             decimal rentalDiscountRate, string sourceBr, int createdUserId, string userName);
        string CheckHPAccountandStartTerm(string hpNo, string sourceBr);
        //Added 29-09-2017
        //string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName);

        //Comment & Modified by HMW at (26-07-2019) : Generate ENO at Script side to prevent "Voucher No Loss Issue" in every already run (or) no need to run case.
        string HPLateFeesAutoPayVoucherProcess(string sourceBr, int createdUserId, string userName);

        //Added 20-10-2017
        IList<LOMDTO00214> HPAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);
        //Added by AAM (23-Oct-2017)
        IList<LOMDTO00215> PLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr);
        IList<LOMDTO00216> HPAbsentHistory_Enquiry(string acctno, string sourceBr);
        IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctno, string sourceBr);

        //IList<LOMDTO00218> HP_LateFees_Outstanding_Listing(string currency, string sourceBr);
        IList<LOMDTO00218> HP_LateFees_Outstanding_Listing(string currency, string sourceBr
                                                   , DateTime startDate, DateTime endDate, int searchBy);//Added By AAM(06-Nov-2017)

        IList<LOMDTO00219> BL_LateFees_Outstanding_Listing(string currency, string sourceBr);//Added By AAM(15-Nov-2017)
        //Updated By ZMS(18-06-2018)
        IList<LOMDTO00220> HP_Installment_Listing(string currency, string sourceBr, string stockGroup, string SortType);//Added By AAM(27-Nov-2017) 
        //Updated By ZMS(18-06-2018)
        IList<LOMDTO00221> PL_Installment_Listing(string currency, string sourceBr, string companyName, string SortType);
        //Updated By ZMS(18-06-2018)
        IList<LOMDTO00222> BL_Installment_Listing(string currency, string sourceBr, string businessType, string SortType);
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
        IList<LOMDTO00235> Get_PL_LimitVou_Lists(string eno);
        IList<LOMDTO00236> Get_BL_LimitVou_Lists(string eno);
        IList<LOMDTO00237> Get_HP_Information_For_Enquiry(string acctNo, string sourceBr);
        string HP_Registration_Reversal(string hpNo, string reversalEno, int createdUserId, string sourceBr);
        string Get_HPInfo_ByHPNo(string hpNo);
        IList<LOMDTO00238> Get_COA_Lists(string sourceBr);
        string Importing_Deposit_Voucher(string acWithOtherBnk, List<LOMDTO00238> lstImportData, string eno, int createdUserId
                                                , string sourceBr, string narration);
												
        // For Year End Income Voucher, added by AAM (28-Mar-2018)
        IList<LOMDTO00239> Get_PNL_Zerorization_Income_Info(string sourceBr);
        string Get_Info_For_PNL_Zerorization_Income_ByPLAC(string plAC, string sourceBr);
        string PNL_Zerorization_Income_Voucher(string plAC, int createdUserId, string sourceBr);//Modified by HMW at 19-Sept-2019 : ENO will generate from script side directly (for both actual date and back date transactions)
        string Check_AlreadyZerorizationForIncomeAC(string ProfitAndLossAc);//Added by HMW at 23-Sept-2019

        // For Year End Expense Voucher,added by AAM (28-Mar-2018)
        IList<LOMDTO00239> Get_Expn_Zerorization_Expense_Info(string sourceBr);
        string Get_Info_For_Expn_Zerorization_Expense_ByExpnAC(string expnAC, string sourceBr);
        string Expn_Zerorization_Expense_Voucher(string expnAC, int createdUserId, string sourceBr);//Modified by HMW at 19-Sept-2019 : ENO will generate from script side directly (for both actual date and back date transactions)
        string Check_AlreadyZerorizationForExpenseAC(string ProfitAndLossAc);//Added by HMW at 23-Sept-2019

        // Personal Loan Manual Prepayment Process,added by AAM (05-Apr-2018)
        string PL_Manual_Pre_Payment_Process(string plNo, int startTerm, int endTerm, decimal totalPaidInstallmentAmt
                                            , decimal totalPaidPrincipleAmt, decimal totalPaidInterestAmt, decimal intDiscountRate, string sourceBr
                                            , int createdUserId, string userName, string formatCode
                                            , int valueCount, string valueStr);
        string Get_PL_PrepaymentInfo(string plNo, int startTerm, int endTerm, string sourceBr);
        string CheckPLAccountandStartTerm(string plNo, string sourceBr);
        IList<LOMDTO00241> Get_HPList_For_Interest_Prepay_ByDealer(LOMDTO00241 hpListBydealer);
        string Dealer_Interest_Prepaid_ForHP(LOMDTO00241 hpListBydealer);
        IList<LOMDTO00242> HPInterestPrepaidByDealer_Listing(LOMDTO00242 hpIntPrepaidList);

        string PL_Registration_Reversal(string plNo, int createdUserId, string sourceBr, string formatCode
                                                , int valueCount, string valueStr);
        string Get_PLInfo_ByPLNo(string plNo);
        string BL_Registration_Reversal(string blNo, string formatCode, int createdUserId, string sourceBr);//Modify by HMW at 27-08-2019
        string Get_BLInfo_ByBLNo(string blNo);

        IList<LOMDTO00240> Get_TotalInterestAndFirstInstallment(LOMDTO00084 dto);
        IList<LOMDTO00244> CheckAccountForAccountClosed(string acctNo, string sourceBr);
        IList<LOMDTO00244> GetAccountInfoForAccountClosed(string acctNo, string sourceBr);
        string Save_AccountClosed(LOMDTO00244 dto);
        IList<LOMDTO00244> AccountClosedListing(LOMDTO00244 dto);
        IList<LOMDTO00245> TransactionListing(LOMDTO00245 dto);

        IList<LOMDTO00219> GetLateFeeInfoByACNo(string acctno, string sourcebr);   //Added by YMP for Late Fee Exception (15-May-2019)
        string SaveLateFeeExceptionInfo(IList<LOMDTO00219>  SaveLateFeeExceptionInfo);   //Added by YMP for Late Fee Exception (16-May-2019)
        IList<LOMDTO00219> GetLateFeeInfoAllForChecker();   //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        string UpdateLateFeeExceptionInfo(IList<LOMDTO00219> latefeeinfo, string ApproveReject);   //Added by YMP for Late Fee Exception (Checker) (17-May-2019)
        IList<LOMDTO00219> BL_OD_AND_LateFee_Outstanding_Listing_ByAccount(string accountno, string sourceBr);//Added by HMW for BL Limit Extend (Manual) Entry at 13-Nov-2019
    }
}