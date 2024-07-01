//----------------------------------------------------------------------
// <copyright file="ISAMCTL00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00050 : IPresenter
    {
        ISAMVEW00050 MessageView { set; get; }
        IList<PFMDTO00048> GetAll();
        void Save(PFMDTO00048 entity);
        void Delete(IList<PFMDTO00048> itemList);
        PFMDTO00048 SelectByCode(string code);
    }

    public interface ISAMVEW00050
    {
        string Code { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        PFMDTO00048 ViewData { get; set; }
        PFMDTO00048 PreviousMessageDto { get; set; }
        IList<PFMDTO00048> Messages { get; set; }
        ISAMCTL00050 Controller { set; get; }
        void ControlSetting(string name, bool isEnable);
        void Successful(string message);
        void Failure(string message);
    }
}