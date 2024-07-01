//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00092 : IPresenter
    {
        IMNMVEW00092 View { get; set; }
        DateTime GetSystemDate(string sourceBr);
    }

    public interface IMNMVEW00092
    {
        IMNMCTL00092 Controller { get; set; }
    }
}
