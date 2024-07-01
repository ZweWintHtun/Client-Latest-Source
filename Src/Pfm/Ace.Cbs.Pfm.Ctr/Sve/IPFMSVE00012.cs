using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;


namespace Ace.Cbs.Pfm.Ctr.Sve
{
    /// <summary>
    /// Link Account Service InterfAce.
    /// </summary>
    public interface IPFMSVE00012
    {
        IPFMDAO00029 LinkAccountDAO { get; set; }
        IPFMDAO00028 CledgerDAO { get; set; }
        IPFMDAO00001 CustomerIdDAO { get; set; }
        string Save(PFMDTO00029 entity);        
        IList<PFMDTO00017> GetCAOFByAccountNumber(string accountNumber,string branchCode);
        IList<PFMDTO00016> GetSAOFByAccountNumber(string accountNumber,string branchCode);
        
        
    }
}