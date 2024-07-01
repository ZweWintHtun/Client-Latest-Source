//----------------------------------------------------------------------
// <copyright file="TCMDTO00003.cs" Name="NPLInt" company="ACE Data Systems">
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
    public class TCMDTO00003 : Supportfields<TCMDTO00003>
    {
        public TCMDTO00003() { }

        public TCMDTO00003(string lno, string acctNo, string aType, decimal amount, string type, string narration,string sourceBr)
        {
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.AType = aType;
            this.Amount = amount;
            this.Type = type;
            this.Narration = narration ;
            this.SourceBr = sourceBr;

        }

        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual string Narration { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> ReleaseDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }

        public string ACode { get; set; }
        public string Currency { get; set; }
    }
}	
