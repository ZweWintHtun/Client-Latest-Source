//----------------------------------------------------------------------
// <copyright file="ITCMDAO00001.cs" Name="Start" company="ACE Data Systems">
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
    /// Start DAO Interface
    /// </summary>
  public  interface ITCMDAO00001 : IDataRepository<TCMORM00001>    
    {
      TCMDTO00001 SelectStartBySourceBr(string sourceBr);
      bool UpdateBySourceBr(string sourceBr, int updatedUserId, string status);
      bool UpdateStatusBySourceBr(string sourceBr, int updatedUserId, string status);

    }
}
