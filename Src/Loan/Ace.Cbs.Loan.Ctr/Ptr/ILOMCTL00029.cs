using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00029 : IPresenter
    {
        ILOMVEW00029 View { get; set; }
        void ClearControls(bool isGird);
        bool Save();
        void Printing();
        bool ValidateAdd();
        bool CheckAmount(IList<TLMDTO00038> transferCollection);
        bool checkAccount();
    }
    public interface ILOMVEW00029
    {
        ILOMCTL00029 Controller { get; set; }
        IList<TLMDTO00038> DenoCollection { get; set; }

        int PrintLineNo { get; set; }
        bool LocationTransactions { get; set; }
        string BranchCode { get; set; }
        string LocalBranchCode { get; set; }
        bool AllowedPrinting { get; set; }
        string Status { get; set; }
        string VoucherNo { get; set; }
        string AccountNo { get; set; }
        string Description { get; set; }
        string Currency { get; set; }
        string ChequeNo { get; set; }
        string AccountSign { get; set; }
        string Narration { get; set; }
        decimal Amount { get; set; }
        decimal TotalAmount { get; set; }
        bool PrintTransactions { get; set; }
        decimal CurrentBalance { get; set; }
        TLMDTO00038 TransferEntity { get; set; }
        bool IsDebitTransaction { get; set; }
        bool IsCreditTransaction { get; set; }
        bool IsCurrentAccount { get; set; }
        bool IsDomesticAccount { get; set; }
        string FormName { get; set; }
        decimal CurrentBal { get; set; }
        void DisableControlsforView(string name);
        decimal TransactionCount { get; set; }
        void BindData();
        void SetCursor(string txt);
        void Successful(string message, string name, string VoucherNo);
        void Failure(string message);
        void DisableEnableControl(bool onlineTransaction);
    }
}
