using System;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
// Passbook -> Transaction Printing (Print Record Controller)
namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00008 : IPresenter
    {
        IPFMVEW00008 PrintRecordView { get; set; }
        bool Save(PFMDTO00045 printRecordEntity);
    }

    public interface IPFMVEW00008
    {
        PFMDTO00045 PrintRecordEntity { get; set; }
        PFMDTO00043 PrnFileDTO { get; set; }
        DateTime TPDate { get; set; }
        string AccountNo { get; set; }
        string Reference { get; set; }
        decimal DAmt { get; set; }
        decimal CAmt { get; set; }
        decimal Balance { get; set; }
        string AccountSign { get; set; }

        IPFMCTL00008 PrintRecordController { set; }
        void ShowErrorMessage(string message, bool isAmountError);

    }
}