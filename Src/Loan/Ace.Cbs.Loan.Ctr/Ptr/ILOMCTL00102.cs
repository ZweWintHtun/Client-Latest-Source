using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using System.Data;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00102 : IPresenter
    {
        ILOMVEW00102 View { get; set; }
        void Print();
        DataSet PrintExel_New(string type);
    }

    public interface ILOMVEW00102
    {
        ILOMCTL00102 Controller { get; set; }
        string townshipCode { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        string LoanType { get; set; }
        string ParentFormName { get; set; }
    }
}
