using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00010
    {
        ITLMVEW00010 View { get; set; }
        void ClearControls(bool isGird);
        void CalculateTotalAmount();
        bool Save();
        void Printing();
        bool ValidateAdd();
        void Call_RemittanceCalculator();
        void Call_AccountInformationEnquiry();
    }
    public interface ITLMVEW00010
    {
        ITLMCTL00010 Controller { get; set; }
        IList<TLMDTO00038> DenoCollection { get; set; }

        bool LocationTransactions { get; set; }
        string VoucherNo { get; set; }
        string VoucherLabel { get; set; }
        string BranchCode { get; set; }
        string LocalBranchCode { get; set; }
        string Status { get; set; }
        string AccountNo{ get; set; }       
        string Name{ get; set; }
        string NRC { get; set; }
        string AccountSign { get; set; }
        string CurrencyCode { get; set; }
        string Currency { get; set; }
        string Narration{ get; set; }       
        decimal Amount{ get; set; }       
        decimal CommunicationCharges{ get; set; }       
        decimal Commissions{ get; set; }
        decimal TotalAmount { get; set; }
        bool InputIncomeAmount{ get; set; }
        bool PrintTransactions { get; set; }
        decimal CurrentBalance { get; set; }
        TLMDTO00038 DepositEntity { get; set; }
        CXDTO00001 DenoInfo { get; set; }

        void BindData();
        void SetCursor(string txt);
        void EnableControlsforView(string name);
        void DisableControlsforView(string name);
        void Successful(string message, string name, string VoucherNo);
        void Failure(string message);
        void Disable();
        void GetEnablePrintStaus(bool isSaving);
    }
}
