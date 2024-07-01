using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00023 : IPresenter
    {
        IMNMVEW00023 View { get; set; }
        void Delete();
        void Save();
    }
    public interface IMNMVEW00023
    {
        string RegisterNo { get; set; }
        string DBank { get; set; }
        decimal Amount { get; set; }
        decimal Commission { get; set; }
        decimal TelexCharges { get; set; }
        bool IsIncomeByTransfer { get; set; }
        bool IsIncomeByCash { get; set; }
        bool IsNoIncome { get; set; }
        string PayerAccountNo { get; set; }
        string PayerName { get; set; }
        string PayerNRC { get; set; }
        string PayerAddress { get; set; }
        string PayerPhoneNo { get; set; }
        string Narration { get; set; }
        string PayeeAccountNo { get; set; }
        string PayeeName { get; set; }
        string PayeeNRC { get; set; }
        string PayeeAddress { get; set; }
        string PayeePhoneNo { get; set; }
        bool SaveStatus { get; set; }
        bool GroupNoLabelVisible { set; }
        string GroupNo { get; set; }
        string ChequeNo { get; set; }
        string Currency { get; set; }
        decimal CalculateCommission { get; set; }
        decimal TlxCharges { get; set; }
        string IncomeType { get; }
        string OldIncomeType { get; set; }
        string DrawingType { get; }
        string OldDrawingType { get; set; }
        string AcSign { get; set; }
        decimal OldCashAmount { get; set; }
        string OldChqueNo { get; set; }
        string OldAccountNo { get; set; }
        string OCheque { get; set; }


        void ClearControl();
        void SetEnableToEdit(bool status);
        void BindCommession();
        void ChequeEnable();
        void ChequeDisable();
        void DisableControl();
        void SetFocus();
        void SetFocusToRegisterNo();
        void EnableControl();
    }
}
