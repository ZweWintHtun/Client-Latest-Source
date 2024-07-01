using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System;

namespace Ace.Cbs.Pfm.Dao
{
    public class PFMDAO00021:DataRepository<PFMORM00021>,IPFMDAO00021
    {
        [Transaction(TransactionPropagation.Required)]
        public void DeleteOldData(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMORM00021.DeleteOldData");
            query.SetString("accountNo", accountNo);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateCustomerIDByAccountNo(string accountNo, string custID, int updateUserID, DateTime updateDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00021.UpdateCustIDByAccountNo");
            query.SetInt32("updatedUserId", updateUserID);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", updateDate);
            query.SetString("custId", custID);
            query.ExecuteUpdate();
        }
         
        [Transaction(TransactionPropagation.Required)]
        public void UpdateByUpdatedUser(string AccountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate)   //Added by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00021.UpdateByUpdatedUser");
            query.SetString("accountNo", AccountNo);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", Convert.ToInt32(updateUserID));
            query.SetDateTime("updateDate", updateDate);
            query.ExecuteUpdate();
        }
    }
}