//----------------------------------------------------------------------
// <copyright file="TCMDTO00005.cs" Name="HP" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/14/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00005 : Supportfields<TCMDTO00005>
    {
        public TCMDTO00005() { }

        public virtual string HPNo { get; set; }
        public virtual string CAccount { get; set; }
        public virtual string DealerAc { get; set; }
        public virtual string StockGroup { get; set; }
        public virtual string StockItems { get; set; }
        public virtual decimal LoanAmount { get; set; }
        public virtual System.Nullable<int> Term { get; set; }
        public virtual decimal Installment { get; set; }
        public virtual System.Nullable<int> PaidTerm { get; set; }
        public virtual System.Nullable<DateTime> LastPaidDate { get; set; }
        public virtual System.Nullable<DateTime> Date { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Repocess { get; set; }
        public virtual decimal Commission { get; set; }
        public virtual decimal RentalCharges { get; set; }
        public virtual System.Nullable<int> UnPaidTerm { get; set; }
        public virtual string Slocation { get; set; }
        public virtual decimal DownPayment { get; set; }
        public virtual decimal ServiceCharges { get; set; }
        public virtual System.Nullable<bool> GuanAcctNo { get; set; }
        public virtual System.Nullable<bool> Multiple { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}