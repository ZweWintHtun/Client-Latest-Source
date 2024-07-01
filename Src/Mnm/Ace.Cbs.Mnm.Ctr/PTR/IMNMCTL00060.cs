//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>27/01/2013</CreatedDate>
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
    public interface IMNMCTL00060 : IPresenter
    {
        IMNMVEW00060 View { get; set; }
        IList<PFMDTO00007> SelectDuration();
        void Print(string duration);
        void ClearCustomErrorMessage();
      
    }

    public interface IMNMVEW00060
    {
        IMNMCTL00060 Controller { get; set; }
        string  RequiredDuration { get; set; }
    }
}