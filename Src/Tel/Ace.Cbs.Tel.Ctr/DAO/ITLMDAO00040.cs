//----------------------------------------------------------------------
// <copyright file="ITLMDAO00040.cs" company="ACE Data Systems">
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
    /// TLMDAO00040 Interface
    /// </summary>
    public interface ITLMDAO00040 : IDataRepository<TLMORM00040>
    {
        bool CheckExist(string bCode, string bDesp, bool isEdit);
        IList<TLMDTO00040> SelectAll();
        TLMDTO00040 SelectByBCode(string bCode);
IList<TLMDTO00040> CheckExist2(string bCode, string desp);
    }
}