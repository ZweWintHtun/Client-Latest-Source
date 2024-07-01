using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    //Fixed Deposit Transfer Interface
    public interface ITCMCTL00001:IPresenter
    {
        ITCMVEW00001 FixedDepositTransferView { get; set; }
        bool Save(PFMDTO00032 fReceiptEntity);
        void PRN_FilePrinting(string accountNo);
        void FPRN_FilePrinting(string accountNo);
    }

    public interface ITCMVEW00001
    {
        string CreditAccountNo { get; set; }
        string DebitAccountNo { get; set; }
        string ChequeNo { get; set; }
        decimal Amount { get; set; }
        string Description { get; set; }
        string ReceiptNo { get; set; }
        decimal Rate { get; set; }
        decimal Duration { get; set; }
        string TakenAccount { get; set; }
        bool AutoRenewal { get; set; }
        bool OnlyPrinciple { get; set; }
        string SourceBranchCode { get; set; }
        string Status { get; set; }
        string AccountSign { get; set; }
        string CurrencyCode { get; set; }
        IList<PFMDTO00007> FixRateList { get; set; }
        PFMDTO00032 FReceiptEntity { get; set; }
        ITCMCTL00001 FixedDepositTransferController { get; set; }
        void GetCheckNofocus();
        void EnableControlsForReceiptEditing(string name);
        void VisibleControlsForReceiptEditing(bool renewalType, bool takenAccount);
        void ShowInformationMessage(string message, object[] arguments);
    }
}
