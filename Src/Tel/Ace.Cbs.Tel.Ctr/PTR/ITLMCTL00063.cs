//----------------------------------------------------------------------
// <copyright file="ITLMCTL00063" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2.9.2013</CreatedDate>
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
    public interface ITLMCTL00063 : IPresenter
    {
        ITLMVEW00063 View { get; set; }
        IList<PFMDTO00042> ShowDepositAllReport();
        IList<PFMDTO00042> ShowDepositByCounterReport();
        IList<PFMDTO00042> ShowDepositByGrade();
        IList<PFMDTO00042> ShowWithdrawByGrade();
       
    }
    public interface ITLMVEW00063
    {
        ITLMCTL00063 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string CounterNo { get; set; }
        decimal MinimumAmount { get; set; }
        decimal MaximumAmount { get; set; }
        string AccountSign { get; set; }
    }
}
