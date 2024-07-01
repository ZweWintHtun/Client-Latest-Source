//----------------------------------------------------------------------
// <copyright file="ISAMCTL00022.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>NLKK</CreatedUser>
// <CreatedDate>08/02/2013</CreatedDate>
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
    public interface ISAMCTL00022 : IPresenter
    {
        ISAMVEW00022 PORateView { set; get; }
        IList<TLMDTO00003> GetAll();
        void Save(TLMDTO00003 entity);
        void Delete(IList<TLMDTO00003> itemList);
        TLMDTO00003 SelectById(int id);
        IList<CurrencyDTO> GetCurrency();
    }

    public interface ISAMVEW00022
    {
        int Id { get; }
        decimal Rate { get; set; }
        decimal FixAmt { get; set; }
        decimal StartNo { get; set; }
        decimal EndNo { get; set; }
        string Cur { get; set; }
        string Status { get; set; }

        TLMDTO00003 ViewData { get; set; }
        TLMDTO00003 PreviousPORateDto { get; set; }
        IList<TLMDTO00003> PORates { get; set; }
        ISAMCTL00022 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}