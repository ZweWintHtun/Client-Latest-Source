using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00444
    {

        ILOMVEW00444 View { get; set; }
        IList<LOMDTO00444> GetLimitExtendList(DateTime Date, string SortBy);
        void Print(DateTime date, string sortby);
    }

    public interface ILOMVEW00444
    {
        ILOMCTL00444 Controller { get; set; }
        string SourceBr { get; set; }
        DateTime Date { get; set; }
        string rptName { get; set; }
    }
}
