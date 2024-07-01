//----------------------------------------------------------------------
// <copyright file="TCMDAO00002.cs" Name="Start" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using NHibernate;

namespace Ace.Cbs.Tcm.Dao
{
    public class TCMDAO00002 : DataRepository<TCMORM00002>, ITCMDAO00002
    {
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("Service_ChargesDAO.SelectMaxId");
            TCMDTO00002 dto = query.UniqueResult<TCMDTO00002>();
            return dto.Id;
        }
    }
}
