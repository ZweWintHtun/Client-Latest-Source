using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00072 : IPresenter
    {
        ILOMVEW00072 CropTypeEntryView { set; get; }
        IList<LOMDTO00072> GetAll();
        void Save(LOMDTO00072 entity);
        void Delete(IList<LOMDTO00072> itemList);
    }

    public interface ILOMVEW00072
    {
        string CropCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00072 ViewData { get; set; }
        LOMDTO00072 PreviousCropTypeDto { get; set; }
        IList<LOMDTO00072> CropTypeList { get; set; }
        ILOMCTL00072 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
