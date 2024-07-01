//----------------------------------------------------------------------
// <copyright file="MNMDAO00024.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Dao;
using NHibernate;

namespace Ace.Cbs.Mnm.Dao
{
    public class MNMDAO00024 : DataRepository<MNMORM00024>, IMNMDAO00024
    {
        public bool DeleteAdjRemitTodScharge(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("DeleteAdjRemitTodScharge");
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }


    }
}
