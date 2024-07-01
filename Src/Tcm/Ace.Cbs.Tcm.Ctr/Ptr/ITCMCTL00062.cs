//----------------------------------------------------------------------
// <copyright file="ITCMCTL00062" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    public interface ITCMCTL00062 : IPresenter
    {
        ITCMVEW00062 View { get; set; }
        IList<PFMDTO00028> GetReconsile();

    }

    public interface ITCMVEW00062 
    {
        ITCMCTL00062 Controller { get; set; }

    }
}
