using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// SAOF Dao Interface
    /// </summary>
    public interface IPFMDAO00016 : IDataRepository<PFMORM00016>
    {
        bool UpdateCloseDate(string AccountNo, Nullable<DateTime> CloseDate, int updatedUserId);


        void DeleteOldData(string accountNo);

        //void DeleteOldData(string accountNo);

        void UpdateCustomerIDByAccountNo(string accountNo, string custID, int updateUserID, DateTime updateDate);

        void UpdateByUpdatedUser(string accountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate);   //Added by ASDA
    }
}