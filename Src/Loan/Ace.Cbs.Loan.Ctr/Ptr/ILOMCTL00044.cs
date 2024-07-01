using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00044 : IPresenter
    {
        ILOMVEW00044 View { get; set; }
        void CalculateOD();
    }

    public interface ILOMVEW00044
    {
        ILOMCTL00044 Controller { get; set; }

        DateTime InterestCalculationDate { get; set; }
    }
}
