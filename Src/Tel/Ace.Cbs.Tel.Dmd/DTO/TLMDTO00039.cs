//----------------------------------------------------------------------
// <copyright file="TLMDTO00039.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
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
    [Serializable]
    public class TLMDTO00039 : Supportfields<TLMDTO00039>
    {
        public TLMDTO00039() { }

        //public TLMDTO00039( string registerNo, string voucherNo, string accountNo, decimal amount, string acode, decimal homeAmount, decimal homeamt,
        //                    decimal homeOAmt, decimal localAmount, decimal localAmt, decimal localOAmt, string SourceCurrency, string description, string narration,
        //                    DateTime datetime, string status, string transactionCode, string accountSign, string sourceBranch, string rate, DateTime settlementDate,
        //                    string channel, string referenceType, string referenceVoucherNo, DateTime issuedDate, string encashNo, string name, int loansCount,
        //                    decimal odLimit, decimal todLimit)
        //{

        //}
        
        public virtual string RegisterNo { get; set; }
        public virtual string VoucherNo { get; set; }
        public virtual string DebitAccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string DebitAcode { get; set; }
        public virtual string CreditAcode { get; set; }
        public virtual decimal HomeAmount { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual decimal LocalAmount { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual string Ebank { get; set; } //<----------------- To ask
        public virtual string SourceCurrency { get; set; }
        public virtual string DebitDescription { get; set; }
        public virtual string Narration { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Status { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string SourceBranch { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string Channel { get; set; }
        public virtual string ReferenceType { get; set; }
        public virtual string ReferenceVoucherNo { get; set; }
        public virtual DateTime IssuedDate { get; set; }
        public virtual string EncashNo { get; set; }
        public virtual string Name { get; set; }
        public virtual int LoansCount { get; set; }
        public virtual decimal ODLimit { get; set; }
        public virtual decimal TODLimit { get; set; }
        public virtual string Currency { get; set; }
        public virtual string UserNo { get; set; } //<-----
        public virtual string CreditAccountNo { get; set; } //<----
        public virtual string CreditDescription { get; set; } //<----
    }
}
