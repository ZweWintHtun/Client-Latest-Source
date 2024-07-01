using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00093 : IDataRepository<LOMVIW00093>
    {
        IList<LOMDTO00093> SelectAllByLoanType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string loanType);
        IList<LOMDTO00093> SelectAllByLoanTypeBySeasonType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string seasonType, string loanType);
        IList<LOMDTO00093> SelectAllByLoanTypeByCropType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string cropType, string loanType);
        
        IList<LOMDTO00093> SelectAll(DateTime startDate, DateTime endDate, string cur, string sourceBr);
        IList<LOMDTO00093> SelectAllBySeasonType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string seasonType);
        IList<LOMDTO00093> SelectAllByCropType(DateTime startDate, DateTime endDate, string cur, string sourceBr, string cropType);
    }
}
