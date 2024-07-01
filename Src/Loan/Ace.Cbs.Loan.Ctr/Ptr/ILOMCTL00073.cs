using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00073 : IPresenter
    {
        ILOMVEW00073 UMEntryView { set; get; }
        IList<LOMDTO00073> GetAll();
        void Save(LOMDTO00073 entity);
        void Delete(IList<LOMDTO00073> itemList);
    }

    public interface ILOMVEW00073
    {
        string UMCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00073 ViewData { get; set; }
        LOMDTO00073 PreviousUMDto { get; set; }
        IList<LOMDTO00073> UMList { get; set; }
        ILOMCTL00073 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
