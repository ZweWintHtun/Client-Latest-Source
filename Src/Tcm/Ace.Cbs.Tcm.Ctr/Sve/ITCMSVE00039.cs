using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
    public interface ITCMSVE00039:IBaseService
    {
        IList<PFMDTO00006> GetIssuedChequeData(PFMDTO00042 data);
        IList<PFMDTO00011> GetStoppedChequeData(PFMDTO00042 data);
        IList<PFMDTO00014> GetPrintedChequeData(PFMDTO00042 data);
        bool CheckIsSavingAccountNo(string accountNo, string sourcebr);
        void CheckingChequeBookNo(string accountNo, string sourcebr);
    }
}
