//----------------------------------------------------------------------
// <copyright file="ITLMSVE00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Sve
{
    public interface ITLMSVE00043:IBaseService
    {
        IList<PFMDTO00054> SelectAllView(string sourceBr);
    }
}
