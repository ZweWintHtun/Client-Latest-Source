using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// Hypothecation Interface DAO
    /// </summary>
    public interface ILOMDAO00017 : IDataRepository<LOMORM00017>
    {
        LOMDTO00017 SelectHypothecationInfoByLoanNoandSourcebr(string lno, string sourcebr);
        bool UpdateHypothecationInfoByLoanNoAndSourceBr(LOMDTO00017 hypothecationDto);
    }
}
