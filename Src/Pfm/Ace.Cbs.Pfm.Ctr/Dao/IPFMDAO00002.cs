using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    //CloseBal Interface Dao
    public interface IPFMDAO00002 : IDataRepository<PFMORM00002>
    {
        PFMDTO00002 SelectCloseBalanceByAccountNo(string accountNo);
        PFMDTO00002 SelectDataForLastWithdrawal(string accountNo, string branchCode);
        bool DeleteForLastWithdrawal(string accountNo);
    }
}