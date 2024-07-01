//----------------------------------------------------------------------
// <copyright file="TLMORM00024.cs" Name="Prev_IBLTLF" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SuNge</CreatedUser>
// <CreatedDate>11/29/2013</CreatedDate>
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
    public class TLMORM00024 : EntityBase<TLMORM00024>
    {
        public TLMORM00024() { }

        public virtual int Id { get; set; }
        public virtual string FromBranch { get; set; }
        public virtual string ToBranch { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string TranType { get; set; }
        public virtual DateTime DATE_TIME { get; set; }
        public virtual bool InOut { get; set; }
        public virtual bool Success { get; set; }
        public virtual string ENo { get; set; }
        public virtual string USERNO { get; set; }
        public virtual string Cheque { get; set; }
        public virtual System.Nullable<decimal> Income { get; set; }
        public virtual System.Nullable<decimal> CommuCharge { get; set; }
        public virtual System.Nullable<bool> Reversal { get; set; }
        public virtual System.Nullable<int> IncomeType { get; set; }
        public virtual string RelatedAC { get; set; }
        public virtual string RelatedBr { get; set; }
        public virtual string UID { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
    }
}