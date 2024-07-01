using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00030 : IBaseService
    {
        TLMDTO00018 GetLoanInformationForRepaymentEdit(string lno, string sourceBr);
        TLMDTO00018 RepayLoanEdit(TLMDTO00018 loanDto,bool fullSettlement, string lno, string accountNo, string repayNo, decimal repaymentAmount, string userNo, int userId, decimal newRepaymenAmount, string sourceBr); 
        
    }
}
