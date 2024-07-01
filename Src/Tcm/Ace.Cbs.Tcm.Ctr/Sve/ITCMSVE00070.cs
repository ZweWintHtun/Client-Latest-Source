//----------------------------------------------------------------------
// <copyright file="ITCMSVE00070.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2014/08/01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
   public interface ITCMSVE00070:IBaseService
    {
       TLMDTO00059 CheckAccountNo(string accountNo, bool isVIP, bool isWithIncome, string workStation, int createdUserId, string sourceBr);
    }
}
