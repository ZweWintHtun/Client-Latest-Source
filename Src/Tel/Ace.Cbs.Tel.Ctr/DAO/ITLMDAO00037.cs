//----------------------------------------------------------------------
// <copyright file="ITLMDAO00037.cs" company="ACE Data Systems">
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
    /// TLMDAO00037 Interface
    /// </summary>
    public interface ITLMDAO00037 : IDataRepository<TLMORM00037>
    {
        bool CheckExist(int id, decimal value, string code);
        IList<TLMDTO00037> SelectAll();
        TLMDTO00037 SelectById(int id);
    }
}