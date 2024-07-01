//----------------------------------------------------------------------
// <copyright file="ITLMCTL00042.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-02</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00042:IPresenter
    {
        ITLMVEW00042 View { get; set; }
        PFMDTO00067 GetAccountInformation();
    }

    public interface ITLMVEW00042
    {
        ITLMCTL00042 Controller { get; set; }
        string AccountNo { get; set; }
        //string ParentFormId { get; set; }
    }
}
