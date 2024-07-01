using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00081 : IDataRepository<PFMORM00032>
    {
        IList<MNMDTO00081> SelectFreceipt(string branchCode);
    }
}
