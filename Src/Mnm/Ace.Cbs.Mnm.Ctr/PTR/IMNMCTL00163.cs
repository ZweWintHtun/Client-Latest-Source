using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.PTR
{
    public interface IMNMCTL00163 : IPresenter
    {
        IMNMVEW00163 View { get; set; }
        void Print();
    }

    public interface IMNMVEW00163
    {
        IMNMCTL00163 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        string Township { get; set; }
        string ParentFormName { get; set; }
    }

}
