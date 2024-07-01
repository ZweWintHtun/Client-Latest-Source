using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00081 : BaseService, IMNMSVE00081
    {
        IMNMDAO00081 InterestOutstanding { get; set; }

        public IList<MNMDTO00081> SelectFreceipt(string branchCode)
        {
            IList<MNMDTO00081> DTOList = InterestOutstanding.SelectFreceipt(branchCode);

            return DTOList;
        }
    }
}
