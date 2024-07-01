//----------------------------------------------------------------------
// <copyright file="MNMDAO00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using System;


namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00008 : DataRepository<MNMORM00008>, IMNMDAO00008
    {
        public IList<MNMDTO00008> SelectAllOI(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<MNMDTO00008>();
        }

        //public bool UpdateCloseDateForOI(string loanNo)
        //{
        //    IQuery query = this.Session.GetNamedQuery("MNMDAO00008.UpdateCloseDateForOI");
        //    query.SetDateTime("closeDate", DateTime.Now);
        //    query.SetString("loanNo", loanNo);
        //    return query.ExecuteUpdate() > 0;
        //}


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateOI(decimal month, string budget, string SourceBranchCode,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.UpdateOI");
            query.SetDecimal("month", month);
            query.SetString("budget", budget);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.ExecuteUpdate() > 0;
        }
     
        public IList<string> SelectCurrency()           //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.SelectCurrency");
            IList<string> CurList = query.List<string>();
            return CurList;
        }

        public MNMDTO00008 SelectByAccountNo(string accountNo,string sourceBr)      //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<MNMDTO00008>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateOI(decimal lastCalculateInt, DateTime intDate, string accountNo, string curMth, int updatedUserId)    //NLKK
        {
            IQuery query = this.Session.CreateQuery("Update MNMORM00008 set " + curMth + " = " + curMth + " + :lastCalculateInt , LastDate = :intDate , UpdatedDate = :updatedDate , UpdatedUserId = :updatedUserId where Acctno = :accountNo");
            query.SetDecimal("lastCalculateInt", lastCalculateInt);
            query.SetDateTime("intDate", intDate);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateOIForInterestEdit(string loanNo,decimal lastInterest,string month1,string month2,string month3,decimal interest1,decimal interest2,decimal interest3,int updatedUserId)
        {
            IQuery query = this.Session.CreateQuery("Update MNMORM00008 set " + month1 + " = :interest1 , " + month2 + " = :interest2 , " + month3 + " = :interest3 , LastInt = :lastInterest , UpdatedDate = :updatedDate , UpdatedUserId = :updatedUserId where LNo = :loanNo");
            query.SetString("loanNo", loanNo);
            query.SetDecimal("interest1", interest1);
            query.SetDecimal("interest2", interest2);
            query.SetDecimal("interest3", interest3);
            query.SetDecimal("lastInterest", lastInterest);
            // query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public MNMDTO00008 SelectByAccountNoAndLoanNo(string accountNo,string loanNo, string sourceBr)      //ASDA
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.SelectByAccountNoAndLoanNo");
            query.SetString("accountNo", accountNo);
            query.SetString("lno", loanNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<MNMDTO00008>();
        }

        public IList<MNMDTO00008> SelectByLoanNo(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00008.SelectByLoanNo");
            query.SetString("lno", loanNo);
        
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00008>();
        
        }
    }
}