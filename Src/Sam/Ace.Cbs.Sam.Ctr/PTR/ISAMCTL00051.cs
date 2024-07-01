//----------------------------------------------------------------------
// <copyright file="ISAMCTL00051.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/08/2013</CreatedDate>
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00051 : IPresenter
    {
        ISAMVEW00051 RateInfoView { set; get; }
        IList<PFMDTO00075> GetAll();
        void Save(PFMDTO00075 entity);
        void Delete(IList<PFMDTO00075> itemList);
        PFMDTO00075 SelectById(int id);
        IList<CurrencyDTO> GetCurrency();
    }

    public interface ISAMVEW00051
    {
        int Id { get; }
        string Cur { get; set; }
        string RateType { get; set; }
        decimal Rate { get; set; }
        string DenoRate { get; set; }
        DateTime RDate { get; set; }
        string ToCur { get; set; }
        string Status { get; set; }

        PFMDTO00075 ViewData { get; set; }
        PFMDTO00075 PreviousRateInfoDto { get; set; }
        IList<PFMDTO00075> RateInfos { get; set; }
        ISAMCTL00051 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}