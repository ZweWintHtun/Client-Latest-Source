//----------------------------------------------------------------------
// <copyright file="ITLMSVE00029.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>05/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;

using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    /// <summary>
    /// Clean Cash OverDraft Report Service Interface
    /// </summary>
    public interface ITCMSVE00029 : IBaseService
    {
        IList<PFMDTO00042> GetOverDraftData(DateTime selectedDateTime, string currency, string workstation, bool isReserval, bool isTransaction, int createduserid, string sourceBr);
    }
}
