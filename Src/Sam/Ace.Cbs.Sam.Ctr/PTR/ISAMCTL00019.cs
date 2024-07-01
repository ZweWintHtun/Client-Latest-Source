//----------------------------------------------------------------------
// <copyright file="ISAMCTL00019.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/26/2013</CreatedDate>
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
    public interface ISAMCTL00019 : IPresenter
    {
        ISAMVEW00019 DayKeyView { set; get; }
        TLMDTO00034 PreviousTestKeyDto { get; set;}

        IList<TLMDTO00034> GetAll(string keyType);
        void Save(TLMDTO00034 entity, string keyType);
        void Delete(IList<TLMDTO00034> itemList, string keyType);
        TLMDTO00034 SelectById(int id);
    }

    public interface ISAMVEW00019
    {
        int Id { get; }
        string Code { get; set; }
        decimal Value { get; set; }
        DateTime Start_Date { get; set; }
        //string UId { get; }
        //System.Nullable<string> SourceBr { get; set; }
        string Status { get; set; }

        TLMDTO00034 ViewData { get; set; }
        IList<TLMDTO00034> Keys { get; set; }
        ISAMCTL00019 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}