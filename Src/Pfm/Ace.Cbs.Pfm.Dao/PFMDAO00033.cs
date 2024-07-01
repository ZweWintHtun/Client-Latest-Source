using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Pfm.Dao
{
    // Balance dao
    public class PFMDAO00033 : DataRepository<PFMORM00033>, IPFMDAO00033
    {

        #region IPFMDAO00033 Members

        public IList<PFMDTO00033> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<PFMDTO00033> res = query.List<PFMDTO00033>();
            return res;
        }

        // Update close date in balance table.
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseDate(string accountNo, System.Nullable<DateTime> closeDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.UpdateCloseDate");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("closeDate", closeDate.HasValue ? closeDate.Value : DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }        

        #endregion

        // Select Currency Code in balance table.       
        public string SelectTopCurrencyCodeByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.SelectTopCurrencyCodeByAccountNo");
            query.SetString("accountNo", accountNo);          
            return query.UniqueResult<PFMDTO00033>().CurrencyCode;
        }


        public IList<PFMDTO00033> SelectBal(DateTime monthFirstday,string m_fileMonth, string acSign,string sourceBr)
        {
            IQuery query = this.Session.CreateQuery("Select new baldto(b.AccountNo,b.DATE_TIME,b." + m_fileMonth[0].ToString() + "onth" + m_fileMonth.Substring(1) + ",b.AccountSign) from PFMORM00033 as b where convert(char(10),b.DATE_TIME,111) < convert(char(10),:monthFirstDay,111) and substring(b.AccountSign,1,1) = :acSign and b.SourceBranchCode= :sourceBr and b.Active = true");
            query.SetDateTime("monthFirstDay",monthFirstday);
            query.SetString("acSign",acSign);
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00033> list = query.List<PFMDTO00033>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCBal(decimal cbal, decimal tcount, string cledgerAC, string SourceBranchCode,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.UpdateCBal");
            query.SetDecimal("cbal", cbal);
            query.SetDecimal("tcount", tcount);
            query.SetString("cledgerAC", cledgerAC);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateFBal(decimal fbal, string fledgerAC, string SourceBranchCode, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.UpdateFBal");
            query.SetDecimal("fbal", fbal);
            query.SetString("fledgerAC", fledgerAC);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBal(string budget, string SourceBranchCode, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00033.UpdateBal");
            //query.SetDecimal("month", month);
            query.SetString("budget", budget);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBalMonth(string accountNo, decimal amount,decimal tcount, string month,string SourceBranchCode, int updatedUserId)
        {
            string monthNo = month.Replace("M", "");
            string dmlString = "update PFMORM00033 bal set bal." + month[0].ToString() + "onth" + monthNo + " = :amount, bal.TransactionCountOfMonth" + monthNo +"=:tcount, bal.UpdatedUserId = :updatedUserId, bal.UpdatedDate = :updatedDate where bal.AccountNo = :accountNo and bal.SourceBranchCode=:SourceBranchCode";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDecimal("amount", amount);
            query.SetDecimal("tcount", tcount);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("accountNo", accountNo);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateBalMonth(string accountNo, decimal amount, string month, string SourceBranchCode, int updatedUserId)
        {
            string monthNo = month.Replace("M", "");
            string dmlString = "update PFMORM00033 bal set bal." + month[0].ToString() + "onth" + monthNo + " = :amount, bal.UpdatedUserId = :updatedUserId, bal.UpdatedDate = :updatedDate where bal.AccountNo = :accountNo and bal.SourceBranchCode=:SourceBranchCode";
            IQuery query = this.Session.CreateQuery(dmlString);
            query.SetDecimal("amount", amount);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("accountNo", accountNo);

            return query.ExecuteUpdate() > 0;
        }

        public string BackupDatabaseAfterMonthClose()
        {
            IQuery query = this.Session.GetNamedQuery("SP_DatabaseBackupAfterMonthClose");
            //query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(string)));
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseImmediately()
        {
            IQuery query = this.Session.GetNamedQuery("SP_DatabaseBackupImmediately");
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseDaily()
        {
            IQuery query = this.Session.GetNamedQuery("SP_DatabaseBackupDaily");
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseBefore()
        {
            IQuery query = this.Session.GetNamedQuery("SP_DatabaseBackupBefore");
            return query.UniqueResult().ToString();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseAfter()
        {
            IQuery query = this.Session.GetNamedQuery("SP_DatabaseBackupAfter");
            return query.UniqueResult().ToString();
        }
        //Added by AAM (18_Sep_2018),Year End Budget Change Process.
        public string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return)
        {
            IQuery query = this.Session.GetNamedQuery("sp_BudInfo");
            query.SetInt32("service", service);
            query.SetDateTime("pDate", pDate);
            query.SetString("branchCode", branchCode);
            query.SetString("Return", Return);
            query.SetTimeout(10000);
            return query.UniqueResult().ToString();
        }
        //Added by AAM (19_Sep_2018),Year End Budget Change Process.
        public IList<PFMDTO00079> GetBLFInfoByActiveBudget(string sourceBr)
        {
            IList<PFMDTO00079> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetBLFByActiveBudget");
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00079)));
            IList<PFMDTO00079> multilist = query.List<PFMDTO00079>();
            return multilist;
        }
        public string AfterDayClose_YearEndProcess(string budget, int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AfterDayCloseAtYearEndProcess");
            query.SetString("budget", budget);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        public string AfterDayClose_YearEndProcess_BudgetFirstMonth(int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AfterDayCloseAtYearEndProcess_BudgetStartMonth");
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        public string AfterDayClose_YearEndProcess_NotBudgetFirstMonth(string month, int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AfterDayCloseAtYearEndProcess_NotBudgetStartMonth");
            query.SetString("month", month);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        public string AfterDayCloseAtYearEndProcess_UpdateLiQBal(string qMonth, int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_AfterDayCloseAtYearEndProcess_UpdateLiQBal");
            query.SetString("quarterMonth", qMonth);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        //Modified by HMW at 27-Sept-2019 : Changing return type (For Back Date EOD)
        public DateTime CheckingYearlyPostingDate(DateTime postingDate)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckingYearlyPostingRunDate");
            query.SetDateTime("postingDate", postingDate);
            return DateTime.Parse(query.UniqueResult().ToString());
        }

    }
}