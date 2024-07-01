//----------------------------------------------------------------------
// <copyright file="LOMDTO00013.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>19/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

/// <summary>
/// LegalDto 
/// </summary>

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00013 : EntityBase<LOMDTO00013>
    {
        public LOMDTO00013() { }

        public LOMDTO00013(string acctNo,
            string lno,
            string aType,
            Nullable<DateTime> legalDate,
            decimal sAmt,
            decimal bal,
            string loansDesp,
            decimal intRate,
            decimal oldInt,
            decimal oldExtra,
            decimal oldScharge,
            decimal legalInt,
            decimal legalIntRate)
        {
            this.AcctNo = acctNo;
            this.Lno = lno;
            this.AType = aType;
            this.LegalDate = legalDate;
            this.SAmt = sAmt;
            this.Bal = bal;
            this.LoansDesp = loansDesp;
            this.IntRate = intRate;
            this.OldInt = oldInt;
            this.OldExtra = oldExtra;
            this.OldScharge = oldScharge;
            this.Interest = legalInt;
            this.LegalIntRate = legalIntRate;
        }

        public LOMDTO00013(string lno, string accno, string actype, decimal bal, decimal oldInt, decimal oldscharge, decimal oldextra, decimal intRate, string sourcebr, string cur, string legalLawyer, decimal sAmount)
        {
            this.Lno = lno;
            this.AcctNo = accno;
            this.AcType = actype;
            this.Bal = bal;
            this.OldInt = oldInt;
            this.OldScharge = oldscharge;
            this.OldExtra = OldExtra;
            this.IntRate = intRate;
            this.SourceBr = sourcebr;
            this.Cur = cur;
            this.LegalLawyer = legalLawyer;
            this.SAmt = sAmount;
        }
        //public LOMDTO00013(string lno, string acctNo, string acType, Nullable<DateTime> legalDate, Nullable<DateTime> closeDate, Nullable<DateTime> lastIntDate, Nullable<DateTime> acceptDate, Nullable<DateTime> releaseDate)
        //{           
        //    this.Lno = lno;
        //    this.AcctNo = acctNo;
        //    this.AcType = acType;
        //    this.LegalDate = legalDate;
        //    this.CloseDate = closeDate;
        //    this.LastIntDate = lastIntDate;
        //    this.AcceptDate = acceptDate;
        //    this.ReleaseDate = releaseDate;       
        //}
        public LOMDTO00013(
         string lno,
         string acctNo,
         string acType,
         Nullable<DateTime> legalDate,
         decimal bal,
         decimal oldInt,
         decimal oldScharge,
         decimal oldExtra,
         decimal interest,
         Nullable<DateTime> closeDate,
         Nullable<DateTime> lastIntDate,
         Nullable<DateTime> acceptDate,
         Nullable<DateTime> releaseDate)
        {
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.AcType = acType;
            this.LegalDate = legalDate;
            this.Bal = bal;
            this.OldInt = oldInt;
            this.OldScharge = oldScharge;
            this.OldExtra = oldExtra;
            this.Interest = interest;
            this.CloseDate = closeDate;
            this.LastIntDate = lastIntDate;
            this.AcceptDate = acceptDate;
            this.ReleaseDate = releaseDate;
        }

        public LOMDTO00013
        (
                string lno,
                string acctNo,
                string acType,
                Nullable<DateTime> legalDate,
                decimal bal,
                decimal oldInt,
                decimal oldScharge,
                decimal oldExtra,
                decimal interest,
                decimal intRate,
                Nullable<DateTime> closeDate,
                Nullable<DateTime> lastIntDate,
                decimal newBal,
                Nullable<DateTime> acceptDate,
                Nullable<DateTime> releaseDate,
                string lastRepayNo,
                string sourceBr,
                string cur
        )
        {
            this.Lno = lno;
            this.AcctNo = acctNo;
            this.AcType = acType;
            this.LegalDate = legalDate;
            this.Bal = bal;
            this.OldInt = oldInt;
            this.OldScharge = oldScharge;
            this.OldExtra = oldExtra;
            this.Interest = interest;
            this.IntRate = intRate;
            this.CloseDate = closeDate;
            this.LastIntDate = lastIntDate;
            this.NewBal = newBal;
            this.AcceptDate = acceptDate;
            this.ReleaseDate = releaseDate;
            this.LastRePayNo = lastRepayNo;
            this.SourceBr = sourceBr;
            this.Cur = cur;
        }

        public LOMDTO00013(int id)
        {
            Id = id;
        }

        public LOMDTO00013(int id,string acctNo,string lno,string cur,
            string name,string atype,string loansDesp,decimal samt,
            DateTime sdate,string sourceBr,DateTime expiredate,
            decimal intrate,DateTime legalDate,DateTime nplDate,
            bool legalCase,bool nplCase)
        {
            this.Id = id;
            this.AcctNo = acctNo;
            this.Lno = lno;
            this.Cur = cur;
            this.Name = name;
            this.AType = atype;
            this.LoansDesp = loansDesp;
            this.SAmt = samt;
            this.SDate = sdate;
            this.SourceBr = sourceBr;
            this.ExpireDate = expiredate;
            this.IntRate = intrate;
            this.LegalDate = legalDate;
            this.NplDate = nplDate;
            this.LegalCase = legalCase;
            this.NplCase = nplCase;
        }

        public virtual int Id { get; set; }
        public virtual string Lno { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string AcType { get; set; }
        public virtual Nullable<DateTime> LegalDate { get; set; }
        public virtual Nullable<decimal> Bal { get; set; }
        public virtual Nullable<decimal> OldInt { get; set; }
        public virtual Nullable<decimal> OldScharge { get; set; }
        public virtual Nullable<decimal> OldExtra { get; set; }    //Tod_SchargeInterest
        public virtual Nullable<decimal> Interest { get; set; }
        public virtual Nullable<decimal> LegalIntRate { get; set; }

        public virtual Nullable<decimal> IntRate { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }
        public virtual Nullable<DateTime> LastIntDate { get; set; }
        public virtual Nullable<decimal> NewBal { get; set; }
        public virtual Nullable<DateTime> AcceptDate { get; set; }
        public virtual Nullable<DateTime> ReleaseDate { get; set; }
        public virtual string LastRePayNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }


        public virtual string Name { get; set; }
        public virtual string AType { get; set; }
        public virtual string LoansDesp { get; set; }
        public virtual Nullable<decimal> SAmt { get; set; }
        public virtual Nullable<DateTime> SDate { get; set; }
        public virtual Nullable<DateTime> ExpireDate { get; set; }
        public virtual Nullable<DateTime> NplDate { get; set; }
        public virtual bool LegalCase { get; set; }
        public virtual bool NplCase { get; set; }

        public virtual string LegalLawyer { get; set; }

        public virtual decimal Tod_SchargeInterest { get; set; }
        public virtual decimal LoansInterest { get; set; }
        public virtual decimal ODInterest { get; set; }

        public virtual string RepayNo { get; set; }
        public virtual Nullable<DateTime> Date_Time { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string DrAccountNo { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string[] NameList { get; set; }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}
