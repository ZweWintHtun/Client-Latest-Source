using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Invoking;
using System;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Code Validation Checker
    /// </summary>
    public interface ICXSVE00006
    {
        IList<PFMDTO00021> FAOFSelectByAccountNumberForRePrintingPassBook(string accountNumber);
        bool IsValidCustomerId(string customerId);
        PFMDTO00001 GetCustomerByCustomerId(string customerId);
        //  bool HasDuplicatedChequeBookIssueNo(string chequeBookNo, string fromNumber, string toNumber, string branchCode);
        bool HasDuplicatedChequeBookIssueNo(string chequeBookNo, string fromNumber, string toNumber, string branchCode, string currencyCode, string accountNo);
        bool IsValidChequeBookIssueNoForStopCheque(string accountNumber, string chequeBookNo, string fromNumber, string toNumber, string branchCode, string cur);
        bool IsValidChequeBookIssueNoForAccountClose(string accountNo, string chequeNo, string branchCode);
        bool IsAlreadyPrintedChequeNo(string acctno, string fromNumber, string toNumber, string branchCode, string chequeBookNo);
        IList<PFMDTO00017> GetCAOFsByAccountNumber(string accountNumber);
        IList<PFMDTO00016> GetSAOFsByAccountNumber(string accountNumber);
        IList<PFMDTO00021> GetFAOFsByAccountNumber(string accountNumber);
        PFMDTO00017 GetCAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer);
        PFMDTO00016 GetSAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer);
        PFMDTO00021 GetFAOFByAccountNumberAndSerialOfCustomer(string accountNumber, int serialOfCustomer);
        IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber(string accountNo);
        IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(string accountNo);//Added by ZMS(16.11.18) for Pristine requirement //Added by ZMS(16.11.18) for Pristine requirement [ can get close ac info ]
        IList<PFMDTO00072> GetSavingAccountInfoByAccountNumber(string accountNo);
        bool HasLoanAccount(string accountNo);
        bool HasCurrentAccountInLinkAccount(string accountNo);
        bool HasSavingAccountInLinkAccount(string accountNo);
        bool HasInterestAccount(string accountNo);
        bool IsFreezeAccount(string accountNo);
        bool IsClosedAccountForCLedger(string accountNo);
        IResponseEntity ServiceResult { get; set; }
        PFMDTO00021 GetTopFAOFINfoByAccountNo(string accountNumber);
        TLMDTO00016 GetPOByPoNoandBudgetYear(string poNo, string budgetYear, string sourcebr);
        bool IsInFAOFAccountNoOrInCledgerAcNo(string accountno);
        PFMDTO00028 GetAccountInfoOfCledgerByAccountNo(string accountNo);
        string GetLinkAccountNo(string accountNo, string accountType);
        IList<PFMDTO00001> GetCustomerInfomationByCaofOrSaof(string accountNo, string accountType);
        IList<PFMDTO00001> GetCustomerInfomationByAccountNo(string accountNo, bool isPhoto);
        bool HasLegalCaseAccount(string accountNo);
        bool HasNPLCaseAccount(string accountNo);
        bool IsExpiredLoansAccount(string accountNo, DateTime todaydate);
        bool CheckAmount(string accountNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit, ref bool isLink, ref string messageCode);
        PFMDTO00028 SelectCurrentBalanceByAccountNo(string accountNo);
        IList<PFMDTO00001> GetCustomerInfomationByAccountNoAndSourceBranchCode(string accountNo, bool isPhoto, string branchcode);
        IList<PFMDTO00006> GetStartNoandEndNo(string accountNo);
        bool IsVaildChequeNoforWithdrawal(string accountNo, string chequeNo, string branchCode);
        PFMDTO00028 SelectCurrentAndMinimumBalanceByAccountNo(string accountNo);
        PFMDTO00023 GetAccountInfoOfFledgerByAccountNo(string accountNo);
        IList<PFMDTO00021> GetCustomerInfoandFAOFInfoByAccountNo(string accountNo);
        void ReversalProcess(string ENO, string ReversalENO, string GroupNo, string BranchCode, DateTime Date, string ActiveBranch, int UpdatedUserID, TLMDTO00015 casndenodto, string Trancode, bool IsCbalChanges);
        void ReversalProcessForReceipt(string ENO, string ReversalENO, string GroupNo, string BranchCode, string cheque, DateTime Date, string ActiveBranch, int UpdatedUserID, TLMDTO00015 casndenodto, string Trancode, bool IsCbalChanges);
        IList<PFMDTO00028> SelectCustomerAccountData(string custid, string status, ref int count);
        IList<PFMDTO00021> SelectFLedgerByCustomerId(string custid, ref int count);
        int SelectLoanCountByCustomerId(string custid);
        PFMDTO00001 SelectCustomerAccountCount(string custid);
        IList<TLMDTO00018> SelectLoanGuarantee(string acctno);
        bool isFAOFAccountNo(string accountno);
        PFMDTO00017 SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(string acccountNo, string accountSign);
        string SelectTopCurrencyCodeByAccountNo(string accountNo);
        bool CheckUserNameandPassword(string user, string password);
        bool CheckChequeBookNo(string chequeBookNo, string branchCode); // For check cheque book no.

        TLMDTO00018 GetExpireAmount(string accountNo);
        void MultipleTransactionReversalProcess(string ENO, string ReversalENO, string GroupNo, string BranchCode, DateTime Date, string ActiveBranch, int UpdatedUserID, TLMDTO00015 casndenodto, string Trancode, bool IsCbalChanges);
        bool IsExpiredLoansAccount_ForAllowCrTrans(string accountNo, DateTime todaydate);
        TCMDTO00001 SelectStartBySourceBr(string sourcebr);
    }
}
