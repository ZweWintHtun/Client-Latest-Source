using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00102 : IBaseService
    {
        IList<LOMDTO00102> GetLoanRecordList(string townshipCode, DateTime startDate, DateTime endDate, string type);
    }
}
