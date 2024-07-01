//----------------------------------------------------------------------
// <copyright file="MNMDTO00017.cs" Name="LI" company="ACE Data Systems">
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
    public class MNMDTO00017 : Supportfields<MNMDTO00017>
    {
        public MNMDTO00017() { }
        public MNMDTO00017(decimal q4) 
        {
            this.Q4 = q4;
        }

        public MNMDTO00017(int iD, string lNo, string acctno, System.Nullable<decimal> q1, System.Nullable<decimal> q2, System.Nullable<decimal> q3, System.Nullable<decimal> q4, System.Nullable<decimal> qBal1, System.Nullable<decimal> qBal2, System.Nullable<decimal> qBal3, System.Nullable<decimal> qBal4, string userNo, string aCSign, System.Nullable<DateTime> closeDate, string budget, string uId, string sourceBr, string cur, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.ID = iD;
            this.LNo = lNo;
            this.Acctno = acctno;
            this.Q1 = q1;
            this.Q2 = q2;
            this.Q3 = q3;
            this.Q4 = q4;
            this.QBal1 = qBal1;
            this.QBal2 = qBal2;
            this.QBal3 = qBal3;
            this.QBal4 = qBal4;
            this.UserNo = userNo;
            this.ACSign = aCSign;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.UId = uId;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public MNMDTO00017(int iD, string tNo, string lNo, string acctno,
           decimal principalAmount, decimal interestAmount, decimal intRate, DateTime startDate, DateTime endDate, int repaymentPeriod, int duration, int repayTotalCount,
           decimal addPayAmount, string addPayInterval,
           System.Nullable<decimal> q1, System.Nullable<decimal> q2, System.Nullable<decimal> q3, System.Nullable<decimal> q4, System.Nullable<decimal> qBal1, System.Nullable<decimal> qBal2, System.Nullable<decimal> qBal3, System.Nullable<decimal> qBal4, string userNo, string aCSign, System.Nullable<DateTime> closeDate, string budget, string uId, string sourceBr, string cur, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate, decimal samt, DateTime sdate)
        {
            this.ID = iD;
            this.TNo = tNo;
            this.LNo = lNo;
            this.Acctno = acctno;
            this.PrincipalAmount = principalAmount;
            this.InterestAmount = interestAmount;
            this.IntRate = intRate;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RepaymentPeriod = repaymentPeriod;
            this.Duration = duration;
            this.RepayTotalCount = repayTotalCount;
            this.AddPayAmount = addPayAmount;
            this.AddPayInterval = AddPayInterval;
            this.Q1 = q1;
            this.Q2 = q2;
            this.Q3 = q3;
            this.Q4 = q4;
            this.QBal1 = qBal1;
            this.QBal2 = qBal2;
            this.QBal3 = qBal3;
            this.QBal4 = qBal4;
            this.UserNo = userNo;
            this.ACSign = aCSign;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.UId = uId;
            this.SourceBr = sourceBr;
            this.Cur = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedUserId = createdUserId;
            this.CreatedDate = createdDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
            this.sAmt = samt;
            this.sDate = sdate;
        }

        public virtual int ID { get; set; }
        public virtual string TNo { get; set; }
        public virtual string LNo { get; set; }       
        public virtual string Acctno { get; set; }
        public virtual System.Nullable<decimal> PrincipalAmount { get; set; }
        public virtual System.Nullable<decimal> InterestAmount { get; set; }
        public virtual System.Nullable<decimal> IntRate { get; set; }
        public virtual System.Nullable<int> RepayTotalCount { get; set; }
        public virtual System.Nullable<decimal> AddPayAmount { get; set; }
        public virtual string AddPayInterval { get; set; }
        public virtual System.Nullable<decimal> Q1 { get; set; }
        public virtual System.Nullable<decimal> Q2 { get; set; }
        public virtual System.Nullable<decimal> Q3 { get; set; }
        public virtual System.Nullable<decimal> Q4 { get; set; }
        public virtual System.Nullable<decimal> QBal1 { get; set; }
        public virtual System.Nullable<decimal> QBal2 { get; set; }
        public virtual System.Nullable<decimal> QBal3 { get; set; }
        public virtual System.Nullable<decimal> QBal4 { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ACSign { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int Duration { get; set; }
        public virtual int RepaymentPeriod { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual decimal sAmt { get; set; }
        public virtual DateTime sDate { get; set; }
    }
}