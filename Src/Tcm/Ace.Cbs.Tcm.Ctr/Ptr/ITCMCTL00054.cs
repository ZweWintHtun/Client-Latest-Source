//----------------------------------------------------------------------
// <copyright file="ITCMCTL00054.cs" company="ACE Data Systems">
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

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
  public interface ITCMCTL00054 :IPresenter
    {
      ITCMVEW00054 View { get; set; }
    }

  public interface ITCMVEW00054
  {
      ITCMCTL00054 Controller { get; set; }
 
  }
}
