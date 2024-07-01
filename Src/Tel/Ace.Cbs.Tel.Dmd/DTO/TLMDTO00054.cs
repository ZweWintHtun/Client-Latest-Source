//----------------------------------------------------------------------
// <copyright file="TLMDTO00054.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe </CreatedUser>
// <CreatedDate>2013-07-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
/// <summary>
///  /// <summary>
/// DrawingRemittanceDTO Entity
    /// </summary> DTO Entity
/// </summary>
{
     [Serializable]
   public class TLMDTO00054 : EntityBase<TLMDTO00054>
    {
         public string GroupNo { get; set; }
         public string SerialNo { get; set; }
         public string DrawingNo { get; set; }
         public string BranchAlias { get; set; }
         public string RegisterNo { get; set; }
         public string AccountNo { get; set; }
         public string Name { get; set; }
         public string NRC { get; set; }
         public string Address { get; set; }
         public string PhoneNo { get; set; }
         public string Narration { get; set; }
         public decimal TotalAmount { get; set; }
         public decimal Amount { get; set; }
         public string ChequeNo { get; set; }
         public string Dbank { get; set; }
         public string ToAccountNo { get; set; }
         public string ToName { get; set; }
         public string ToNRC { get; set; }
         public string ToAddress { get; set; }
         public decimal ToAmount { get; set; }
         public decimal Commission { get; set; }
         public decimal RemitAmount { get; set; }
         public decimal TelexCharges { get; set; }
         public string Budget { get; set; }
         public string ToPhoneNo { get; set; }
         public string SourceBranchCode { get; set; }
         public string Channel { get; set; }
         public string SettlementDate { get; set; }
         public string CounterNo { get; set; }
         public string Type { get; set; }
         public string CashStatus { get; set; }
         public string Rate { get; set; }
         public string CurrencyCode { get; set; }
         public string RDType { get; set; }
         public string IncomeType { get; set; }
         public string AccountType { get; set; }
         public int CreatedUserId { get; set; }
         public DateTime DateTime { get; set; }
         public decimal CashAmount { get; set; }
         public string AccountSign { get; set; }
         public decimal TestKey { get; set; }
         public string TransactionStatus { get; set; }
         public decimal AdjustAmount { get; set; }

         public string BankDescription { get; set; }
         public string CashAmountInWord { get; set; }
         public string AmountInZawGyiFont { get; set; }
         public string BankTown { get; set; }

         public bool IsTakeIncome { get; set; }////For solve drawing, encash different amount.

    }
}
