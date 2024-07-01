using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    public interface ILOMDAO00079 : IDataRepository<LOMORM00079>
    {
        LOMDTO00079 SelectPersonalGuaranteeInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdatePGOfFarmLoanByLnoAndSourceBr(LOMDTO00079 pgDto);
    }
}
