//----------------------------------------------------------------------
// <copyright file="MNMDTO00023.cs"  company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San </CreatedUser>
// <CreatedDate>11/27/2013</CreatedDate>
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
    public class MNMDTO00023 : EntityBase<MNMDTO00023>
    {
        public MNMDTO00023() { }
        public virtual string eno{ get; set; }
        public virtual string aCCTNO{ get; set; }
        public virtual string lno{ get; set; }
        public virtual string todSerial{ get; set; }
        public virtual System.Nullable<double> m1{ get; set; }
        public virtual System.Nullable<double> m2{ get; set; }
        public virtual System.Nullable<double> m3{ get; set; }
        public virtual System.Nullable<double> m4{ get; set; }
        public virtual System.Nullable<double> m5{ get; set; }
        public virtual System.Nullable<double> m6{ get; set; }
        public virtual System.Nullable<double> m7{ get; set; }
        public virtual System.Nullable<double> m8{ get; set; }
        public virtual System.Nullable<double> m9{ get; set; }
        public virtual System.Nullable<double> m10{ get; set; }
        public virtual System.Nullable<double> m11{ get; set; }
        public virtual System.Nullable<double> m12{ get; set; }
        public virtual System.Nullable<DateTime> lastDate{ get; set; }
        public virtual System.Nullable<double> lastInt{ get; set; }
        public virtual string sourceBr{ get; set; }
        public virtual string cur{ get; set; }
        public virtual System.Guid uID{ get; set; }
        public virtual bool active{ get; set; }
        public virtual System.DateTime tS{ get; set; }
        public virtual System.DateTime createdDate{ get; set; }
        public virtual int createdUserId{ get; set; }
        public virtual System.Nullable<DateTime> updatedDate{ get; set; }
        public virtual System.Nullable<int> updatedUserId{ get; set; }


        #region Unknown
        public MNMDTO00023(string acode, string status, string sourcecur, decimal LocalAmt, decimal homeAmt, decimal localOAmt, decimal homeOAmt, decimal clearing_Amount, decimal clearing_HomeAmount, decimal cash_LocalAmt, decimal cash_HomeAmt, string sourcebr)
        {
            this.ACODE = acode;
            this.Status_Letter_One = status;
            this.SOURCECUR = sourcecur;
            this.LocalAmt = LocalAmt;
            this.HomeAmt = homeAmt;
            this.LocalOAmt = localOAmt;
            this.HomeOAmt = homeOAmt;
            this.Clearing_Amount = clearing_Amount;
            this.Clearing_HomeAmount = clearing_HomeAmount;
            this.Cash_LocalAmt = cash_LocalAmt;
            this.Cash_HomeAmt = cash_HomeAmt;
            this.SOURCEBR = sourcebr;
        }
        public virtual string ACODE { get; set; }
        public virtual string Status_Letter_One { get; set; }
        public virtual string SOURCECUR { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual string WorkStation { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string CheckTime { get; set; }
        public virtual decimal LocalAmt { get; set; }
        public virtual decimal HomeAmt { get; set; }
        public virtual decimal LocalOAmt { get; set; }
        public virtual decimal HomeOAmt { get; set; }
        public virtual decimal Clearing_Amount { get; set; }
        public virtual decimal Clearing_HomeAmount { get; set; }
        public virtual decimal Cash_LocalAmt { get; set; }
        public virtual decimal Cash_HomeAmt { get; set; }
        #endregion
    }
}
