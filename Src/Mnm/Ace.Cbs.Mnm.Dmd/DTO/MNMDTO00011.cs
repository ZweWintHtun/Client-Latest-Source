//----------------------------------------------------------------------
// <copyright file="MNMDTO00011.cs" Name="COMMIT_FEES" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>SSA</CreatedUser>
// <CreatedDate>12/04/2013</CreatedDate>
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
    public class MNMDTO00011 : Supportfields<MNMDTO00011>
    {
        public MNMDTO00011() { }

        public MNMDTO00011(int Id, 
                            string Acctno, 
                            string lNo, 
                            decimal m1, 
                            decimal m2, 
                            decimal m3, 
                            decimal m4, 
                            decimal m5, 
                            decimal m6, 
                            decimal m7, 
                            decimal m8, 
                            decimal m9, 
                            decimal m10, 
                            decimal m11, 
                            decimal m12, 
                            string p1Status, 
                            string p2Status, 
                            string p3Status, 
                            string p4Status, 
                            System.Nullable<DateTime> lastDate,
                            System.Nullable<decimal> lastInt,
                            string userNo, 
                            string aCSign, 
                            System.Nullable<DateTime> closeDate, 
                            string budget, 
                            System.Nullable<DateTime> tODCloseDate, 
                            string uId, 
                            string sourceBr, 
                            string cur, 
                            bool active, 
                            byte[] tS, 
                            DateTime createdDate, 
                            int createdUserId, 
                            System.Nullable<DateTime> updatedDate, 
                            System.Nullable<int> updatedUserId)
        {
            this.Id = Id;
            this.Acctno = Acctno;
            this.LNo = lNo;
            this.M1 = m1;
            this.M2 = m2;
            this.M3 = m3;
            this.M4 = m4;
            this.M5 = m5;
            this.M6 = m6;
            this.M7 = m7;
            this.M8 = m8;
            this.M9 = m9;
            this.M10 = m10;
            this.M11 = m11;
            this.M12 = m12;
            this.P1Status = p1Status;
            this.P2Status = p2Status;
            this.P3Status = p3Status;
            this.P4Status = p4Status;
            this.LastDate = lastDate;
            this.LastInt = lastInt;
            this.UserNo = userNo;
            this.ACSign = aCSign;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.TODCloseDate = tODCloseDate;
            this.UId = uId;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }
        public virtual int Id { get; set; }
        public virtual string Acctno { get; set; }
        public virtual string LNo { get; set; }
        public virtual decimal M1 { get; set; }
        public virtual decimal M2 { get; set; }
        public virtual decimal M3 { get; set; }
        public virtual decimal M4 { get; set; }
        public virtual decimal M5 { get; set; }
        public virtual decimal M6 { get; set; }
        public virtual decimal M7 { get; set; }
        public virtual decimal M8 { get; set; }
        public virtual decimal M9 { get; set; }
        public virtual decimal M10 { get; set; }
        public virtual decimal M11 { get; set; }
        public virtual decimal M12 { get; set; }
        public virtual string P1Status { get; set; }
        public virtual string P2Status { get; set; }
        public virtual string P3Status { get; set; }
        public virtual string P4Status { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual System.Nullable<decimal> LastInt { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual string Budget { get; set; }
        public virtual System.Nullable<DateTime> TODCloseDate { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}