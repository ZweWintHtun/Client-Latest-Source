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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Dao
{
    /// <summary>
    /// BranchDAO 
    /// </summary>
    public class SAMDAO00004 : DataRepository<Branch>, ISAMDAO00004
    {
        public IList<BranchDTO> SelectAllBranch()
        {
            IQuery query = this.Session.GetNamedQuery("BranchCode.SelectAllBranchForCbo");
            return query.List<BranchDTO>();
        }
    }
}
