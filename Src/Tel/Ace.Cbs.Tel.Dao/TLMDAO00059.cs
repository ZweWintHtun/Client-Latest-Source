//----------------------------------------------------------------------
// <copyright file="TLMDAO00059.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> NYO ME SAN </CreatedUser>
// <CreatedDate> 2013.8.21 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00059 : DataRepository<TLMVIW00017>, ITLMDAO00059
    {
        public IList<TLMDTO00001> SelectEncashRegisterOutstanding(string sourceBr)
        {
            try
            {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00059.SelectEncashRegisterOutstanding");
            query.SetString("sourceBr", sourceBr);
            IList<TLMDTO00001> list = query.List<TLMDTO00001>();
            return list;
            }
            catch (Exception ex)
            { return null; }

        }
    }
}
