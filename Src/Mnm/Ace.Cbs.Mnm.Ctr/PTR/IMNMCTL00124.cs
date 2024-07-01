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
    public interface IMNMCTL00124 : IPresenter
    {
        IMNMVEW00124 View { get; set; }
        IList<PFMDTO00042> Print();
    }

    public interface IMNMVEW00124
    {
        IMNMCTL00124 Controller { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }
    }
}
