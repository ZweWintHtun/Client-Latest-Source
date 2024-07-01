using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    //fledger interface
    public interface IPFMDAO00023:IDataRepository<PFMORM00023>
    {
        PFMDTO00023 SelectACSignAndCurByAccountNo(string accountNo);
        bool UpdatePrintLine(string accountNo, int lineNo, int updatedUserId);
        int GetPrintLineNumberByAccountNo(string accountNo);
        decimal SelectFBalByAccountNo(string accountNo);
        bool UpdateFBalOfFLedgerForDeposit(string accountNo, decimal amount, int updatedUserId, DateTime updatedDate);
        bool UpdateFBalOfFLedgerForWithdrawal(string accountNo, decimal amount, int updatedUserId, DateTime updatedDate);
        IList<PFMDTO00023> SelectFledgerFBal(string SourceBranchCode);
        IList<PFMDTO00023> SelectSumFixedBal(string sourcebr);
    }
}