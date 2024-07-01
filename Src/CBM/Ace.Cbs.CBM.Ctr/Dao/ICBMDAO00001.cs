using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;

namespace Ace.Cbs.CBM.Ctr.Dao
{
    // Cash In Hand Interface Dao
    public interface ICBMDAO00001 : IDataRepository<PFMORM00042>
    {
        IList<PFMDTO00042> GetAll_CashInHandPosition(DateTime date,string Currency);
        PFMDTO00042 GetAll_CashFlowData_CBM(DateTime date, string Currency);
        IList<PFMDTO00042> GetAll_DailyPosition_CBM(DateTime date, string Currency);
        IList<PFMDTO00042> GetAll_FinancialStatement_CBM(DateTime date, string Currency);
        IList<PFMDTO00042> GetAll_DailyImprovement_CBM(DateTime date, int budgetMonth, string Currency);
        IList<PFMDTO00042> GetAll_DailyProgress_CBM(DateTime date, int budgetMonth, string Currency);
        PFMDTO00042 Get_Liquidity_Ratio_CBM(DateTime date, string Currency);
    }
}