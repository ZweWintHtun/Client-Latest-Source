//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMDAO00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>05/26/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Sam.Dmd;
using System;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Dao
{
    /// <summary>
    /// BranchDAO Interface
    /// </summary>
    public interface ISAMDAO00004 : IDataRepository<Branch>
    {
        IList<BranchDTO> SelectAllBranch();
    }
}
