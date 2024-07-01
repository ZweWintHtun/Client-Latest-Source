using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
    /// <summary>
    /// Land_Building Interface DAO
    /// </summary>
    public interface ILOMDAO00015 : IDataRepository<LOMORM00015>
    {
        LOMDTO00015 SelectLand_BuildingInfoByLoanNoAndSourceBr(string lno, string sourcebr);
        bool UpdateLand_BuildingInfoByLoanNoAndSourceBr(LOMDTO00015 loanDto);
    }
}
