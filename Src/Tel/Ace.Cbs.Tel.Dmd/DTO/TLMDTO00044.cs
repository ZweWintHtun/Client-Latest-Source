//----------------------------------------------------------------------
// <copyright file="TLMDTO00044.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung </CreatedUser>
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


namespace Ace.Cbs.Tel.Dmd.DTO
{
   [Serializable]
   public class TLMDTO00044:Supportfields<TLMDTO00044>
    {
       public TLMDTO00044() { }

       public virtual string VoucherNo { get; set; }
       public virtual string PaymentOrderNo { get; set; }
       public virtual string BudgetYear { get; set; }
       public virtual string RegisterNo { get; set; }
       public virtual decimal Amount { get; set; }
       public virtual decimal TotalAmount { get; set; }
    }

}
