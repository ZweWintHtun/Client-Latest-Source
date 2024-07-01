using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00001 : IPresenter
    {
        ILOMVEW00001 BusinessCodeView { set; get; }
        IList<LOMDTO00001> GetAll();
        void Save(LOMDTO00001 entity);
        void Delete(IList<LOMDTO00001> itemList);
        LOMDTO00001 SelectByBusinessCode(string businessCode);
    }

    public interface ILOMVEW00001
    {
        string BusinessCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00001 ViewData { get; set; }
        LOMDTO00001 PreviousBusinessDto { get; set; }
        IList<LOMDTO00001> BusinessCodes { get; set; }

        ILOMCTL00001 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}
