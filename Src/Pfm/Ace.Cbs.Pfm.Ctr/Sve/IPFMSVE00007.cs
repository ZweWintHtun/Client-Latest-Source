using Ace.Cbs.Pfm.Dmd;
namespace Ace.Cbs.Pfm.Ctr.Sve

//PassBook->Transaction Binding->Printing User(enquiry) Service
{
    public interface IPFMSVE00007
    {
        PFMDTO00044 SelectPrintUserByBranchCode(string BranchCode);
        bool IsValidPassword(string sourceBranch,string password);
        void Save(PFMDTO00044 printUserEntity);
        void Update(PFMDTO00044 printUserEntity);
    }
}