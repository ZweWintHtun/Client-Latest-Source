//----------------------------------------------------------------------
// <copyright file="TLMDAO00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// PO DAO
    /// </summary>
    public class TLMDAO00016 : DataRepository<TLMORM00016>, ITLMDAO00016
    {
        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePOByPONo(DateTime issueDate, string status, string budget, int updatedUserId, string poNo, string userNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.UpdatePOByPONo");
            query.SetDateTime("issuedate", issueDate);
            query.SetString("status", status);
            query.SetString("budget", budget);
            query.SetString("userno", userNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("poNo", poNo);
            return query.ExecuteUpdate() > 0;
        }
        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePORefundByPONoAndBudgetYear(DateTime issueDate, DateTime refundDate, string status, string budget, string poNo,string toacctno, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.UpdatePORefundByPONoAndBudgetYear");
            query.SetDateTime("issuedate", DateTime.Now);
            query.SetDateTime("refundDate", refundDate);
            query.SetString("status", status);
            query.SetString("budget", budget);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("poNo", poNo);
            query.SetString("toacctno", toacctno);
            return query.ExecuteUpdate() > 0;
        }    

        public IList<TLMDTO00016> GetPOOutstandingReport(IList<string> acodelist, IList<string> toaccountnolist)
        {  
            IList<TLMDTO00016> list =new List<TLMDTO00016>();
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectPOOutstandingReport");
            if(acodelist.Count!=0)
            {
            query.SetParameterList("acodelist", acodelist);
            query.SetParameterList("toaccountnolist", toaccountnolist);
            list = query.List<TLMDTO00016>();
            return list;
            }
            else
            {               
               return list;
             }

        }

        [Transaction(TransactionPropagation.Required)]
        public bool CheckExist(string pono)
        {
            IQuery query = this.Session.GetNamedQuery("PODAO.CheckExist");
            query.SetString("pono", pono);
            IList<TLMDTO00016> poDTO = query.List<TLMDTO00016>();
            return poDTO.Count == 0 ? true : false;

        }
        public IList<TLMDTO00016> SelectPOByPOOutstandingNormal(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PODAO.POOutstandingNormalReport");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<TLMDTO00016>();
            //return null;
        }

        public IList<TLMDTO00016> SelectPO(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectPO");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<TLMDTO00016>();
        }

        public IList<TLMDTO00016> SelectByPoNOforRE(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectByPoNOforRE");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<TLMDTO00016> res = query.List<TLMDTO00016>();
            return res;
        }
        [Transaction(TransactionPropagation.Required)]
        public void DeletePO(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.DeletePO");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.ExecuteUpdate();

        }

        public IList<TLMDTO00016> SelectSumPOAmount(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectSumPOAmount");
            query.SetString("SourceBranchCode", SourceBranchCode);

            return query.List<TLMDTO00016>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateIDateAndStatus(string poNo, int updatedUesrId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.UpdateIDateAndStatus");
            query.SetString("poNo", poNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUesrId);
            return query.ExecuteUpdate() > 0;
        }

        public TLMDTO00016 SelectPOByPONoandBudgetYear(string pono, string budgetyear, string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectByPONoAndBudgetYear");
            query.SetString("pono", pono);
            query.SetString("budget", budgetyear);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.UniqueResult<TLMDTO00016>();
        }

        public TLMDTO00016 SelectPOByPONoAndSourceBrAndCurAndBudgetYear(string pono, string sourceBr, string cur, string budgetyear)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectByPONoAndSourceBrAndCurAndBudgetYear");
            query.SetString("pono", pono);
            query.SetString("sourceBr", sourceBr);
            query.SetString("cur", cur);
            query.SetString("budget", budgetyear);
            return query.UniqueResult<TLMDTO00016>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeletePOByActive(string pono, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.DeletePOByActive");
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("pono", pono);
            query.SetString("sourceBr", sourceBr);
            bool isUpdate = query.ExecuteUpdate() > 0;
            return isUpdate;
        }
        // select PO info by acctno,branchno and active = true
        public IList<TLMDTO00016> SelectPOInfoByAcctno(string acctno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectPOinfoByacctno");
            query.SetString("acctno", acctno);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00016>();
        }

        public TLMDTO00016 GetPOData(string poNo, string budget, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectPONo");
            query.SetString("poNo", poNo);
            query.SetString("budget", budget);
            query.SetString("sourceBranch", sourceBranch);
            //IList<TLMDTO00016> dto = query.List<TLMDTO00016>();
            //return dto;
            return query.UniqueResult<TLMDTO00016>();
        }

        public IList<TLMDTO00016> POData(string poNo, string budget, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.SelectPONo");
            query.SetString("poNo", poNo);
            query.SetString("budget", budget);
            query.SetString("sourceBranch", sourceBranch);
            IList<TLMDTO00016> dto = query.List<TLMDTO00016>();
            return dto;

        }


        [Transaction(TransactionPropagation.Required)]
        public bool DeletePOData(string poNo, string budget, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.DeletePOData");
            query.SetString("poNo", poNo);
            query.SetString("budget", budget);
            query.SetString("sourceBranch", sourceBranch);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            bool isUpdate = query.ExecuteUpdate() > 0;
            return isUpdate;
        }

         [Transaction(TransactionPropagation.Required)]
        public bool UpdatePOByAmount(string poNo, string budget, string sourceBranch, decimal amount, decimal charges, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.UpdatePOByAmount");
            query.SetString("poNo", poNo);
            query.SetString("budget", budget);
            query.SetString("sourceBranch", sourceBranch);
            query.SetDecimal("amount", amount);
            query.SetDecimal("charges", charges);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateIDateAndRefundSDate(string poNo, string budget, string sourceBranch, int updatedUesrId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00016.UpdateIDateAndRefundSDate");
            query.SetString("poNo", poNo);
            query.SetString("budget", budget);
            query.SetString("sourceBranch", sourceBranch);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUesrId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return)
        {
            IQuery query = this.Session.GetNamedQuery("sp_BudInfo");
            query.SetInt32("service", service);
            query.SetDateTime("pDate", pDate);
            query.SetString("branchCode", branchCode);
            query.SetString("Return", Return);
            //query.SetTimeout(10000);
            return query.UniqueResult().ToString();
        }
    }
}
