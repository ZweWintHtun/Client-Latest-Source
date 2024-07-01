//----------------------------------------------------------------------
// <copyright file="TLMDTO00053.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai </CreatedUser>
// <CreatedDate>2013-08-01</CreatedDate>
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
{
    /// <summary>
    /// Clearing Delivered and ReceiptDTO
    /// </summary>
    [Serializable]
    public class TLMDTO00053 : EntityBase<TLMDTO00053>
    {
        public string TransactionStatus { get; set; }
        public string AccountNo { get; set; }
        public string AccountSign { get; set; }
        public string AccountName { get; set; }
        public string ReceiptAccountNo { get; set; }
        public string CurrencyCode { get; set; }
        public string OtherBank { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNo { get; set; }
        public string SourceBranchCode { get; set; }
        public bool IsDomesticAccountType { get; set; }
        public bool IsLinkTransaction { get; set; }
        public decimal LocalAmt { get; set; }
        public decimal LocalOamt { get; set; }
        public bool IsVIP { get; set; }

    }
}
