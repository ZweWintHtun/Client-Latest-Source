//----------------------------------------------------------------------
// <copyright file="ITLMSVE00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-23</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Service;
using System;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00050:IBaseService
    {
       IList<TLMDTO00037> SelectAllView();
       string SelectMaxDate(DateTime datetime);
       IList<TLMDTO00037> SelectAllIBLTestKeyListingByMaxDate(DateTime date);
    }
}
