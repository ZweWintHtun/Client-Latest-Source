//----------------------------------------------------------------------
// <copyright file="LOMORM00011.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>07/01/2015</CreatedDate>
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
    public class LOMORM00011 : EntityBase<LOMORM00011>
    {
        public LOMORM00011() { }
        public LOMORM00011(int id) { this.Id = id; }
        public virtual string AcctNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual decimal OVDLimit { get; set; }
        public virtual string LoanNo { get; set; }
        public virtual decimal OLDLimit { get; set; }
        public virtual string UserNo { get; set; }
        public virtual Nullable<DateTime> CloseDate { get; set; }       
        public virtual string SourceBr { get; set; }
        public virtual string Cur { get; set; }        
    }
}
