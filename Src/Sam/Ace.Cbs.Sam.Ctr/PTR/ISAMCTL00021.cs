//----------------------------------------------------------------------
// <copyright file="ISAMCTL00021.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/24/2013</CreatedDate>
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
    public interface ISAMCTL00021 : IPresenter
    {
        ISAMVEW00021 InitialView { set; get; }
        IList<PFMDTO00003> GetAll();
        void Save(PFMDTO00003 entity);
        void Delete(IList<PFMDTO00003> itemList);
        PFMDTO00003 SelectByInitial(string initial);
    }

    public interface ISAMVEW00021
    {
        string Initial { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        PFMDTO00003 ViewData { get; set; }
        PFMDTO00003 PreviousInitialDto { get; set; }
        IList<PFMDTO00003> Initials { get; set; }
        ISAMCTL00021 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}