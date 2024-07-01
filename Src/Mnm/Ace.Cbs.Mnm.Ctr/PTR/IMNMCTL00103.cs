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

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00103 : IPresenter
    {
        IMNMVEW00103 View { get; set; }
        MNMDTO00032 GetSubLedgerEntity();
    }

    public interface IMNMVEW00103
    {
        IMNMCTL00103 Controller { get; set; }
        string FormName { get; set; }
        IList<MNMDTO00032> list { get; set; }
    }
}
