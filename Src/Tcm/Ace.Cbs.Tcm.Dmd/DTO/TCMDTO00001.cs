//----------------------------------------------------------------------
// <copyright file="TCMDTO00001.cs" Name="Start" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/14/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMDTO00001 : Supportfields<TCMDTO00001>
    {
        public TCMDTO00001() { }

        public TCMDTO00001(string bankhead,string status,DateTime date)
        {
            this.BankHead = bankhead;
            this.Status = status;
            this.Date = date;     
      
        }

        public virtual DateTime Date { get; set; }
        public virtual string BankCode { get; set; }
        public virtual string BankHead { get; set; }
        public virtual string GetColo { get; set; }
        public virtual string Status { get; set; }
        public virtual string Stop { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual DateTime FixInterestDate { get; set; }
    }
}