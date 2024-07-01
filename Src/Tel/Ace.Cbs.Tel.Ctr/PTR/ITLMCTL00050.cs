//----------------------------------------------------------------------
// <copyright file="ITLMCTL00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-23</CreatedDate>
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
   public interface ITLMCTL00050:IPresenter
    {
       ITLMVEW00050 IBLTestKeyListingView { get; set; }
       IList<TLMDTO00037> GetPrintData(DateTime date);
       IList<TLMDTO00037> GetALLPrintData();
    }
   public interface ITLMVEW00050
   {
       ITLMCTL00050 IBLTestKeyListingController { get; set; }
       DateTime Date { get; set; }
        void CloseForm();

   }
}
