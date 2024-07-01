//----------------------------------------------------------------------
// <copyright file="LOMDTO00015.cs" Name="Land_Building" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Haymar</CreatedUser>
// <CreatedDate>30/01/2015</CreatedDate>
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
/// Land_Building DTO
/// </summary>
namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00015 : Supportfields<LOMDTO00015>
    {
        public LOMDTO00015(){}

        public LOMDTO00015(string lno, System.Nullable<decimal> capital)
        {
            this.LNo = lno;
            this.Capital = capital;
        }

        public LOMDTO00015(string lno, System.Nullable<decimal> capital, System.Nullable<decimal> expyear,System.Nullable<DateTime> edate,string _char,
            string eva,string gw,string address, string yearPB, System.Nullable<decimal> tax, System.Nullable<decimal> isamt,
            string istype,System.Nullable<DateTime> isdate,string sdeed,string land,string hislb,string bpermit,
            string laffid, string padv,string stype,string _class,string power,System.Nullable<DateTime> ddate,
            System.Nullable<decimal> fsvland, System.Nullable<decimal> fsvbld, System.Nullable<DateTime> closedate,
            System.Nullable<DateTime> isexpireddate, string sourcebr, string cur, System.Nullable<DateTime> landLeaseSDate, System.Nullable<DateTime> landLeaseEDate,
            string remarkForLand)
        {
            this.LNo = lno;
            this.Capital = capital;
            this.ExpYear = expyear;
            this.EDate = edate;
            this.Char = _char;
            this.EVA = eva;
            this.GW = gw;
            this.Address = address;
            this.YearPB = yearPB;
            this.Tax = tax;
            this.IsAMT = isamt;
            this.IsType = istype;
            this.IsDate = isdate;
            this.SDEED = sdeed;
            this.Land = land;
            this.HISLB = hislb;
            this.BPERMIT = bpermit;
            this.LAFFID = laffid;
            this.PADV = padv;
            this.SType = stype;
            this.Class = _class;
            this.Power = power;
            this.DDate = ddate;
            this.FSVLand = fsvland;
            this.FSVBLD = fsvbld;
            this.CloseDate = closedate;
            this.IsExpiredDate = isexpireddate;
            this.SourceBr = sourcebr;
            this.Cur = cur;
            this.LandLeaseSDate = landLeaseSDate;
            this.LandLeaseEDate = landLeaseEDate;
            this.RemarkForLand = remarkForLand;
        }

        public  string LNo { get; set; }
        public  System.Nullable<decimal> Capital { get; set; }
        public  System.Nullable<decimal> ExpYear { get; set; }
        public  System.Nullable<DateTime> EDate { get; set; }
        public  string Char { get; set; }
        public  string EVA { get; set; }
        public  string GW { get; set; }
        public  string Address { get; set; }
        public  string YearPB { get; set; }
        public  System.Nullable<decimal> Tax { get; set; }
        public  System.Nullable<decimal> IsAMT { get; set; }
        public  string IsType { get; set; }
        public  System.Nullable<DateTime> IsDate { get; set; }
        public  string SDEED { get; set; }
        public  string Land { get; set; }
        public  string HISLB { get; set; }
        public  string BPERMIT { get; set; }
        public  string LAFFID { get; set; }
        public  string PADV { get; set; }
        public  string SType { get; set; }
        public  string Class { get; set; }
        public  string Power { get; set; }
        public  System.Nullable<DateTime> DDate { get; set; }
        public  System.Nullable<decimal> FSVLand { get; set; }
        public  System.Nullable<decimal> FSVBLD { get; set; }
        public  System.Nullable<DateTime> CloseDate { get; set; }
        public  System.Nullable<DateTime> IsExpiredDate { get; set; }
        public  string SourceBr { get; set; }
        public  string Cur { get; set; }

        public System.Nullable<DateTime> LandLeaseSDate { get; set; }
        public System.Nullable<DateTime> LandLeaseEDate { get; set; }
        public string RemarkForLand { get; set; }
    }
}
