using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00415 : IPresenter
    {
        ILOMVEW00415 PersonalLoanProductCodeEntryView { set; get; }
        IList<LOMDTO00415> GetAll();
        IList<LOMDTO00415> SelectAll_ACode();
        void Save(LOMDTO00415 entity);
        void Delete(IList<LOMDTO00415> itemList);
    }

    public interface ILOMVEW00415
    {
        string ProductCode { get; set; }
        string Description { get; set; }
        string RelatedGLACode { get; set; }
        string Status { get; set; }

        LOMDTO00415 ViewData { get; set; }
        LOMDTO00415 PreviousProductCodeDto { get; set; }
        IList<LOMDTO00415> ProductCodeList { get; set; }
        ILOMCTL00415 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
