//----------------------------------------------------------------------
// <copyright file="ITLMCTL00026.cs" company="ACE Data Systems">
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
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    
    public interface ITLMCTL00026 : IPresenter
    {
        ITLMVEW00026 View { get; set; }
        void ClearCustomErrorMessage();
        bool Validate();
    }

   
    public interface ITLMVEW00026
    {
        ITLMCTL00026 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        decimal MinimumAmount { get; set; }
        decimal MaximumAmount { get; set; }
        string AccountSign { get; set; }
        string Status { get; set; }
      
    }
}
