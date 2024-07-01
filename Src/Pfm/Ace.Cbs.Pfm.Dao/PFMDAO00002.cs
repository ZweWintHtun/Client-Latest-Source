using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    /// <summary>
    /// CloseBal Dao
    /// </summary>
    public class PFMDAO00002 : DataRepository<PFMORM00002>, IPFMDAO00002
    {
        public PFMDTO00002 SelectCloseBalanceByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CloseBal.SelectCloseBalanceByAccountNo");
            query.SetString("accountNo", accountNo);
            PFMDTO00002 closebalanceDTO = query.UniqueResult<PFMDTO00002>();
            return closebalanceDTO == null ? null : closebalanceDTO;
        }

        public PFMDTO00002 SelectDataForLastWithdrawal(string accountNo,string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CloseBal.SelectDataForLastWithdrawal");
            query.SetString("accountNo", accountNo);
            query.SetString("branchCode", branchCode);
            PFMDTO00002 closebalanceDTO = query.UniqueResult<PFMDTO00002>();
            return closebalanceDTO == null ? null : closebalanceDTO;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool DeleteForLastWithdrawal(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("CloseBal.DeleteForLastWithdrawal");
            query.SetString("accountNo", accountNo);
            return query.ExecuteUpdate() > 0;
        }
    }
}