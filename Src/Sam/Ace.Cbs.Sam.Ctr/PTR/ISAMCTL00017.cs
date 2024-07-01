//----------------------------------------------------------------------
// <copyright file="ISAMCTL00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>07/30/2013</CreatedDate>
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00017 : IPresenter
    {
        ISAMVEW00017 ZoneView { set; get; }
        IList<TLMDTO00031> GetAll();
        void Save(TLMDTO00031 entity);
        void Delete(IList<TLMDTO00031> itemList);
        TLMDTO00031 SelectById(int id);
        IList<BranchDTO> GetBranchCode();
        IList<TLMDTO00031> GetAllByDistinct();
    }

    public interface ISAMVEW00017
    {
        int Id { get; }
        string ZoneType { get; set; }
        //string ZONEDESP { get; set; }
        string BrCode { get; set; }
        string ACode { get; set; }
        //string UID { get; set; }
        //string SOURCEBR { get; set; }
        string Status { get; set; }

        TLMDTO00031 ViewData { get; set; }
        TLMDTO00031 PreviousZoneDto { get; set; }
        IList<TLMDTO00031> Zones { get; set; }
        ISAMCTL00017 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}