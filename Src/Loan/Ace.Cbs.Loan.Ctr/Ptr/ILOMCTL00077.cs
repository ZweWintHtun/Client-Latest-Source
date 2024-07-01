using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00077 : IPresenter
    {
        ILOMVEW00077 LSProductTypeItemSetupView { set; get; }
        IList<LOMDTO00077> GetAll();
        void Save(LOMDTO00077 entity);
        void Delete(IList<LOMDTO00077> itemList);
    }

    public interface ILOMVEW00077
    {
        string ProductCode { get; set; }
        string LSBusinessCode { get; set; }
        string UMCode { get; set; }
        int DurationMonths { get; set; }
        string Status { get; set; }

        LOMDTO00077 ViewData { get; set; }
        LOMDTO00077 PreviousLSProductTypeItemDto { get; set; }
        IList<LOMDTO00077> LSProductTypeItemList { get; set; }
        ILOMCTL00077 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
