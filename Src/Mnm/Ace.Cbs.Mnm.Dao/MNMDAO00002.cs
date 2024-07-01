//----------------------------------------------------------------------
// <copyright file="MNMDAO00002.cs" company="ACE Data Systems">
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
    public class MNMDAO00002 : DataRepository<MNMORM00002>, IMNMDAO00002
    {
        [Transaction(TransactionPropagation.Required)]
        public void FormatDefinitionMaxValueUpdate(string sourcebr, int updateduserid)
        {
            IQuery query = this.Session.GetNamedQuery("MNMDAO00002.FormatDefinitionMaxValueUpdate");
            query.SetString("branchCode", sourcebr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updateduserid);
            query.ExecuteUpdate();
        }       
    }
}