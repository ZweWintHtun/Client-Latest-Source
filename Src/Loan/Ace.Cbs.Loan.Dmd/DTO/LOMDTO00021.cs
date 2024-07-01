//----------------------------------------------------------------------
// <copyright file="LOMDTO00021.cs" Name="LI" company="ACE Data Systems">
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

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00021 : Supportfields<LOMDTO00021>
    {
        public LOMDTO00021() { }

        public LOMDTO00021(int id)
        {
            this.Id = id;
        }

        //public LOMDTO00021(decimal interestAmount)
        //{
        //    this.InterestAmount = interestAmount;
        //}
        public LOMDTO00021(int iD, string lNo, string acctno, System.Nullable<decimal> q1, System.Nullable<decimal> q2, System.Nullable<decimal> q3,
            System.Nullable<decimal> q4, System.Nullable<decimal> qBal1, System.Nullable<decimal> qBal2, System.Nullable<decimal> qBal3, System.Nullable<decimal> qBal4,
            string userNo, string aCSign, System.Nullable<DateTime> closeDate, string budget, string uId, string sourceBr, string cur, bool active, byte[] tS,
            int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            this.Id = iD;
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

        public LOMDTO00021(int iD, string lNo, string acctno, System.Nullable<decimal> intrate, int duration,int repaymentoption,System.Nullable<DateTime> closeDate, string budget, string sourceBr, string cur)
        {
            this.Id = iD;
            this.LNo = lNo;
            this.Acctno = acctno;
            this.IntRate = intrate;
            this.Duration = duration;
            this.RepaymentPeriod = repaymentoption;
            this.CloseDate = closeDate;
            this.Budget = budget;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        public LOMDTO00021(int iD, string lNo, string acctno,
          decimal intRate,int duration,
           System.Nullable<decimal> q1, System.Nullable<decimal> q2,
            System.Nullable<decimal> q3, System.Nullable<decimal> q4,
            System.Nullable<decimal> qBal1, System.Nullable<decimal> qBal2,
            System.Nullable<decimal> qBal3, System.Nullable<decimal> qBal4,
            string userNo, string aCSign, System.Nullable<DateTime> closeDate,
            string budget, string uId, string sourceBr, string cur, bool active,
            byte[] tS, int createdUserId, DateTime createdDate,
            System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate,
            decimal samt, DateTime sdate)
        {
            this.Id = iD;
            this.LNo = lNo;
            this.Acctno = acctno;
            this.IntRate = intRate;
            this.Duration = duration;
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
        // MNMDAO00017.SelectByLoanNo
        public LOMDTO00021(int id,string lNo, string acctNo, Nullable<decimal> intRate,
            Nullable<decimal> q1, Nullable<decimal> q2, Nullable<decimal> q3, Nullable<decimal> q4,
            Nullable<decimal> qBal1, Nullable<decimal> qBal2, Nullable<decimal> qBal3, Nullable<decimal> qBal4, string userNo, string acSign, Nullable<DateTime> closeDate,
            int duration, string budget, string uId, string sourceBr, string cur, bool active, byte[] tS, int createdUserId, DateTime createdDate, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {
            Id = id;
            LNo = lNo;
            Acctno = acctNo;
            IntRate = intRate;
            Q1 = q1;
            Q2 = q2;
            Q3 = q3;
            Q4 = q4;
            QBal1 = qBal1;
            QBal2 = qBal2;
            QBal3 = qBal3;
            QBal4 = qBal4;
            UserNo = userNo;
            ACSign = acSign;
            CloseDate = closeDate;
            Duration = duration;
            Budget = budget;
            UId = uId;
            SourceBr = sourceBr;
            Cur = cur;
            Active = active;
            TS = tS;
            CreatedUserId = createdUserId;
            CreatedDate = createdDate;
            UpdatedUserId = updatedUserId;
            UpdatedDate = updatedDate;
        }

        public LOMDTO00021(string acctNo, string lno, decimal q1, decimal q2, decimal q3,
            decimal q4, string name, bool legalcase, bool nplcase, string budget, string cur, string sourcebr)
        {
            this.Acctno = acctNo;
            this.LNo = lno;
            this.Q1 = q1;
            this.Q2 = q2;
            this.Q3 = q3;
            this.Q4 = q4;
            this.Name = name;
            this.LegalCase = legalcase;
            this.NplCase = nplcase;
            this.Budget = budget;
            this.Cur = cur;
            this.SourceBr = sourcebr;
        }
        /// my new change
        public LOMDTO00021( Nullable<decimal> intRate,System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate)
        {            
            IntRate = intRate;
            UpdatedUserId = updatedUserId;
            UpdatedDate = updatedDate;
        }
        /// //for MNMORM00017.SelectLiAndLoans
        public LOMDTO00021(int iD, string lNo, string acctno, decimal intRate,
               int duration, int repaymentOption,
               System.Nullable<decimal> m1, System.Nullable<decimal> m2,
               System.Nullable<decimal> m3, System.Nullable<decimal> m4,
               System.Nullable<decimal> m5, System.Nullable<decimal> m6,
               System.Nullable<decimal> m7, System.Nullable<decimal> m8,
               System.Nullable<decimal> m9, System.Nullable<decimal> m10,
               System.Nullable<decimal> m11, System.Nullable<decimal> m12,
               System.Nullable<decimal> q1, System.Nullable<decimal> q2,
               System.Nullable<decimal> q3, System.Nullable<decimal> q4,
               System.Nullable<decimal> qBal1, System.Nullable<decimal> qBal2,
               System.Nullable<decimal> qBal3, System.Nullable<decimal> qBal4,
               string userNo, string aCSign, System.Nullable<DateTime> closeDate,
               string budget, string uId, string sourceBr, string cur, bool active,
               byte[] tS, int createdUserId, DateTime createdDate,
               System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate
            , decimal samt, DateTime sdate)
        {
            this.Id = iD;
            this.LNo = lNo;
            this.Acctno = acctno;
            this.IntRate = intRate;
            this.Duration = duration;
            this.Repaymentoption = repaymentOption;
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
        public virtual int Id { get; set; }
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
        public virtual DateTime DueDate { get; set; }
        public virtual int Duration { get; set; }
        public virtual int RepaymentPeriod { get; set; }
        public virtual string Budget { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual decimal sAmt { get; set; }
        public virtual DateTime sDate { get; set; }

        public virtual string QuaterNo { get; set; }
        public virtual string BudgetYear { get; set; }
        public virtual string QAmt { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual bool NplCase { get; set; }
        public virtual string Name { get; set; }

        public virtual Nullable<decimal> M1 { get; set; }
        public virtual Nullable<decimal> M2 { get; set; }
        public virtual Nullable<decimal> M3 { get; set; }
        public virtual Nullable<decimal> M4 { get; set; }
        public virtual Nullable<decimal> M5 { get; set; }
        public virtual Nullable<decimal> M6 { get; set; }
        public virtual Nullable<decimal> M7 { get; set; }
        public virtual Nullable<decimal> M8 { get; set; }
        public virtual Nullable<decimal> M9 { get; set; }
        public virtual Nullable<decimal> M10 { get; set; }
        public virtual Nullable<decimal> M11 { get; set; }
        public virtual Nullable<decimal> M12 { get; set; }
        public virtual int Repaymentoption { get; set; }       

        //public virtual Nullable<decimal> SAmount { get; set; }
        //public virtual DateTime SDate { get; set; }
    }
}