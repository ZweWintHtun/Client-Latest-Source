//----------------------------------------------------------------------
// <copyright file="ITLMCTL00040.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-09-17 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00040:IPresenter
    {
       ITLMVEW00040 DrawingRemittanceEncashNRCandNameView { get; set; }
       IList<TLMDTO00017> MainPrint(string typename);

    }
   public interface ITLMVEW00040
   {
       ITLMCTL00040 DrawingRemittanceEncashNRCandNameController { get; set; }
       DateTime StartDate { get; set; }
       DateTime EndDate { get; set; }
       string NameAndNRC { get; set; }

   }
}
