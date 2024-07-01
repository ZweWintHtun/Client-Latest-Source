//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00008 : IPresenter
    {
        ISAMVEW00008 DEPOSITCODEView { set; get; }
        IList<TLMDTO00020> GetAll(string sourceBr);
        void Save(TLMDTO00020 entity);
        void Delete(IList<TLMDTO00020> itemList);
        TLMDTO00020 SelectByDEPCODE(string dEPCODE);
    }

    public interface ISAMVEW00008
    {
        string DepositCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        TLMDTO00020 ViewData { get; set; }
        TLMDTO00020 PreviousDepositCodeDto { get; set; }
        IList<TLMDTO00020> DEPOSITCODEs { get; set; }
        ISAMCTL00008 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);

    }
}