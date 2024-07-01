//----------------------------------------------------------------------
// <copyright file="MNMDTO00012.cs" Name="Legalint" company="ACE Data Systems">
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

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00012 : Supportfields<MNMDTO00012>
    {
        public MNMDTO00012() { }

        public MNMDTO00012(int id, string lno, string acctNo, string aType, decimal amount, DateTime date_time, string type, string narration,
            string cracctNo, string userNo, DateTime closedate, string sourceBr, string cur, string uid, bool active, DateTime createddate)
        {
            this.Id = id;
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.AType = aType;
            this.Amount = amount;
            this.Date_Time = date_time;
            this.Type = type;
            this.Narration = narration;
            this.CRAcctno = cracctNo;
            this.UserNo = userNo;
            this.CloseDate = closedate;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.UId = uid;
            this.Active = active;
            this.CreatedDate = createddate;
        }

        public MNMDTO00012(int id, string lno, string acctNo, string aType, decimal amount, DateTime datetime, string type, string narration , 
            string crAcctNo, string userNo, DateTime closeDate, string sourceBr, string cur)
        {
            this.Id = id;
            this.LNo = lno;
            this.AcctNo = acctNo;
            this.AType = aType;
            this.Amount = amount;
            this.Date_Time = datetime;
            this.Type = type;
            this.Narration = narration;
            this.CRAcctno = crAcctNo;
            this.UserNo = userNo;
            this.CloseDate = closeDate;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        public virtual int Id { get; set; }
        public virtual string LNo { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AType { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string Type { get; set; }
        public virtual string Narration { get; set; }
        public virtual string CRAcctno { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}	
