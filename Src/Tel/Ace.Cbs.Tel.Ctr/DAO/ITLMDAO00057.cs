using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
   public interface ITLMDAO00057 : IDataRepository<TLMVIW00015>
    {
       //IList<TLMDTO00017> SelectDrawingRegisterOutstanding();
       IList<TLMDTO00017> SelectDrawingRegisterOutstanding(string sourceBr); //edited with sourcebr
       IList<TLMDTO00017> SelectDrawingRegisterOutstandingByIncomeOutstand(string sourceBr);  //edited with sourcebr
       IList<TLMDTO00017> SelectDrawingRegisterOutstandingByDrawingAmountOutstand(string sourceBr); //edited with sourcebr
    }
}
