using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00024
    {
        //IPFMDAO00024 coaDAO { get; set; }
        ChargeOfAccountDTO SelectACode(string olsAccountNo, string sourceBranch);
    }
}