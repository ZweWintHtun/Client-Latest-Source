using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00076 : IPresenter
    {
        ILOMVEW00076 LSBusinessCodeView { set; get; }
        IList<LOMDTO00076> GetAll();
        void Save(LOMDTO00076 entity);
        void Delete(IList<LOMDTO00076> itemList);
        LOMDTO00076 SelectByLSBusinessCode(string lsBusinessCode);
    }
    public interface ILOMVEW00076
    {
        string LSBusinessCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00076 ViewData { get; set; }
        LOMDTO00076 PreviousLSBusinessDto { get; set; }
        IList<LOMDTO00076> LSBusinessCodes { get; set; }
        ILOMCTL00076 Controller { get; set; }
        void Successful(string message);
        void Failure(string message);
    }
}
