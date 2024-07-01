using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    // CustomerId Interface Dao
    public interface IPFMDAO00001: IDataRepository<PFMORM00001>
    {
        bool CheckExist( string nrc);
        IList<PFMDTO00001> SelectAll();
        PFMDTO00001 SelectByCustomerId(string customerid);
        PFMDTO00001 SelectTopCustomerId();
        PFMDTO00001 SelectLastCustomerId();
    //    IList<PFMDTO00001> SelectByCustomerSearchInfo(PFMDTO00001 customerIdDTO, int maxSearchRecordCounts);
        IList<PFMDTO00001> SelectByCustomerSearchInfo(PFMDTO00001 customerIdDTO);
        bool UpdateCloseAccount(string id, int updatedUserId);
        bool UpdateOpenAccount(string id, int updatedUserId);
        IList<PFMDTO00001> SelectListByCustId(IList<string> customerlist);
        int CountByCustomerSearchInfo(PFMDTO00001 custDTO);
        bool UpdateName(PFMDTO00001 custEntity);
        PFMDTO00001 SelectCustomerByCustID(string customerId);

        //PFMDTO00001 SelectCustomerInfoFromCAOFByAccountNo(string accountNo);

        bool UpdateOpenAccount_Minus(string id, int updatedUserId);
        PFMDTO00001 GetTownshipCode(string customerId);

        TownshipDTO SelectTownship(string townshipCode);

        //Added by ZMS For Budget End Flexible
        IList<PFMDTO00079> GetBLFInfoByStartDate(DateTime pDate, string sourceBr);

        //Added by ZMS for checking black list
        PFMDTO00080 CheckNRCForExternalBlackListCustomer(string nRC, string BranchCode);
    }
}