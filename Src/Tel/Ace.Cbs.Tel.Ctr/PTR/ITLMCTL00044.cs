//----------------------------------------------------------------------
// <copyright file="ITLMCTL00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-08-21</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
   public interface ITLMCTL00044:IPresenter
    {
       ITLMVEW00044 DenominationOutstandingMultipleTransactionView { get; set; }
       IList<TLMDTO00009> GetPrintData();
    }

   public interface ITLMVEW00044
   {
       ITLMCTL00044 DenominationOutstandingMultipleTransactionController { get; set; }
   }
}
