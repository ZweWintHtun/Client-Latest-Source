using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00300 : IPresenter
    {
        ILOMVEW00300 View { get; set; }
        void CalculatePenalFee();
    }

    public interface ILOMVEW00300
    {
        ILOMCTL00300 Controller { get; set; }

        DateTime CalculatedDate { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
