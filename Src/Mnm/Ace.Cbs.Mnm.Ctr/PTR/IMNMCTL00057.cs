using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00057 : IPresenter
    {
        IMNMVEW00057 View { get; set; }
        void Print();
        bool Validate_Form();
        void ClearCustomErrorMessage();
    }
    public interface IMNMVEW00057
    {
        IMNMCTL00057 Controller { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string FormName { get; set; }       
    }
}
