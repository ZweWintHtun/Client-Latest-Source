using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00009 : IDataRepository<PFMORM00009>
    {
        bool CheckExist(string code, string desp, System.DateTime dATE_TIME, bool lASTMODIFY, decimal rate, bool isEdit);
        IList<PFMDTO00009> SelectAll();
        PFMDTO00009 SelectByCode(string code);
        PFMDTO00009 SelectByRateCode(string code);

        bool UpdateRate(PFMDTO00009 entity);
        bool DeleteRate(PFMDTO00009 entity);
    }
}