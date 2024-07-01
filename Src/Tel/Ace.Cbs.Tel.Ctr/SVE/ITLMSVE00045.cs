//----------------------------------------------------------------------
// <copyright file="ITLMSVE00045.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Sve
{
   public interface ITLMSVE00045:IBaseService
    {      
       IList<TLMDTO00016> GetPOOutstandingReport(string SourceBr);          
    }
}
