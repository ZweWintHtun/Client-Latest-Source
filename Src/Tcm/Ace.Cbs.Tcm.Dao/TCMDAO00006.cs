//----------------------------------------------------------------------
// <copyright file="TCMDAO00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>12/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
namespace Ace.Cbs.Tcm.Dao
{
	public class TCMDAO00006 : DataRepository<TCMORM00006>, ITCMDAO00006
    {
        public bool DeleteByAccountNo(int updatedUserId, string accountno, string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO00006.DeleteByAccountNo");
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("accountno", accountno);
            query.SetDateTime("datetime", DateTime.Now);
            query.SetString("sourcebr", sourcebr);
            return query.ExecuteUpdate() > 0;
        }
	}
}