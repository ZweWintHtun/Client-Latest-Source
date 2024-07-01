using System;
using Ace.Cbs.Loan.Ctr.Ptr;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00008 : IPresenter
    {
        ILOMVEW00008 KStockNoView { set; get; }
        IList<LOMDTO00010> GetAll();
        void Save(LOMDTO00010 entity);
        void Delete(IList<LOMDTO00010> itemList);
        LOMDTO00010 SelectByCode(string kstockNo);

    }


    public interface ILOMVEW00008
    {
        string KStockNo { get; set; }
        string Desp { get; set; }
        string Status { get; set; }

        LOMDTO00010 ViewData { get; set; }
        LOMDTO00010 PreviousKStockNoDto { get; set; }
        IList<LOMDTO00010> KStockCode { get; set; }
        ILOMCTL00008 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }


}
