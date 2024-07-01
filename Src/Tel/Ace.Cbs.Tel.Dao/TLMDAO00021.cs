//----------------------------------------------------------------------
// <copyright file="TLMDAO00025.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nway Ei Ei Aung</CreatedUser>
// <CreatedDate>2013-11-26</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Tel.Dao
{
    public class TLMDAO00021:DataRepository<TLMORM00021>,ITLMDAO00021
    {
        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00021.SelectMaxId");
            TLMDTO00021 dto = query.UniqueResult<TLMDTO00021>();
            return dto.Id;
        }


         [Transaction(TransactionPropagation.Required)]
        public bool DeleteByWorkStation(string workStation,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00021.DeleteByWorkStation");
            query.SetString("workStation", workStation);
            query.SetString("SourceBranchCode", sourcebr);
            return query.ExecuteUpdate() > 0;
        }

    }
}
