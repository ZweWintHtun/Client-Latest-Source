//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Dmd;
using System;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    /// <summary>
    /// MNMDAO00013 Interface
    /// </summary>
    public interface IMNMDAO00013 : IDataRepository<MNMORM00013>
    {
        bool CheckExist(DateTime fIXINTDATE, DateTime fIXVOUDATE, string uID, bool isEdit);
        IList<MNMDTO00013> SelectAll();
        MNMDTO00013 SelectByFIXINTDATE(DateTime fIXINTDATE);
    }
}