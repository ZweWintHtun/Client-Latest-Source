using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00012 : IBaseService
    {
        TLMDTO00018 isValidLoanNo(string lno, string sourceBr);        
        //PFMDTO00001 GetAccountInformation(string AccountNo);
        void SaveODLimitChangeData(TLMDTO00018 odLimitChangeEntity);
    }
}
