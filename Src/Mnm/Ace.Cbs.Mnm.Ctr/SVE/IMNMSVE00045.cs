//----------------------------------------------------------------------
//<copyright file="IMNMSVE00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>01/22/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00045:IBaseService
    {
        IList<PFMDTO00042> print(bool isHomeCur, DateTime date, int updatedUserId, string dateType, string branchCode, string cur, string workstation, string sourceBr, bool isReversal);
    }
}
