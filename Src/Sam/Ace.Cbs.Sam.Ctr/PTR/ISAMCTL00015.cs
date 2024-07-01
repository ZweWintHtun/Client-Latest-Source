//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
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
    public interface ISAMCTL00015 : IPresenter
    {
        ISAMVEW00015 FixRateView { set; get; }
        IList<PFMDTO00007> GetAll();
        void Save(PFMDTO00007 entity);
        void Delete(IList<PFMDTO00007> itemList);
        PFMDTO00007 SelectById(int id);
    }

    public interface ISAMVEW00015
    {
        int Id { get; }
        string Desp { get; set; }
        decimal Rate { get; set; }
        decimal Duration { get; set; }
        string Status { get; set; }

        PFMDTO00007 ViewData { get; set; }
        PFMDTO00007 PreviousFixedRateDto { get; set; }
        IList<PFMDTO00007> FixRates { get; set; }
        ISAMCTL00015 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}