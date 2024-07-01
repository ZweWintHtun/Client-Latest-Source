//----------------------------------------------------------------------
// <copyright file="ISAMCTL00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/25/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00004 : IPresenter
    {
        ISAMVEW00004 BCodeView { set; get; }
        IList<TLMDTO00040> GetAll();
        void Save(TLMDTO00040 entity);
        void Delete(IList<TLMDTO00040> itemList);
        TLMDTO00040 SelectByBCode(string bCode);
    }

    public interface ISAMVEW00004
    {
        string BCode { get; set; }
        string BDesp { get; set; }
        string BAcctNo { get; set; }
        //System.Nullable<string> UId { get; }
        string Status { get; set; }
        
        TLMDTO00040 PreviousBCodeDto { get; set; }
        TLMDTO00040 ViewData { get; set; }
        IList<TLMDTO00040> BCodes { get; set; }
        ISAMCTL00004 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}