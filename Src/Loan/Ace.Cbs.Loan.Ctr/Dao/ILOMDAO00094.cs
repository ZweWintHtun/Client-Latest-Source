using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00094 : IDataRepository<LOMVIW00094>
    {
        IList<LOMDTO00094> SelectAllByLoanType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string loanType);
        IList<LOMDTO00094> SelectAllByLoanTypeByBusinessType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string businessType, string loanType);
        IList<LOMDTO00094> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00094> SelectAllByBusinessType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string businessType);
    }
}
