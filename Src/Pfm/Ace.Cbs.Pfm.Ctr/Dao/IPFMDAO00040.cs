using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;


namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// SI Dao Interface
    /// </summary>
    public interface IPFMDAO00040:IDataRepository<PFMORM00040>
    {
        bool UpdateCloseDate(string AccountNo, Nullable<DateTime> CloseDate, int updatedUserId);
        object GetMonthlyAmount(string monthlyQuery, string accountNo);
        bool UpdateInterest(string accountNo, decimal amount, string file_month, int updatedUserId);
        IList<PFMDTO00040> SelectAll(string SourceBranchCode);
        bool UpdateSi(decimal si_month, int accruedint, string budget, string SourceBranchCode, int UpdatedUserID);
        IList<PFMDTO00040> SelectByCloseDate(string sourceBr, string cur);
        IList<PFMDTO00040> SelectByBudgetYear(string sourceBr, string cur, string BudgetYear);
        void UpdateAccruedInt(decimal accruedInt, string accountNo, int updatedUserId);
        IList<string> SelectCurrency(string sourceBr);
        void UpdateAccruedIntTo0(int updatedUserId);
        PFMDTO00040 SelectInterestByAccountNo(string accountNo);
        void UpdateAccruedIntTo0ByAccountNo(int updatedUserId, string accountNo);
        bool UpdateAccruedIntByAccountNo(decimal amount, int updatedUserId, string accountno);
    }
}