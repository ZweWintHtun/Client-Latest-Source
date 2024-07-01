using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00046 : IDataRepository<TLMVIW000A9>
    {
        //IList<PFMDTO00042> BankSatatementByDepositAmount(int workstation, string accountNo, DateTime year, DateTime month);
        //IList<PFMDTO00042> BankSatatementByWithdrawAmount(string workstation, string accountNo, DateTime year, DateTime month);
        IList<PFMDTO00017> SelectCustID(string accountNo);
        IList<PFMDTO00017> SelectSCustID(string accountNo);
        PFMDTO00001 SelectCustInfoByCustID(string custID);
        TownshipDTO SelectTownship(string townshipCode);
        PFMDTO00028 SelectAccountSign(string accountNo, string sourceBr);
    }
}
