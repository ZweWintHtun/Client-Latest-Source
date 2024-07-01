//----------------------------------------------------------------------
// <copyright file="TLMDAO00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Dao
{
	public class TLMDAO00002 : DataRepository<TLMORM00002>, ITLMDAO00002
    {

		public bool CheckExist(string counterNo,string description ,bool hasVault,bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("COUNTERINFODAO.CheckExist");
			query.SetString("counterNo", counterNo);
            query.SetString("description", description);
           
            IList<TLMDTO00002> COUNTERINFOList = query.List<TLMDTO00002>();
            return COUNTERINFOList == null ? false : this.CheckDTOList(COUNTERINFOList, counterNo, isEdit);
		}

        public IList<CounterInfoDTO> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("COUNTERINFODAO.SelectAll");
            return query.List<CounterInfoDTO>();
        }

        public TLMDTO00002 SelectByCounterNo(string counterNo)
        {
            IQuery query = this.Session.GetNamedQuery("COUNTERINFODAO.SelectByCounterNo");
            query.SetString("counterNo", counterNo);
            return query.UniqueResult<TLMDTO00002>();
        }
		
		private bool CheckDTOList(IList<TLMDTO00002> cOUNTERINFOList,string counterNo,bool isEdit)
        {
            foreach (TLMDTO00002 info in cOUNTERINFOList)
            {
                if (info.CounterNo != counterNo && isEdit)
                    return true;
                else if (!isEdit)
                    return true;
            }
            return false;
        }

	}
}
