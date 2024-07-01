using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00034 :IBaseService
    {
        //IList<LOMDTO00034> GetReportData(LOMDTO00034 dto, bool IsByloan);
        //IList<LOMDTO00034> GetReportData(LOMDTO00034 dto);
        IList<LOMDTO00034> SelectLoanListing(string loans, DateTime startDate, DateTime endDate, string sourceBranchCode, string cur);
        IList<LOMDTO00034> SelectLoanListingAll(DateTime startDate, DateTime endDate, string sourceBranchCode, string cur);
        IList<LOMDTO00204> GetBLInfoListingByDateRange(DateTime startDate, DateTime endDate, string sourceBranchCode,string businessType);
    }
}
