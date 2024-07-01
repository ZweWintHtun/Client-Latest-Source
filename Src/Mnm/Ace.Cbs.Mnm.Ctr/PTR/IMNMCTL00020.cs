//----------------------------------------------------------------------
// <copyright file="IMNMCTL00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>14/02/2014</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using System.Windows.Forms;


namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00020 : IPresenter
    {
        IMNMVEW00020 View { get; set; }
        void FormCleaning();
        void ClearCustomErrorMessage();
        bool ValidateForm(object validationContext);
        void SavePOIssueTransfer(IList<TLMDTO00043> POIssueLists);
        bool CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit);
        bool AddPOIssue();
        TLMDTO00043 GetEntity();  
    }

    public interface IMNMVEW00020
    {
        #region DTO

        IMNMCTL00020 Controller { get; set; }
        TLMDTO00043 TempData { get; set; }
        IList<TLMDTO00043> ViewDataList { get; set; }
        TLMDTO00016 PODTO { get; set; }

        #endregion

        #region Control Properties

        string AccountNo { get; set; }
        decimal POAmount { get; set; }
        string PaymentOrderNo { get; set; }
        string ChequeNo { get; set; }
        string Currency { get; set; }
        decimal Charges { get; set; }
        decimal TotalAmount { get; set; }
        bool IsVIPCustomer { get; set; }
        string ACSign { get; set; }
        string Texts { get; set; }
        bool isWithIncome { get; set; }
        string BudgetYear { get; set; }

        #endregion

        #region Methods
        void InitializeControls();
        void Successful(string message);
        void Failure(string message);
        void BindTempDataListToGridview();
        int GetMenuIDPermission();
        void DisableChequeNo();
        #endregion
    }
}
