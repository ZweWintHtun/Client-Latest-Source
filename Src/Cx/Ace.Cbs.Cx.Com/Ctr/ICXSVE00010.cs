using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Invoking;
using Ace.Windows.Core.Service;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;
using System;
namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Data_Generate_InSQL
    /// </summary>
    public interface ICXSVE00010 : IBaseService
    {
        IList<TLMDTO00015> CashDenominationListing_ForMultiTransaction(string currency, string whereString, string orderString);
        PFMDTO00042 GetReportDataGenerateInSQL(CXDTO00006 reportParameters);

        bool HasSavingAccountTransaction(string accountNo, int userid);

        bool AllUpdateForWithdraw(string eno, string acctno, decimal amount, decimal Oamount, bool wStatus, string chequeNo, string userId, string soruceBr, string channel, DateTime settlementDate, bool isAutoLink, string errorMessage, int createdUserId, bool isLastWithdraw);

        bool IBL_Withdrawal(string voucherNo, string accountNo, decimal amount, string isVIP, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
                string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel, string chequeNo, int createdUserId);

        bool IBL_Voucher(string eno, string acode, decimal amount, string status, string trancode, string type, string orgnTranCode, string orgnEno,
             decimal incomeAmount, decimal faxCharges, int takeincome, string incomeAc, string FaxAc, string userId, string curCode, string sourceCur, decimal exchangeRate, string soruceBr, DateTime settlementDate, string channel);

        bool AllUpdateForClearing(PFMORM00054 tlf, bool wStatus);

        bool IsValidAmountCheck(CXDTO00004 parameters);

        bool IsLinkOKForCurrentAccount(CXDTO00004 parameters);

        bool EncashVou(TLMDTO00001 reDTO);

        string TranslateToCXMessageCode(string errorMessageCode);

        string UpdateForTransfer(string voucherNo, string accountNo, decimal amount, decimal oAmount, string chequeNo, string voucherStatus, bool status, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        string IsCheckSavingDate(string accountNo, int userId);

        bool IBLRemit(TLMDTO00017 drawingRemit);
        bool RemitVoucher(TLMDTO00017 drawingRemit);
        bool AllUpdateRemit(TLMDTO00017 drawingRemit);

        bool IBL_Deposit(string voucherNo, string accountNo, decimal amount, int forceCheck, int minBalCheck, string tempStatus, string tempTranCode, string reference, decimal receiptNo,
             string fromBranch, decimal incomeAmount, decimal faxCharges, int takeIncome, string IBSAC, string incomeAC, string faxAC, string narTest, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        bool TransferDebitVoucher(string voucherNo, string accountNo, string isVIP, decimal amount, string chequeNo, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string creditAccount, decimal comissionCharges, decimal communicationCharges, bool status, string iBSAC, string incomeAC, string faxAC, int takeIncome,string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        bool TransferCreditVoucher(string voucherNo, string accountNo, decimal amount, string voucherStatus, string transactionCode, string reference, string debitBranch, string creditBranch, string debitAccount, bool status, string iBSAC, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        bool TransferSameBarnchVoucher(string voucherNo, string creditAccountNo, string debitAccountNo, string chequeNo, string isVIP, decimal amount, decimal incomeAmount, decimal faxCharges, string debitBranch, string creditBranch, string fromBranch, bool status, string iBSAC, string faxAC, int takeIncome, string narration, string userId, string sourceCur, decimal homeExchangeRate, string sourceBr, DateTime settlementDate, string channel);

        bool EncashIBLPassing(int id, string eno, string acctno, decimal amount, string registerno, string pono, bool postatus, string encashNo, string userno, bool closestatus, string budgetyear, string narrationtext, string branchcode, string sourcecur, decimal homeexchangerate, string sourceBranch, DateTime settlementdate, string channel, int createdUserId);

        bool DepositAdjustment(string newEno, string eno, string mAcctno, string mAcode, string mName, decimal amount, decimal oAmount, string mAcSign, string currency, decimal homeExRate, string brCode, DateTime sattlementDate, int createduserId, string channel);
        bool ServiceCharges(CXDTO00010 servicechargedto);
        bool NPLServiceCharges(CXDTO00010 servicechargedto);
        
        PFMDTO00042 BankCashScrollCALC(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId);
        PFMDTO00042 BankCashScroll(string machineName, DateTime requestDate, int rStatus, string dStatus, string brCode, int createduserId);
        PFMDTO00042 BankCashScrollBySourceCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, int createduserId);
        PFMDTO00042 BankCashScrollByHomeCur(string machineName, DateTime requestDate, int rStatus, string dStatus, string currency, string brCode, int createduserId);

        PFMDTO00042 ClosingBalanceByHomeCurrencyAll(string machineName, DateTime requestDate, string parameter, int rStatus, string brCode, int createduserId);
        PFMDTO00042 ClosingBalanceBySourceCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, int createduserId);
        PFMDTO00042 ClosingBalance(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId);
        PFMDTO00042 ClosingBalanceByHomeCurrency(string machineName, DateTime requestDate, string parameter, int rStatus, string currency, string brCode, int createduserId);


        //Nullable<decimal> GetCDTotalByDayBook(DateTime date, string crdr, string workstation, int createduserid);  //for TCMSVE00028 // DAYBOOK_SUMMARY_CDDATA_SP_FORBRANCH
        //IList<PFMDTO00042> GetDayBookSummaryReport(DateTime date, string crdr, string workstation, int createduserid);  //for TCMSVE00028  // SP_DAYBOOK_SUMMARYFORBRANCHNEW
       


        bool Sp_ChangeTables(DateTime lastSettlementDate, DateTime nextSettlementDate,string sourceBr);
        bool Sp_ChangeTables_AllCLedger(DateTime lastSettlementDate, DateTime nextSettlementDate, string sourcebr, string budget);//Updated By HWKO (17-Mar-2017)
        PFMDTO00042 GetMatureDate(DateTime requiredDate, decimal duration, DateTime registerDate, int createduserId);
        PFMDTO00042 GetInterest(DateTime requiredDate, decimal amount, int createduserId);
        IList<object> CashDenominationListing(string currency, string whereString, string orderString);
        IList<object> CashControlRefundList(string currency, string whereString, string orderString);
        IList<object> CashControlTotalVaultList(string currency, string whereString, string orderString);
        bool SavePOIssueEntry(TLMDTO00043 POIssueDTO);

        PFMDTO00054 Sp_ALUpdate_Check(string accountno);

        string Sp_ALUpdate_Int_TransferAdjust(string neweno, string eno, string accountno, decimal amount, string cheque, string userno,
           bool tstatus, string voustatus, string channel, string refvno, string reftype, string sourcebr, decimal rate, string cur, DateTime settlementdate,int createdDate);

        //LOMSVE00012
        bool Sp_SERVICECHARGES_VOU(string eNO, string mAcctNo, string lno, string narration, decimal amount, decimal oAmount, string userNo, string vouStatus,
            bool tStatus, string cur, int homeExRate, string sourceBr, DateTime settlementDate, string channel, bool returnValue, string message);

        string UpdateForHPIntPrepaymentVoucher(string voucherNo, string accountNo, decimal amount, string narration, string userId, string sourceCur, string sourceBr, DateTime settlementDate, string channel);//Added by HWKO (14-Sep-2017) // For HP Interest Prepayment Voucher Entry

    }
}
