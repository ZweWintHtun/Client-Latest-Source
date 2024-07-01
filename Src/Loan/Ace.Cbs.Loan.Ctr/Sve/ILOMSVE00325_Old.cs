using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    //Added by HWKO (28-Jul-2017)
    public interface ILOMSVE00325 : IBaseService
    {
        IList<PFMDTO00072> SelectPersonalLoanInfoByloanNoandSourcebr(string plno, string sourcebr);
        string Save_PersonalLoansVoucher(string plno, string sourcebr);
    }
}
