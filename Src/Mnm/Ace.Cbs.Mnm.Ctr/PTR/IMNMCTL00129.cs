//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate271/01/2013</CreatedDate>
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
    public interface IMNMCTL00129 : IPresenter
    {
        IMNMVEW00129 View { get; set; }
        IList<PFMDTO00029> SelectLinkAutoPriority(string SourceBr);
      
    }

    public interface IMNMVEW00129
    {
        IMNMCTL00129 Controller { get; set; }
    }
}