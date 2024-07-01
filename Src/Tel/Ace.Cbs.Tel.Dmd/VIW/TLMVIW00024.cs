//----------------------------------------------------------------------
// <copyright file="TLMVIW00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-09-06</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tel.Dmd
{
    /// <summary>
    /// VW_MOB344_ALL
    /// </summary>
   [Serializable]
   public class TLMVIW00024
    {
           public TLMVIW00024() { }

           public TLMVIW00024(string eno, string accountno, string desp, decimal amount, string userno, DateTime datetime, DateTime time, string acsign, string sourcecur, string workstation) 
           {
               this.ENO = eno;
               this.AccNo = accountno;
               this.Desp = desp;
               this.Amount = amount;
               this.UserNo = userno;
               this.Date_Time = datetime;
               this.Time = time;
               this.AcSign = acsign;
               this.SourceCur = sourcecur;
               this.WorkStation = workstation;
               //this.Status = status;
               //this.OrgEno = orgeno;
           }

           public virtual int Id { get; set; }
           public virtual string ENO { get; set; }
           public virtual string AccNo { get; set; }
           public virtual string Desp { get; set; }
           public virtual Nullable<decimal> Amount { get; set; }
           public virtual string UserNo { get; set; }
           public virtual Nullable<DateTime> Date_Time { get; set; }
           public virtual Nullable<DateTime> Time { get; set; }
           public virtual string AcSign { get; set; }
           public virtual string SourceCur { get; set; }
           public virtual string WorkStation { get; set; }
           public virtual string Status { get; set; }
           public virtual string OrgEno { get; set; }
           public virtual string SourceBr { get; set; }
    }
}
