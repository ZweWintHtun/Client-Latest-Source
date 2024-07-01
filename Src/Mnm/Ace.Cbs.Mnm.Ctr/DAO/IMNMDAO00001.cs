using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    public interface IMNMDAO00001 : IDataRepository<MNMORM00001>
    {
        string SelectbyYearpost(string name, string sourceBr);
        bool UpdateStatus(DateTime datetime, string postingname, string sourceBr, int updatedUserId);
        IList<MNMDTO00001> SelectPostDateByPostName(string sourceBr);
        bool UpdateStatusByBranchCode(DateTime datetime, string postingname, string sourceBr, int updatedUserId);
    }
    
}
