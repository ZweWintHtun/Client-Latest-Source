using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using System.Collections.Generic;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    
    //StopCheque Dao Contract
    public interface IPFMDAO00011 : IDataRepository<PFMORM00011>
    {
        IList<PFMDTO00011> SelectSChequeData(string accountNo);
        IList<PFMDTO00011> SelectSChequeDataByAccount(string accountNo, string branch);
        IList<PFMDTO00011> SelectSChequeDataByDate(DateTime startDate,DateTime endDate,string branch);
        IList<PFMDTO00011> GetSChequeInfoByChequeBookNo(string accountNo, string checkBookNo, string branch);
        bool UpdateSChequeData(string accountNo, string checkBookNo, string startSerialNo, string endSerialNo, int updatedUserId, DateTime updatedDate);
    }
}