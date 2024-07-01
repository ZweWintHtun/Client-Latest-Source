using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    //Cheque -> Cheque Issue (Book)
    public interface IPFMSVE00013 : IBaseService
    {
        IPFMDAO00006 ChequeDAO { get; set; }
        
        void Save(PFMDTO00006 entity);
    }
}