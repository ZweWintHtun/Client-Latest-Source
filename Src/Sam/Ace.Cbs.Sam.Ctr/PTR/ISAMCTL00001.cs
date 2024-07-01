//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser>ksw</UpdatedUser>
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
    public interface ISAMCTL00001 : IPresenter
    {
        ISAMVEW00001 AccountTypeView { set; get; }
        PFMDTO00015 PreviousAccountTypeDto { get; set; }

        IList<PFMDTO00015> GetAll();
        void Save(PFMDTO00015 entity);
        void Delete(IList<PFMDTO00015> itemList);
        PFMDTO00015 SelectById(int id);
    }

    public interface ISAMVEW00001
    {
        int Id { get; }
        string Code { get; set; }
        string Description { get; set; }
        string Symbol { get; set; }
        string Status { get; set; }

        PFMDTO00015 ViewData { get; set; }
        IList<PFMDTO00015> AccountTypes { get; set; }
        ISAMCTL00001 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}