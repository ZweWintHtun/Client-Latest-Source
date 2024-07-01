using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00054 : IDataRepository<PFMORM00054>
    {
        IList<PFMDTO00054> SelectTlfInfoByLGNo(string lgno, string sourceBranch);
        bool Delete(string eno, int updatedUserId, string sourceBr);
        void DeleteTlfByEno(string eno);
        IList<PFMDTO00054> GetNarrationByEno(string eno);
        PFMDTO00054 GetTlfInfo(string entryNo, string sourceBr, string tranCode);
        IList<PFMDTO00054> GetTlfInfoByEntryNo(string eno, string sourceBr);
        IList<PFMDTO00054> GetTlfInfoForWithdrawEntry(string eno, DateTime settlementDate);
        IList<PFMDTO00054> SelectByDRegisterNo(string dRegisterNo, string sourceBr, DateTime Date);
        IList<PFMDTO00054> SelectByERegisterNo(string eRegisterNo, string sourceBr, DateTime Date);
        IList<PFMDTO00054> SelectForReversal(string eno, string sourceBr);
        int SelectMaxId();
        PFMDTO00054 SelectTlfDataByEntryNo(string sourceBranch, string eno);
        IList<PFMDTO00054> SelectTlfDataByPONo(string poNo, string sourceBranch);
        IList<PFMDTO00054> SelectTlfForPORefundReversal(string poNo, string sourceBranch);
        IList<PFMDTO00054> SelectTlfForPORegisterByTransferReversal(string poNo, string sourceBranch);
        PFMDTO00054 SelectTlfForReversal(string accountNo, string receiptNo, string sourceBranch);
        PFMDTO00054 SelectTlfInfoByEnoandDate(string entryNo);
        IList<PFMDTO00054> SelectTlfInfoByEnoandDate(string entryNo, string tranCodedebit, string tranCodecredit, string sourcebr);
        IList<PFMDTO00054> SelectTLFInfoForReversalByEntryNo(string entryno, string sourceBr);
        IList<PFMDTO00054> SelectTlfInfoList(string sourceBranch);
        PFMDTO00054 SelectTlfInfoListInService(string sourceBranch, string eno);
        IList<PFMDTO00054> SelectTlfListDataByEntryNo(string sourceBranch, string eno);
        bool UpdateCloseDateByLoanType(string loanType, string loanNo);
        bool UpdateCloseDateForLI(string loanNo);
        bool UpdateCloseDateForOI(string loanNo);
        bool UpdateCloseDateForLMT9900(string loanNo);
        bool UpdateCloseDateForLoan(string loanNo);
        bool UpdateTlf(string eno, decimal amount, decimal homeAmount, string paidBank, string otherBankChq, string narration, int updatedUserId, DateTime updatedDate);
        bool UpdateTlfByDRegisterNo(string oldDregisterNo, string newDregisterNo, string sourcebr, int updatedUserId);
        bool UpdateTlfByOrgnEno(string orgnEno, string orgnTranCode, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate);
        bool UpdateTlfByPONo(string poNo, string orgnEno, string sourceBranch, int updatedUserId, DateTime updatedDate);
        bool UpdateTlfByRefVno(string registerNo, string refVno, string refType, string sourceBranch, int updatedUserId, DateTime updatedDate);
        bool UpdateTLFForSavingInterestWithdrawReversal(string orgneno, string orgntrancode, DateTime updateddate, int updateduserid, string eno, string transactioncode, string sourcecurrency, string sourcebr, byte[] ts);
        bool UpdateTlfHomeAmt(int id, decimal amount);
        bool UpdateTlfRegisterNoToAddC(string registerNo, string newRegNo, string sourcebr, int updatedUserId);
        bool UpdateTlfByLnoAndRepayNo(string loanNo, string eno, string sourceBr, int updatedUserID);  //Legal Loan Repayment (OD)

        PFMDTO00054 SelectGroupAmountForMultipleReversal(string groupNo, string sourceBr);//ZMS (Multiple Withdraw and Deposit Reversal)
        string Check_EntryNo_Individual_DepWdwReverse(string eno, string sourceBr);// Added By AAM (23-Jan-2018)
        string Check_EntryNo_Multiple_DepWdwReverse(string groupNo, string eno, string sourceBr);// Added By HMW (29-May-2019) : Multiple Withdraw and Deposit Reversal For Seperating EOD        
        IList<PFMDTO00054> GetTransactionInfoByEnoANDGroupNo(string groupNo, string eno, string sourceBr);// Added By HMW (6-June-2019) : Multiple Withdraw and Deposit Reversal) For Seperating EOD          
    }
}
