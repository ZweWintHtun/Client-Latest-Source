//----------------------------------------------------------------------
// <copyright file="MNMDAO00011.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SuNge</CreatedUser>
// <CreatedDate>12/04/2013</CreatedDate>
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
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace ACE.Cbs.Mnm.Dao
{
	public class MNMDAO00011 : DataRepository<MNMORM00011>, IMNMDAO00011
    {
        public IList<MNMDTO00011> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00011.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<MNMDTO00011> res = query.List<MNMDTO00011>();
            return res;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCommit(decimal month, string budget, string SourceBranchCode,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00011.Updatecommit");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
            
        }

        public IList<MNMDTO00011> SelectByAccountNo(string accountNo)      //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00011.SelectByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<MNMDTO00011>();
        }

        public IList<MNMDTO00011> SelectByLoansNo(string loanNo, string sourceBr)      //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00011.SelectByLoansNo");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00011>();
        }
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCommitmentFeesForInterestEdit(string loanNo, decimal lastInterest, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId)
        {
            IQuery query = this.Session.CreateQuery("Update MNMORM00011 set " + month1 + " = :interest1 , " + month2 + " = :interest2 , " + month3 + " = :interest3 , LastInt = :lastInterest , UpdatedDate = :updatedDate , UpdatedUserId = :updatedUserId where LNo = :loanNo");
            query.SetDecimal("interest1", interest1);
            query.SetDecimal("interest2", interest2);
            query.SetDecimal("interest3", interest3);
            query.SetDecimal("lastInterest", lastInterest);
            query.SetString("loanNo", loanNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public IList<MNMDTO00011> SelectByLoanNo(string accountNo, string loanNo)      //TAK
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00011.SelectByLoan");
            query.SetString("accountNo", accountNo);
            query.SetString("loanNo", loanNo);
            return query.List<MNMDTO00011>();
        }
	}
}
