using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System;
using System.Collections.Generic;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00030 : IDataRepository<PFMORM00042>
    {
        IList<PFMDTO00042> SelectAll(string sourceBr);
        IList<PFMDTO00042> SelectDistinctACodeFromReportTLF(string dcode);        
    }    
}
