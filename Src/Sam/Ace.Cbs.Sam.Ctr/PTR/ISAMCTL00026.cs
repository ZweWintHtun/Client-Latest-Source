//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00026.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Lenovo</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
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
    public interface ISAMCTL00026 : IPresenter
    {
        ISAMVEW00026 RemitBrView { set; get; }
        TLMDTO00028 PreviousRemittanceDto { get; set; }
        void Save(TLMDTO00028 entity,IList<TLMDTO00032> itemList);
        void Delete(TLMDTO00028 itemList);
        IList<BranchDTO> SelectBranchCode();
        void BindContorls();
        IList<CurrencyDTO> GetCurrency();
    }

    public interface ISAMVEW00026
    {
        int Id { get; set; }
        string BranchCode { get; set; }
        decimal TlxCharges { get; set; }
        string DrawAc { get; set; }
        string EncashAc { get; set; }
        string IBSComAc { get; set; }
        string TelexAc { get; set; }
        string IRPOAC { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Status { get; set; }
        
        TLMDTO00028 ViewData { get; set; }
        TLMDTO00028 PreviousRemittanceDto { get; set; }
        ISAMCTL00026 Controller { set; get; }
        IList<TLMDTO00032> RmitRates { get; set; }

        void dgVRemitBr_DataBind();
        IList<TLMDTO00032> GetItemCollection();
        void Successful(string message);
        void Failure(string message);
    }
}