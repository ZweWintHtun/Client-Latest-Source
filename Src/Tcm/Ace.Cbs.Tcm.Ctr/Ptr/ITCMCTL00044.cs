//----------------------------------------------------------------------
// <copyright file="ITCMCTL00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-09</CreatedDate>
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
   public interface ITCMCTL00044:IPresenter
    {
       ITCMVEW00044 POPrintingView { get; set; }
       IList<TLMDTO00001> SelectREDTOList(DateTime requireDate);
       bool CheckDate();
    }
   public interface ITCMVEW00044
   {
       ITCMCTL00044 POPrintingController { get; set; }
       DateTime RequiredDate { get; set; }
       void InitializeControls();
       void BindGridView();
   }
}
