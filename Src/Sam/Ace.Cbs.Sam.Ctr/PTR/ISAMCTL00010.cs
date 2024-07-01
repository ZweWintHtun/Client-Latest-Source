//----------------------------------------------------------------------
// <copyright file="ISAMCTL00010.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00010 : IPresenter
    {
        ISAMVEW00010 AppSettingsView { set; get; }
        IList<PFMDTO00053> GetAll();
        void Save(PFMDTO00053 entity);
        void Delete(IList<PFMDTO00053> itemList);
        PFMDTO00053 SelectById(int id);
    }

    public interface ISAMVEW00010
    {
        int Id { get; }
        string KeyName { get; set; }
        string KeyValue { get; set; }
        string Description { get; set; }
        int Location { get; set; }
        int Type { get; set; }
        //byte[] BinaryValue { get; set; }
        string Status { get; set; }

        PFMDTO00053 ViewData { get; set; }
        PFMDTO00053 PreviousAppSettingDto { get; set; }
        IList<PFMDTO00053> AppSettingss { get; set; }
        ISAMCTL00010 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}