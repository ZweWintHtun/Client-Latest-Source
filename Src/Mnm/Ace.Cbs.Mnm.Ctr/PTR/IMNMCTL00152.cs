using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using System.Drawing;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00152 : IPresenter
    {
        IMNMVEW00152 View { get; set; }
        void Print(string status);
        bool Validate_Form();
        void ClearCustomErrorMessage();   

    }

    public interface IMNMVEW00152
    {
        IMNMCTL00152 Controller { get; set; }
        string CurrencyCode { get; set; }
        string ReportFormName { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
