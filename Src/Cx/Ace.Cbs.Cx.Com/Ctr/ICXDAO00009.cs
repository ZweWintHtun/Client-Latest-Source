//----------------------------------------------------------------------
// <copyright file="ICXDAO00009" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>♠ Ye Mann Aung ♠</CreatedUser>
// <CreatedDate> 2013.12.11 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// DAO Interface Class for View Queries
    /// </summary>
    public interface ICXDAO00009
    {

        IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches(string workstation, DateTime datetime); //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches(string workstation, string cur, DateTime datetime); //VW_TRANSFERSCROLL
        IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch(string workstation, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch(string workstation, string cur, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL

        IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_BySDate(string workstation, DateTime datetime); //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_BySDate(string workstation, string cur, DateTime datetime); //VW_TRANSFERSCROLL
        IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_BySDate(string workstation, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_BySDate(string workstation, string cur, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL

        IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_withoutReverse(string workstation, DateTime datetime); //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_withoutReverse(string workstation, string cur, DateTime datetime); //VW_TRANSFERSCROLL
        IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_withoutReverse(string workstation, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_withoutReverse(string workstation, string cur, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL

        IList<MNMDTO00033> SelectTransferScroll_Home_AllBranches_BySDate_withoutReverse(string workstation, DateTime datetime); //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_AllBranches_BySDate_withoutReverse(string workstation, string cur, DateTime datetime); //VW_TRANSFERSCROLL
        IList<MNMDTO00033> SelectTransferScroll_Home_ByBranch_BySDate_withoutReverse(string workstation, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL_Home
        IList<MNMDTO00033> SelectTransferScroll_ByCur_ByBranch_BySDate_withoutReverse(string workstation, string cur, DateTime datetime, string sourcebr);  //VW_TRANSFERSCROLL

 IList<TLMDTO00009> SelectDataForMultiDeno(string cur, string branchno, DateTime cashdate);
        //"TLMVIW00D14.SelectDataForMultiDeno for All Counter"
        IList<TLMDTO00009> SelectDataForMultiDenoByCounterNo(string cur, string branchno, DateTime cashdate, string counterno);
        IList<MNMDTO00035> SelectFReceiptInfo(string acctno, string branchno, string cur);
        IList<MNMDTO00035> SelectDurationForFixedDeposit(decimal duration, string branchno);


        IList<PFMDTO00021> SelectFixedDepoInfoForAll(DateTime start_date, DateTime end_date, string branchno, string cur);
        IList<PFMDTO00021> SelectFixedDepoInfoForOther(DateTime start_date, DateTime end_date, string branchno, string cur, string acsign);
        IList<PFMDTO00021> SelectFixedDepoInfoForAllByFilter(DateTime start_date, DateTime end_date, string branchno, string cur, string accruedstatus);
        IList<PFMDTO00021> SelectFixedDepoInfoForOtherByFilter(DateTime start_date, DateTime end_date, string branchno, string cur, string acsign, string accruedstatus);

        IList<PFMDTO00029> SelectLinkACAll(string branchNo);
        IList<PFMDTO00029> SelectLinkACExcess(string branchNo);
        IList<PFMDTO00001> SelectSaofInfo(string sourceBr);
        IList<PFMDTO00001> SelectCaofInfo(string sourceBr);
        PFMDTO00001 SelectCaofInfoByAcctno(string acctno);
        PFMDTO00001 SelectSaofInfoByAcctno(string acctno);
        IList<PFMDTO00054> SelectDenoOutstandingReport(string sourceBr);
        IList<TLMDTO00009> SelectMultiTransactionDenoOutstandingReport(string sourceBr);
        IList<TLMDTO00004> HomeIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate);
        IList<TLMDTO00004> ActiveIncomeListingByAllBranch(string sourceBr, DateTime startDate, DateTime endDate);
        IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branch, string sourceBranch);//edited by KMT
        IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(DateTime startDate, DateTime endDate, string branch, string sourceBranch);
        IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranchForReversal(DateTime startDate, DateTime endDate,string branch,string sourceBranch);
        IList<TLMDTO00004> HomeTransactionByBranchListing(DateTime startDate, DateTime endDate, string branch, string sourceBranch);
        IList<TLMDTO00004> ActiveTransactionByBranchListing(DateTime startDate, DateTime endDate, string branch, string sourceBranch);
        IList<TLMDTO00037> SelectIBLTestKeyListingReport();
        Nullable<DateTime> SelectMaxDate(DateTime date);
        UserDTO SelectUserIdbyUsername(string username);
        UserDTO SelectUserNamebyUserIdForUserNoReport(string username);
        IList<TLMDTO00037> SelectAllIBLTestKeyListingByMaxDate(DateTime maxdate);
        Nullable<decimal> SelectSumM1Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM2Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM3Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM4Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM5Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM6Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM7Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM8Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM9Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM10Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM11Data(string accountNo, string budgetYear);
        Nullable<decimal> SelectSumM12Data(string accountNo, string budgetYear);
        IList<PFMDTO00042> SelectDepositListingByAll(string sourcebr,string workStation);
        IList<PFMDTO00042> SelectDepositListingByCounterNo(string sourcebr, string counterNo,string workstation);
        IList<PFMDTO00042> SelectDepositListingByGrade(DateTime startDate, DateTime endDate, decimal minimumAmount, decimal maximumAmount, string acSign, string sourcebr,string workstation);
        IList<PFMDTO00042> SelectDepositListingByAccountNo(string sourceBr, string accountNo,string workstation);
        //IList<PFMDTO00042> SelectDepositListingByAccountType(string workStation, string accountSign, string userNo);
        IList<PFMDTO00042> SelectDepositListingByAccountType(string sourceBr, string accountSign,string workstation);
        IList<PFMDTO00042> SelectWithdrawalListingAllReport(DateTime startDate, DateTime endDate, string sourcebranchcode, int workstation);
        IList<PFMDTO00042> SelectWithdrawalListingByAccountTypeReport(DateTime startDate, DateTime endDate, int workstation, string acsign, string sourcebr);
        IList<PFMDTO00042> SelectWithdrawalListingByCounterNoReport(DateTime startDate, DateTime endDate, string sourcebr, int workstationId,string userno);
        IList<PFMDTO00042> SelectWithdrawalListingByAccountNoReport(DateTime startDate, DateTime endDate, string accountNo, string sourcebr, int workstationId);
        IList<PFMDTO00042> SelectTransactionDateWithReversalByHome(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectTransactionDateWithReversalByCurrencyCode(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithReversalByCurrencyCodeSettlementDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithdrawAmountAndDepositAmountBankStatementForFixed(string workstation, string accountno, DateTime firstdate, DateTime seconddate);
        IList<PFMDTO00042> SelectDatasFromBankStatementForFixed(string workstation, string accountno, DateTime startdate, DateTime enddate);
        IList<TLMDTO00058> SelectDayBookCurrent(string workStation, string sourceCur, DateTime requireDate);
        IList<TLMDTO00058> SelectDayBookSavings(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomestic(string workStation, string sourceCur, DateTime requireDate);
        IList<TLMDTO00017> SelectDataForDrawingRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate,string sourceBr);  //edited
        IList<TLMDTO00017> SelectDataForDrawingRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate,string sourceBr); //edited 
        IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr);  //edited
        IList<TLMDTO00017> SelectDataForDrawingRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr); //edited
        //IList<TLMDTO00017> SelectAmountForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
        IList<TLMDTO00017> SelectAmountForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr); //edited 
        //IList<TLMDTO00017> SelectAmountForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount);
        IList<TLMDTO00017> SelectAmountForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr); //edited
        IList<TLMDTO00017> SelectNRCForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNameForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForDrawingRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
        IList<PFMDTO00042> SelectTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectWithReversalByForAllBranchAndSourceCurBySettlementDate(PFMDTO00042 bankCashDTO);
        IList<TLMDTO00058> SelectDayBookCurrentReversal(string workStation, string sourceCur, System.DateTime requireDate);
        IList<TLMDTO00058> SelectDayBookSavingsReversal(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticReversal(string workStation, string sourceCur, DateTime requireDate);
        IList<PFMDTO00042> SelectAllWithoutReversalByHomeTransactionDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeTransactionDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectAllWithoutReversalByHomeSettlementDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelectByBankCashWithoutReversalByCurCodeSettlementDate(PFMDTO00042 bankCashDTO);
        IList<TLMDTO00058> SelectDayBookCurrentHome(string workStation, string sourceCur, DateTime requireDate);
        IList<TLMDTO00058> SelectDayFixed(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticHome(string workStation, string sourceCur, DateTime requireDate);
        IList<TLMDTO00017> SelectDataForEncashRemittanceAllByTransactionDate(DateTime startDate, DateTime endDate,string sourceBr);  //edited
        IList<TLMDTO00017> SelectDataForEncashRemittanceAllBySettlementDate(DateTime startDate, DateTime endDate,string sourceBr);  //edited
        IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchByTransactionDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr);
        IList<TLMDTO00017> SelectDataForEncashRemittanceByBranchBySettlementDate(DateTime startDate, DateTime endDate, string bankno,string sourceBr);
        IList<TLMDTO00017> SelectAmountForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr);
        IList<TLMDTO00017> SelectAmountForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, decimal startamount, decimal endamount,string sourceBr);
        IList<TLMDTO00017> SelectNRCForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNRCExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string nrc);
        IList<TLMDTO00017> SelectNameForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceByTransactionDate(DateTime startDate, DateTime endDate, string name);
        IList<TLMDTO00017> SelectNameExactlyForEncashRemittanceBySettlementDate(DateTime startDate, DateTime endDate, string name);
        IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurTransactionDate(PFMDTO00042 bankCashDTO);
        IList<PFMDTO00042> SelecteWithoutReversalByForAllBranchAndSourceCurSettlementDate(PFMDTO00042 bankCashDTO);
        //IList<TLMDTO00058> SelectDayBookCurrentHomeReversal(string workStation, string sourceCur, DateTime requireDate);
        IList<TLMDTO00058> SelectDayFixedReversal(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticHomeReversal(string workStation, string sourceCur, DateTime requireDate);
        IList<PFMDTO00042> GetScrollData_LC(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval);
        IList<PFMDTO00042> GetScrollData_LD(string workstation, DateTime date_time, string currnecy, bool isTransactionDate, bool isReserval);
        IList<PFMDTO00042> GetCleanCashByHomeCurrencyData(string workStation, DateTime datetime, string currency);
        IList<PFMDTO00042> GetCleanCashData(string workStation, DateTime datetime, string currency);
        IList<PFMDTO00042> GetCleanCashWithoutReversalByHomeCurrencyData(string workStation, DateTime datetime, string currency);
        IList<PFMDTO00042> GetCleanCashWithoutReversalData(string workStation, DateTime datetime, string currency);
        IList<PFMDTO00017> GetAllCustomerLists();
        IList<PFMDTO00042> SelectWithdrawAmountAndDepositAmountBankStatementForCS(string workstation, string accountno, DateTime firstdate, DateTime seconddate);
        //IList<PFMDTO00042> SelectDatasFromBankStatementForCS(string workstation, string accountno, DateTime startdate, DateTime enddate);
        IList<MNMDTO00010> SelectSumCCOAAmount(string cur, string acode, string budget, string dcode);
        IList<MNMDTO00023> SelectAll(DateTime startdate, DateTime enddate, string branchCode, string workstation);
        IList<PFMDTO00042> SelectWithdrawListingByGrade(DateTime startDate, DateTime endDate, decimal minimumAmount,
            decimal maximumAmount, string acSign, string sourceBr, int workstation);

        PFMDTO00042 SelectCrTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO);
        PFMDTO00042 SelectDrTranDateWithReversalByForAllBranchAndSourceCur(PFMDTO00042 bankCashDTO);
        string SelectAccountNamefromCOA(string acode, string sourcebranchcode);


        IList<TLMDTO00058> SelectDayBookCurrentBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        IList<TLMDTO00058> SelectDayBookCurrentReversalBySettlementDate(string workStation, string sourceCur, System.DateTime requireDate);

        IList<TLMDTO00058> SelectDayBookCurrent_HomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        //IList<TLMDTO00058> SelectDayBookCurrentHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        IList<TLMDTO00058> SelectDayBookSavingsBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        IList<TLMDTO00058> SelectDayBookSavingsReversalBySettlemtntDate(string workStation, string sourceCur, DateTime requireDate);

        IList<TLMDTO00058> SelectDayFixedBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        IList<TLMDTO00058> SelectDayFixedReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticBySettlementDate(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticHomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate);
        //IList<TLMDTO00058> SelectDayBookDomesticHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate);

        IList<MNMDTO00010> SelectTrialBalanceDetailBySource(string month, string dcode, string cur);
        IList<MNMDTO00010> SelectTrialBalanceDetailBySourceAllBranch(string month, string cur);
        IList<MNMDTO00010> SelectTrialBalanceDetailByHome(string month, string dcode);
        IList<MNMDTO00010> SelectTrialBalanceDetailByHomeAllBranch(string month);
        IList<MNMDTO00010> SelectTrialBalanceDetailBySourceAllBranchHome(string month, string cur);
        IList<MNMDTO00010> SelectTrialBalanceDetailBySourceHome(string month, string cur, string dcode);
        UserDTO SelectUserNamebyUserId(int userid);

        IList<MNMDTO00034> SelectInterest(string sourceBr);
        //DateTime SelectDateTime();

        #region Sub_Ledger(Domestic)
        IList<MNMDTO00010> GetHOBaLAndCBalForSubLedger_Domestic(string acode, string budYear, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00010> GetHOBaLAndCBalForSubLedger_DomesticByCur(string currency, string acode, string budYear, string sourcebr);//call from MNMSVE00054       

        IList<MNMDTO00054> SelectLedgerListingByDateTime(string date1, string date2, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListingBySettlementDate(string date1, string date2, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListingByDateTimeAndCurrency(string date1, string date2, string sourcecur, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListingBySettlementDateAndCurrency(string date1, string date2, string sourcecur, string workstation, string sourcebr);//call from MNMSVE00054

        IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndDateTime(string acode, string date1, string date2, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndSettlementDate(string acode, string date1, string date2, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndDateTimeAndCur(string acode, string date1, string date2, string sourcecur, string workstation, string sourcebr);//call from MNMSVE00054
        IList<MNMDTO00054> SelectLedgerListing_ByACtypeAndSettlementDateAndCur(string acode, string date1, string date2, string sourcecur, string workstation, string sourcebr);//call from MNMSVE00054

        //With HomeCurrency and TransactionDate
        IList<MNMDTO00054> GetLedgerListingRptByTDate(DateTime startDate, DateTime endDate, string workstation, string sourcebr);  //Cash = 1
        IList<MNMDTO00054> GetLedgerListingRptByTDate1(DateTime startDate, DateTime endDate, string workstation, string sourcebr); // Cash = 0 && 1
        IList<MNMDTO00054> GetLedgerListingRptByTDate2(string aCode, DateTime startDate, DateTime endDate, string workstation, string sourcebr); // By Acode 

        //With HomeCurrency and SettlementDate
        IList<MNMDTO00054> GetLedgerListingRptBySDate(DateTime startDate, DateTime endDate, string workstation, string sourcebr);  //Cash = 1
        IList<MNMDTO00054> GetLedgerListingRptBySDate1(DateTime startDate, DateTime endDate, string workstation, string sourcebr); // Cash = 0 && 1
        IList<MNMDTO00054> GetLedgerListingRptBySDate2(string aCode, DateTime startDate, DateTime endDate, string workstation, string sourcebr); // By Acode 

        //With SourceCur and TransactionDate
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr);  //Cash = 1
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate1(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr); // Cash = 0 && 1
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndTdate2(string aCode, DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr); // By Acode 

        //With SourceCur and SettlementDate
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr);  //Cash = 1
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate1(DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr); // Cash = 0 && 1
        IList<MNMDTO00054> GetLedgerListingRptBySourceCurAndSdate2(string aCode, DateTime startDate, DateTime endDate, string sourcecur, string workstation, string sourcebr); // By Acode 
        #endregion

        //IList<MNMDTO00035> SelectLedgerBalanceAll(string sourceBr);

        IList<MNMDTO00035> SelectLedgerBalanceAllByCurrency(string sourceBr, string cur);
        IList<MNMDTO00035> SelectLedgerBalanceByAcsignAndCurrency(string sourceBr, string acSign, string cur);
        IList<MNMDTO00035> SelectLedgerBalanceByFixedAccount(string sourceBr, string cur);
        IList<MNMDTO00035> SelectLedgerBalanceAllByAllCurrency(string sourceBr);
        IList<MNMDTO00035> SelectLedgerBalanceByAcsignAndAllCurrency(string sourceBr, string acSign);
        IList<MNMDTO00035> SelectLedgerBalanceByFixedAccountAndAllCurrency(string sourceBr);
        IList<MNMDTO00035> SelectLedgerBalanceByOverdraftAndCurrency(string sourceBr, string cur);
        IList<MNMDTO00035> SelectLedgerBalanceByOverdraftAndAllCurrency(string sourceBr);

        //IList<MNMDTO00035> SelectLedgerBalanceAllByCurrency(string sourceBr, string cur);
        //IList<MNMDTO00035> SelectLedgerBalanceByAcsignAndCurrency(string sourceBr, string acSign, string cur);
        //IList<MNMDTO00035> SelectLedgerBalanceByFixedAccount(string sourceBr, string cur);



        IList<MNMDTO00033> SelectTRScrollHomeCurAllBrTdate(string workstation, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRScrollSourceBrHomeCurTdate(string workstation, string sourcebr, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRScrollHomeCurAllBrSdate(string workstation, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRScrollSourceBrHomeCurSdate(string workstation, string sourcebr, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRScrollAllBrSourceCurTdate(string workstation, string sourcecur, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRScrollSourceBrSourceCurTdate(string workstation, string sourcebr, string sourcecur, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRScrollAllBrSourceCurSdate(string workstation, string sourcecur, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRScrollSourceBrSourceCurSdate(string workstation, string sourcebr, string sourcecur, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalHomeCurAllBrTdate(string workstation, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalSourceBrHomeCurTdate(string workstation, string sourcebr, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalHomeCurAllBrSdate(string workstation, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalSourceBrHomeCurSdate(string workstation, string sourcebr, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalAllBrSourceCurTdate(string workstation, string sourcecur, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalSourceBrSourceCurTdate(string workstation, string sourcebr, string sourcecur, DateTime TDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalAllBrSourceCurSdate(string workstation, string sourcecur, DateTime SDatetime);
        IList<MNMDTO00033> SelectTRWithoutReversalSourceBrSourceCurSdate(string workstation, string sourcebr, string sourcecur, DateTime SDatetime);
        IList<MNMDTO00037> SelectCurrentClosedAccountByDate(DateTime startDate, DateTime endDate, string branch);
        IList<MNMDTO00037> SelectSavingClosedAccountByDate(DateTime startDate, DateTime endDate, string branch);
        IList<MNMDTO00039> SelectCustIDByDate(DateTime startDate, DateTime endDate, string branch);//, string currency //Commented by HWKO (25-Aug-2017)
        IList<MNMDTO00039> SelectCustIDByTownship(DateTime startDate, DateTime endDate, string branch, string township);//, string currency //Commented by HWKO (25-Aug-2017)

        IList<MNMDTO00040> SelectLedgerBalanceByGradeCurrent(decimal startAmount, decimal endAmount, string currency, string sourcebr);
        IList<MNMDTO00040> SelectLedgerBalanceByGradeCurrentAllCurrency(decimal startAmount, decimal endAmount, string sourcebr);
        IList<MNMDTO00040> SelectLedgerBalanceByGradeSavingAllCurrency(decimal startAmount, decimal endAmount, string sourcebr);
        IList<MNMDTO00040> SelectLedgerBalanceByGradeSaving(decimal startAmount, decimal endAmount, string currency, string sourcebr);

        IList<PFMDTO00042> SelectTrialSheetWithoutReversal(string cur, string workstation, string sourceBr);
        IList<PFMDTO00042> SelectTrialSheetWithReversal(string cur, string workstation, string sourceBr);
        IList<PFMDTO00042> SelectClearingDeliveredReversalListingReports(DateTime startDate, DateTime endDate, string workStation, string sourcebr);
        IList<PFMDTO00042> SelectClearingReceiptReversalListingReports(DateTime startDate, DateTime endDate, string workStation);

        IList<PFMDTO00001> SelectCurrentAC_AllByMonth(string month, string sourceBr);

        #region Sub_Ledger(Customer)
        IList<PFMDTO00001> SelectCurrentAC_All(string sourcebr);
        IList<PFMDTO00001> SelectSavingAC_All(string sourcebr);
        IList<PFMDTO00001> SelectBankStatementAll_ByAcctNo(string acctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr);
        IList<PFMDTO00042> SelectBankStatement_ByAcctNo(string acctNo, DateTime startPeriod, DateTime endPeriod, string sourceBr);
        PFMDTO00033 SelectBalance_ByAcctNoAndBudYear(string month, string acctNo, string budYear, string sourceBr);
        #endregion

        #region CustomerAccountListing
        IList<PFMDTO00017> SelectCurrentAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        IList<PFMDTO00017> SelectCurrentAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        IList<PFMDTO00017> SelectSavingAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        IList<PFMDTO00017> SelectSavingAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr);
        #endregion

        #region DailyDrawingAndEncashRemittanceListing

        IList<TLMDTO00001> SelectDailyEncashRemittanceListing_ByTransactionDate(DateTime date, string eBank, string sourceBr);  //VW_MOB836
        IList<TLMDTO00001> SelectDailyEncashRemittanceListing_BySettlementDate(DateTime date, string eBank, string sourceBr); //VW_MOB836 
        IList<TLMDTO00017> SelectDailyDrawingRemittanceListing_ByTransactionDate(DateTime date, string dBank, string sourceBr);  //VW_MOB831
        IList<TLMDTO00017> SelectDailyDrawingRemittanceListing_BySettlementDate(DateTime date, string dBank, string sourceBr);  //VW_MOB831

        #endregion

        IList<MNMDTO00040> SelectNameByAccountNo(string acctno);
        IList<MNMDTO00039> GetFAOFCustomerInfo(string accountNo);

        //MNMDTO00010 VW_CCOA_SumMonthByACode(string aCode, string currency, string budMonth); //nnl
        MNMDTO00010 VW_CCOA_SumMonthByACode(string strOpeningField, string aCode, string currency, string budYear); //ASDA

        IList<PFMDTO00001> SelectSavingAC_AllByMonth(string month, string sourceBr);

        IList<TCMDTO00013> SelectAcctNobyOVERDRAWN(string workstation, string currency, string sorting);
        IList<TCMDTO00013> SelectAcctNoAbyWorkstation(string workstation, string currency, string sorting);
        IList<TCMDTO00013> SelectAcctNoCbyWorkstation(string workstation, string currency, string sorting);
        IList<TCMDTO00013> SelectAcctNoSbyWorkstation(string workstation, string currency, string sorting);
        IList<TCMDTO00013> SelectAcctNoFbyWorkstation(string workstation, string currency, string sorting);

        PFMDTO00033 VW_BAL_SelectMonth(string month, string accountNo, string budget);
        IList<PFMDTO00042> BankSatatementByWithdrawAmount(string workstation, string accountNo, int year, int month);
        IList<PFMDTO00042> BankSatatementByDepositAmount(string workstation, string accountNo, int year, int month);
        IList<PFMDTO00042> BankSatatementByAllWithdrawDeposit(string workstation, string accountNo, int year, int month);
        #region PO and IR Listing

        IList<PFMDTO00042> SelectIR_Outstanding(string sourceBr);
        IList<PFMDTO00042> SelectPORegisterEncashListing(DateTime startDate, DateTime endDate, string sourceBr);
        IList<PFMDTO00042> SelectPOAndIR_RegisterAndWithdrawalListing(DateTime startDate, DateTime endDate, string formName, bool IsTransactionDat, string sourceBranchCode);
        IList<PFMDTO00042> SelectPOWithdrawalEncashListing(DateTime startDate,DateTime endDate,string formName,string sourceBranchCode);

        #endregion Fixed
        IList<MNMDTO00077> SelectByFixedAutoRenewalListing(DateTime startDate, DateTime endDate, string cur, string status, string sourceBr, string formName);
        IList<MNMDTO00077> SelectByFixedAutoRenewalAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);


        IList<MNMDTO00044> SelectFixedYEInterestPrevList(string SourceBr);
        IList<MNMDTO00043> SelectFixedYEInterestList(string SourceBr);

        //IList<TLMDTO00001> SelectEncashRegisterOutstanding(string sourceBr);  //ASDA

        UserDTO SelectUserInfobyUseNameForUserNoReport(string username,string branchcode);

        IList<LOMDTO00013> GetLegalCaseListByAccountNo(string accountNo, string sourceBr);   //LOMSVE00032

      //  IList<TLMDTO00017> SelectDrawingAndEncashMonthlyClosingList(string sourceBr, string budget);

        #region "Monthly Closing Drawing+Encash"
        IList<TLMDTO00017> SelectDrawingRemittanceListByMonthlyClosingByReceiptDate(string sourceBr, string budget);
        IList<TLMDTO00017> SelectDrawingRemittanceListByMonthlyClosingBySettlementDate(string sourceBr, string budget);
        IList<TLMDTO00001> SelectEncashRemittanceListByMonthlyClosingByIssueDate(string sourceBr, string budget);
        IList<TLMDTO00001> SelectEncashRemittanceListByMonthlyClosingBySettlementDate(string sourceBr, string budget);
        #endregion

        IList<PFMDTO00042> SelectDataFromReportTlf(string accountNo, DateTime startOfMonth, DateTime endOfMonth, int workStationId, string sourceBr);  //LOMSVE00016
        IList<SAMDTO00056> SelectRateFileListByStatusActive(string status);//Interest Rate File List for System Admin 
        IList<SAMDTO00056> SelectRateFileList();
        IList<SAMDTO00056> SelectRateFileListByRate(string rate);

        IList<MNMDTO00071> SelectSavingAccuredInterestAll();
        IList<MNMDTO00071> SelectSavingAccuredInterestBetweenStartDateandEndDate(DateTime startDate, DateTime endDate);
        IList<MNMDTO00071> SelectSavingAccuredInterestByCash(DateTime startDate, DateTime endDate);
        IList<MNMDTO00071> SelectSavingAccuredInterestByTransfer(DateTime startDate, DateTime endDate);

        IList<TLMDTO00019> SelectFixedInterestWithdrawListing(DateTime startDate, DateTime endDate, string datetype, string sourceBr);

        IList<PFMDTO00042> SelectDatasFromBankStatementForCS(string workstation, string accountno, DateTime startdate, DateTime enddate, bool withReversal);//Updated By HWKO (17-May-2017)

        IList<PFMDTO00017> SelectBLHPPAccountAll(DateTime startDate, DateTime endDate, string acSign, string sourceBr); // Added By HWKO (23-Jun-2017)
        IList<PFMDTO00017> SelectBLHPPAccountSpecific(DateTime startDate, DateTime endDate, string acSign, string sourceBr); // Added By HWKO (23-Jun-2017)

        //IList<TLMDTO00058> SelectCurrentDayBookAllHome(string workStation, string sourceCur, DateTime requireDate, string acsign);//Added by HWKO (14-Aug-2017)
        //IList<TLMDTO00058> SelectDayBookCurrentAll_HomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign);//Added by HWKO (14-Aug-2017)
        //IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversal(string workStation, string sourceCur, DateTime requireDate, string acsign);//Added by HWKO (14-Aug-2017)
        //IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign);//Added by HWKO (14-Aug-2017)

        IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversal(string workStation, string sourceCur, DateTime requireDate, string acsign,bool sortByName);//Added by ZMS (14/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAllHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (14/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentHomeReversal(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticHomeReversal(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticHomeReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticHome(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticHomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticReversal(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticReversalBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomesticBySettlementDate(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAll(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAllBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookDomestic(string workStation, string sourceCur, DateTime requireDate, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectCurrentDayBookAllHome(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAll_HomeBySettlementDate(string workStation, string sourceCur, DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAllReversal(string workStation, string sourceCur, System.DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        IList<TLMDTO00058> SelectDayBookCurrentAllReversalBySettlementDate(string workStation, string sourceCur, System.DateTime requireDate, string acsign, bool sortByName);//Added by ZMS (19/12/2107)
        
        IList<TCMDTO00013> SelectAcctNoBbyWorkstation(string workstation, string currency, string sorting);//Added by HWKO (17-Aug-2017)
        IList<TCMDTO00013> SelectAcctNoHbyWorkstation(string workstation, string currency, string sorting);//Added by HWKO (17-Aug-2017)
        IList<TCMDTO00013> SelectAcctNoPbyWorkstation(string workstation, string currency, string sorting);//Added by HWKO (17-Aug-2017)
        IList<TCMDTO00013> SelectAcctNoDbyWorkstation(string workstation, string currency, string sorting);//Added by HWKO (17-Aug-2017)


        IList<MNMDTO00010> SelectTriDetailForBackDate(string currency, string branchCode, DateTime selectedDate, string stropeningfield);//Added by HWKO (03-Sep-2017)

        IList<PFMDTO00042> SelectDepositListingByAll_New(string sourceBr, string workstation);
        
        IList<MNMDTO00054> GetLedgerListingRptByTDate_ForCashInHands(string aCode, DateTime startDate, DateTime endDate, string workstation, string sourcebr);

        IList<PFMDTO00042> SelectWithdrawalListingAllReport_New(string sourceBr, int workstationId);//Added by JZT (06-Feb-2018)
        bool DeleteAll_from_ReportTlf_bySourceBr(string sourceBr);//Added by HMW at 04-Sept-2019: To fix "Data header receiving error occur".
        IList<TCMDTO00013> GetAccountLedgerbyAcSignWorkstation(string acSign, string workstationId, string cur);//Added by HMW at 04-Mar-2019: To fix "Data header receiving error occur".

    }
}
