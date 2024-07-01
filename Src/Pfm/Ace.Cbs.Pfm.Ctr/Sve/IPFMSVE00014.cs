using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Pfm.Ctr.Sve
{
    //Stop Cheque Service Contract
    
    public interface IPFMSVE00014
    {
        void Save(PFMDTO00011 entity);
        IPFMDAO00011 StopChequeDAO {get;set;}
        IPFMDAO00001 CustomerIdDAO { get; set; }
        IPFMDAO00006 ChequeDAO { get; set; }
        IList<PFMDTO00001> GetCustomerListByAccountNumber(string accountNumber);
        bool CheckEndChequeNo(string accountNo, string chequeNo, string endNo, string branch);
        bool CheckStartChequeNo(string accountNo, string chequeNo, string startNo, string branch);
    }
}