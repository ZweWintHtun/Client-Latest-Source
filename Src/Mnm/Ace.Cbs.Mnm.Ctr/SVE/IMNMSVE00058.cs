using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Sve
{
    public interface IMNMSVE00058
    {
        IList<PFMDTO00021> SelectFixedDepoistAll(DateTime sdate, DateTime edate, string cur, string acsign, string branchno, string status);
    }
}
