//----------------------------------------------------------------------
// <copyright file="ITLMSVE00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>24/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    /// <summary>
    ///  Vault Withdrawl Denomination Entry Service Interface
    /// </summary>
    public interface ITLMSVE00004
    {
        ICXSVE00002 CodeGenerator { get; set; }

        TLMDTO00015 Save(IList<TLMDTO00015> cashDenoDTOList);
        IList<CounterInfoDTO> GetAllCounterInfoListBySourceBranchCode(string sourceBranchCode);
    }
}
