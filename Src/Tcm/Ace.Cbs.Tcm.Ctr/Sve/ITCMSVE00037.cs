//----------------------------------------------------------------------
// <copyright file="ITCMSVE00037.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>2014-02-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00037 : IBaseService
    {
        IList<PFMDTO00042> GetClearingReceiptReverseService(DateTime startDate, DateTime endDate, string userNo, int createdUserId, string sourceBr);
    }
}
