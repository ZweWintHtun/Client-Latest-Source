using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface  ILOMCTL00426 :IPresenter
    {
        ILOMVEW00426 View { get; set; }
        void CallingForm ();
    }
    public interface ILOMVEW00426 
    {
        ILOMCTL00426 Controller { get; set; }
        int indexOfCombo { get; set; } 
    }
}
