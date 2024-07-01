using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00035 : IBaseService
    {
        IList<LOMDTO00035> SelectODDataByLoansType(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectAllODData(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectAllDataByLoansType(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectAllData(LOMDTO00035 dto);
        IList<LOMDTO00035> SelectAllLoansDailyPositionByCur(LOMDTO00035 dto);
    }
}
