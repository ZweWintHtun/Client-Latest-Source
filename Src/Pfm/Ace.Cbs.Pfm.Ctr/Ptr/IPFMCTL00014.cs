using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    // Stop Cheque Presenter Contract

    public interface IPFMCTL00014 : IPresenter
    {
        void Save(PFMDTO00011 entity);
        void ClearControls();
        IPFMVEW00014 StopChequeView { get; set; }
    }

    public interface IPFMVEW00014 // Stop Cheque View Contract
    {
        int Id { get; }
        string AccountNo { get; set; }
        string ChequeBookNo { get; set; }
        string StartSerialNo { get; set; }
        string EndSerialNo { get; set; }
        string Remark { get; set; }
        IPFMCTL00014 StopChequeController { get; set; }
        PFMDTO00011 StopChequeEntity { get; set; }
        void Successful(string message);
        void Failure(string message);
        void gvCustomer_DataBind(IList<PFMDTO00001> custList);
    }

}