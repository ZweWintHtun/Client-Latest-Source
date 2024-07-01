using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    // Balance interface dao
    public interface IPFMDAO00033 : IDataRepository<PFMORM00033>
    {
        IList<PFMDTO00033> SelectAll(string SourceBranchCode);
        bool UpdateCloseDate(string accountNo, System.Nullable<DateTime> closeDate, int updatedUserId);
        string SelectTopCurrencyCodeByAccountNo(string accountNo);

        IList<PFMDTO00033> SelectBal(DateTime monthFirstday, string m_fileMonth, string acSign, string sourceBr);
        bool UpdateCBal(decimal cbal, decimal tcount, string cledgerAC,string SourceBranchCode, int updatedUserId);
        bool UpdateFBal(decimal fbal, string fledgerAC,string SourceBranchCode, int updatedUserId);
        bool UpdateBal(string budget, string SourceBranchCode,int updatedUserId);
        bool UpdateBalMonth(string accountNo, decimal amount, string month, string SourceBranchCode, int updatedUserId);
        bool UpdateBalMonth(string accountNo, decimal amount, decimal tcount, string month, string SourceBranchCode, int updatedUserId);//Updated by HWKO (14-Mar-2017)
        string BackupDatabaseAfterMonthClose();//Updated by HWKO (14-Mar-2017)
        string BackupDatabaseImmediately();//Added by HWKO (15-May-2017)
        string BackupDatabaseDaily();//Added by HWKO (15-May-2017)
        string BackupDatabaseBefore();//Added by HWKO (15-May-2017)
        string BackupDatabaseAfter();//Added by HWKO (15-May-2017)
        //Added by AAM for year end process.
        string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return);
        IList<PFMDTO00079> GetBLFInfoByActiveBudget(string sourceBr);
        string AfterDayClose_YearEndProcess(string budget, int createdUserId, string sourceBr);
        string AfterDayClose_YearEndProcess_BudgetFirstMonth(int createdUserId, string sourceBr);
        string AfterDayClose_YearEndProcess_NotBudgetFirstMonth(string month, int createdUserId, string sourceBr);
        string AfterDayCloseAtYearEndProcess_UpdateLiQBal(string qMonth, int createdUserId, string sourceBr);
        DateTime CheckingYearlyPostingDate(DateTime postingDate);
    }
}