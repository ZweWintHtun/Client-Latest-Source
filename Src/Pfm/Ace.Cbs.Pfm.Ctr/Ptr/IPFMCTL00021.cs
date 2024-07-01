using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00021 : IPresenter
    {
        IPFMVEW00021 SavingWithdrawalView { set; get; }      
        bool IsValidACode();
        bool IsValidAccountCode();
        void Print();
        
        //PFMDTO00028 SelectCustomerIdByAccountNo(string accountNo); 
       // PFMDTO00024 SelectACode(string olsAccountNo, string sourceBranchCode);
    }

    public interface IPFMVEW00021
    {
        IPFMCTL00021 SavingWithdrawalController { set; get; }
        string FormName { get; set; }
        string OLSACNo { get; set; }
        string AccountNo { get; set; }
        string NRC { get; set; }
        string Amount { get; set;}
        string Name { get; set; }
        string SourceBranchCode { get; set; }
        //string AccountSign { get; set; }
        PFMDTO00059 ViewData { get; set; }
        IList<PFMDTO00059> ViewDataList { get; set; }
        void SetCursor(string txt);
    }
}