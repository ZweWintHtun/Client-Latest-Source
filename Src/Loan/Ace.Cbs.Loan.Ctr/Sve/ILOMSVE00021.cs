using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
  public interface ILOMSVE00021:IBaseService
    {
      LOMDTO00013 SelectLegalInfoByLoanNo(string Lno, string sourceBr);
      bool Update(string loanNo, string sourceBr,decimal intRate,string legalawer, int updatedUserId);
    }
}
