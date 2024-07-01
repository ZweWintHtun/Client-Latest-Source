
//----------------------------------------------------------------------
// <copyright file="ITLMCTL00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
using System.Collections.Generic;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Tel.Ctr.Ptr
{
   /// <summary>
   /// Drawing Remittance Entry Controller Interface
   /// </summary>
    public interface ITLMCTL00018 : IPresenter
    {
        ITLMVEW00018 View { get; set; }
        //bool ValidAccountNo(string accountNo);
        bool ValidAccountNo(string accountNo, string drawerBank);  //use service TLMSVE00014 to check accInfo
        TLMDTO00029 GetTelexChargesByIBLDrawerBranchCodeAndCurrencyCode(string drawerbranchcode, string currencycode);
        TLMDTO00030 GetCommisionByIBLDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode, decimal amount);
        TLMDTO00030 GetEndNoByIBLDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode);
        TLMDTO00032 GetCommisionByIBSDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode, decimal amount);
        TLMDTO00032 GetEndNoByIBSDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode);
        TLMDTO00028 GetTelexChargesByIBSDrawerBranchCodeAndCurrencyCode(string drawerbranchcode, string currencycode);
        void Save(IList<TLMDTO00054>drawingList);
        CXDMD00004 _AccountType { get; set; }
        void Continue();
        string GetSourceBranch();
        void ClearControls(bool isCancel);
        bool IsDomesticAcType { get; set; }
        //void ClearCustomErrorMessage();
    }

    public interface ITLMVEW00018
    {
        ITLMCTL00018 Controller { get; set; }
        string GroupNo { get; set; }
        string CurrencyCode { get; set; }
        string AccountNo { get; set; }
        string SenderName { get; set; }
        string NRC { get; set; }
        string Address { get; set; }
        string PhoneNo { get; set; }       
        string Narration { get; set; }
        decimal TotalAmount { get; set; }
        string ChequeNo { get; set; }
        string IncomeType { get; set; }
        bool IsVIP { get; set; }
        bool IsCash { get; set; }
        bool IsIncome { get; set; }
        bool IsTakeIncome { get; set; }
        void Failure(string message,string branchcode);
        void Failure(string message);
        void EnableControlByAccountDrawing();
        void DisableControlsByAccountDrawing();
        void ReadOnlyControl(bool tabstop);
        decimal totalamount { get; set; }
        decimal totalcomission { get; set; }
        decimal totaltelexcharges { get; set; }
        bool Successful(string message);
        string TransactionStatus { get; }
        void EnableDisableControlsforContinueClick();
        void BindBranchCode();
        void gvCustomer_DataBind(IList<TLMDTO00054> RegisterNoList);
        void HideControls(bool enable, bool isDomesticAccType, bool isContinue);
        bool IsChequeNoEnable { get; set; }
        void InitializedState();
        void DisableEnableControlsForContinueEvent(bool enable);
        bool IsDrawingGroupBox { get; set; }
        bool IsCancelExit { get; set; }
        void InformAboutCharges(string message);
        bool IsEnableIncomeBox { get; set; }
        void DisableGroupBox();
        //void CheckBoxEnable();
        //string drawerbank { get; set; }
    }
}
