using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00018
    {
        IPFMDAO00010 CustPhotoDAO { get; set; }
        PFMDTO00010 CusPhotoSelectById(string Id);
        

    }
}