using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00005
    {
        IPFMDAO00001 CustomerIdDAO { set; }
        IList<PFMDTO00001> GetList();
        IList<PFMDTO00001> GetAll();
        PFMDTO00074 SelectByCustomerSearchInfo(PFMDTO00001 customerIdDTO);
    }
}