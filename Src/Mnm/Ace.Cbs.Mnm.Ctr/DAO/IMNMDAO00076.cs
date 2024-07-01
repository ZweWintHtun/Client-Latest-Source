using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00076 : IDataRepository<MNMVIW00076>
    {
        IList<MNMDTO00076> SelectPoNo(string SourceBr);
    }
}
