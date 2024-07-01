//----------------------------------------------------------------------
// <copyright file="ISAMCTL00003.cs" company="ACE Data Systems">
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
    public interface ISAMCTL00003 : IPresenter
    {
        ISAMVEW00003 OccupationCodeView { set; get; }
        IList<PFMDTO00004> GetAll();
        void Save(PFMDTO00004 entity);
        void Delete(IList<PFMDTO00004> itemList);
        PFMDTO00004 SelectByOccupationCode(string occupationCode);
    }

    public interface ISAMVEW00003
    {
        string OccupationCode { get; set; }
        string Desp { get; set; }
        string Status { get; set; }

        PFMDTO00004 ViewData { get; set; }
        PFMDTO00004 PreviousOccupationDto { get; set; }
        IList<PFMDTO00004> OccupationCodes { get; set; }
        ISAMCTL00003 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}