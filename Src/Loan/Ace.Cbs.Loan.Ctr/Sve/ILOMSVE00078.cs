using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00078 : IBaseService
    {
        ILOMDAO00078 FarmLoanDAO { get; set; }
        IList<PFMDTO00072> IsValidForLoanAcctno(string acctno);
        IList<LOMDTO00078> SelectByGroupNo(string groupNo);
        LOMDTO00078 SelectFarmLoanInfoByLnoAndSourceBr(string lno, string sourcebr);

        string Save_LandAndBuilding(LOMDTO00015 land_BuildingDto, LOMDTO00085 farmliDto, LOMDTO00300 farmLoanPenalFeeDto, LOMDTO00078 farmLoanDto, string BranchCode);
        string Save_PersonalGuarantee(LOMDTO00015 land_BuildingDto, LOMDTO00079 personal_GuaranteeDto, LOMDTO00085 farmliDto, LOMDTO00300 farmLoanPenalFeeDto, LOMDTO00078 farmLoanDto,string BranchCode);
        LOMDTO00078 isValidLoanNo(string loanNo, string sourceBr);
    }
}
