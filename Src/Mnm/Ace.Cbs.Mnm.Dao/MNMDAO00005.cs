//----------------------------------------------------------------------
// <copyright file="MNMDAO00005.cs" company="ACE Data Systems">
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
using System;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00005 : DataRepository<MNMORM00005>, IMNMDAO00005
    {

        //For Posting
        public string GetCoaSetupAccountNo(string accountName, string branchCode, string currencyCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXCOM00010.SelectCoaSetupAccountNo");
            query.SetString("accountName", accountName);
            query.SetString("currencyCode", currencyCode);
            query.SetString("branchCode", branchCode);


            object rate = query.UniqueResult();

            if (rate == null)
            {
                return null;
            }

            return rate.ToString();
        }

        public IList<MNMDTO00005> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00005.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<MNMDTO00005> res = query.List<MNMDTO00005>();
            return res;
        }
        public IList<MNMDTO00005> SelectByLoanNo(string loanNo, string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00005.SelectByAccountNoAndLoanNo");
            query.SetString("loanNo", loanNo);
            query.SetString("accountNo", accountNo);

            query.SetString("sourceBr", sourceBr);
            return query.List<MNMDTO00005>();

        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTOD_SCHARGED(decimal tod_month, string budget, string SourceBranchCode, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00005.UpdateTOD_SCHARGED");
            query.SetDecimal("tod_month", tod_month);
            query.SetString("budget", budget);
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00005> SelectByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00005.SelectByAccountNo");
            query.SetString("accountNo", accountNo);  
            return query.List<MNMDTO00005>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTOD_SChargeForInterestEdit(string accountNo, decimal lastInterest, string month1, string month2, string month3, decimal interest1, decimal interest2, decimal interest3, int updatedUserId)
        {
            IQuery query = this.Session.CreateQuery("Update MNMORM00005 set " + month1 + " = :interest1 , " + month2 + " = :interest2 , " + month3 + " = :interest3 , LastInt = :lastInterest , UpdatedDate = :updatedDate , UpdatedUserId = :updatedUserId where Acctno = :accountNo");
            query.SetDecimal("interest1", interest1);
            query.SetDecimal("interest2", interest2);
            query.SetDecimal("interest3", interest3);
            query.SetDecimal("lastInterest", lastInterest);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        //Added by HWKO (28-Aug-2017)
        //Updated by HWKO (11-Oct-2017)
        [Transaction(TransactionPropagation.Required)]
        public string SaveUpdateHistoryOfCCOA( string dcode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_INSERT_CCOAHISTORY_DATA");
            //query.SetString("acode", acode);
            query.SetString("dcode", dcode);
            //query.SetString("cur", cur);
            return query.UniqueResult().ToString();
        }


    }
}