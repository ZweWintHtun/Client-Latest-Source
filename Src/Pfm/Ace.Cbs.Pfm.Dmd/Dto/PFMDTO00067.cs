//----------------------------------------------------------------------
// <copyright file="PFMDTO00067.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
     [Serializable]
    public class PFMDTO00067 : Supportfields<PFMDTO00067>
    {
        public PFMDTO00067() { }

        public PFMDTO00067(string accountNo, decimal amount, string accountSign, System.Nullable<DateTime> closedDate, string linkAccountNo, byte[] photo, byte[] signature,
                           IList<PFMDTO00001> customerInfo,decimal overDraftAmount,decimal expireAmount, decimal linkAmount, decimal numberOfLoan, decimal miniumBalance,
                            int numberOfPersonToSign, string jointType)
        {
            this.AccountNo = accountNo;
            this.Amount = amount;
            this.AccountSign = accountSign;
            this.ClosedDate = closedDate;
            this.LinkAccountNo = linkAccountNo;
            this.Photo = photo;
            this.Signature = signature;
            this.CustomerInfo = customerInfo;
            this.OverDraftAmount = overDraftAmount;
            this.LinkAmount = linkAmount;
            this.ExpireAmount = expireAmount;
            this.NoOfLoan = numberOfLoan;
            this.MiniumBalance = miniumBalance;
            this.NoOfPersonToSign = numberOfPersonToSign;
            this.JointType = jointType;
        }
        
        public virtual string AccountNo { get; set; } //and it can be also used as Avaliable Amount
        public virtual decimal Amount{get;set;}
        public virtual string AccountSign { get; set; }
        public virtual System.Nullable<DateTime> ClosedDate { get; set; }
        public virtual string LinkAccountNo { get; set; } //Get LinkAccountNo and Balance
        public virtual byte[] Photo { get; set; }
        public virtual byte[] Signature { get; set; }
        public virtual IList<PFMDTO00001> CustomerInfo { get; set; }
        public virtual IList<PFMDTO00006> ChequeInfo { get; set; }
        public virtual decimal OverDraftAmount { get; set; } //and it can be also used as ExpireAmount
        public virtual decimal ExpireAmount { get; set; }
        public virtual decimal LinkAmount { get; set; }
        public virtual decimal NoOfLoan { get; set; }
        public virtual decimal MiniumBalance { get; set; }
        public virtual decimal CBal { get; set;}
        public virtual int NoOfPersonToSign { get; set; }
        public virtual string JointType { get; set; }
        public virtual string Currency { get; set; }
        public string message { get; set; }
        public string SourceBr { get; set; }

        public DateTime OpenDate { get; set; }
        public virtual decimal LoansAmount { get; set; } //Added By HWKO (26s-Jun-2017)

         
    }
}
