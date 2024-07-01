using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00231 : IPresenter
    {
        ILOMVEW00231 View { get; set; }
        void ExportToExcel(string rptName, DateTime date, string currency, string sourceBr, decimal curUnits, string curUnitsTitle);
    }
    public interface ILOMVEW00231
    {
        ILOMCTL00231 Controller { get; set; }
        string Currency { get; set; }
        string SourceBr { get; set; }

    }
}
