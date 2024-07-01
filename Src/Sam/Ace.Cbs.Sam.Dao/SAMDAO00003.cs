//----------------------------------------------------------------------
// <copyright file="SAMDAO00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;

namespace Ace.Cbs.Sam.Dao
{
	public class SAMDAO00003 : DataRepository<SAMORM00003>, ISAMDAO00003
    {
		public bool CheckExist(int id,DateTime dATE ,string dESCRIPTION )
        {
            IQuery query = this.Session.GetNamedQuery("HOLIDAYDAO.CheckExist");
			query.SetDateTime("dATE", dATE);
            //query.SetString("dESCRIPTION", dESCRIPTION); 
            SAMDTO00003 hOLIDAY = query.UniqueResult<SAMDTO00003>();
            return hOLIDAY == null ? false : (hOLIDAY.Id == id ? false : true);
        }

        public IList<SAMDTO00003> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("HOLIDAYDAO.SelectAll");
            return query.List<SAMDTO00003>();
        }

        public SAMDTO00003 SelectById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("HOLIDAYDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<SAMDTO00003>();
        }


        public IList<SAMDTO00003> SelectByDateAll()
        {
            IQuery query = this.Session.GetNamedQuery("HOLIDAYDAO.SelectByDateAll");
            return query.List<SAMDTO00003>();
        }

	}
}
