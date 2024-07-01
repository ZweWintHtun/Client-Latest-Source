using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.PTR
{
    public interface IMNMCTL00165 : IPresenter
    {
        IMNMVEW00165 View { get; set; }

        void ClearCustomErrorMessage();
        void Print();
        bool Validate_Form();
    }

    public interface IMNMVEW00165
    {
        IMNMCTL00165 Controller { get; set; }

        string BranchCode { get; set; }
        string CurrencyNo { get; set; }
        DateTime SelectedDate { get; set; }
        string Title { get; set; }
    }
}
