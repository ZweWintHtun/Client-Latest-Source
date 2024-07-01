//----------------------------------------------------------------------
// <copyright file="ITLMCTL00023.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00023 :IPresenter
    {
        ITLMVEW00023 View { get; set; }
        void GetTransaction();
    }

    public interface ITLMVEW00023
    {
        ITLMCTL00023 Controller { get; set; }
        string Name { get; set; }
        int Index { get; set; }
    }
}
