using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00081 : IPresenter
    {
        ITLMVEW00081 View { get; set; }
        void ClearControls(bool isGird);
        void Call_Enquiry();
        bool ChecKLocalDrCr();
        bool ChecKOnlineDrCr();
        bool ValidateAdd();
        bool DebitAccountInformationChecking();
        bool CheckInterestAmountByAcctNo();
        bool CheckAmount(IList<TLMDTO00038> transferCollection);
        bool Save();
        ChargeOfAccountDTO GetCOAByAcode(string acode, string sourcebr);
        DateTime GetSystemDate(string sourceBr);
        DateTime GetLastSettlementDate(string sourceBr);
    }

    public interface ITLMVEW00081
    {
        ITLMCTL00081 Controller { get; set; }

        TLMDTO00038 TransferEntity { get; set; }
        string VoucherNo { get; set; }
        string AccountNo { get; set; }
        string CurrencyCode { get; set; }
        string Currency { get; set; }
        string Description { get; set; }
        string Narration { get; set; }
        decimal Amount { get; set; }
        bool IsDebitTransaction { get; set; }
        bool IsCreditTransaction { get; set; }
        string RGLACode { get; set; }
        string RGLACodeDesp { get; set; }

        string LocalBranchCode { get; set; }
        string Status { get; set; }
        bool IsCurrentAccount { get; set; }
        bool IsDomesticAccount { get; set; }
        string BranchCode { get; set; }
        bool IsAutoLink { get; set; }
        bool LocationTransactions { get; set; }
        int SerialNo { get; set; }
        string AccountSign { get; set; }
        decimal LinkAmount { get; set; }
        decimal CurrentBalance { get; set; }
        string FormName { get; set; }

        IList<TLMDTO00038> DenoCollection { get; set; }

        void DisableControlsforView(string name);
        void BindData();
        void SetCursor(string txt);
        void TransactionForControls(bool isDebit, bool isLocal, bool isPrinting);
        void DisableEnableControl(bool onlineTransaction);
        void Successful(string message, string name, string VoucherNo);
        void Failure(string message);
    }
}
