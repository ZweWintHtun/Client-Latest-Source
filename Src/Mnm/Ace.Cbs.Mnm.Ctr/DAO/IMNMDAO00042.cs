//----------------------------------------------------------------------
// <copyright file="IMNMDAO00041.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>07/17/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using System;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00042 : IDataRepository<MNMORM00042>
    {

        bool DeleteTemptable(string sourceBr);
    }
}
