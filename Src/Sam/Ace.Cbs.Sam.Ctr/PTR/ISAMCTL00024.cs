//----------------------------------------------------------------------
// <copyright file="ISAMCTL00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00024 : IPresenter
    {
        ISAMVEW00024 DenoView { set; get; }
        IList<TLMDTO00012> GetAll();
        void Save(TLMDTO00012 entity);
        void Delete(IList<TLMDTO00012> itemList);
        TLMDTO00012 SelectById(int id);
        IList<CurrencyDTO> GetCur();
    }

    public interface ISAMVEW00024
    {
        int Id { get; }
        string DESP { get; set; }
        string D1 { get; set; }
        string D2 { get; set; }
        //string UID { get; set; }
        string CUR { get; set; }
        string SYMBOL { get; set; }
        string Status { get; set; }

        TLMDTO00012 ViewData { get; set; }
        TLMDTO00012 PreviousDenoInfoDto { get; set; }

        IList<TLMDTO00012> Denos { get; set; }
        ISAMCTL00024 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}