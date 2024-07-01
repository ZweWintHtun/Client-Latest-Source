using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    //LinkAccount (LinkAC)
    public interface IPFMDAO00029 : IDataRepository<PFMORM00029>
    {
        bool HasAlreadyLinkAccount(string currentAccountNo, string savingAccountNo);
        PFMDTO00029 SelectLinkAmount(string currentAccountNo, string savingAccountNo);

    }
}