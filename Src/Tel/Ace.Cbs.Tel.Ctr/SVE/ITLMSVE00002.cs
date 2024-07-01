//----------------------------------------------------------------------
// <copyright file="ITLMSVE00002" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    /// <summary>
    /// Encash Remit Registration Service Interface
    /// </summary>
  public  interface ITLMSVE00002
    {
        bool CheckDuplicateRegisterNo(string registerNo);
        string SaveRE(TLMDTO00001 reDTO);
        string SaveREandPO(TLMDTO00001 reDTO);
        TLMDTO00001 PrintPOData(string registerNo,string sourceBranch);
    }
}
