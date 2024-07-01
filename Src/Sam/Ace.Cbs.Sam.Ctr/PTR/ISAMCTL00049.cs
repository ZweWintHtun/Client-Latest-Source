//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00049.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00049 : IPresenter
    {
        ISAMVEW00049 Sys001View { set; get; }
        IList<PFMDTO00056> GetAll();
        void Save(PFMDTO00056 entity,IList<BranchDTO> BranchList);
        void Delete(IList<PFMDTO00056> itemList);
        PFMDTO00056 SelectById(int id);
    }

    public interface ISAMVEW00049
    {
        int Id { get; }
        string Name { get; set; }
        PFMDTO00056 ViewData { get; set; }
        PFMDTO00056 PreviousSys001Dto { get; set; }
        string Status { get; set; }
        bool chkStatus { get; set; }
        IList<PFMDTO00056> Sys001s { get; set; }
        ISAMCTL00049 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}