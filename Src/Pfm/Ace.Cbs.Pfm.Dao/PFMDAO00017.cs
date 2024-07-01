using System;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using NHibernate.Transform;

namespace Ace.Cbs.Pfm.Dao
{
    // Caof dao
    public class PFMDAO00017 : DataRepository<PFMORM00017>, IPFMDAO00017
    {
        #region IPFMDAO00017 Members

        // Update close date in caof table.
        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseDate(string accountNo, DateTime closeDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00017.UpdateCloseDate");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("closeDate", closeDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);

            return query.ExecuteUpdate() > 0;
        }



        [Transaction(TransactionPropagation.Required)]
        public void DeleteOldData(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00017.DeleteOldData");
            query.SetString("accountNo", accountNo);
            query.ExecuteUpdate();
        }

        
        [Transaction(TransactionPropagation.Required)]
        public void UpdateCustomerIDByAccountNo(string accountNo, string custID,string name,string business, int updateUserID, DateTime updateDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00017.UpdateCustIDByAccountNo");
            query.SetInt32("updatedUserId",updateUserID);            
            query.SetString("accountNo",accountNo);
            query.SetDateTime("updatedDate", updateDate);
            query.SetString("custId",custID);
            if (string.IsNullOrEmpty(name)) name = null;
            query.SetString("name", name);
            if (string.IsNullOrEmpty(business)) business = null;
            query.SetString("business", business);
            query.ExecuteUpdate();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateByUpdatedUser(string AccountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate)  //added by ASDA
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00017.UpdateByUpdatedUser");

            query.SetString("accountNo", AccountNo);
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("updatedUserId", Convert.ToInt32(updateUserID));
            query.SetDateTime("updateDate", updateDate);
            query.ExecuteUpdate();
        }

        public IList<PFMDTO00017> SelectCAOFData(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00017.SelectCustDataFromLoanAccountClose");
            query.SetString("accountNumber", accountNo);
            return query.List<PFMDTO00017>();
        }

        public PFMDTO00080 CheckBlackListCustomerByCustId(string custId, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BlackListsCustomerSelectByCustId");
            query.SetString("custId", custId);
            query.SetString("branchCode", branchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00080)));
            return query.UniqueResult<PFMDTO00080>();
        }
        #endregion
    }
}