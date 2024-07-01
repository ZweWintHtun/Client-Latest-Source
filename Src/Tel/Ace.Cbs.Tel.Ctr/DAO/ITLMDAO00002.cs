//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITLMDAO00002.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// TLMDAO00002 Interface
    /// </summary>
    public interface ITLMDAO00002 : IDataRepository<TLMORM00002>
    {
        bool CheckExist(string counterNo, string description, bool hasVault, bool isEdit);
        IList<TLMDTO00002> SelectAll();
        TLMDTO00002 SelectByCounterNo(string counterNo);
    }
}