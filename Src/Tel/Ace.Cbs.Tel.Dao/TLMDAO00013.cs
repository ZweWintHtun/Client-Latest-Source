//----------------------------------------------------------------------
// <copyright file="TLMDAO00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    public class TLMDAO00013 : DataRepository<TLMORM00013>, ITLMDAO00013
    {
        public IList<TLMDTO00013> SelectCounterInfoForCashClosing(string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CashSetup.SelectCounterInfoForCashClosing");
            query.SetString("branchCode", branchCode);
            return query.List<TLMDTO00013>();
        }

        public IList<TLMDTO00013> SelectCashSetupForCashClosing()
        {
            IQuery query = this.Session.GetNamedQuery("CashSetup.SelectCashSetupForCashClosing");
            return query.List<TLMDTO00013>();
        }


    }
}