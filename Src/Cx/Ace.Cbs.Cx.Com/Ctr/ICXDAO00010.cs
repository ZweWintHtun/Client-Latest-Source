using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Dto;
using System.Data;
using System;
namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00010
    {
        IList<TLMDTO00015> CashDenominationListing_ForMultiTrasaction(string currency, string whereString, string orderString);
      
        PFMDTO00042 GetReportByTransactionDate_Or_SettlementDate(CXDTO00006 reportParameters);        

        string IBL_Voucher(string eno, string acode, decimal amount, string status, string trancode, string type, string orgnTranCode, string orgnEno,
             decimal incomeAmount, decimal faxCharges, int takeincome, string incomeAc, string FaxAc, string userId, string curCode, string sourceCur, decimal exchangeRate, string soruceBr, DateTime settlementDate, string channel);

        string IBL_Deposit(string voucherNo, string accountNo, decimal amount, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
             string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string narTest, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, string settlementDate, string channel);

        string IsCheckSavingDate(string accountNo, int userId);

        string AllUpdateForWithdrawal(string eno, string acctno, decimal amount, decimal Oamount, string chequeNo, string soruceBr, DateTime settlementDate, string channel,bool isAutoLink, int createdUserId,bool isLastwithdraw);

        string IBL_Withdrawal(string voucherNo, string accountNo, decimal amount, string isVIP, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
             string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel, string chequeNo, int createdUserId);

        string UpdateForTransfer(string voucherNo, string accountNo, decimal amount, decimal oAmount, string chequeNo, string voucherStatus, bool status, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        string AllUpdateForClearing(PFMORM00054 tlf, bool wStatus);

        CXDTO00008 IBL_AmountCheck(CXDTO00004 parameters);

        CXDTO00008 SP_ATL_AMOUNTCHECKING_CHECK_SAVAC_DATE(CXDTO00004 parameters);

        string EncashVou(TLMDTO00001 reDTO);

        //TLMDTO00017 IBLRemit(TLMDTO00017 drawingRemitDTO);
        string IBLRemit(TLMDTO00017 drawingRemitDTO);
        string RemitVoucher(TLMDTO00017 drawingRemitDTO);
        string AllUpdateRemit(TLMDTO00017 drawingRemitDTO);

        string TransferDebitVoucher(string voucherNo, string accountNo, string isVIP, decimal amount, string chequeNo, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string creditAccount, decimal comissionCharges, decimal communicationCharges, bool status, string iBSAC, string incomeAC, string faxAC, int takeIncome,string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        string TransferCreditVoucher(string voucherNo, string accountNo, decimal amount, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string debitAccount, bool status, string iBSAC, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        string TransferSameBarnchVoucher(string voucherNo, string creditAccountNo, string debitAccountNo, string chequeNo, string isVIP, decimal amount, decimal incomeAmount, decimal faxCharges, string debitBranch, string creditBranch, string fromBranch, bool status, string iBSAC, string faxAC, int takeIncome, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        string IBLEncashPassing(int id, string eno, string acctno, decimal amount, string registerno, string pono, bool postatus, string encashNo, string userno, bool closestatus, string budgetyear, string narrationtext, string branchcode, string sourcecur, decimal homeexchangerate, string sourceBranch, DateTime settlementdate, string channel, int createdUserId);
       
        PFMDTO00042 BankCashScroll(string machineName, DateTime requestDate, int rStatus, string dStatus, string brCode, int createduserId);
        
        PFMDTO00042 BankCashScrollByHomeCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId);
        
        PFMDTO00042 BankCashScrollBySourceCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, int createduserId);
        
        PFMDTO00042 BankCashScrollCALC(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId);

        string DepositAdjustment(string newEno, string eno, string mAcctno, string mAcode, string mName, decimal amount, decimal oAmount, string mAcSign, string currency, decimal homeExRate, string brCode, DateTime sattlementDate, int createduserId, string channel);
        object ServiceCharges(CXDTO00010 servicechargesdto);

        PFMDTO00042 ClosingBalanceByHomeCurrencyAll(string machineName, DateTime requestDate, string parameter, int rStatus, string brCode, int createduserId);
        PFMDTO00042 ClosingBalanceBySourceCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, int createduserId);
        PFMDTO00042 ClosingBalance(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId);
        PFMDTO00042 ClosingBalanceByHomeCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId);

        Nullable<decimal> GetCDTotalByDayBook(DateTime date, string crdr, string workstation, int createduserid, string brCode, string sourcecur);  //for TCMSVE00028 // DAYBOOK_SUMMARY_CDDATA_SP_FORBRANCH
        IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string crdr, string workstation, int createduserid, string brCode,string sourcecur);  //for TCMSVE00028  // SP_DAYBOOK_SUMMARYFORBRANCHNEW       

        object NPLServiceCharges(CXDTO00010 servicechargesdto);

        object SP_ChangeTables(DateTime lastSettlementDate, DateTime nextSettlementDate,string sourceBr);
        object Sp_ChangeTables_AllCLedger(DateTime lastSettlementDate, DateTime nextSettlementDate, string sourceBr, string budget);//Updated By HWKO (17-Mar-2017)

        PFMDTO00042 GetMatureDate(DateTime requiredDate, decimal duration, DateTime registerDate, int createduserId);
        PFMDTO00042 GetInterest(DateTime requiredDate, decimal amount, int createduserId);

        IList<object> CashDenominationListing(string currency, string whereString, string orderString);
        IList<object> CashControlRefundListString(string currency, string whereString, string orderString);
        IList<object> CashControlTotalVault(string currency, string whereString, string orderString);

        string POIssueByTransfer(TLMDTO00043 POIssueDTO);
         

        object TransferScroll(string sourceBr, string workstation, DateTime datetime, int Rstatus, char Dstatus, string Cur, decimal Cltot, decimal Totalcash);

        IList<MNMDTO00010> SelectTrialGroupByHomeAllBranch(string stramount, string cur, int ishome, string branch);
        IList<MNMDTO00010> SelectTrialGroupByHomeBranch(string stramount, string cur, int ishome, string branch);
        IList<MNMDTO00010> SelectTrialGroupBySourceAllBranch(string stramount, string cur, int ishome, string branch);
        IList<MNMDTO00010> SelectTrialGroupBySourceBranch(string stramount, string cur, int ishome, string branch);

        TCMDTO00052 SelectDailyClosing(string rDATE, string bUDMONTH, string cUR);
        IList<GLMDTO00013> SelectIncomeExpenditure(string budMonth, string year, int month);

        //Auto Link Schedule Report
        IList<PFMDTO00029> SelectAutoLinkListing(int workstationid, int reversal, string currency, string sourcebranch);

        PFMDTO00054 Sp_ALUpdate_Check(string accountno);

        string Sp_ALUpdate_Int_TransferAdjust(string neweno, string eno, string accountno, decimal amount, string cheque, string userno,
           bool tstatus, string voustatus, string channel, string refvno, string reftype, string sourcebr, decimal rate, string cur, DateTime settlementdate,int createdDate);

        string ProcessFixedYearendInterest(DateTime processdate, DateTime yearendDate, string budSDate, string budendDate, int user, string sourcebr, int RetMsg);
        string ProcessFixedYearendPrevInterest(DateTime processdate, DateTime yearendDate, string budSDate, string budendDate, int user, string sourcebr, int RetMsg);
        

        #region Interest(Payment) 
        IList<PFMDTO00042> SelectRenewalVoucherListing(int workstationId, DateTime date, string currency, string sourceBr); //ASDA       
        #endregion

        //IList<PFMDTO00042> SelectDebitListing(string workStation, string acSign, string sourceBr, string transactionCode, DateTime datetime, string sourceCur);

      //  IList<PFMDTO00042> SelectAutoLinkListingReport(int workstationid, DateTime datetime, string accountSign, string voucherType, string sortedField, int reversal);

        string Sp_SERVICECHARGES_VOU(string eNO, string mAcctNo, string lno, string narration, decimal amount, decimal oAmount, string userNo, string vouStatus,
             bool tStatus, string cur, int homeExRate, string sourceBr, DateTime settlementDate, string channel, bool returnValue, string message);  // LOMSVE00012 (OD Change Limit Entry) 

        //Nullable<decimal> SP_LOANINTEREST(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, int period, decimal retInterest);   //LOMSVE00016 (Legal Interest Entry)
        //Nullable<decimal> SP_LoanScharge(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, int period, int update, decimal retInterest); //LOMSVE00016 (Legal Interest Entry)

        Nullable<decimal> SP_LOANINTEREST_NewLogic(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, string termNo, decimal retInterest, string sourceBr, int updatedUserId);
        Nullable<decimal> SP_LoanScharge_NewLogic(string lno, decimal daysInYear, DateTime qtrSDate, DateTime qtrEDate, string termNo, int updatedUserId, string sourceBr, decimal retInterest);

        IList<MNMDTO00010> SelectTriGroupForBackDate(string currency, string branchCode, DateTime selectedDate, string stropeningfield);//Added by HWKO (31-Aug-2017)
        string UpdateForHPIntPrepaymentVoucher(string voucherNo, string accountNo, decimal amount, string narration, string userId, string sourceCur, string sourceBr, DateTime settlementDate, string channel);//Added by HWKO (14-Sep-2017) // For HP Interest Prepayment Voucher Entry        
    }
}
