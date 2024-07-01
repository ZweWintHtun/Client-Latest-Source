//----------------------------------------------------------------------
// <copyright file="MNMDAO00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>07/17/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00042 : DataRepository<MNMORM00042>, IMNMDAO00042
    {
       public bool DeleteTemptable(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TFrecipt.DeleteAll");
            query.SetString("SourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }
     
    }
}
