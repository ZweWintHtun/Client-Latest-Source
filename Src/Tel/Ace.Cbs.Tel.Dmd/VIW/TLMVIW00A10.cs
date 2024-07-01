//----------------------------------------------------------------------
// <copyright file="TLMVIW00A10.cs" company="ACE Data Systems">
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
    /// VW_BANK_STATEMENT
    /// </summary>
     [Serializable]
    public class TLMVIW00A10 : Supportfields<TLMVIW00A10>
    {
       public TLMVIW00A10() { }
       public virtual int Id { get; set; }

       public virtual Nullable<DateTime> DateTime { get; set; }
       public virtual string AccountNo { get; set; }
       public virtual string Cheque { get; set; }
       public virtual string ReceiptNo { get; set; }
       public virtual string SourceBr { get; set; }
       //public virtual bool Active { get; set; }
       public virtual string Description { get; set; }
       public virtual Nullable<decimal> WithdrawAmount { get; set; }
       public virtual Nullable<decimal> DepositAmount { get; set; }
       public virtual string S { get; set; }
       public virtual string Status { get; set; }
       public virtual string WorkStation { get; set; }
       public virtual Nullable<DateTime> ChkTime { get; set; }
    }
}
