
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00041 : IDataRepository<PFMORM00041>
    {
        bool UpdateDenoStatusBySourceBr(string sourceBr, int updatedUserId);
    }
}