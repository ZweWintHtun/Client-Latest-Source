using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

//COA
namespace Ace.Cbs.Pfm.Ctr.Dao
{
    public interface IPFMDAO00024 : IDataRepository<ChargeOfAccount>
    {
        //PFMDTO00024 SelectACode(string aCode, string sourceBranchCode);
        //PFMDTO00024 SelectCoACode(string aCode, string sourceBranchCode);
        //PFMDTO00024 COASelectAccountName(string accountName, string accountNo);
        //PFMDTO00024 GetDescriptionForPOReceipt(string acode);

        //bool CheckExist(string aCode, string aCName, string dCODE, string aCType, bool isEdit);
        //IList<PFMDTO00024> SelectAll();
        //PFMDTO00024 SelectByACode(string aCode);
        //IList<PFMDTO00027> SelectCurrency();

        ChargeOfAccountDTO SelectByCode(string aCode, string sourceBranchCode);
    }
}