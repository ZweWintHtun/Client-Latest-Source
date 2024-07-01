//----------------------------------------------------------------------
// <copyright file="ITLMSVE00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00005
    {

        ITLMDAO00015 CashDenoDAO { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        string Save(TLMDTO00015 cashDenoEntity);
    }
}
