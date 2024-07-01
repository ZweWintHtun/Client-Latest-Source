using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System;


namespace Ace.Cbs.Pfm.Ctr.Dao
{ 
    //faof interface
    public interface IPFMDAO00021:IDataRepository<PFMORM00021>

    {
        void UpdateCustomerIDByAccountNo(string accountNo, string custID, int updateUserID, DateTime updateDate);
    
        void DeleteOldData(string accountNo);

        void UpdateByUpdatedUser(string accountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate);   //Added by ASDA
    }
}