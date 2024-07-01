//----------------------------------------------------------------------
// <copyright file="ITCMDAO00002.cs" Name="Start" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tcm.Dmd;


namespace Ace.Cbs.Tcm.Ctr.Dao
{
    /// <summary>
    /// ServiceCharges DAO Interface
    /// </summary>
    public interface ITCMDAO00002 : IDataRepository<TCMORM00002>
    {
        int SelectMaxId();
    }
}
