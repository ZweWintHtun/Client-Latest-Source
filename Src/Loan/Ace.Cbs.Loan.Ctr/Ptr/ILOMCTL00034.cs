using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00034 :IPresenter
    {
        ILOMVEW00034 View { get; set; }
        void Print(string loans, string formname);
    }
    public interface ILOMVEW00034
    {
        ILOMCTL00034 Controller { get; set; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string SourceBranch { get; set; }
        string Currency { get; set; }
        //string ParentFormName { get; set; }
    }
}
