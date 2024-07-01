using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00015 : IPresenter
    {
        //PrintCheque Controller Interface
        IPFMVEW00015 PrintChequeView { get; set; }
        string GetCurrentBranch();
        void Print();
        void PrintWithRDLC();
    }

    public interface IPFMVEW00015 // Print Cheque View Contract
    {
        string AccountNo { get; set; }
        string ChequeBookNo { get; set; }
        string StartSerialNo { get; set; }
        string EndSerialNo { get; set; }
        string SourceBranchCode { get; set; }
        IPFMCTL00015 PrintChequeController { get; set; }
        PFMDTO00006 ChequeEntity { get; set; }
        IList<PFMDTO00014> PrintCheques { get; set; }
        void Successful(string message);
        void Failure(string message);

    }
}