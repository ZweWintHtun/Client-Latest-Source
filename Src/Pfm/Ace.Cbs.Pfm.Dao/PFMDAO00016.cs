using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Pfm.Dao
{
    /// <summary>
    /// Saof Dao
    /// </summary>
    public class PFMDAO00016 : DataRepository<PFMORM00016>, IPFMDAO00016
    {
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseDate(string AccountNo, Nullable<DateTime> CloseDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00016.UpdateCloseDate");
            query.SetString("accountNo", AccountNo);
            query.SetDateTime("closeDate", CloseDate.Value);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteOldData(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00016.DeleteOldData");
            query.SetString("accountNo", accountNo);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateCustomerIDByAccountNo(string accountNo, string custID, int updateUserID, DateTime updateDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00016.UpdateCustIDByAccountNo");
            query.SetInt32("updatedUserId", updateUserID);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", updateDate);
            query.SetString("custId", custID);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateByUpdatedUser(string AccountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate)  //Added by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00016.UpdateByUpdatedUser");

            query.SetString("accountNo", AccountNo);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", Convert.ToInt32(updateUserID));
            query.SetDateTime("updateDate", updateDate);
            query.ExecuteUpdate();
        }
               
    }
}