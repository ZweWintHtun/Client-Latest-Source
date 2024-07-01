//----------------------------------------------------------------------
// <copyright file="LOMDTO00402.cs" Name="LRP99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ZMS</CreatedUser>
// <CreatedDate>07/09/2017</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// LRP99#00 DTO
    /// </summary>
    [Serializable]
    public class LOMDTO00402 : Supportfields<LOMDTO00402>
    {
        public LOMDTO00402() { }

        public LOMDTO00402(int id) 
        {
            this.Id = id;
        }

        public virtual int Id { get; set; }
        public virtual string LNO { get; set; }
        public virtual string RepayNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<decimal> Interest { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }

        public virtual string LCState { get; set; }
        public virtual System.Nullable<decimal> Old_IntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)
        public virtual System.Nullable<decimal> New_IntRate { get; set; }//Added by HMW at 30-02-2023 (For "interest rate" change LC Increase)
    }
}
