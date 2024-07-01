//----------------------------------------------------------------------
// <copyright file="SAMDAO00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using ACE.CBS.SAM.CTR.DAO;
using ACE.CBS.SAM.DMD;
using ACE.Windows.Core.DAO;
using NHibernate;

namespace ACE.CBS.SAM.DAO
{
	public class SAMDAO00001 : DataRepository<SAMORM00001>, ISAMDAO00001
    {
		public bool CheckExist(int id,string code ,string description ,string symbol )
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.CheckExist");
			query.SetString("code", code);
            query.SetString("description", description); 
            query.SetString("symbol", symbol); 
            SAMDTO00001 accountType = query.UniqueResult<SAMDTO00001>();
            return accountType == null ? false : (accountType.Id == id ? false : true);
        }

        public IList<SAMDTO00001> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.SelectAll");
            return query.List<SAMDTO00001>();
        }

        public SAMDTO00001 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<SAMDTO00001>();
        }
		
		public bool UpdateById(SAMDTO00001 accountTypeInfo)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.UpdateById");
			query.SetString("code", accountTypeInfo.Code);
			query.SetString("description", accountTypeInfo.Description);
			query.SetString("symbol", accountTypeInfo.Symbol);
            query.SetDateTime("updatedDate", accountTypeInfo.UpdatedDate.Value);
            query.SetInt32("updatedUserId", accountTypeInfo.UpdatedUserId.Value);
            query.SetInt32("id", accountTypeInfo.Id);
            return query.ExecuteUpdate() > 0;
        }

        public bool DeleteById(SAMDTO00001 accountTypeInfo)
        {
            IQuery query = this.Session.GetNamedQuery("AccountTypeDAO.DeleteById");
            query.SetDateTime("updatedDate", accountTypeInfo.UpdatedDate.Value);
            query.SetInt32("updatedUserId", accountTypeInfo.UpdatedUserId.Value);
            query.SetInt32("id", accountTypeInfo.Id);
            return query.ExecuteUpdate() > 0;
        }

	}
}