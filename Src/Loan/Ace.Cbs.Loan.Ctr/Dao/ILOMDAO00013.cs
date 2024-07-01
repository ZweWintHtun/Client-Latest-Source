using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Dao
{
   public interface ILOMDAO00013 :IDataRepository<LOMORM00013>    
    {
       IList<LOMDTO00013> SelectLegalInfoByLoanNo(string lno, string sourceBr);
       bool UpdateIntRate(decimal intRate, string loanNo, string sourceBr, int updatedUserId);
       IList<LOMDTO00013> SelectAllByLoanNo(string lno, string sourceBr); //LOMSVE00016
       bool UpdateLegalForReleaseCase(string lno, string sourceBr, int updatedUserId);  //LOMSVE00016
       IList<LOMDTO00013> SelectLegalInfoByCloseDateNull(string lno, string sourceBr); //LOMSVE00027 (LegalLoanRepay)
       bool UpateLegalForLoanRepay(decimal currentBalance, string voucherNumber, string acctNo, string lno, string sourceBr, int currentUserId);  //LOMSVE00027(LegalLoanRepay)
    }
}
