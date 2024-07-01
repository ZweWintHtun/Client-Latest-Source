//----------------------------------------------------------------------
// <copyright file="TLMVIW000A9.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-12</CreatedDate>
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
    /// VW_BANK_STATEMENT_BYDATE
    /// </summary>
    [Serializable]
   public class TLMVIW000A9
    {
        public TLMVIW000A9(){}

        //public TLMVIW000A9(DateTime dateTime, string accountNo, string Cheque, string description, decimal withdrawAmount, decimal depositAmount) 
        //{
        //    this.DateTime = dateTime;
        //    this.AccountNo = accountNo;
        //    this.Cheque = Cheque;
        //    this.
        //}
        public virtual int Id { get; set; }

        public virtual Nullable<DateTime> DateTime { get; set; }
        public virtual string AccountNo{get;set;}
        public virtual string Cheque{get;set;}
        public virtual string ReceiptNo{get;set;}
        public virtual string Description{get;set;}
        public virtual Nullable<decimal> WithdrawAmount { get; set; }
         public virtual Nullable<decimal> DepositAmount{get;set;}
        public virtual string S{get;set;}
         public virtual string Status{get;set;}
        public virtual string WorkStation{get;set;}
         public virtual Nullable<DateTime> ChkTime{get;set;}
         public virtual string OrgnEno { get; set; }
         public virtual Nullable<DateTime> CreatedDate { get; set; }
    }
}
