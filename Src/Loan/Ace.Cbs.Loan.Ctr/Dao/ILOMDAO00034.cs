using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00034 : IDataRepository<LOMVIW00034>
    {
        IList<LOMDTO00034> SelectLoanListing(string loans, DateTime startDate, DateTime endDate, string sourceBranchCode, string cur);
        IList<LOMDTO00034> SelectLoanListingAll(DateTime startDate, DateTime endDate, string sourceBranchCode, string cur);
    }
}
