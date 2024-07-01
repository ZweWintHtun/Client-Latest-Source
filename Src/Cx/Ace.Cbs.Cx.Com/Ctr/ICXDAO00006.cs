using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Cbs.Tcm.Dmd;


namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00006
    {
        
        IList<PFMDTO00021> FAOFSelectByAccountNumberForRePrintingPassBook(string accountNumber);
        int CustomerSelectCount(string customerId);
        PFMDTO00001 CustomerSelectByCustomerId(string customerId);
        int ChequeSelectCount(string chequeBookNo, string startNo, string endNo, string branchCode);
        //int ChequeSelectCount(string accountNo, string chequeBookNo, string startNo, string endNo, string branchCode, string cur);
        int ChequeSelectCount(string accountNo, string chequeBookNo, string startNo, string endNo, string branchCode, string currency);

        int ChequeSelectCount(string accountNo, string chequeNo, string branchCode);
        int PrintChequeSelectCount(string acctno,string startNo, string endNo, string branchCode,string chequeBookNo);
        int SCheckSelectCount(string chequeBookNo, string startNo, string endNo, string branchCode, string accountNo);
        /**/
        int SCheckSelectCountForStopCheque(string chequeBookNo, string startNo, string endNo, string branchCode);
        int SCheckSelectCount(string chequeNo, string branchCode, string accountNo);
        int UCheckSelectCount(string startNo, string endNo, string branchCode, string accountNo);
        IList<PFMDTO00017> GetCAOFsByAccountNumber(string accountNumber);
        IList<PFMDTO00016> GetSAOFsByAccountNumber(string accountNumber);
        IList<PFMDTO00021> GetFAOFsByAccountNumber(string accountNumber);
        PFMDTO00017 GetCAOFByAccountNumber(string accountNumber, int serialOfCustomer);
        PFMDTO00016 GetSAOFByAccountNumber(string accountNumber, int serialOfCustomer);
        PFMDTO00021 GetFAOFByAccountNumber(string accountNumber, int serialOfCustomer);
        IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber(string accountNo);
        IList<PFMDTO00072> GetCurrentAccountInfoByAccountNumber_ForClosedACAndUnClosed(string accountNo);//Added by ZMS(16.11.18) for Pristine requirement [ can get close ac info ]
        IList<PFMDTO00072> GetSavingAccountInfoByAccountNumber(string accountNo);
        int GetLinkAccountCountByCurrentAccountNo(string accountNo);
        int GetLinkAccountCountBySavingAccountNo(string accountNo);
        int GetLoanAccountCountFromPer_GuanByAccountNo(string accountNo);
        int GetLoanAccountCountFromCLedgerByAccountNo(string accountNo);
        int GetToAccountNoCountByAccountNo(string accountNo);
        int GetFreezeAccountCountByAccountNo(string accountNo);
        object GetClosedAccountByAccountNo(string accountNo);
        TLMDTO00001 SelectREByPoNo(string poNo, string budgetYear, string sourcebr);
        TLMDTO00016 SelectPOByPoNo(string poNo, string sourceBr);
        PFMDTO00028 GetAccountInfoOfCledgerByAccountNo(string accountNo);
        PFMDTO00028 GetCurrentBalanceByAccountNo(string accountNo);
        PFMDTO00029 GetLinkAccountCountByAccountNo(string accountNo, string accountType);
        IList<PFMDTO00001> GetCustomerInformationBySAOForCAOF(string accountNo, string accountType);
        int GetLegalCaseFromLoansByAccountNo(string accountNo);
        int GetNPLCaseFromLoansByAccountNo(string accountNo);
        int GetExpiredLoansFromLoansByAccountNo(string accountNo, DateTime todaydate);
        IList<PFMDTO00006> SelectStartNoandEndNobyCurrentAccountNo(string accountNo);
        PFMDTO00041 SelectMinBal(string currencyCode, string soruceBranch);
        PFMDTO00057 SelectByVariable(string variable);
        TLMDTO00018 SelectSAmountByAccountNo(string accountNo);
        PFMDTO00029 LinkAcSelectLinkAmount(string accountNo);
        PFMDTO00023 GetAccountInfoOfFledgerByAccountNo(string accountNo);
        bool CheckAccountNo(string acctNo);

        IList<PFMDTO00001> SelectCustomerInformationByFAOF(string accountNumber);
        IList<PFMDTO00054> SelectTLFByENOBranchCodeDate(string ENO, string ActiveBranch, DateTime Date, string Trancode);
        bool CheckUchequeByAccountNoChequeNo(string AccountNo, string ChequeNo, string ActiveBranch);
        IList<TLMDTO00004> SelectIBLTLFs(string ENO, string BranchCode);
        bool UpdateFLedgerByAccountNo(string AccountNo);
        bool UpdateCurrentBalance(string accountNo, decimal currentBalance, decimal tCount, int updatedUserId, string updatedUserNo);
        bool UpdateFReceiptByAccountNoRNO(string accountNo, string receiptNo, decimal FixedBalance, int updatedUserId);
        bool UpdateCashDenoByENO(string OriginalENO, string ReversalENO, string SourceBranchCode, int UpdatedUserId);
        bool UpdateDepoDenoByTLF_EnoGropuNoSourceBr(string ENO, string GroupNo, string SourceBranchCode, int UpdatedUserId);
        bool UpdateReversalIBLTLFByENo(string ENO, string SourceBranchCode, int UpdatedUserId);
        //bool UpdateCashDenoByENOStatus(string ReversalENO, string SourceBranchCode, int UpdatedUserId, string Status);
        bool DeleteDepoDenoByTlf_EnoGroupNo(string ENO, string GroupNo, string SourceBranchCode, int UpdatedUserId);
        bool DeletefromUCheckbyChequeNoAccountNo(string AccountNo, string ChequeNo, string SourceBranchCode, int UpdatedUserId);
        bool DeleteCashDenoByTLF_enoSourceBrReverse(string ENO, string SourceBranchCode, int UpdatedUserId);
        decimal SelectDepoDenoSumAmountByGroupNo(string ENO, string GroupNo, string SourceBranchCode);
        TLMDTO00005 SelectByTranCode(string tranCode);
        TLMDTO00015 SelectCashDenoByGroupNo(string GroupNo, string SourceBranchCode);
        TLMDTO00015 SelectCashDenoByGroupNoAndStatus(string GroupNo, string SourceBranchCode, string status);   //Added by ASDA

        PFMDTO00028 GetAccountInfoOfCledgerByAccountNoAndSourceBranch(string accountNo, string sourcebranch);
        bool UpdateTLFForClearingPosting(PFMDTO00054 TLFDTO);

        PFMDTO00017 GetTopCAOFInfoByAccountNumber(string accountNumber);
        PFMDTO00016 GetTopSAOFInfoByAccountNumber(string accountNumber);
        PFMDTO00021 GetTopFAOFINfoByAccountNumber(string accountNumber);
        IList<TLMDTO00009> SelectDepoDenoChargesAmountByEntryNo(string GroupNo);
        bool UpdateTLFOrgnENOOrgnTranCodeByENO(string ReversalENO, string AccountNo, string ReversalTrancode, string ENO, string SourceBranchCode, int UpdatedUserId, DateTime updatedDate);
        IList<TLMDTO00004> SelectMaxIBLTLFID();
        IList<PFMDTO00028> GetCustomerAccountData(string custid, string status, ref int count);
        IList<PFMDTO00021> GetFLedgerByCustomerId(string custid, ref int count);
        int GetLoanCountByCustomerId(string custid);
        PFMDTO00001 GetCustomerAccountCount(string custid);
        IList<TLMDTO00018> GetLoanGuarantee(string acctno);
        string SelectTopCurrencyCodeByAccountNo(string accountNo);

        PFMDTO00001 GetCustomerInfo(string custid, string sourcebr); //for Sub_Ledger Customer
        PFMDTO00001 GetCustomerInfomation(string custid);
        int ChequeSelectCountByBookNoAndSourceBr(string chequeBookNo, string branchCode, string currencyCode);
        bool CheckUserNameandPassword(string name, string password);
        PFMDTO00006 GetChequeInfoByChequeBookNo(string chequeBookNo, string branchCode);// For Check Cheque Duplicate

        bool UpdateAmountForOnlineTransaction(string eno,string reversalENO,string branchCode,decimal amount);  //added by ASDA

        bool UpdateCashDenoByAcType(string AcType, string ReversalENO, string SourceBranchCode, int UpdatedUserId);

        bool UpdateDepoDenoByGropuNoSourceBr(string GroupNo, string SourceBranchCode, int UpdatedUserId);
        TLMDTO00018 GetExpireAmount(string accountNo);

        //Added By ZMS For Multiple Deposit And Withdraw Reversal (19/12/2017)
        TLMDTO00009 SelectDepoDenoReverseStatusByEntryNoAndGroupNo(string groupno,string entryNo,string sourcebr);
        TLMDTO00015 SelectCashDenoGroupTransactionByGroupNo(string GroupNo, string SourceBranchCode);
        bool UpdateCashDenoReverseStatusOfGroupByENO(string OriginalENO, string ReversalENO, string SourceBranchCode, int UpdatedUserId);

        //Added by HMW For "Seperating EOD" (22/04/2019)
        TCMDTO00001 SelectStartBySourceBr(string sourceBr); //Select Start Table
        IList<PFMDTO00056> SelectAllAutoPayStatusList(string sourceBr);
    }
}
