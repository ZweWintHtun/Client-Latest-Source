using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    //CustomerId Service Interface
    public interface IPFMSVE00004 
    {
        IPFMDAO00001 CustomerIdDAO { get; set; }
        string Save(PFMDTO00001 entity);
        void Update(PFMDTO00001 custentity, PFMDTO00010 custphotoentity);
        IList<PFMDTO00001> SelectAll();
        PFMDTO00001 SelectByCustomerId(string customerid);
        PFMDTO00001 SelectTopCustomerId();
        PFMDTO00001 SelectLastCustomerId();
        PFMDTO00001 GetCustomerById(string customerid);
        IList<PFMDTO00001> GetRange(string customerid, string click, int rows);

        //Added by ZMS to check black list external customer
        PFMDTO00080 CheckNRCForExternalBlackListCustomer(string nRC, string BranchCode);
    }
}