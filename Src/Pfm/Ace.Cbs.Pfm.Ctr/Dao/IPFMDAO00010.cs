using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00010 : IDataRepository<PFMORM00010>
    {
        PFMDTO00010 CustPhotoSelectById(string CusId);
        bool UpdateCustPhoto(PFMDTO00010 custphotoEntity);
        bool DeleteCustPhoto(PFMDTO00010 custphotoEntity);
    }
}