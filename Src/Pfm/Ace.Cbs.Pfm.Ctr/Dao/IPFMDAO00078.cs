using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.DAO
{
    /// <summary>
    /// Solidarity DAO Interface
    /// </summary>
    public interface IPFMDAO00078 : IDataRepository<PFMORM00078>
    {       
        string SelectSolidarityCountNo();
        IList<PFMDTO00078> SelectByGroupNo(string groupNo);
        bool UpdateSolidarity(PFMDTO00078 solidarity);
    }
}
