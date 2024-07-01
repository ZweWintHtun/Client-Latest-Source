using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00021
    {
        //IPFMDAO00024 COADAO { get; set; }
        ChargeOfAccountDTO SelectACode(string aCode, string sourceBranchCode);
        PFMDTO00028 SelectAccountNoByCustomerId(string accountNo);
        IList<PFMDTO00016> GetSAOFByAccountNumber(string accountNumber);
        PFMDTO00001 GetCustomerByAccountNumber(string accountNumber);
    }
}