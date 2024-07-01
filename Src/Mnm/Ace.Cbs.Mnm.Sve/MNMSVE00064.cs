using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd ;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00064 : BaseService , IMNMSVE00064
    {
        IMNMDAO00007 PrevSiDAO { get; set; }
        IList<MNMDTO00007> PrintDataList { get; set; }

        public IList<MNMDTO00007> GetPrintDataList(string budgetYear, string sourceBr)
        {
            return PrintDataList = PrevSiDAO.SelectUnionAllSI(budgetYear, sourceBr);
        }
    }
}
