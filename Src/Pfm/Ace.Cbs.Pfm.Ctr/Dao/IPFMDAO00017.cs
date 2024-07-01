using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    // Caof interface dao
    public interface IPFMDAO00017 : IDataRepository<PFMORM00017> 
    {
        bool UpdateCloseDate(string accountNo, DateTime closeDate, int updatedUserId);
        void DeleteOldData(string accountNo);
        void UpdateCustomerIDByAccountNo(string accountNo,string custID,string name,string business,int updateUserID,DateTime updateDate);
        void UpdateByUpdatedUser(string AccountNo, string sourceBr, Nullable<int> updateUserID, DateTime updateDate); //added by ASDA
        IList<PFMDTO00017> SelectCAOFData(string accountNo);

        PFMDTO00080 CheckBlackListCustomerByCustId(string custId, string branchCode);
    }
}