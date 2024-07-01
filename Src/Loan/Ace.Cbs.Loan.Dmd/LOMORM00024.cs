//----------------------------------------------------------------------
// <copyright file="LOMORM0018.cs" Name="LMT99#00" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
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
    /// <summary>
    /// PaymentInterval ORM 
    /// </summary>
    [Serializable]
    public class LOMORM00024 : Supportfields<LOMORM00024>
    {
        public LOMORM00024() { }

        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string TermPerYear { get; set; }
        public virtual string USERNO { get; set; }
        public virtual DateTime Date_Time { get; set; }        
    }
}
