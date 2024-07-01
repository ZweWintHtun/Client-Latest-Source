//----------------------------------------------------------------------
// <copyright file="TLMDAO00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;

namespace Ace.Cbs.Tel.Dao
{
	public class TLMDAO00010 : DataRepository<TLMORM00010>, ITLMDAO00010
    {
		public bool CheckExist(int id,string name ,string iPAddress ,string hostName ,string maskAddress)
        {
            IQuery query = this.Session.GetNamedQuery("WorkStationDAO.CheckExist");
			query.SetString("name", name);
            query.SetString("iPAddress", iPAddress); 
            query.SetString("hostName", hostName); 
            query.SetString("maskAddress", maskAddress);
            //query.SetString("sourceBr", sourceBr);    
            TLMDTO00010 WorkStation = query.UniqueResult<TLMDTO00010>();
            return WorkStation == null ? false : (WorkStation.Id == id ? false : true);

        }
        public IList<TLMDTO00010> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("WorkStationDAO.SelectAll");
            return query.List<TLMDTO00010>();
        }

        public TLMDTO00010 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("WorkStationDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<TLMDTO00010>();
        }
		


	}
}
