using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00020 : IBaseService
    {
        TLMDTO00018 isValidLoanNo(string loanNo, string sourceBr);    
        bool Update(string loanNo, string sourceBr, decimal quarterint, int updatedUserId);

      //  IList<bool> Update(string p, string p_2, decimal? nullable, int p_3);
    }
}
