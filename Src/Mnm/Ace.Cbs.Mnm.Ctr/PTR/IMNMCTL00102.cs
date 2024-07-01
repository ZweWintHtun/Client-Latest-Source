//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/31/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Windows.Core.Presenter;
using System.Drawing;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00102 : IPresenter
    {
        IMNMVEW00102 View { get; set; }
        MNMDTO00032 GetSubLedgerEntity();
    }

    public interface IMNMVEW00102
    {
        IMNMCTL00102 Controller { get; set; }
        string FormName { get; set; }
        IList<MNMDTO00035> list { get; set; }
    }
}
