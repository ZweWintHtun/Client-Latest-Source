using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
   public interface ILOMDAO00102 : IDataRepository<LOMDTO00102>
    {
       IList<LOMDTO00102> GetLoanRecordList(string townshipCode, DateTime startDate, DateTime endDate, string type);
    }
}
