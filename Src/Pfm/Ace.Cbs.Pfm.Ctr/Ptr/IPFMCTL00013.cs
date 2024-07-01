using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    //Cheque -> Cheque Issue (Book)
    public interface IPFMCTL00013 : IPresenter //ChequeController
    {
        void Save(PFMDTO00006 entity);
        bool ValidateForm(object validationContext);
        void ClearControls();
        IPFMVEW00013 ChequeView { set; get; }
    }

    public interface IPFMVEW00013 //ChequeView
    {
        bool IsMainMenu { get; set; }
        string AccountNo { get; set; }
        string StartNo { get; set; }
        string EndNo { get; set; }
        string ChequeBookNo { get; set; }            

        PFMDTO00006 ChequeEntity { get; set; }
        IPFMCTL00013 ChequeController { set; get; }
        void Successful(string message);
        void Failure(string message); 
    }
}