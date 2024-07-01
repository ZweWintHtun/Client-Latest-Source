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
    public class MNMDAO00041 : DataRepository<MNMORM00041>, IMNMDAO00041
    {
        public IList<MNMDTO00041> SelectByStartDATE_Time(DateTime startDATE_Time, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SelectByStartDATE_Time");
            query.SetDateTime("startDATE_Time", startDATE_Time);
            query.SetString("SourceBr", sourceBr);
            IList<MNMDTO00041> List = query.List<MNMDTO00041>();
            return List;
           
        }
    }
}