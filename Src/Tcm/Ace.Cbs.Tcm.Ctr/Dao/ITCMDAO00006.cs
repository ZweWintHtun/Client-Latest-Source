//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ITCMDAO00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>12/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Dao
{
    /// <summary>
    /// TCMDAO00006 Interface
    /// </summary>
    public interface ITCMDAO00006 : IDataRepository<TCMORM00006>
    {
        bool DeleteByAccountNo(int updatedUserId, string accountno, string sourcebr);
    }
}