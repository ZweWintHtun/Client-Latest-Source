//----------------------------------------------------------------------
// <copyright file="TLMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>26/09/2013</CreatedDate>
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
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00017
    {
        ITLMVEW00017 View { get; set; }
        IList<TLMDTO00017> GetRDData(string status);
        IList<TLMDTO00001> GetREData(string sourceBranch); //requested by Ma SZ, comment by ASDA
        //IList<TLMDTO00001> GetREData();
        void PassingDrawingRemittanceByCheck(string status);
        bool PassingDrawingRemittanceByTimer();
        bool ApprovedData(int index);
        TLMDTO00056 GetPassingData();
    }

    public interface ITLMVEW00017
    {
        ITLMCTL00017 Controller { get; set; }
        IList<TLMDTO00001> REDTO { get; set; }
        IList<TLMDTO00017> RDDto { get; set; }
        string RegisterNo { get; set; }
        DateTime SettlementDate { get; set; }
        int ProcessTime { get; set; }
        int IntervalTime { get; set; }
        bool isSelected { get; set; }
        void AddStatusToListbox(string status);
        void BindGridData();
        string ParentFormId { get; }
        CXDMD00010 CurrentFormPermissionEntity { get; set; }
        void EncashPasingSuccessful(string Message, string iblpo, string registerNo, decimal amount);
        void EncashPassingFail(string Message);
    }
}
