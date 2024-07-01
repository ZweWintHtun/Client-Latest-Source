//----------------------------------------------------------------------
// <copyright file="ITCMCTL00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-11-15</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
   public interface ITCMCTL00043:IPresenter
    {
       ITCMVEW00043 ClearingPostingView { get; set; }
       IList<PFMDTO00054> GetTLFList();
      // IList<PFMDTO00054> TLFDTOList { get; set; }
       void ClearingPosting(IList<PFMDTO00054> TLFDTOList);
    }
   public interface ITCMVEW00043
   {
       ITCMCTL00043 ClearingPostingController { get; set; }
       void BindGridView();
       void HideShowChequeNo();
       int GetMenuIDPermission();
   }
}
