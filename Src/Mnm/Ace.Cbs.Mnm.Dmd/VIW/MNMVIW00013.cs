//----------------------------------------------------------------------
// <copyright file="MNMVIW00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> HM </CreatedUser>
// <CreatedDate>2014-01-20</CreatedDate>
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
    public class MNMVIW00013 : Supportfields<MNMVIW00013>
    {
        public MNMVIW00013() { }

        // public MNMVIW00013(string customerid,string name)
        //{
        //    this.AcctNo = customerid;
        //    this.Name = name;
        //    //this.Nrc = nrc;
        //    //this.Address = address;
        //}
        //public MNMVIW00013(string acctno, string name, decimal cbal, DateTime date_time, string desp, string address, string nrc)
        //{
        //    this.AcctNo = acctno;
        //    this.Name = name;
        //    this.CBal = cbal;
        //    this.Date_Time = date_time;
        //    this.Desp = desp;
        //    this.Address = address;
        //    this.Nrc = nrc;
        //}

        public virtual int Id { get; set; }
        public virtual string AcctNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Nrc { get; set; }
        public virtual decimal CBal { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string Desp { get; set; }
        public virtual string SourceBranch { get; set; }
    }
}