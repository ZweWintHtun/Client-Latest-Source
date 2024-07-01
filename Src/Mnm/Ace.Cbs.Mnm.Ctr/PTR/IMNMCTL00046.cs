using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using System.Drawing;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00046 : IPresenter
    {
        IMNMVEW00046 View { get; set; }
        bool Print();
        bool Validate_Form();
        void ViewReport(IList<PFMDTO00001> AccountList, string name);
        //void ViewReportbyAccountno(string accountno, string month, string formname);
    }

    public interface IMNMVEW00046
    {
        IMNMCTL00046 Controller { get; set; }
        
        IList<PFMDTO00001> DTOList { get; set; }
        string FormName { get; set; }
        DateTime CurrentDate { get; set; }
        string AccountNumber { get; set; }        
        int Year { get; set; }
        int Month { get; set; }
    }
}
