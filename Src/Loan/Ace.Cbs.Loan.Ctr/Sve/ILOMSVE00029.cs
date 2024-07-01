using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00029 : IBaseService
    {
        IList<PFMDTO00001> SelectByAccountNumber(string accountNo);
        //bool DebitInformationCheckingAndLink(TLMDTO00038 transferEntity);
        string SaveSpecialTransfer(IList<TLMDTO00038> transferCollection);
    }
}
