//----------------------------------------------------------------------
// <copyright file="ITCMCTL00033.cs" company="ACE Data Systems">
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
    /// <summary>
    /// Delivered Cheque Listing
    /// </summary>
    public interface ITCMCTL00033 : IPresenter
    {
        ITCMVEW00033 View { get; set; }
        void DeliveredChequeNotYetPosted();
        void DeliveredChequePosted();
        bool CheckDate();
    }

    public interface ITCMVEW00033
    {
        ITCMCTL00033 Controller { get; set; }
        string FormName { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
