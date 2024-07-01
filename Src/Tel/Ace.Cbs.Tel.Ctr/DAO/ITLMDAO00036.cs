//----------------------------------------------------------------------
// <copyright file="ITLMDAO00036.cs" company="ACE Data Systems">
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
    /// TLMDAO00036 Interface
    /// </summary>
    public interface ITLMDAO00036 : IDataRepository<TLMORM00036>
    {
        bool CheckExist(int id, decimal value, string code);
        IList<TLMDTO00036> SelectAll();
        TLMDTO00036 SelectById(int id);
    }
}