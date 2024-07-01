//----------------------------------------------------------------------
// <copyright file="PFMDAO00057.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System;

namespace Ace.Cbs.Pfm.Dao
{
/// <summary>
/// New Set Up
/// </summary>
	public class PFMDAO00057 : DataRepository<PFMORM00057>, IPFMDAO00057
    {

		public bool CheckExist(string variable,string value ,bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.CheckExist");
			query.SetString("variable", variable);
            //query.SetString("value", value); 
            IList<PFMDTO00057> NewSetupList = query.List<PFMDTO00057>();
            return NewSetupList == null ? false : this.CheckDTOList(NewSetupList, variable, isEdit);
            //return NewSetupList == null ? false : true;
		}

        public IList<PFMDTO00057> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.SelectAll");
            return query.List<PFMDTO00057>();
        }

        public PFMDTO00057 SelectByVariable(string variable)
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.SelectByVariable");
            query.SetString("variable", variable);
            return query.UniqueResult<PFMDTO00057>();
        }

        public IList<PFMDTO00057> CheckExist2(string variable, string value)
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.CheckExist2");
            query.SetString("variable", variable);
            //query.SetString("value", value);
            IList<PFMDTO00057> NewSetUpList = query.List<PFMDTO00057>();
            return NewSetUpList;
        }
		
		private bool CheckDTOList(IList<PFMDTO00057> newSetupList,string variable,bool isEdit)
        {
            foreach (PFMDTO00057 info in newSetupList)
            {
                if (info.Variable != variable && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateValueOfRunTrigger(string Disable_Enable,int updatedUserId)      //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.UpdateValue");
            query.SetString("value", Disable_Enable);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("variable", "RunTrigger");
            query.ExecuteUpdate();
        }

        public string SelectBudDate(string variable)
        {
            IQuery query = this.Session.GetNamedQuery("NewSetupDAO.SelectBudDate");
            query.SetString("variable", variable);
            PFMDTO00057 newsetup = query.UniqueResult<PFMDTO00057>();
            return newsetup.Value.ToString();

        }

        public bool UpdateByVariable(string variable, string value, int updateduserid)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00057.UpdateByVariable");
            query.SetString("variable", variable);
            query.SetString("value", value);
            query.SetInt32("updatedUserId", updateduserid);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00057> NewSetup_SelectSDateEDate()
        {
            IQuery query = this.Session.GetNamedQuery("NewSetup_SelectSDateEDate");
            return query.List<PFMDTO00057>();
        }
        //Added by AAM (20_Sep_2018)
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
        public string YearlyPostingProcess(string budget, int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_YearlyPostingProcess");
            query.SetString("budget", budget);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
        public string YearlyPostingProcess_Initial(int createdUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_YearlyPostingProcess_CurYearInitial");
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }

	}
}
