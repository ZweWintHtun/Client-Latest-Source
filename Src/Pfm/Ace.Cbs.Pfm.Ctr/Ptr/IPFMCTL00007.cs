using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

// Controller for Print User
namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00007 : IPresenter
    {
        IPFMVEW00007 PrintUserView { get; set; }
        void UpdatePrintUserEntity(PFMDTO00044 printUserEntity);
        void SavePrintUserEntity(PFMDTO00044 printUserEntity);
        void CheckUserExist(string branchCode);
        bool IsValidPassword(string branchCode, string OldPassword);
    }

    public interface IPFMVEW00007
    {
        string UserName { get; set; }
        string OldPassword { get; set; }
        string NewPassword { get; set; }
        string ConfirmPassword { get; set; }
        string BranchCode { get; }
        bool IsCheckOrEdit { get; }
        PFMDTO00044 PrintUserEntity { get; set; }
        IPFMCTL00007 PrintUserController { get; set; }
        void Successful(string message);
        void Failure(string message);
        void VisibleControlsForNewUser();
        void VisibleControlsForCurrentUser(string userName);
        void RebindAuthorizeUserTextBox(string userName);
        void DisableControlsForNewUser();
    }
}