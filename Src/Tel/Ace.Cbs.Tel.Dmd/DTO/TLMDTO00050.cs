//----------------------------------------------------------------------
// <copyright file="TLMDTO00050.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-06-20</CreatedDate>
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
    public class TLMDTO00050
    {
        public TLMDTO00050() { }

        public TLMDTO00050(string accountNo, string description, string currency, decimal amount, string debitcredit)
        {
            this.AccountNo = accountNo;
            this.Description = description;
            this.Currency = currency;
            this.Amount = amount;
            this.DebitCredit = debitcredit;
        }

        public string RegisterNo { get; set; }
        public string EBank { get; set; }
        public string AccountNo { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string ToAccountNo { get; set; }
        public string ToName { get; set; }
        public string AccountSign { get; set; }
        public string Parameter { get; set; }
        public string DebitCredit { get; set; } // <------- Debit or Credit
        public string SourceBranch { get; set; }
    }
}
