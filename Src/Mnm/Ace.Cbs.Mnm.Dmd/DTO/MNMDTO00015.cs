//----------------------------------------------------------------------
// <copyright file="MNMDTO00015.cs" Name="PREV_CI" company="ACE Data Systems">
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
    public class MNMDTO00015 : Supportfields<MNMDTO00015>
    {
        public MNMDTO00015() { }

        public MNMDTO00015(string aCCTNO, System.Nullable<decimal> m1, System.Nullable<decimal> m2, System.Nullable<decimal> m3, System.Nullable<decimal> m4, System.Nullable<decimal> m5, System.Nullable<decimal> m6, System.Nullable<decimal> m7, System.Nullable<decimal> m8, System.Nullable<decimal> m9, System.Nullable<decimal> m10, System.Nullable<decimal> m11, System.Nullable<decimal> m12, System.Nullable<DateTime> lASTDATE, System.Nullable<decimal> lASTINT, System.Nullable<DateTime> cLOSEDATE, System.Nullable<DateTime> dATE_TIME, string bUDGET, string uID, string sOURCEBR)
        {
            this.ACCTNO = aCCTNO;
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
            this.LASTDATE = lASTDATE;
            this.LASTINT = lASTINT;
            this.CLOSEDATE = cLOSEDATE;
            this.DATE_TIME = dATE_TIME;
            this.BUDGET = bUDGET;
            this.UID = uID;
            this.SOURCEBR = sOURCEBR;
        }

        
        public virtual string ACCTNO { get; set; }
        public virtual System.Nullable<decimal> M1 { get; set; }
        public virtual System.Nullable<decimal> M2 { get; set; }
        public virtual System.Nullable<decimal> M3 { get; set; }
        public virtual System.Nullable<decimal> M4 { get; set; }
        public virtual System.Nullable<decimal> M5 { get; set; }
        public virtual System.Nullable<decimal> M6 { get; set; }
        public virtual System.Nullable<decimal> M7 { get; set; }
        public virtual System.Nullable<decimal> M8 { get; set; }
        public virtual System.Nullable<decimal> M9 { get; set; }
        public virtual System.Nullable<decimal> M10 { get; set; }
        public virtual System.Nullable<decimal> M11 { get; set; }
        public virtual System.Nullable<decimal> M12 { get; set; }
        public virtual System.Nullable<DateTime> LASTDATE { get; set; }
        public virtual System.Nullable<decimal> LASTINT { get; set; }
        public virtual System.Nullable<DateTime> CLOSEDATE { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string BUDGET { get; set; }
        public virtual string UID { get; set; }
        public virtual string SOURCEBR { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}