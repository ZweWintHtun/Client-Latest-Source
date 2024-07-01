//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00002.cs" company="ACE Data Systems">
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
    public interface ISAMCTL00002 : IPresenter
    {
        ISAMVEW00002 SubAccountTypeView { set; get; }
        IList<PFMDTO00022> GetAll();
        void Save(PFMDTO00022 entity);
        void Delete(IList<PFMDTO00022> itemList);
        PFMDTO00022 SelectById(int id);
        IList<PFMDTO00015> SelectAll();
    }

    public interface ISAMVEW00002
    {
        int Id { get; }
        string Code { get; set; }
        string Description { get; set; }
        string Symbol { get; set; }
        string Status { get; set; }
        string AccountSign { get; set; }

        PFMDTO00022 PreviousSubAccountType { get; set; }
        PFMDTO00022 ViewData { get; set; }
        IList<PFMDTO00022> SubAccountTypes { get; set; }
        ISAMCTL00002 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}