using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
namespace Ace.Cbs.Pfm.Ctr.Dao
{
    //PassBook->Transaction Binding->Printing User(enquiry) Interface

    public interface IPFMDAO00044 : IDataRepository<PFMORM00044>
    {
        PFMDTO00044 SelectPrintUserBySourceBr(string branchCode);
        void UpdatePrintUser(PFMDTO00044 printUserEntity);
        PFMDTO00044 IsValidPassword(string sourceBranch);
    }
}