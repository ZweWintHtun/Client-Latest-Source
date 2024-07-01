using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    // Cledger Interface Dao
    public interface IPFMDAO00028 : IDataRepository<PFMORM00028>
    {
        // Check customer id is valid or not
        bool IsValidCustomerId(string customerID);

        // Update table to close account.
        bool UpdateForClosing(string accountNo, System.Nullable<DateTime> closeDate, decimal currentBalance, decimal minimumBalance, int updatedUserId);

        //Select Minimum Balance By AccountNo.
        PFMDTO00028 SelectMinimumBalanceByAccountNo(string accountNo);

        PFMDTO00028 SelectAccountNoByCustomerId(string accountNo);

        bool UpdatePrintLine(string accountNo, int lineNo, int updatedUserId);

        int GetPrintLineNumberByAccountNo(string account);

        PFMDTO00028 GetLoansInformation(string accountNo, string sourceBranchCode);

        bool UpdateCurrentBalance(string accountNo, decimal currentBalance, decimal tCount, int updatedUserId,string updatedUserNo);

        PFMDTO00028 SelectACSignByAccountNo(string accountNo);

        void UpdateMinBal(string accountNo, decimal minBal, int updatedUserId);

        IList<PFMDTO00028> SelectCbalTCount(string SourceBranchCode);

        void UpdateTcount(string SourceBranchCode, int updatedUserId);
        bool UpdateDOBal(string branchCode, DateTime updatedDate, int updatedUserId);

        IList<string> SelectCurrencyByACSign();

        void UpdateCBal(decimal cBal, string accountNo, int updatedUserId);

        IList<PFMDTO00028> SelectTotalBalanceByCurrency(string sourceBr);

        IList<PFMDTO00028> SelectForOverDraftPosting(string sourceBr);

        IList<PFMDTO00028> SelectSumDoBal(string sourcebr , string accountsign);

        PFMDTO00028 SelectByAccountNoAndSourceBr(string accountno, string sourcebr);
        bool UpdateCBalForPORefundReversal(string accountNo, decimal currentBalance, int updatedUserId);

        bool UpdateTransactionCount(string accountNo, int updatedUserId);
        IList<PFMDTO00028> SelectSumDoBalForOD(string accountsign, string sourcebr);
        bool UpdatePrnLineNoByAccountNo(string accountNo, int updatedUserId, int lineNo);

        bool UpdateOVDLimitInCledger(decimal oVDLimit, string sourceBranchCode, string accountNo, int updatedUserId);
       
        bool UpdateLoansCountForLoan(string sourceBranchCode, string accountNo, int updatedUserId, DateTime updatedDate);
        bool UpdateLoansCountForOD(string sourceBranchCode, string accountNo, int updatedUserId, DateTime updatedDate, decimal rate, decimal amount);

        PFMDTO00033 SelectAccountInfoFromCledgerAndBal(string budYear,DateTime endOfMonth,string accountNo, string sourceBr); //LOMSVE00016

        bool UpdateCledgerCBalByAccountNo(string accountNo,decimal cledgerCBal, string sourceBr, int workStationId, int currentUserId);
        bool UpdateLoansCountForCledger(string sourceBranchCode, string accountNo, int updatedUserId, DateTime updatedDate);

        IList<PFMDTO00028> SelectAccountInfoFromCledgerForPLContractPrinting(string accountNo, string sourceBranchCode);
    }
}