using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00069 : IPresenter
    {
        ILOMVEW00069 HirePurchaseStockSubItemCodeRegisterationView { set; get; }
        IList<LOMDTO00069> GetAll();
        void Save(LOMDTO00069 entity);
        void Delete(IList<LOMDTO00069> itemList);
    }

    public interface ILOMVEW00069
    {
        string GroupCode { get; set; }
        string Description { get; set; }
        string SubCode { get; set; }
        string Status { get; set; }

        LOMDTO00069 ViewData { get; set; }
        LOMDTO00069 PreviousStockItemDto { get; set; }
        IList<LOMDTO00069> StockItemList { get; set; }
        ILOMCTL00069 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
