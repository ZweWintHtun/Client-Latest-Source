using System;
using Ace.Cbs.Loan.Ctr.Ptr;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00007 : IPresenter
    
    {
        ILOMVEW00007 StockNoView { set; get; }
        IList<LOMDTO00009> GetAll();
        void Save(LOMDTO00009 entity);
        void Delete(IList<LOMDTO00009> itemList);
        LOMDTO00009 SelectByCode(string stockNo);
 
    }


    public interface ILOMVEW00007
    {
        string StockNo { get; set; }
        string Name { get; set; }
        string Status { get; set; }

        LOMDTO00009 ViewData { get; set; }
        LOMDTO00009 PreviousStockNoDto { get; set; }
        IList<LOMDTO00009> StockCode { get; set; }
        ILOMCTL00007 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}
