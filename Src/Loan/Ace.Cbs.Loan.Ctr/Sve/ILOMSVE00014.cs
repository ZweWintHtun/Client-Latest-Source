using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00014 : IBaseService
    {
        TLMDTO00018 isValidLoanNo(string lno, string sourceBr);
        bool UpdateLoansForNPLCase(string lno, string userName, string sourceBr, int updatedUserId);
    }
}
