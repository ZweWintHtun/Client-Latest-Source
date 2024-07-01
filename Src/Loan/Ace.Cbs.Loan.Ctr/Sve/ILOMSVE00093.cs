using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00093 : IBaseService
    {
        ILOMDAO00093 FarmLoanReportDAO { get; set; }

        IList<LOMDTO00093> SelectAllByLoanType(LOMDTO00093 dto);
        IList<LOMDTO00093> SelectAllByLoanTypeBySeasonType(LOMDTO00093 dto);
        IList<LOMDTO00093> SelectAllByLoanTypeByCropType(LOMDTO00093 dto);

        IList<LOMDTO00093> SelectAll(LOMDTO00093 dto);
        IList<LOMDTO00093> SelectAllBySeasonType(LOMDTO00093 dto);
        IList<LOMDTO00093> SelectAllByCropType(LOMDTO00093 dto);

        IList<LOMDTO00094> SelectAllLS(LOMDTO00093 dto);
        IList<LOMDTO00094> SelectAllLiveStockByLoanType(LOMDTO00093 dto);
        IList<LOMDTO00094> SelectAllByLoanTypeByBusinessType(LOMDTO00093 dto);
    }
}
