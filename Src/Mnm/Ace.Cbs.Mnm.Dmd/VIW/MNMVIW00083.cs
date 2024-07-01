//----------------------------------------------------------------------
// <copyright file="MNMVIW00083.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-12</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Mnm.Dmd
{
     [Serializable]
   public class MNMVIW00083
    {
         public MNMVIW00083() { }
         public virtual int Id { get; set; }
         public virtual Nullable<DateTime> ReceiptDate { get; set; }
         public virtual string DrawingNo { get; set; }
         public virtual string Br_Alias { get; set; }
         public virtual string RegisterNo { get; set; }
         public virtual decimal Commision { get; set; }
         public virtual decimal Amount { get; set; }
         public virtual string DBank { get; set; }
         public virtual decimal Total { get; set; }
         public virtual decimal TLxCharges { get; set; }
         public virtual Nullable<DateTime> DateTime { get; set; }
         public virtual string Currency { get; set; }
         public virtual DateTime SettlementDate { get; set; }
         public virtual bool OtherBank { get; set; }
         public virtual string Budget { get; set; }
         public virtual string SourceBr { get; set; }
    }
}
