using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using System;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXDAO00005:IDataRepository<TLMORM00015>
    {
        int SelectMaxId();
        string InsertCashDeno_MultipleWithdrawAndDepositReversal(TLMORM00015 CashDenoORM);
    }
}
