//----------------------------------------------------------------------
// <copyright file="TLMDTO00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// PO Issue Entry DTO Entity
    /// </summary>
     [Serializable]
    public class TLMDTO00043 : Supportfields<TLMDTO00043>
    {
         public TLMDTO00043() { }

         public virtual string PONo { get; set; }
         public virtual string RegisterNo { get; set; }
         public virtual decimal Amount { get; set; }
         public virtual string AccountNo { get; set; }
         public virtual DateTime ADate { get; set; }
         public virtual System.Nullable<DateTime> IDate { get; set; }
         public virtual string POStatus { get; set; }
         public virtual string TlfStatus { get; set; }
         public virtual string CashDenoStatus { get; set; }
         public virtual string ToAccountNo { get; set; }
         public virtual string CheckNo { get; set; }
         public virtual string Income { get; set; }
         public virtual string UserNo { get; set; }
         public virtual string AccountSign { get; set; }
         public virtual decimal Charges { get; set; }
         public virtual string ACode { get; set; }
         public virtual string Budget { get; set; }
         public virtual string Uid { get; set; }
         public virtual string SourceBranch { get; set; }
         public virtual string Currency { get; set; }
         public virtual decimal Rate { get; set; }
         public virtual DateTime SettlementDate { get; set; }
         public virtual DateTime RefundsDate { get; set; }
         public virtual string ENo { get; set; }
         public virtual decimal HomeAmount { get; set; }
         public virtual decimal HomeAmt { get; set; }
         public virtual decimal LocalAmount { get; set; }
         public virtual decimal LocalAmt { get; set; }
         public virtual string SourceCurrency { get; set; }
         public virtual string Description { get; set; }
         public virtual string Narration { get; set; }
         public virtual string IncomeNarration { get; set; }
         public virtual string ReceiptNo { get; set; }
         public virtual DateTime DateTime { get; set; }
         public virtual string TransactonCode { get; set; }
         public virtual string Channel { get; set; }
         public virtual string ReferenceVoucherNo { get; set; }
         public virtual string ReferenceType { get; set; }
         public virtual string GroupNo { get; set; }
         public virtual string Tlf_Eno { get; set; }
         public virtual string AccountType { get; set; }
         public virtual bool Reverse_Status { get; set; }
         public virtual decimal IncomeAmount { get; set; }
         public virtual decimal CommunicationChargesAmount { get; set; }
         public virtual string DenominationEntryNo { get; set; }
         public virtual string TlfEntryNo { get; set; }
         public virtual string FromType { get; set; }
         public virtual string BranchCode { get; set; }
         public virtual decimal AdjustmentAmount { get; set; }
         public virtual DateTime Cash_Date { get; set; }
         public virtual string DenominationDetail { get; set; }
         public virtual string DenominationRefundDetail { get; set; }
         public virtual string CounterNo { get; set; }
         public virtual bool Reverse { get; set; }
         public virtual string DenominationRate { get; set; }
         public virtual string DenominationRefundRate { get; set; }
         public virtual string AllDenominationRate { get; set; }
         public virtual string IncomeACode { get; set; }
         public virtual string IncomeAccountNo { get; set; }
         public virtual string IncomeDescription { get; set; }
         public virtual string CoaSetupAccountNo1 { get; set; }
         public virtual string CoaSetupAccountNo2 { get; set; }
         public virtual string COAACName1 { get; set; }
         public virtual string COAACName2 { get; set; }
        
    }
}
