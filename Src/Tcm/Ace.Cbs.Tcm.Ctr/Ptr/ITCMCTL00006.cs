using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
    //Fixed Deposit Interest Interface
    public interface ITCMCTL00006 : IPresenter
    {
        ITCMVEW00006 View { get; set; }
        bool Save(PFMDTO00032 fReceiptEntity);
        void FPRN_FilePrinting(string accountNo);
        void PRN_FilePrinting(string accountNo);
    }

    public interface ITCMVEW00006
    {
        string VoucherNo { get; set; }
        string AccountNo { get; set; }
        string DebitAccountSign { get; set; }
        string CreditAccountNo { get; set; }
        decimal AccruedInterest { get; set; }
        string Nrc { get; set; }
        string Name { get; set; }
        string CreditNrc { get; set; }
        string CreditName { get; set; }
        string SourceBranchCode { get; set; }
        string CurrencyCode { get; set; }
        string FormCaption { get; }
        string Status { get; set; }
        PFMDTO00032 Entity { get; set; }
        PFMDTO00028 CledgerInfo { get; set; }
        ITCMCTL00006 Controller { get; set; }
    }
}
