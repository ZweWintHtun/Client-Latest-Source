//----------------------------------------------------------------------
// <copyright file="MNMDTO00005.cs" Name="TOD_SCHARGE" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
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
    public class MNMDTO00005 : Supportfields<MNMDTO00005>
    {
        public MNMDTO00005() { }

        public MNMDTO00005(int iD, string acctno, string lNo, System.Nullable<decimal> s1, System.Nullable<decimal> s2, System.Nullable<decimal> s3, System.Nullable<decimal> s4, System.Nullable<decimal> s5, System.Nullable<decimal> s6, System.Nullable<decimal> s7, System.Nullable<decimal> s8, System.Nullable<decimal> s9, System.Nullable<decimal> s10, System.Nullable<decimal> s11, System.Nullable<decimal> s12, System.Nullable<decimal> lastInt, System.Nullable<DateTime> lastDate, string budget, string userNo, System.Nullable<DateTime> closeDate, string aCSign, System.Nullable<DateTime> tODCloseDate, System.Nullable<DateTime> tOD_SDate, string sourceBr, string cur, string uId, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.ID = iD;
            this.Acctno = acctno;
            this.LNo = lNo;
            this.S1 = s1;
            this.S2 = s2;
            this.S3 = s3;
            this.S4 = s4;
            this.S5 = s5;
            this.S6 = s6;
            this.S7 = s7;
            this.S8 = s8;
            this.S9 = s9;
            this.S10 = s10;
            this.S11 = s11;
            this.S12 = s12;
            this.LastInt = lastInt;
            this.LastDate = lastDate;
            this.Budget = budget;
            this.UserNo = userNo;
            this.CloseDate = closeDate;
            this.ACSign = aCSign;
            this.TODCloseDate = tODCloseDate;
            this.TOD_SDate = tOD_SDate;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.UId = uId;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public virtual int ID { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string LNo { get; set; }
        public virtual System.Nullable<decimal> S1 { get; set; }
        public virtual System.Nullable<decimal> S2 { get; set; }
        public virtual System.Nullable<decimal> S3 { get; set; }
        public virtual System.Nullable<decimal> S4 { get; set; }
        public virtual System.Nullable<decimal> S5 { get; set; }
        public virtual System.Nullable<decimal> S6 { get; set; }
        public virtual System.Nullable<decimal> S7 { get; set; }
        public virtual System.Nullable<decimal> S8 { get; set; }
        public virtual System.Nullable<decimal> S9 { get; set; }
        public virtual System.Nullable<decimal> S10 { get; set; }
        public virtual System.Nullable<decimal> S11 { get; set; }
        public virtual System.Nullable<decimal> S12 { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> TODCloseDate { get; set; }
        public virtual System.Nullable<DateTime> TOD_SDate { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual string UId { get; set; }
        public virtual bool IsCheck { get; set; }	
    }
}