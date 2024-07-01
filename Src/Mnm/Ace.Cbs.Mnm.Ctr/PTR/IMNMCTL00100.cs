//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/30/2013</CreatedDate>
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
    public interface IMNMCTL00100 : IPresenter
    {
        IMNMVEW00100 View { get; set; }

        MNMDTO00032 GetSavingEntity();
        IList<MNMDTO00034> GetInterestList();
    }

    public interface IMNMVEW00100
    {
        IMNMCTL00100 Controller { get; set; }
        string FormName { get; set; }
        IList<MNMDTO00034> list { get; set; }
    }
}
