using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00009:IBaseService
    {
        TLMDTO00018 isValidLoanNo(string loanNo, string sourceBr,string formName);
        TCMDTO00045 GetAccountNoInformation(string loanNo,string accountNo, string sourceBr, string formName, string month1);
        void Save(TCMDTO00045 dto, string formName);
        
    }
}
