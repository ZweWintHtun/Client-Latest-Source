//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
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

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00007 : IPresenter
    {
        ISAMVEW00007 HOLIDAYView { set; get; }
        IList<SAMDTO00003> GetAll();
        void Save(SAMDTO00003 entity);
        void Delete(IList<SAMDTO00003> itemList);
        SAMDTO00003 SelectById(int id);
    }

    public interface ISAMVEW00007
    {
        int Id { get; }
        DateTime DATE { get; set; }
        string DESCRIPTION { get; set; }
        string Status { get; set; }

        SAMDTO00003 ViewData { get; set; }
        SAMDTO00003 PreviousHolidayDto { get; set; }
        IList<SAMDTO00003> HOLIDAYs { get; set; }
        ISAMCTL00007 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}