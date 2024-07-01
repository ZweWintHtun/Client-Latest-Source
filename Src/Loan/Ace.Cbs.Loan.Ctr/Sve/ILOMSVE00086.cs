using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Ix.Core.DataModel;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00086 : IBaseService
    {
        string SaveServerAndServerClient(LOMDTO00086 entity);
       IList<LOMDTO00099> GetLoanRecordByLoanNo(string eno);
        void UpdateLoanRecord(LOMDTO00086 entity, IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(string eno);
        int CheckLoanAccNo(string acctNo);
    }
}
