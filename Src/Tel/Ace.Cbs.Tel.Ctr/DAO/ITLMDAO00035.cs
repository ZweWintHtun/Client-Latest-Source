//----------------------------------------------------------------------
// <copyright file="ITLMDAO00035.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
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
    /// TLMDAO00035 Interface
    /// </summary>
    public interface ITLMDAO00035 : IDataRepository<TLMORM00035>
    {
        bool CheckExist(int id, decimal value, string code);
        IList<TLMDTO00035> SelectAll();
        TLMDTO00035 SelectById(int id);
    }
}