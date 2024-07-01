using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00003:IPresenter
    {
        ITLMVEW00003 View { get; set; }
        void ClearControls(bool isGird);
        bool Save();
        void Printing();
        bool ValidateAdd();
        bool CheckAmount(IList<TLMDTO00038> transferCollection);
        void Call_RemittanceCalculator();
        void Call_Enquiry();
        bool DebitAccountInformationChecking();
        bool ChecKLocalDrCr();
        bool ChecKOnlineDrCr();
        IList<PFMDTO00001> SelectByAccountNumber_ForNotAllowDrTrans(string acctNo, DateTime todayDate);
        DateTime GetSystemDate(string sourceBr);//Added by HMW at 13-Aug-2019
      
    }

    public interface ITLMVEW00003
    {
        ITLMCTL00003 Controller { get; set; }
        IList<TLMDTO00038> DenoCollection { get; set; }

        bool LocationTransactions { get; set; }
        string BranchCode { get; set; }
        string LocalBranchCode { get; set; }
        bool AllowedPrinting { get; set; }
        string Status { get; set; }
        string VoucherNo { get; set; }
        string AccountNo { get; set; }
        string Description { get; set; }
        string CurrencyCode { get; set; }
        string Currency { get; set; }
        string ChequeNo { get; set; }
        string AccountSign { get; set; }
        string Narration { get; set; }
        decimal Amount { get; set; }
        decimal LinkAmount { get; set; }
        decimal TotalAmount { get; set; }
        decimal CommunicationCharges { get; set; }
        decimal Commissions { get; set; }
        bool InputIncomeAmount { get; set; }
        bool PrintTransactions { get; set; }
        decimal CurrentBalance { get; set; }
        TLMDTO00038 TransferEntity { get; set; }
      //  CXDTO00001 DenoInfo { get; set; }
        bool IsDebitTransaction { get; set; }
        bool IsCreditTransaction { get; set; }
        bool IsIncomeByCash { get; set; }
        bool IsIncomeByTransfer { get; set; }
        bool IsCurrentAccount { get; set; }
        bool IsDomesticAccount { get; set; }
        bool IsAutoLink { get; set; }
        bool IsVIP { get; set; }
        string FormName { get; set; }

        void EnableControlsforView(string name);
        void DisableControlsforView(string name);

        void BindData();
        void TransactionForControls(bool isDebit, bool isLocal, bool isPrinting);
        void SetCursor(string txt);
       // void Successful(string message, string VoucherNo);
        void Successful(string message, string name ,string VoucherNo);
        void Failure(string message);

        //void DisableControl(bool enable);
        void DisableEnableControl(bool onlineTransaction);
    }
}
