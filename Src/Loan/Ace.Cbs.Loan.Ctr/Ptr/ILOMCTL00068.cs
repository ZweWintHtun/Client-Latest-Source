using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00068 : IPresenter
    {
        ILOMVEW00068 HirePurchaseStockGroupEntryView { set; get; }
        IList<LOMDTO00068> GetAll();
        void Save(LOMDTO00068 entity);
        void Delete(IList<LOMDTO00068> itemList);
    }

    public interface ILOMVEW00068
    {
        string GroupCode { get;set; }
        string Description { get;set; }
        string PreFix { get; set; }
        string Status { get; set; }

        LOMDTO00068 ViewData { get; set; }
        LOMDTO00068 PreviousStockGroupDto { get; set; }
        IList<LOMDTO00068> StockGroupList { get; set; }
        ILOMCTL00068 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
