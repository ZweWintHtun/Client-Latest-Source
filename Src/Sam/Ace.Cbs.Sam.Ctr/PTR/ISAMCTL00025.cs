// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>

using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00025 : IPresenter
    {
        ISAMVEW00025 RemitBrIblView { set; get; }
        TLMDTO00029 PreviousIBLRemitBrDto{get;set;}
        void Save(TLMDTO00029 entity, IList<TLMDTO00030> itemList);
        void Delete(TLMDTO00029 itemList);
        IList<BranchDTO> SelectBranchCode();
        IList<CurrencyDTO> GetCurrency();
        void BindContorls();
    }

    public interface ISAMVEW00025
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
        IList<TLMDTO00030> GetItemCollection();
        TLMDTO00029 ViewData { get; set; }
        ISAMCTL00025 Controller { set; get; }
        IList<TLMDTO00030> RmitIblRates { get; set; }

        void dgVRemitIblBr_DataBind();
        void Successful(string message);
        void Failure(string message);
    }
}
