//----------------------------------------------------------------------
// <copyright file="ICXCTR00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Dmd;
using System;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Manager Approve Form Controller Interface
    /// </summary>
    public interface ICXCTR00016 : IPresenter
    {
        ICXCLE00016 View { get; set; }
        void GetManagerApprove();
        void ClearControls();
        
    }
    /// <summary>
    /// Manager Approve Form Interface
    /// </summary>
    public interface ICXCLE00016
    {
        string UserName { get; set; }
        string Password { get; set; }
        string TestKey { get; set; }
        string BranchKey { get; set; }
        CXDMD00006 RemittanceType { get; set; }
        CXDMD00010 CurrentFormPermissionEntity { get; set; }
        decimal ValidTestKey { get; set; }
        decimal EncashAmount { get; set; }
        DateTime EncashDate { get; set; }
        string ConfirmPassword { get; set; }
        string ProgramId { get; }
        bool ChkRememberPassword { get; set; }
        bool HasTestKey { get; set; }
        ICXCTR00016 Controller { get; set; }

        void ResetRememberPassword(int userid,string password, string userName, bool isRememberPassword);
        void Successful(int validPassword);
        void Failure(string message);
    }
}
