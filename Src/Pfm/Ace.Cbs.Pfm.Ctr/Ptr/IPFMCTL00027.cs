using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Pfm.Ctr.PTR
{
   
    //Freceipt Interface
    public interface IPFMCTL00027:IPresenter
    {
        bool ValidateFormForAccountOpening(PFMDTO00032 freceiptentity);
        bool Save(PFMDTO00032 freceiptentity);
        IPFMVEW00027 FReceiptView { get; set; }
        void Update(int id,string rNo);
        void ClearErrorMessage();
    }

    public interface IPFMVEW00027
    {
        bool IsMainMenu { get; set; }
        string AccountNo { get; set; }
        decimal Amount { get; set; }
        string Description { get; set; }
        string ReceiptNo { get; set; }
        decimal Rate { get; set; }
        string TakenAccount { get; set; }
        bool AutoRenewal { get; }

        string LocalBranchCode { get; set; }
        
        PFMDTO00032 FReceiptEntity { get; set; }
        IPFMCTL00027 FReceiptController { get; set; }
        void Successful(string message);
        void SuccessfulReceiptNo(string message,string recepeiptNo);
        void Failure(string message);
        void ShowInformationMessage(string message, object[] arguments);
        void RebindReceiptNoTextBox(string receiptNo);
    }


}